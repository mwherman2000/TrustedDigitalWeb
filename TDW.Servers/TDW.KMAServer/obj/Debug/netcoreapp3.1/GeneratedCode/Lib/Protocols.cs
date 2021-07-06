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
namespace TDW.KMAServer
{
    
    public abstract partial class TDWKMAServiceBase : TrinityServer
    {
        protected override void RegisterMessageHandler()
        {
            
            {
                
                MessageRegistry.RegisterMessageHandler((ushort)(ushort)global::TDW.KMAServer.TSL.TrinityServer.TDWKMAService.SynReqMessageType.InitializeMasterKeyVault, _InitializeMasterKeyVaultHandler);
                
            }
            
        }
        
        private unsafe void _InitializeMasterKeyVaultHandler(SynReqArgs args)
        {
            InitializeMasterKeyVaultHandler(new KMAInitializeMasterKeyVaultRequestReader(args.Buffer, args.Offset));
            
        }
        
        public abstract void InitializeMasterKeyVaultHandler(KMAInitializeMasterKeyVaultRequestReader request);
        
    }
    
    namespace TDWKMAService
    {
        public static class MessagePassingExtension
        {
            
        #region prototype definition template variables
        
        #endregion
        
        public unsafe static void InitializeMasterKeyVault(this Trinity.Storage.IMessagePassingEndpoint storage, KMAInitializeMasterKeyVaultRequestWriter msg)
        {
            byte* bufferPtr = msg.buffer;
            *(int*)(bufferPtr) = msg.Length + TrinityProtocol.TrinityMsgHeader;
            *(TrinityMessageType*)(bufferPtr + TrinityProtocol.MsgTypeOffset) = TrinityMessageType.SYNC ;
            *(ushort*)(bufferPtr + TrinityProtocol.MsgIdOffset) = (ushort)global::TDW.KMAServer.TSL.TrinityServer.TDWKMAService.SynReqMessageType.InitializeMasterKeyVault;
            storage.SendMessage(bufferPtr, msg.Length + TrinityProtocol.MsgHeader);
        }
        
        }
    }
    
    #region Legacy
    public static class LegacyMessagePassingExtension
    {
        
        #region prototype definition template variables
        
        #endregion
        
        public unsafe static void InitializeMasterKeyVaultToTDWKMAService(this Trinity.Storage.MemoryCloud storage,  int partitionId, KMAInitializeMasterKeyVaultRequestWriter msg)
        {
            TDWKMAService.MessagePassingExtension.InitializeMasterKeyVault(storage[partitionId], msg);
        }
        
    }
    
    #endregion
}

#pragma warning restore 162,168,649,660,661,1522
