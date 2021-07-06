#pragma warning disable 162,168,649,660,661,1522
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trinity;
using Trinity.TSL;
namespace TDW.TRAServer
{
    
    /// <summary>
    /// Represents the enum type TRATrustLevel defined in the TSL.
    /// </summary>
    public enum TRATrustLevel : byte
    {
        Undefined = 0,UnResolvable = 1,Unsigned = 2,HashedThumbprint = 3,SignedHashSignature = 4,Verifiable = 5,CorruptSignatures = 6
    }
    
    /// <summary>
    /// Represents the enum type TRAEncryptionFlag defined in the TSL.
    /// </summary>
    public enum TRAEncryptionFlag : byte
    {
        NotEncrypted = 0,Encrypted = 1
    }
    
    /// <summary>
    /// Represents the enum type TRACredentialType defined in the TSL.
    /// </summary>
    public enum TRACredentialType : byte
    {
        GenericCredential = 0,UDIDDocument = 1,VerifiableCredential = 2,VerifiableCapabilityAuthorization = 3,MasterVerifiableCapabilityAuthorization = 4,ServerCertificate = 5,RevocationCertificate = 6
    }
    
    /// <summary>
    /// Represents the enum type TRAServiceType defined in the TSL.
    /// </summary>
    public enum TRAServiceType : byte
    {
        Unknown = 0,ResourceService = 1,StorageService = 2,KeyManagementService = 3,MasterKeyManagementService = 4,AuthenticationService = 5,VerifiableDataRegistryService = 6
    }
    
}

#pragma warning restore 162,168,649,660,661,1522
