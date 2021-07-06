#pragma warning disable 162,168,649,660,661,1522
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trinity.Core.Lib;
using Trinity.Network.Messaging;
using Trinity.Storage;
using Trinity.TSL;
using Trinity.TSL.Lib;
namespace TDW.KMAServer
{
    
    /// <summary>
    /// Represents a read-only accessor on the message of type KMAInitializeMasterKeyVaultRequest defined in the TSL protocols.
    /// The message readers will be instantiated by the system and passed to user's logic.
    /// After finished accessing the message. It is the user's responsibility to call Dispose()
    /// on the reader object. Recommend wrapping the reader with a <c>using Statement block</c>.
    /// <seealso ref="https://msdn.microsoft.com/en-us/library/yh598w02.aspx"/>
    /// </summary>
    public unsafe sealed class KMAInitializeMasterKeyVaultRequestReader : KMAInitializeMasterKeyVaultRequest_Accessor, IDisposable
    {
        byte * buffer;
        internal KMAInitializeMasterKeyVaultRequestReader(byte* buf, int offset)
            : base(buf + offset
                  
                  , ReaderResizeFunc
                   )
        {
            buffer = buf;
        }
        
        /** 
         * KMAInitializeMasterKeyVaultRequestReader is not resizable because it may be attached
         * to a buffer passed in from the network layer and we don't know how
         * to resize it.
         */
        static byte* ReaderResizeFunc(byte* ptr, int offset, int delta)
        {
            throw new InvalidOperationException("KMAInitializeMasterKeyVaultRequestReader is not resizable");
        }
        
        /// <summary>
        /// Dispose the message reader and release the memory resource.
        /// It is the user's responsibility to call this method after finished accessing the message.
        /// </summary>
        public void Dispose()
        {
            Memory.free(buffer);
            buffer = null;
        }
    }
    /// <summary>
    /// Represents a writer accessor on the message of type KMAInitializeMasterKeyVaultRequest defined in the TSL protocols.
    /// The message writers should be instantiated by the user's logic and passed to the system to send it out.
    /// After finished accessing the message. It is the user's responsibility to call Dispose()
    /// on the writer object. Recommend wrapping the reader with a <c>using Statement block</c>.
    /// </summary>
    /// <seealso ref="https://msdn.microsoft.com/en-us/library/yh598w02.aspx"/>
    /// <remarks>Calling <c>Dispose()</c> does not send the message out.</remarks>
    public unsafe sealed class KMAInitializeMasterKeyVaultRequestWriter : KMAInitializeMasterKeyVaultRequest_Accessor, IDisposable
    {
        internal byte* buffer = null;
        internal int BufferLength;
        internal int Length; 
        public unsafe KMAInitializeMasterKeyVaultRequestWriter( string reserved = default(string) )
            : base(null
                  
                  , null
                   )
        {
            int preservedHeaderLength = TrinityProtocol.MsgHeader;
            
            byte* targetPtr;
            
            targetPtr = (byte*)preservedHeaderLength;
            
            {

        if(reserved!= null)
        {
            int strlen_2 = reserved.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            byte* tmpcellptr = (byte*)Memory.malloc((ulong)targetPtr);
            {
                BufferLength     = (int)targetPtr;
                Memory.memset(tmpcellptr, 0, (ulong)targetPtr);
                targetPtr = tmpcellptr;
                tmpcellptr += preservedHeaderLength;
                targetPtr  += preservedHeaderLength;
                
            {

        if(reserved!= null)
        {
            int strlen_2 = reserved.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = reserved)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }
            }
            
            buffer = tmpcellptr - preservedHeaderLength;
            this.m_ptr = buffer + preservedHeaderLength;
            Length = BufferLength - preservedHeaderLength;
            
            this.ResizeFunction = WriterResizeFunction;
            
        }
        internal unsafe KMAInitializeMasterKeyVaultRequestWriter(int asyncRspHeaderLength,  string reserved = default(string) )
            : base(null
                  
                  , null
                   )
        {
            int preservedHeaderLength = TrinityProtocol.MsgHeader + asyncRspHeaderLength;
            
            byte* targetPtr;
            
            targetPtr = (byte*)preservedHeaderLength;
            
            {

        if(reserved!= null)
        {
            int strlen_2 = reserved.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            byte* tmpcellptr = (byte*)Memory.malloc((ulong)targetPtr);
            {
                BufferLength     = (int)targetPtr;
                Memory.memset(tmpcellptr, 0, (ulong)targetPtr);
                targetPtr = tmpcellptr;
                tmpcellptr += preservedHeaderLength;
                targetPtr  += preservedHeaderLength;
                
            {

        if(reserved!= null)
        {
            int strlen_2 = reserved.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = reserved)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }
            }
            
            buffer = tmpcellptr - preservedHeaderLength;
            this.m_ptr = buffer + preservedHeaderLength;
            Length = BufferLength - preservedHeaderLength;
            
            this.ResizeFunction = WriterResizeFunction;
            
        }
        
        private byte* WriterResizeFunction(byte* ptr, int ptr_offset, int delta)
        {
            int curlen = Length;
            int tgtlen = curlen + delta;
            if (delta >= 0)
            {
                byte* currentBufferPtr = buffer;
                int required_length = (int)(tgtlen + (this.m_ptr - currentBufferPtr));
                if(required_length < curlen) throw new AccessorResizeException("Accessor size overflow.");
                if (required_length <= BufferLength)
                {
                    Memory.memmove(
                        ptr + ptr_offset + delta,
                        ptr + ptr_offset,
                        (ulong)(curlen - (ptr + ptr_offset - this.m_ptr)));
                    Length = tgtlen;
                    return ptr;
                }
                else
                {
                    while (BufferLength < required_length)
                    {
                        if (int.MaxValue - BufferLength >= (BufferLength>>1)) BufferLength += (BufferLength >> 1);
                        else if (int.MaxValue - BufferLength >= (1 << 20)) BufferLength += (1 << 20);
                        else BufferLength = int.MaxValue;
                    }
                    byte* tmpBuffer = (byte*)Memory.malloc((ulong)BufferLength);
                    Memory.memcpy(
                        tmpBuffer,
                        currentBufferPtr,
                        (ulong)(ptr + ptr_offset - currentBufferPtr));
                    byte* newCellPtr = tmpBuffer + (this.m_ptr - currentBufferPtr);
                    Memory.memcpy(
                        newCellPtr + (ptr_offset + delta),
                        ptr + ptr_offset,
                        (ulong)(curlen - (ptr + ptr_offset - this.m_ptr)));
                    Length = tgtlen;
                    this.m_ptr = newCellPtr;
                    Memory.free(buffer);
                    buffer = tmpBuffer;
                    return tmpBuffer + (ptr - currentBufferPtr);
                }
            }
            else
            {
                if (curlen + delta < 0) throw new AccessorResizeException("Accessor target size underflow.");
                Memory.memmove(
                    ptr + ptr_offset,
                    ptr + ptr_offset - delta,
                    (ulong)(Length - (ptr + ptr_offset - delta - this.m_ptr)));
                Length = tgtlen;
                return ptr;
            }
        }
        
        /// <summary>
        /// Dispose the message writer and release the memory resource.
        /// It is the user's responsibility to call this method after finished accessing the message.
        /// </summary>
        public void Dispose()
        {
            Memory.free(buffer);
            buffer = null;
        }
    }
    
}

#pragma warning restore 162,168,649,660,661,1522
