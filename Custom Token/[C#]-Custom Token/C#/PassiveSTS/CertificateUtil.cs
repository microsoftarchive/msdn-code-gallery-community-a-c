//----------------------------------------------------------------------------------------------
//    Copyright 2012 Microsoft Corporation
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
//----------------------------------------------------------------------------------------------


using System;
using System.Security.Cryptography.X509Certificates;

/// <summary>
/// A utility class which helps to retrieve an x509 certificate
/// </summary>
public class CertificateUtil
{
    /// <summary>
    /// Get the certificate from a specific store/location/subject.
    /// </summary>
    public static X509Certificate2 GetCertificate( StoreName name, StoreLocation location, string subjectName )
    {
        X509Store store = new X509Store( name, location );
        X509Certificate2Collection certificates = null;
        store.Open( OpenFlags.ReadOnly );

        try
        {
            X509Certificate2 result = null;

            //
            // Every time we call store.Certificates property, a new collection will be returned.
            //
            certificates = store.Certificates;

            for ( int i = 0; i < certificates.Count; i++ )
            {
                X509Certificate2 cert = certificates[i];

                if ( cert.SubjectName.Name.ToLower() == subjectName.ToLower() )
                {
                    if ( result != null )
                    {
                        throw new ApplicationException( string.Format( "More than one certificate was found for subject Name {0}", subjectName ) );
                    }

                    result = new X509Certificate2( cert );
                }
            }

            if ( result == null )
            {
                throw new ApplicationException( string.Format( "No certificate was found for subject Name {0}", subjectName ) );
            }

            return result;
        }
        finally
        {
            if ( certificates != null )
            {
                for ( int i = 0; i < certificates.Count; i++ )
                {
                    X509Certificate2 cert = certificates[i];
                    cert.Reset();
                }
            }

            store.Close();
        }
    }
}

