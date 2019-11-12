// =====================================================================
//
//  This file is part of the Microsoft CRM V4.0 SDK Code Samples.
//
//  Copyright (C) Microsoft Corporation.  All rights reserved.
//
//  This source code is intended only as a supplement to Microsoft
//  Development Tools and/or on-line documentation.  See these other
//  materials for detailed information regarding Microsoft code samples.
//
//  THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
//  KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//  IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//  PARTICULAR PURPOSE.
//
// =====================================================================
//<snippetDeviceIdManager>
using System;
using System.Globalization;
using System.IO;
using System.Net;
using System.Runtime.Serialization;
//using System.ServiceModel.Description;
using System.Text;
using System.Xml;

namespace Microsoft.Crm.Sdk.Samples
{
	/// <summary>
	/// Management utility for the Device Id
    /// Please note that this is a modified version of DeviceIdManager class from the one that ships with the SDK. 
    /// The modifications have been made to remove any writes to local disk which unfortunately removes the caching of device id as well. 
	/// </summary>
	public static class DeviceIdManager
	{
		#region Fields
		private static readonly Encoding XmlEncoding = Encoding.UTF8;
		private static readonly Random RandomInstance = new Random();

		#endregion

		#region Methods
		/// <summary>
		/// Registers the given device with Live ID with a random application ID
		/// </summary>
		/// <returns>ClientCredentials that were registered</returns>
        public static DeviceCredentials RegisterDevice()
		{
			return RegisterDevice(Guid.NewGuid());
		}

		/// <summary>
		/// Registers the given device with Live ID
		/// </summary>
		/// <param name="applicationId">ID for the application</param>
		/// <returns>ClientCredentials that were registered</returns>
        public static DeviceCredentials RegisterDevice(Guid applicationId)
		{
			//Create the credentials
			DeviceCredentials credentials = GenerateCredentials();

			//Execute the registration request
            string puid = ExecuteRegistrationRequest(LiveIdConstants.RegistrationEndpointUri, CreateRegistrationEnvelope(
                LiveIdConstants.DevicePrefix, applicationId, credentials.DeviceName, credentials.Password));

			//Read the result
            return credentials;
		}


		#endregion

		#region Private Methods
		private static DeviceCredentials ReadDeviceCredentials()
		{
			//Retrieve the file info
			if (!File.Exists(LiveIdConstants.LiveDeviceFileName))
			{
				return null;
			}

			//Load the XML
			using (Stream stream = File.Open(LiveIdConstants.LiveDeviceFileName, FileMode.Open, FileAccess.Read))
			{
				//Load the XML document
				XmlDocument doc = LoadXmlDocument(stream);

				//Read the user information
				foreach (XmlNode node in doc.DocumentElement.ChildNodes)
				{
					if (string.Equals(node.Name, "User", StringComparison.OrdinalIgnoreCase))
					{
						//Extract the user name
						string deviceName = ReadAttributeValue(node, "username");

						//The password is a child node of this node
						string devicePassword = null;
						foreach (XmlNode childNode in node.ChildNodes)
						{
							if (string.Equals(childNode.Name, "Pwd", StringComparison.OrdinalIgnoreCase))
							{
								devicePassword = ReadNodeText(childNode);
								break;
							}
						}

						//If the device password was not set, return null
						if (string.IsNullOrWhiteSpace(devicePassword))
						{
							return null;
						}

						//Decrypt the password and return the credentials
						//return new DeviceCredentials(deviceName, DecryptPassword(devicePassword));
					}
				}
			}

			return null;
		}

		private static string CreateRegistrationEnvelope(string prefix, Guid applicationId, string deviceName, string password)
		{
			//The format of the envelope is the following:
			//<DeviceAddRequest>
			//  <ClientInfo name="[app GUID]" version="1.0"/>
			//  <Authentication>
			//    <Membername>[prefix][device name]</Membername>
			//    <Password>[device password]</Password>
			//  </Authentication>
			//</DeviceAddRequest>

			//Instantiate the writer and write the envelope
			using (StringWriter writer = new StringWriter())
			{
				using (XmlWriter xml = XmlWriter.Create(writer, CreateWriterSettings()))
				{
					//Create the node
					xml.WriteStartElement("DeviceAddRequest");

					//Write the ClientInfo node
					xml.WriteStartElement("ClientInfo");
					xml.WriteAttributeString("name", applicationId.ToString());
					xml.WriteAttributeString("version", "1.0");
					xml.WriteEndElement();

					//Write the Authentication node
					xml.WriteStartElement("Authentication");
					xml.WriteElementString("Membername", prefix + deviceName);
					xml.WriteElementString("Password", password);
					xml.WriteEndElement();

					xml.WriteEndElement();
				}

				return writer.ToString();
			}
		}

