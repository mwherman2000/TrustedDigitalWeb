#pragma warning disable 162,168,649,660,661,1522
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Trinity;
using Trinity.TSL;
using Trinity.Core.Lib;
using Trinity.Network;
using Trinity.Network.Messaging;
using System.Collections.Concurrent;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using Trinity.Storage;
namespace TDW.TRAServer
{
    
    public abstract partial class TRAResourceAgentBase : TrinityServer
    {
        protected override void RegisterMessageHandler()
        {
            
            {
                
                MessageRegistry.RegisterMessageHandler((ushort)(ushort)global::TDW.TRAServer.TSL.TrinityServer.TRAResourceAgent.SynReqRspMessageType.SignHashThumbprintTDWCredential, _SignHashThumbprintTDWCredentialHandler);
                
            }
            
            {
                
                MessageRegistry.RegisterMessageHandler((ushort)(ushort)global::TDW.TRAServer.TSL.TrinityServer.TRAResourceAgent.SynReqRspMessageType.SignSignatureTDWCredential, _SignSignatureTDWCredentialHandler);
                
            }
            
            {
                
                MessageRegistry.RegisterMessageHandler((ushort)(ushort)global::TDW.TRAServer.TSL.TrinityServer.TRAResourceAgent.SynReqRspMessageType.NotarizeTDWCredential, _NotarizeTDWCredentialHandler);
                
            }
            
        }
        
        private unsafe void _SignHashThumbprintTDWCredentialHandler(SynReqRspArgs args)
        {
            var rsp = new TDWCredentialResponseWriter();
            SignHashThumbprintTDWCredentialHandler(new TDWProcessCredentialRequestReader(args.Buffer, args.Offset), rsp);
            *(int*)(rsp.m_ptr - TrinityProtocol.MsgHeader) = rsp.Length + TrinityProtocol.TrinityMsgHeader;
            args.Response = new TrinityMessage(rsp.buffer, rsp.Length + TrinityProtocol.MsgHeader);
        }
        public abstract void SignHashThumbprintTDWCredentialHandler(TDWProcessCredentialRequestReader request, TDWCredentialResponseWriter response);
        
        private unsafe void _SignSignatureTDWCredentialHandler(SynReqRspArgs args)
        {
            var rsp = new TDWCredentialResponseWriter();
            SignSignatureTDWCredentialHandler(new TDWProcessCredentialRequestReader(args.Buffer, args.Offset), rsp);
            *(int*)(rsp.m_ptr - TrinityProtocol.MsgHeader) = rsp.Length + TrinityProtocol.TrinityMsgHeader;
            args.Response = new TrinityMessage(rsp.buffer, rsp.Length + TrinityProtocol.MsgHeader);
        }
        public abstract void SignSignatureTDWCredentialHandler(TDWProcessCredentialRequestReader request, TDWCredentialResponseWriter response);
        
        private unsafe void _NotarizeTDWCredentialHandler(SynReqRspArgs args)
        {
            var rsp = new TDWCredentialResponseWriter();
            NotarizeTDWCredentialHandler(new TDWProcessCredentialRequestReader(args.Buffer, args.Offset), rsp);
            *(int*)(rsp.m_ptr - TrinityProtocol.MsgHeader) = rsp.Length + TrinityProtocol.TrinityMsgHeader;
            args.Response = new TrinityMessage(rsp.buffer, rsp.Length + TrinityProtocol.MsgHeader);
        }
        public abstract void NotarizeTDWCredentialHandler(TDWProcessCredentialRequestReader request, TDWCredentialResponseWriter response);
        
    }
    
    namespace TRAResourceAgent
    {
        public static class MessagePassingExtension
        {
            
        #region prototype definition template variables
        
        #endregion
        
