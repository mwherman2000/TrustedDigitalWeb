using Stratis.SmartContracts;
using System;

public class TDWVDASmartContract : SmartContract
{
    const string AUTHORITY_METHOD = "did:svrn:authority";
    const string AUTHORITY_REGISTRAR = "0001/0001/1001";

    const string REGISTRARTAG = "Registrar";
    const string REGISTRARUDIDTAG = "RegistrarUdid";
    const string VERSIONTAG = "Version";

    const string REVOCATIONLISTTAG = "RevocationList";
    const string REVOCATIONLISTCOUNTTAG = "RevocationListCount";

    const string UIRLISTTAG = "UIRList";
    const string UIRCOUNTTAG = "UIRCount";

    const string SEPRLISTTAG = "SEPRList";
    const string SEPRCOUNTTAG = "SERPListCount";

    const long ContractVersion = 1001001;

    public enum ResultType
    {
        Unknown,
        NewEntry,
        UpdatedEntry,
        BadRevoker
    }

    struct LogMessage
    {
        public string Message;
    }

    public TDWVDASmartContract(ISmartContractState smartContractState) : base(smartContractState)
    {
        Version = "TDWVDASmartContract" + " " + ContractVersion.ToString();

        Registrar = Message.Sender;
        RegistrarUdid = AUTHORITY_METHOD + ":" + AUTHORITY_REGISTRAR;

        UIRLength = 0;
        SEPRLength = 0;
        RevocationListLength = 0;

        Log(new LogMessage { Message = Version });
    }

    public string Version
    {
        get
        {
            return PersistentState.GetString(VERSIONTAG);
        }
        private set
        {
            PersistentState.SetString(VERSIONTAG, value);
        }
    }

    public Address Registrar
    {
        get
        {
            return PersistentState.GetAddress(REGISTRARTAG);
        }
        private set
        {
            PersistentState.SetAddress(REGISTRARTAG, value);
        }
    }
    public string RegistrarUdid
    {
        get
        {
            return PersistentState.GetString(REGISTRARUDIDTAG);
        }
        private set
        {
            PersistentState.SetString(REGISTRARUDIDTAG, value);
        }
    }

    public Address SenderAddress
    {
        get
        {
            return Message.Sender;
        }
    }

    public string HelloWorld()
    {
        return "Hello World!";
    }

    public string Ping()
    {
        Log(new LogMessage { Message = "Ping" + " " + "Pong" });
        return "Pong";
    }

    public long RevocationListLength
    {
        get
        {
            return PersistentState.GetInt64(REVOCATIONLISTCOUNTTAG);
        }
        private set
        {
            PersistentState.SetInt64(REVOCATIONLISTCOUNTTAG, value);
        }
    }

    public long UIRLength
    {
        get
        {
            return PersistentState.GetInt64(UIRCOUNTTAG);
        }
        private set
        {
            PersistentState.SetInt64(UIRCOUNTTAG, value);
        }
    }

    public long SEPRLength
    {
        get
        {
            return PersistentState.GetInt64(SEPRCOUNTTAG);
        }
        private set
        {
            PersistentState.SetInt64(SEPRCOUNTTAG, value);
        }
    }

    //////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Common structures for VDA Smart Contract and Stratis VDAHelpers library:
    /// TDW.VDASmartContract/TDWVDASmartContract.cs and TDW.VDAServer/TDWVDAStratisHelpers.cs
    /// </summary>

    public struct UIREntry // Universal Identifier Registry (UIR) Entry
    {
        public string identifierudid;
        public string credserviceendpointudid;
        public string credsignaturehash16;
        public Address requesteraddress;
        public string requesterudid;
        public long registeredticks;
        public string message;
    }

    public struct SEPREntry // Service Endpoint Registry (SEPR) Entry
    {
        public string serviceendpointudid;
        public string serviceendpointurl;
        public long serviceendpointport;
        public Address requesteraddress;
        public string requesterudid;
        public long registeredticks;
        public string message;
    }