		private static string ExecuteRegistrationRequest(string url, string soapEnvelope)
		{
			//Create the request that will submit the request to the server
			WebRequest request = WebRequest.Create(url);
			request.ContentType = "application/soap+xml; charset=UTF-8";
			request.Method = "POST";
			request.Timeout = 180000;

			//Write the envelope to the RequestStream
			byte[] bytes = XmlEncoding.GetBytes(soapEnvelope);
			using (Stream stream = request.GetRequestStream())
			{
				stream.Write(bytes, 0, bytes.Length);
			}

			// Read the response into an XmlDocument and return that doc
			try
			{
				using (WebResponse response = request.GetResponse())
				{
					return ParseRegistrationResponse(response, false);
				}
			}
			catch (WebException ex)
			{
				ParseRegistrationResponse(ex.Response, true);
				return null;
			}
		}

		private static string ParseRegistrationResponse(WebResponse response, bool isFailure)
		{
			using (Stream stream = response.GetResponseStream())
			{
				XmlDocument doc = LoadXmlDocument(stream);

				//Loop through the properties and populate them
				bool isSuccess = false;
				string puid = null;
				DeviceRegistrationErrorCode? errorCode = null;
				string errorSubCode = null;
				foreach (XmlNode childNode in doc.DocumentElement.ChildNodes)
				{
					switch (childNode.Name.ToUpperInvariant())
					{
						case "SUCCESS":
							bool.TryParse(ReadNodeText(childNode), out isSuccess);
							break;
						case "PUID":
							puid = ReadNodeText(childNode);
							break;
						case "ERROR":
							{
								//Set the error code to the Unknown error in case the parsing logic fails
								errorCode = DeviceRegistrationErrorCode.Unknown;

								//Attempt to parse the code
								string codeLabel = ReadAttributeValue(childNode, "Code");
								if (!string.IsNullOrWhiteSpace(codeLabel))
								{
									//Parse the error code
									if (codeLabel.StartsWith("dc", StringComparison.Ordinal))
									{
										int code;
										if (int.TryParse(codeLabel.Substring(2), NumberStyles.Integer,
											CultureInfo.InvariantCulture, out code) &&
											Enum.IsDefined(typeof(DeviceRegistrationErrorCode), code))
										{
											errorCode = (DeviceRegistrationErrorCode)Enum.ToObject(
												typeof(DeviceRegistrationErrorCode), code);
										}
									}
								}
							}
							break;
						case "ERRORSUBCODE":
							errorSubCode = ReadNodeText(childNode);
							break;
					}
				}

				//If this was a failure, throw an excepton
				if (isFailure)
				{
					throw new DeviceRegistrationFailedException(errorCode.GetValueOrDefault(), errorSubCode);
				}

				//It was successful
				return puid;
			}
		}


		private static DeviceCredentials GenerateCredentials()
		{
			string deviceName = GenerateRandomString(LiveIdConstants.ValidDeviceNameCharacters, LiveIdConstants.DeviceNameLength);
			string devicePassword = GenerateRandomString(LiveIdConstants.ValidDevicePasswordCharacters,
				LiveIdConstants.DevicePasswordLength);

			return new DeviceCredentials(deviceName, devicePassword);
		}