        public unsafe static TDWCredentialResponseReader SignHashThumbprintTDWCredential(this Trinity.Storage.IMessagePassingEndpoint storage, TDWProcessCredentialRequestWriter msg)
        {
            byte* bufferPtr = msg.buffer;
            *(int*)(bufferPtr) = msg.Length + TrinityProtocol.TrinityMsgHeader;
            *(TrinityMessageType*)(bufferPtr + TrinityProtocol.MsgTypeOffset) = TrinityMessageType.SYNC_WITH_RSP ;
            *(ushort*)(bufferPtr + TrinityProtocol.MsgIdOffset) = (ushort)global::TDW.TRAServer.TSL.TrinityServer.TRAResourceAgent.SynReqRspMessageType.SignHashThumbprintTDWCredential;
            TrinityResponse response;
            storage.SendMessage(bufferPtr, msg.Length + TrinityProtocol.MsgHeader, out response);
            return new TDWCredentialResponseReader(response.Buffer, response.Offset);
        }
        
        #region prototype definition template variables
        
        #endregion
        
        public unsafe static TDWCredentialResponseReader SignSignatureTDWCredential(this Trinity.Storage.IMessagePassingEndpoint storage, TDWProcessCredentialRequestWriter msg)
        {
            byte* bufferPtr = msg.buffer;
            *(int*)(bufferPtr) = msg.Length + TrinityProtocol.TrinityMsgHeader;
            *(TrinityMessageType*)(bufferPtr + TrinityProtocol.MsgTypeOffset) = TrinityMessageType.SYNC_WITH_RSP ;
            *(ushort*)(bufferPtr + TrinityProtocol.MsgIdOffset) = (ushort)global::TDW.TRAServer.TSL.TrinityServer.TRAResourceAgent.SynReqRspMessageType.SignSignatureTDWCredential;
            TrinityResponse response;
            storage.SendMessage(bufferPtr, msg.Length + TrinityProtocol.MsgHeader, out response);
            return new TDWCredentialResponseReader(response.Buffer, response.Offset);
        }
        
        #region prototype definition template variables
        
        #endregion
        
        public unsafe static TDWCredentialResponseReader NotarizeTDWCredential(this Trinity.Storage.IMessagePassingEndpoint storage, TDWProcessCredentialRequestWriter msg)
        {
            byte* bufferPtr = msg.buffer;
            *(int*)(bufferPtr) = msg.Length + TrinityProtocol.TrinityMsgHeader;
            *(TrinityMessageType*)(bufferPtr + TrinityProtocol.MsgTypeOffset) = TrinityMessageType.SYNC_WITH_RSP ;
            *(ushort*)(bufferPtr + TrinityProtocol.MsgIdOffset) = (ushort)global::TDW.TRAServer.TSL.TrinityServer.TRAResourceAgent.SynReqRspMessageType.NotarizeTDWCredential;
            TrinityResponse response;
            storage.SendMessage(bufferPtr, msg.Length + TrinityProtocol.MsgHeader, out response);
            return new TDWCredentialResponseReader(response.Buffer, response.Offset);
        }
        
        }
    }
    
    #region Legacy
    public static class LegacyMessagePassingExtension
    {
        
        #region prototype definition template variables
        
        #endregion
        
        public unsafe static TDWCredentialResponseReader SignHashThumbprintTDWCredentialToTRAResourceAgent(this Trinity.Storage.MemoryCloud storage,  int partitionId, TDWProcessCredentialRequestWriter msg)
        {
            return TRAResourceAgent.MessagePassingExtension.SignHashThumbprintTDWCredential(storage[partitionId], msg);
        }
        
        #region prototype definition template variables
        
        #endregion
        
        public unsafe static TDWCredentialResponseReader SignSignatureTDWCredentialToTRAResourceAgent(this Trinity.Storage.MemoryCloud storage,  int partitionId, TDWProcessCredentialRequestWriter msg)
        {
            return TRAResourceAgent.MessagePassingExtension.SignSignatureTDWCredential(storage[partitionId], msg);
        }
        
        #region prototype definition template variables
        
        #endregion
        
        public unsafe static TDWCredentialResponseReader NotarizeTDWCredentialToTRAResourceAgent(this Trinity.Storage.MemoryCloud storage,  int partitionId, TDWProcessCredentialRequestWriter msg)
        {
            return TRAResourceAgent.MessagePassingExtension.NotarizeTDWCredential(storage[partitionId], msg);
        }
        
    }
    
    #endregion
}

#pragma warning restore 162,168,649,660,661,1522