    public struct RevocationListEntry // Revocation List Entry
    {
        public string credudid;
        public string credserviceendpointudid;
        public Address revokeraddress;
        public string revokerudid;
        public long revokedticks;
        public string message;
    }

    //////////////////////////////////////////////////////////////////////////////

    public UIREntry NewUIREntry()
    {
        return new UIREntry();
    }

    public UIREntry NewUIREntryInitialized(
       string identifierudid,
       string credserviceendpointudid,
       string credsignaturehash16,
       Address requesteraddress,
       string requesterudid,
       long registeredticks,
       string message
    )
    {
        UIREntry entry = new UIREntry();
        entry.identifierudid = identifierudid;
        entry.credserviceendpointudid = credserviceendpointudid;
        entry.credsignaturehash16 = credsignaturehash16;
        entry.requesteraddress = requesteraddress;
        entry.requesterudid = requesterudid;
        entry.registeredticks = registeredticks;
        entry.message = message;
        return entry;
    }

    private string ToJson(UIREntry entry)
    {
        string json;
        json = "{" +
            " identifierudid: \"" + entry.identifierudid + "\"," +
            " credserviceendpointudid: \"" + entry.credserviceendpointudid + "\"," +
            " credsignaturehash16: \"" + entry.credsignaturehash16 + "\"" +
            " requesteraddress: \"" + entry.requesteraddress + "\"," +
            " requesterudid: \"" + entry.requesterudid + "\"," +
            " registeredticks: " + entry.registeredticks.ToString() + "," +
            " message: \"" + entry.message + "\"" +
            " }";
        return json;
    }

    public ResultType SaveUIREntry(
       string identifierudid,
       string credserviceendpointudid,
       string credsignaturehash16,
       Address requesteraddress,
       string requesterudid,
       long registeredticks,
       string message
    )
    {
        UIREntry entry = NewUIREntryInitialized(identifierudid, credserviceendpointudid, credsignaturehash16, requesteraddress, requesterudid, registeredticks, message);
        return Save(entry);
    }

    private ResultType Save(UIREntry entry)
    {
        Address requester = Message.Sender;
        ResultType rc = ResultType.Unknown;

        byte[] bytes = this.PersistentState.GetBytes($"{UIRLISTTAG}[{entry.identifierudid}]");
        if (bytes == null) // add new entry
        {
            this.PersistentState.SetStruct<UIREntry>($"{UIRLISTTAG}[{entry.identifierudid}]", entry);
            RevocationListLength++;
            rc = ResultType.NewEntry;
        }
        else // existing entry: check if requester matches
        {
            UIREntry existingentry = this.Serializer.ToStruct<UIREntry>(bytes);
            if (existingentry.requesteraddress == requester) // update existing entry
            {
                this.PersistentState.SetStruct<UIREntry>($"{UIRLISTTAG}[{existingentry.identifierudid}]", entry);
                rc = ResultType.UpdatedEntry;
            }
            else // illegal requester - skip save
            {
                rc = ResultType.BadRevoker;
            }
        }

        Log(new LogMessage { Message = rc + " " + rc.ToString() });
        return rc;
    }

    public UIREntry LoadUIREntry(string identifierudid)
    {
        UIREntry entry;
        byte[] bytes = this.PersistentState.GetBytes($"{UIRLISTTAG}[{identifierudid}]");
        if (bytes == null) // not found in the revocation list
        {
            entry = new UIREntry();
            entry.message = "not found";
        }
        else // found in the revocation list
        {
            entry = this.Serializer.ToStruct<UIREntry>(bytes);
        }
        return entry;
    }

    public bool IsVerified(string identifierudid, string credsignaturehash16)
    {
        bool isVerified = false;

        UIREntry entry = LoadUIREntry(identifierudid);
        if (entry.message != "not found")
        {
            if (entry.credsignaturehash16 == credsignaturehash16)
            {
                isVerified = true;
            }
        }

        return isVerified;
    }