		private static string GenerateRandomString(string characterSet, int count)
		{
			//Create an array of the characters that will hold the final list of random characters
			char[] value = new char[count];

			//Convert the character set to an array that can be randomly accessed
			char[] set = characterSet.ToCharArray();

			//Loop the set of characters and locate the space character.
			int spaceCharacterIndex = -1;
			for (int i = 0; i < set.Length; i++)
			{
				if (' ' == set[i])
				{
					spaceCharacterIndex = i;
				}
			}

			//Populate the array with random characters from the character set
			for (int i = 0; i < count; i++)
			{
				//If this is the first or the last character, exclude the space (to avoid trimming and encryption issues)
				//The main reason for this restriction is the EncryptPassword/DecryptPassword methods will pad the string
				//with spaces (' ') if the string needs to be longer.
				int characterCount = set.Length;
				if (-1 != spaceCharacterIndex && (0 == i || count == i + 1))
				{
					characterCount--;
				}

				//Select an index that's within the set
				int index = RandomInstance.Next(0, characterCount);
		
				//If this character is at or past the space character (and it is supposed to be excluded),
				//increment the index by 1. The effect of this operation is that the space character will never be included
				//in the random set since the possible values for index are:
				//<0, spaceCharacterIndex - 1> and <spaceCharacterIndex, set.Length - 2> (according to the value of characterCount).
				//By incrementing the index by 1, the range will be:
				//<0, spaceCharacterIndex - 1> and <spaceCharacterIndex + 1, set.Length - 1>
				if (characterCount != set.Length && index >= spaceCharacterIndex)
				{
					index++;
				}

				//Select the character from the set and store it in the return value
				value[i] = set[index];
			}

			return new string(value);
		}

		#region XML Handling Code
		private static XmlWriterSettings CreateWriterSettings()
		{
			XmlWriterSettings settings = new XmlWriterSettings();
			settings.OmitXmlDeclaration = true;
			settings.Indent = true;
			settings.Encoding = XmlEncoding;

			return settings;
		}

		private static XmlDocument LoadXmlDocument(Stream stream)
		{
			//Initialize the XmlReaderSettings that will ensure that the XML can be read
			XmlReaderSettings settings = new XmlReaderSettings();
			settings.IgnoreWhitespace = true;
			settings.ConformanceLevel = ConformanceLevel.Fragment;

			//Read the XML into a document
			using (XmlReader reader = XmlReader.Create(stream, settings))
			{
				XmlDocument doc = new XmlDocument();
				doc.XmlResolver = null;
				doc.Load(reader);

				return doc;
			}
		}

		private static string ReadNodeText(XmlNode node)
		{
			if (null == node)
			{
				throw new ArgumentNullException("node");
			}

			//Ensure that there is at least one child node
			if (0 == node.ChildNodes.Count)
			{
				return null;
			}

			//Loop through the child nodes and append them together. There may be multiple text nodes for a single node.
			StringBuilder sb = new StringBuilder();
			foreach (XmlNode childNode in node.ChildNodes)
			{
				//Ignore the child node
				if (null == childNode)
				{
					continue;
				}

				//Ensure that this is an expected node
				if (XmlNodeType.Text != childNode.NodeType)
				{
					throw new ArgumentException("All child nodes must be Text nodes. Encountered a node of type: " + childNode.NodeType,
						"node");
				}

				//Add the text into the builder
				sb.Append(childNode.Value);
			}

			return sb.ToString();
		}

		private static string ReadAttributeValue(XmlNode node, string attributeName)
		{
			if (null == node)
			{
				throw new ArgumentNullException("node");
			}
			else if (string.IsNullOrWhiteSpace(attributeName))
			{
				throw new ArgumentNullException("attributeName");
			}

			//If the attributes are null, then it won't contain any attributes
			if (null == node.Attributes)
			{
				return null;
			}

			//Retrieve the attribute
			XmlAttribute attribute = node.Attributes[attributeName];
			if (null == attribute)
			{
				return null;
			}
			else
			{
				return attribute.Value;
			}
		}
		#endregion
		#endregion

		#region Private Classes
		private static class LiveIdConstants
		{
            public const string RegistrationEndpointUri = @"https://login.live.com/ppsecure/DeviceAddCredential.srf";


			public const string DevicePrefix = "11";
			public static readonly string LiveDeviceFileName = Path.Combine(Path.Combine(
				Environment.ExpandEnvironmentVariables("%USERPROFILE%"), "LiveDeviceID"), "LiveDevice.xml");

			//Consists of valid, lowercase ANSI characters
			//public const string ValidDeviceNameCharacters = " !\"#$%&'()*+,-./0123456789:;<=>?@abcdefghijklmnopqrstuvqxyz[\\]^_`{|}~¡¢£¤¥¦§¨©ª«¬­®¯°±²³´µ¶·¸¹º»¼½¾¿àáâãäåæçèéêëìíîïðñòóôõö×øùúûüýþß÷ÿ";

