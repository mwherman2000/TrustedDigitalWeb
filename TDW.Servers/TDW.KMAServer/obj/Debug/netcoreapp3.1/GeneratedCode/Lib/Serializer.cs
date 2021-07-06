#pragma warning disable 162,168,649,660,661,1522

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Trinity;
using Trinity.TSL;
using Trinity.TSL.Lib;
namespace TDW.KMAServer
{
    /// <summary>
    /// Provides facilities for serializing data to Json strings.
    /// </summary>
    public class Serializer
    {
        [ThreadStatic]
        static StringBuilder s_stringBuilder;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void s_ensure_string_builder()
        {
            if (s_stringBuilder == null)
                s_stringBuilder = new StringBuilder();
            else
                s_stringBuilder.Clear();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a bool object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(bool value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a long object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(long value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a string object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(string value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a List<string> object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(List<string> value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a KMAComputeHashKeyPairSignatureRequest object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(KMAComputeHashKeyPairSignatureRequest value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a KMAComputePayloadHashRequest object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(KMAComputePayloadHashRequest value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a KMACreateKeyPairRequest object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(KMACreateKeyPairRequest value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a KMAGetBestKeyPairRequest object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(KMAGetBestKeyPairRequest value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a KMAHashKeyPairSignatureResponse object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(KMAHashKeyPairSignatureResponse value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a KMAInitializeMasterKeyVaultRequest object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(KMAInitializeMasterKeyVaultRequest value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a KMAKeyPairResponse object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(KMAKeyPairResponse value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a KMAPayloadHashResponse object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(KMAPayloadHashResponse value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a KMAValidateHashKeyPairSignatureRequest object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(KMAValidateHashKeyPairSignatureRequest value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a KMAValidateHashKeyPairSignatureResponse object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(KMAValidateHashKeyPairSignatureResponse value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a KMAKeyPairType object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(KMAKeyPairType value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        /// <summary>
        /// Serializes a KMAKeyPair object to Json string.
        /// </summary>
        /// <param name="value">The target cell object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(KMAKeyPair cell)
        {
            s_ensure_string_builder();
            s_stringBuilder.Append('{');
            s_stringBuilder.AppendFormat("\"CellId\":{0}", cell.CellId);
            
            {
                
                if (cell.udid != null)
                {
                    
                    s_stringBuilder.Append(',');
                    s_stringBuilder.Append("\"udid\":");
                    ToString_impl(cell.udid, s_stringBuilder, in_json: true);
                    
                }
                
            }
            
            {
                
                if (cell.keyringudid != null)
                {
                    
                    s_stringBuilder.Append(',');
                    s_stringBuilder.Append("\"keyringudid\":");
                    ToString_impl(cell.keyringudid, s_stringBuilder, in_json: true);
                    
                }
                
            }
            
            {
                
                    s_stringBuilder.Append(',');
                    s_stringBuilder.Append("\"keypairtype\":");
                    ToString_impl(cell.keypairtype, s_stringBuilder, in_json: true);
                    
            }
            
            {
                
                if (cell.algorithm != null)
                {
                    
                    s_stringBuilder.Append(',');
                    s_stringBuilder.Append("\"algorithm\":");
                    ToString_impl(cell.algorithm, s_stringBuilder, in_json: true);
                    
                }
                
            }
            
            {
                
                    s_stringBuilder.Append(',');
                    s_stringBuilder.Append("\"keysize\":");
                    ToString_impl(cell.keysize, s_stringBuilder, in_json: true);
                    
            }
            
            {
                
                if (cell.encryptedkeypair64 != null)
                {
                    
                    s_stringBuilder.Append(',');
                    s_stringBuilder.Append("\"encryptedkeypair64\":");
                    ToString_impl(cell.encryptedkeypair64, s_stringBuilder, in_json: true);
                    
                }
                
            }
            
            {
                
                if (cell.publickey != null)
                {
                    
                    s_stringBuilder.Append(',');
                    s_stringBuilder.Append("\"publickey\":");
                    ToString_impl(cell.publickey, s_stringBuilder, in_json: true);
                    
                }
                
            }
            
            s_stringBuilder.Append('}');
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(bool value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                {
                    str_builder.Append(value.ToString().ToLowerInvariant());
                }
                
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(long value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                {
                    str_builder.Append(value);
                }
                
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(string value, StringBuilder str_builder, bool in_json)
        {
            
            if (in_json)
            {
                str_builder.Append(JsonStringProcessor.escape(value));
            }
            else
            {
                str_builder.Append(value);
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(List<string> value, StringBuilder str_builder, bool in_json)
        {
            
            {
                str_builder.Append('[');
                bool first = true;
                foreach (var element in value)
                {
                    if (first)
                    {
                        first = false;
                    }
                    else
                    {
                        str_builder.Append(',');
                    }
                    ToString_impl(element, str_builder, in_json:true);
                }
                str_builder.Append(']');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(KMAComputeHashKeyPairSignatureRequest value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"keypairid\":");
                        
                        ToString_impl(value.keypairid, str_builder, in_json: true);
                        
                }
                
                {
                    
                    if (value.keypairsalt != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"keypairsalt\":");
                        
                        ToString_impl(value.keypairsalt, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.hash64 != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"hash64\":");
                        
                        ToString_impl(value.hash64, str_builder, in_json: true);
                        
                    }
                    
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(KMAComputePayloadHashRequest value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                    if (value.payload64 != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"payload64\":");
                        
                        ToString_impl(value.payload64, str_builder, in_json: true);
                        
                    }
                    
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(KMACreateKeyPairRequest value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                    if (value.keypairsalt != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"keypairsalt\":");
                        
                        ToString_impl(value.keypairsalt, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.keyringudid != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"keyringudid\":");
                        
                        ToString_impl(value.keyringudid, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"keypairtype\":");
                        
                        ToString_impl(value.keypairtype, str_builder, in_json: true);
                        
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(KMAGetBestKeyPairRequest value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                    if (value.keyringudid != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"keyringudid\":");
                        
                        ToString_impl(value.keyringudid, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"keypairtype\":");
                        
                        ToString_impl(value.keypairtype, str_builder, in_json: true);
                        
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(KMAHashKeyPairSignatureResponse value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"rc\":");
                        
                        ToString_impl(value.rc, str_builder, in_json: true);
                        
                }
                
                {
                    
                    if (value.messages != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"messages\":");
                        
                        ToString_impl(value.messages, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.signature64 != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"signature64\":");
                        
                        ToString_impl(value.signature64, str_builder, in_json: true);
                        
                    }
                    
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(KMAInitializeMasterKeyVaultRequest value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                    if (value.reserved != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"reserved\":");
                        
                        ToString_impl(value.reserved, str_builder, in_json: true);
                        
                    }
                    
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(KMAKeyPairResponse value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"id\":");
                        
                        ToString_impl(value.id, str_builder, in_json: true);
                        
                }
                
                {
                    
                    if (value.udid != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"udid\":");
                        
                        ToString_impl(value.udid, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"rc\":");
                        
                        ToString_impl(value.rc, str_builder, in_json: true);
                        
                }
                
                {
                    
                    if (value.messages != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"messages\":");
                        
                        ToString_impl(value.messages, str_builder, in_json: true);
                        
                    }
                    
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(KMAPayloadHashResponse value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"rc\":");
                        
                        ToString_impl(value.rc, str_builder, in_json: true);
                        
                }
                
                {
                    
                    if (value.messages != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"messages\":");
                        
                        ToString_impl(value.messages, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.hash64 != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"hash64\":");
                        
                        ToString_impl(value.hash64, str_builder, in_json: true);
                        
                    }
                    
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(KMAValidateHashKeyPairSignatureRequest value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"keypairid\":");
                        
                        ToString_impl(value.keypairid, str_builder, in_json: true);
                        
                }
                
                {
                    
                    if (value.keypairsalt != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"keypairsalt\":");
                        
                        ToString_impl(value.keypairsalt, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.hash64 != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"hash64\":");
                        
                        ToString_impl(value.hash64, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.signature64 != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"signature64\":");
                        
                        ToString_impl(value.signature64, str_builder, in_json: true);
                        
                    }
                    
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(KMAValidateHashKeyPairSignatureResponse value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"rc\":");
                        
                        ToString_impl(value.rc, str_builder, in_json: true);
                        
                }
                
                {
                    
                    if (value.messages != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"messages\":");
                        
                        ToString_impl(value.messages, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"valid\":");
                        
                        ToString_impl(value.valid, str_builder, in_json: true);
                        
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(KMAKeyPairType value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                if(in_json)
                    str_builder.Append('"');
                
                {
                    str_builder.Append(value);
                }
                
                if(in_json)
                    str_builder.Append('"');
                
            }
            
        }
        
        #region mute
        
        #endregion
    }
}

#pragma warning restore 162,168,649,660,661,1522