    //////////////////////////////////////////////////////////////////////////////

    public SEPREntry NewSEPREntry()
    {
        return new SEPREntry();
    }

    public SEPREntry NewSEPREntryInitialized(
       string serviceendpointudid,
       string serviceendpointurl,
       long serviceendpointport,
       Address requesteraddress,
       string requesterudid,
       long registeredticks,
       string message
    )
    {
        SEPREntry entry = new SEPREntry();
        entry.serviceendpointudid = serviceendpointudid;
        entry.serviceendpointurl = serviceendpointurl;
        entry.serviceendpointport = serviceendpointport;
        entry.requesteraddress = requesteraddress;
        entry.requesterudid = requesterudid;
        entry.registeredticks = registeredticks;
        entry.message = message;
        return entry;
    }

    private string ToJson(SEPREntry entry)
    {
        string json;
        json = "{" +
            " serviceendpointudid: \"" + entry.serviceendpointudid + "\"," +
            " serviceendpointurl: \"" + entry.serviceendpointurl + "\"," +
            " serviceendpointport: \"" + entry.serviceendpointport.ToString() + "\"," +
            " requesteraddress: \"" + entry.requesteraddress + "\"," +
            " requesterudid: \"" + entry.requesterudid + "\"," +
            " registeredticks: " + entry.registeredticks.ToString() + "," +
            " message: \"" + entry.message + "\"" +
            " }";
        return json;
    }

    public ResultType SaveSEPREntry(
       string serviceendpointudid,
       string serviceendpointurl,
       long serviceendpointport,
       Address requesteraddress,
       string requesterudid,
       long registeredticks,
       string message
    )
    {
        SEPREntry entry = NewSEPREntryInitialized(serviceendpointudid, serviceendpointurl, serviceendpointport, requesteraddress, requesterudid,  registeredticks, message);
        return Save(entry);
    }

    private ResultType Save(SEPREntry entry)
    {
        Address requester = Message.Sender;
        ResultType rc = ResultType.Unknown;

        byte[] bytes = this.PersistentState.GetBytes($"{SEPRLISTTAG}[{entry.serviceendpointudid}]");
        if (bytes == null) // add new entry
        {
            this.PersistentState.SetStruct<SEPREntry>($"{SEPRLISTTAG}[{entry.serviceendpointudid}]", entry);
            RevocationListLength++;
            rc = ResultType.NewEntry;
        }
        else // existing entry: check if requester matches
        {
            SEPREntry existingentry = this.Serializer.ToStruct<SEPREntry>(bytes);
            if (existingentry.requesteraddress == requester) // update existing entry
            {
                this.PersistentState.SetStruct<SEPREntry>($"{SEPRLISTTAG}[{existingentry.serviceendpointudid}]", entry);
                rc = ResultType.UpdatedEntry;
            }
            else // illegal requester - skip save
            {
                rc = ResultType.BadRevoker;
            }
        }

        Log(new LogMessage { Message = rc + " " + rc.ToString() });
        return rc;
    }

    public SEPREntry LoadSEPREntry(string serviceendpointudid)
    {
        SEPREntry entry;
        byte[] bytes = this.PersistentState.GetBytes($"{SEPRLISTTAG}[{serviceendpointudid}]");
        if (bytes == null) // not found in the revocation list
        {
            entry = new SEPREntry();
            entry.message = "not found";
        }
        else // found in the revocation list
        {
            entry = this.Serializer.ToStruct<SEPREntry>(bytes);
        }
        return entry;
    }

    public bool IfSEPFound(string serviceendpointudid)
    {
        bool isFound;
        byte[] bytes = this.PersistentState.GetBytes($"{SEPRLISTTAG}[{serviceendpointudid}]");
        isFound = (bytes != null); // found in the revocation list - no need to deserialize to struct

        return isFound;
    }