			//TODO: Determine the valid range of characters. If ths specified valid characters are given, it fails
			public const string ValidDeviceNameCharacters = "0123456789abcdefghijklmnopqrstuvqxyz";
			public const int DeviceNameLength = 24;

			//Consists of the list of characters specified in the documentation
			public const string ValidDevicePasswordCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^*()-_=+; ,./?`~";
			public const int DevicePasswordLength = 24;
		}
        #endregion
        /// <summary>
		/// Represents the device credentials
		/// </summary>
		public class DeviceCredentials
		{
			/// <summary>
			/// Instantiates an instance of the device credentials object
			/// </summary>
			/// <param name="deviceName">Device Name</param>
			/// <param name="password">Password</param>
			public DeviceCredentials(string deviceName, string password)
			{
				this.DeviceName = deviceName;
				this.Password = password;
			}

			#region Properties
			public string DeviceName { get; private set; }

			public string Password { get; private set; }
			#endregion

		}
	}

	#region Public Classes & Enums
	/// <summary>
	/// Indicates an error during registration
	/// </summary>
	public enum DeviceRegistrationErrorCode
	{
		/// <summary>
		/// Unspecified or Unknown Error occurred
		/// </summary>
		Unknown = 0,

		/// <summary>
		/// Interface Disabled
		/// </summary>
		InterfaceDisabled = 1,

		/// <summary>
		/// Invalid Request Format
		/// </summary>
		InvalidRequestFormat = 3,

		/// <summary>
		/// Unknown Client Version
		/// </summary>
		UnknownClientVersion = 4,

		/// <summary>
		/// Blank Password
		/// </summary>
		BlankPassword = 6,

		/// <summary>
		/// Missing Device User Name or Password
		/// </summary>
		MissingDeviceUserNameOrPassword = 7,

		/// <summary>
		/// Invalid Parameter Syntax
		/// </summary>
		InvalidParameterSyntax = 8,

		/// <summary>
		/// Internal Error
		/// </summary>
		InternalError = 11,

		/// <summary>
		/// Device Already Exists
		/// </summary>
		DeviceAlreadyExists = 13
	}

	/// <summary>
	/// Indicates that Device Registration failed
	/// </summary>
	[Serializable]
	public sealed class DeviceRegistrationFailedException : Exception
	{
		/// <summary>
		/// Construct an instance of the DeviceRegistrationFailedException class
		/// </summary>
		public DeviceRegistrationFailedException()
			: base()
		{
		}

		/// <summary>
		/// Construct an instance of the DeviceRegistrationFailedException class
		/// </summary>
		/// <param name="message">Message to pass</param>
		public DeviceRegistrationFailedException(string message)
			: base(message)
		{
		}

		/// <summary>
		/// Construct an instance of the DeviceRegistrationFailedException class
		/// </summary>
		/// <param name="message">Message to pass</param>
		/// <param name="innerException">Exception to include</param>
		public DeviceRegistrationFailedException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		/// <summary>
		/// Construct an instance of the DeviceRegistrationFailedException class
		/// </summary>
		/// <param name="code">Error code that occurred</param>
		/// <param name="subCode">Subcode that occurred</param>
		public DeviceRegistrationFailedException(DeviceRegistrationErrorCode code, string subCode)
			: this(code, subCode, null)
		{
		}

		/// <summary>
		/// Construct an instance of the DeviceRegistrationFailedException class
		/// </summary>
		/// <param name="code">Error code that occurred</param>
		/// <param name="subCode">Subcode that occurred</param>
		/// <param name="innerException">Inner exception</param>
		public DeviceRegistrationFailedException(DeviceRegistrationErrorCode code, string subCode, Exception innerException)
			: base(string.Concat(code.ToString(), ": ", subCode), innerException)
		{
		}

		/// <summary>
		/// Construct an instance of the DeviceRegistrationFailedException class
		/// </summary>
		/// <param name="si"></param>
		/// <param name="sc"></param>
		private DeviceRegistrationFailedException(SerializationInfo si, StreamingContext sc)
			: base(si, sc)
		{
		}
	}
	#endregion
}
//</snippetDeviceIdManager>