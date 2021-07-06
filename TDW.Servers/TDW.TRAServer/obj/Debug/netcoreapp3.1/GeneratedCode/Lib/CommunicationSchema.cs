#pragma warning disable 162,168,649,660,661,1522

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Trinity;
using Trinity.Network;
using Trinity.Network.Http;
using Trinity.Network.Messaging;
using Trinity.TSL;
using Trinity.TSL.Lib;
namespace TDW.TRAServer
{
    internal class ProtocolDescriptor : IProtocolDescriptor
    {
        public string Name
        {
            get;
            set;
        }
        public string RequestSignature
        {
            get;
            set;
        }
        public string ResponseSignature
        {
            get;
            set;
        }
        public TrinityMessageType Type
        {
            get;
            set;
        }
    }
    #region Server
    
    public class TRAResourceAgentCommunicationSchema : ICommunicationSchema
    {
        IEnumerable<IProtocolDescriptor> ICommunicationSchema.SynReqProtocolDescriptors
        {
            get
            {
                string request_sig;
                
                yield break;
            }
        }
        IEnumerable<IProtocolDescriptor> ICommunicationSchema.SynReqRspProtocolDescriptors
        {
            get
            {
                string request_sig, response_sig;
                
                {
                    
                    request_sig = "{long|string}";
                    
                    response_sig = "{long|string|long|List<string>}";
                    yield return new ProtocolDescriptor()
                    {
                        Name = "SignHashThumbprintTDWCredential",
                        RequestSignature = request_sig,
                        ResponseSignature = response_sig,
                        Type = Trinity.Network.Messaging.TrinityMessageType.SYNC_WITH_RSP
                    };
                }
                
                {
                    
                    request_sig = "{long|string}";
                    
                    response_sig = "{long|string|long|List<string>}";
                    yield return new ProtocolDescriptor()
                    {
                        Name = "SignSignatureTDWCredential",
                        RequestSignature = request_sig,
                        ResponseSignature = response_sig,
                        Type = Trinity.Network.Messaging.TrinityMessageType.SYNC_WITH_RSP
                    };
                }
                
                {
                    
                    request_sig = "{long|string}";
                    
                    response_sig = "{long|string|long|List<string>}";
                    yield return new ProtocolDescriptor()
                    {
                        Name = "NotarizeTDWCredential",
                        RequestSignature = request_sig,
                        ResponseSignature = response_sig,
                        Type = Trinity.Network.Messaging.TrinityMessageType.SYNC_WITH_RSP
                    };
                }
                
                yield break;
            }
        }
        IEnumerable<IProtocolDescriptor> ICommunicationSchema.AsynReqProtocolDescriptors
        {
            get
            {
                string request_sig;
                
                yield break;
            }
        }
        IEnumerable<IProtocolDescriptor> ICommunicationSchema.AsynReqRspProtocolDescriptors
        {
            get
            {
                string request_sig;
                string response_sig;
                
                yield break;
            }
        }
        string ICommunicationSchema.Name
        {
            get { return "TRAResourceAgent"; }
        }
        IEnumerable<string> ICommunicationSchema.HttpEndpointNames
        {
            get
            {
                
                yield return "CreateTDWCredential";
                
                yield break;
            }
        }
    }
    [CommunicationSchema(typeof(TRAResourceAgentCommunicationSchema))]
    public abstract partial class TRAResourceAgentBase : TrinityServer { }
    namespace TSL.TrinityServer.TRAResourceAgent
    {
        /// <summary>
        /// Specifies the type of a synchronous request (without response, that is, response type is void) message.
        /// </summary>
        public enum SynReqMessageType : ushort
        {
            
        }
        /// <summary>
        /// Specifies the type of a synchronous request (with response) message.
        /// </summary>
        public enum SynReqRspMessageType : ushort
        {
            SignHashThumbprintTDWCredential,
            SignSignatureTDWCredential,
            NotarizeTDWCredential,
            
        }
        /// <summary>
        /// Specifies the type of an asynchronous request (without response) message.
        /// </summary>
        public enum AsynReqMessageType : ushort
        {
            
        }
        /// <summary>
        /// Specifies the type of an asynchronous request (with response) message.
        /// </summary>
        public enum AsynReqRspMessageType : ushort
        {
            
        }
    }
    
    #endregion
    #region Proxy
    
    #endregion
    #region Module
    
    #endregion
    
}

#pragma warning restore 162,168,649,660,661,1522