    public bool IsSEPExists(string serviceendpointudid)
    {
        bool isExists = IfSEPFound(serviceendpointudid);
        return isExists;
    }

    //////////////////////////////////////////////////////////////////////////////

    public RevocationListEntry NewRevocationListEntry()
    {
        return new RevocationListEntry();
    }

    public RevocationListEntry NewRecovationListEntryInitialized(
       string credudid,
       string credserviceendpointudid,
       Address revokeraddress,
       string revokerudid,
       long revokedticks,
       string message
    )
    {
        RevocationListEntry entry = new RevocationListEntry();
        entry.credudid = credudid;
        entry.credserviceendpointudid = credserviceendpointudid;
        entry.revokeraddress = revokeraddress;
        entry.revokerudid = revokerudid;
        entry.revokedticks = revokedticks;
        entry.message = message;
        return entry;
    }

    private string ToJson(RevocationListEntry entry)
    {
        string json;
        json = "{" +
            " credudid: \"" + entry.credudid + "\"," +
            " credserviceEndpointudid: \"" + entry.credserviceendpointudid + "\"," +
            " revokeraddress: \"" + entry.revokeraddress + "\"," +
            " revokerudid: \"" + entry.revokerudid + "\"," +
            " revokedticks: " + entry.revokedticks.ToString() + "," +
            " message: \"" + entry.message + "\"" +
            " }";
        return json;
    }

    public ResultType SaveRevocationListEntry(
       string credudid,
       string credserviceendpointudid,
       Address revokeraddress,
       string revokerudid,
       long revokedticks,
       string message
    )
    {
        RevocationListEntry entry = NewRecovationListEntryInitialized(credudid, credserviceendpointudid, revokeraddress, revokerudid, revokedticks, message);
        return Save(entry);
    }

    private ResultType Save(RevocationListEntry entry)
    {
        Address revoker = Message.Sender;
        ResultType rc = ResultType.Unknown;

        byte[] bytes = this.PersistentState.GetBytes($"{REVOCATIONLISTTAG}[{entry.credudid}]");
        if (bytes == null) // add new entry
        {
            this.PersistentState.SetStruct<RevocationListEntry>($"{REVOCATIONLISTTAG}[{entry.credudid}]", entry);
            RevocationListLength++;
            rc = ResultType.NewEntry;
        }
        else // existing entry: check if revoker matches
        {
            RevocationListEntry existingentry = this.Serializer.ToStruct<RevocationListEntry>(bytes);
            if (existingentry.revokeraddress == revoker) // update existing entry
            {
                this.PersistentState.SetStruct<RevocationListEntry>($"{REVOCATIONLISTTAG}[{existingentry.credudid}]", entry);
                rc = ResultType.UpdatedEntry;
            }
            else // illegal revoker - skip save
            {
                rc = ResultType.BadRevoker;
            }
        }

        Log(new LogMessage { Message = rc + " " + rc.ToString() });
        return rc;
    }

    public RevocationListEntry LoadRevocationListEntry(string credudid)
    {
        RevocationListEntry entry;
        byte[] bytes = this.PersistentState.GetBytes($"{REVOCATIONLISTTAG}[{credudid}]");
        if (bytes == null) // not found in the revocation list
        {
            entry = new RevocationListEntry();
            entry.message = "not found";
        }
        else // found in the revocation list
        {
            entry = this.Serializer.ToStruct<RevocationListEntry>(bytes);
        }
        return entry;
    }

    public bool IfRevocationListEntryFound(string credudid)
    {
        bool isFound;
        byte[] bytes = this.PersistentState.GetBytes($"{REVOCATIONLISTTAG}[{credudid}]");
        isFound = (bytes != null); // found in the revocation list - no need to deserialize to struct

        return isFound;
    }

    public bool IfCredentialRevoked(string credudid)
    {
        bool isRevoked = IfRevocationListEntryFound(credudid);
        return isRevoked;
    }
}