using System.Diagnostics;
using System.DirectoryServices;

namespace GlobalAddressListSample
{
    [DebuggerDisplay("DisplayName = {DisplayName}, Mail = {Mail}")]
    public class Address
    {
        internal Address(DirectoryEntry entry)
        {
            //
            // You can get one or more of the following properties:
            //
            //
            // objectClass
            // cn
            // description
            // givenName
            // distinguishedName
            // instanceType
            // whenCreated
            // whenChanged
            // displayName
            // uSNCreated
            // memberOf
            // uSNChanged
            // homeMTA
            // proxyAddresses
            // homeMDB
            // mDBUseDefaults
            // mailNickname
            // protocolSettings
            // name
            // objectGUID
            // userAccountControl
            // badPwdCount
            // codePage
            // countryCode
            // badPasswordTime
            // lastLogon
            // pwdLastSet
            // primaryGroupID
            // objectSid
            // accountExpires
            // logonCount
            // sAMAccountName
            // sAMAccountType
            // showInAddressBook
            // legacyExchangeDN
            // userPrincipalName
            // lockoutTime
            // objectCategory
            // dSCorePropagationData
            // lastLogonTimestamp
            // textEncodedORAddress
            // mail
            // msExchPoliciesExcluded
            // msExchMailboxTemplateLink
            // msExchRecipientDisplayType
            // msExchUserCulture
            // msExchVersion
            // msExchRecipientTypeDetails
            // msExchHomeServerName
            // msExchALObjectVersion
            // msExchMailboxSecurityDescriptor
            // msExchUserAccountControl
            // msExchMailboxGuid
            // nTSecurityDescriptor

            // As an example we get only two properties
            this.DisplayName = (string)entry.Properties["displayName"].Value;
            this.Mail = (string)entry.Properties["mail"].Value;
        }

        public string DisplayName
        {
            get;
            private set;
        }

        public string Mail
        {
            get;
            private set;
        }
    }
}
