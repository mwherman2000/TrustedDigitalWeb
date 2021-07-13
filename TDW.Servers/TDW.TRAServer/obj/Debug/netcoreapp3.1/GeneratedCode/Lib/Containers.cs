#pragma warning disable 162,168,649,660,661,1522
using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using Trinity.Core.Lib;
using Trinity.TSL;
using Trinity.TSL.Lib;

namespace TDW.TRAServer
{
    
    public unsafe class TRAKeyValuePair_AccessorListAccessor : IEnumerable<TRAKeyValuePair_Accessor>
    {
        internal byte* m_ptr;
        internal long m_cellId;
        internal ResizeFunctionDelegate ResizeFunction;
        internal TRAKeyValuePair_AccessorListAccessor(byte* _CellPtr, ResizeFunctionDelegate func)
        {
            m_ptr = _CellPtr;
            ResizeFunction = func;
            m_ptr += 4;
                    elementAccessor = new TRAKeyValuePair_Accessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.m_ptr = this.ResizeFunction(this.m_ptr-sizeof(int), ptr_offset + substructure_offset +sizeof(int), delta);
                    *(int*)this.m_ptr += delta;
                    this.m_ptr += sizeof(int);
                    return this.m_ptr + substructure_offset;
                });
        }
        internal int length
        {
            get
            {
                return *(int*)(m_ptr - 4);
            }
        }
        TRAKeyValuePair_Accessor elementAccessor;
        
        /// <summary>
        /// Gets the number of elements actually contained in the List. 
        /// </summary>";
        public unsafe int Count
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                byte* endPtr = m_ptr + length;
                int ret = 0;
                while (targetPtr < endPtr)
                {
                    {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
                    ++ret;
                }
                return ret;
                
            }
        }
        /// <summary>
        /// Gets or sets the element at the specified index. 
        /// </summary>
        /// <param name="index">Given index</param>
        /// <returns>Corresponding element at the specified index</returns>";
        public unsafe TRAKeyValuePair_Accessor this[int index]
        {
            get
            {
                
                {
                    
                    {
                        byte* targetPtr = m_ptr;
                        while (index-- > 0)
                        {
                            {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
                        }
                        
                        elementAccessor.m_ptr = targetPtr;
                        
                    }
                    
                    elementAccessor.m_cellId = this.m_cellId;
                    return elementAccessor;
                }
                
            }
            set
            {
                
                {
                    if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                    elementAccessor.m_cellId = this.m_cellId;
                    byte* targetPtr = m_ptr;
                    
                    while (index-- > 0)
                    {
                        {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
                    }
                    
                int offset = (int)(targetPtr - m_ptr);
                byte* oldtargetPtr = targetPtr;
                int oldlength = (int)(targetPtr - oldtargetPtr);
                targetPtr = value.m_ptr;
                int newlength = (int)(targetPtr - value.m_ptr);
                if (newlength != oldlength)
                {
                    if (value.m_cellId != this.m_cellId)
                    {
                        this.m_ptr = this.ResizeFunction(this.m_ptr, offset, newlength - oldlength);
                        Memory.Copy(value.m_ptr, this.m_ptr + offset, newlength);
                    }
                    else
                    {
                        byte[] tmpcell = new byte[newlength];
                        fixed(byte* tmpcellptr = tmpcell)
                        {
                            Memory.Copy(value.m_ptr, tmpcellptr, newlength);
                            this.m_ptr = this.ResizeFunction(this.m_ptr, offset, newlength - oldlength);
                            Memory.Copy(tmpcellptr, this.m_ptr + offset, newlength);
                        }
                    }
                }
                else
                {
                    Memory.Copy(value.m_ptr, oldtargetPtr, oldlength);
                }
                }
                
            }
        }
        /// <summary>
        /// Copies the elements to a new byte array
        /// </summary>
        /// <returns>Elements compactly arranged in a byte array.</returns>
        public unsafe byte[] ToByteArray()
        {
            byte[] ret = new byte[length];
            fixed (byte* retptr = ret)
            {
                Memory.Copy(m_ptr, retptr, length);
                return ret;
            }
        }
        /// <summary>
        /// Performs the specified action on each elements
        /// </summary>
        /// <param name="action">A lambda expression which has one parameter indicates element in List</param>
        public unsafe void ForEach(Action<TRAKeyValuePair_Accessor> action)
        {
            byte* targetPtr = m_ptr;
            byte* endPtr = m_ptr + length;
            
            elementAccessor.m_cellId = this.m_cellId;
            
            while (targetPtr < endPtr)
            {
                
                {
                    elementAccessor.m_ptr = targetPtr;
                    action(elementAccessor);
                    {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
                }
                
            }
        }
        /// <summary>
        /// Performs the specified action on each elements
        /// </summary>
        /// <param name="action">A lambda expression which has two parameters. First indicates element in the List and second the index of this element.</param>
        public unsafe void ForEach(Action<TRAKeyValuePair_Accessor, int> action)
        {
            byte* targetPtr = m_ptr;
            byte* endPtr = m_ptr + length;
            for (int index = 0; targetPtr < endPtr; ++index)
            {
                
                {
                    elementAccessor.m_ptr = targetPtr;
                    action(elementAccessor, index);
                    {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
                }
                
            }
        }
        internal unsafe struct _iterator
        {
            byte* targetPtr;
            byte* endPtr;
            TRAKeyValuePair_AccessorListAccessor target;
            internal _iterator(TRAKeyValuePair_AccessorListAccessor target)
            {
                targetPtr = target.m_ptr;
                endPtr = targetPtr + target.length;
                this.target = target;
            }
            internal bool good()
            {
                return (targetPtr < endPtr);
            }
            internal TRAKeyValuePair_Accessor current()
            {
                
                {
                    target.elementAccessor.m_ptr = targetPtr;
                    return target.elementAccessor;
                }
                
            }
            internal void move_next()
            {
                 
                {
                    {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
                }
                
            }
        }
        public IEnumerator<TRAKeyValuePair_Accessor> GetEnumerator()
        {
            _iterator _it = new _iterator(this);
            while (_it.good())
            {
                yield return _it.current();
                _it.move_next();
            }
        }
        unsafe IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        /// <summary>
        /// Adds an item to the end of the List
        /// </summary>
        /// <param name="element">The object to be added to the end of the List.</param>
        public unsafe void Add(TRAKeyValuePair element)
        {
            byte* targetPtr = null;
            {
                
            {

        if(element.key!= null)
        {
            int strlen_1 = element.key.Length * 2;
            targetPtr += strlen_1+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(element.value!= null)
        {
            int strlen_1 = element.value.Length * 2;
            targetPtr += strlen_1+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            }
            int size = (int)targetPtr;
            this.m_ptr = this.ResizeFunction(this.m_ptr - sizeof(int), *(int*)(this.m_ptr-sizeof(int))+sizeof(int), size);
            targetPtr = this.m_ptr + (*(int*)this.m_ptr)+sizeof(int);
            *(int*)this.m_ptr += size;
            this.m_ptr += sizeof(int);
            
            {

        if(element.key!= null)
        {
            int strlen_1 = element.key.Length * 2;
            *(int*)targetPtr = strlen_1;
            targetPtr += sizeof(int);
            fixed(char* pstr_1 = element.key)
            {
                Memory.Copy(pstr_1, targetPtr, strlen_1);
                targetPtr += strlen_1;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(element.value!= null)
        {
            int strlen_1 = element.value.Length * 2;
            *(int*)targetPtr = strlen_1;
            targetPtr += sizeof(int);
            fixed(char* pstr_1 = element.value)
            {
                Memory.Copy(pstr_1, targetPtr, strlen_1);
                targetPtr += strlen_1;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }
        }
        /// <summary>
        /// Inserts an element into the List at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which item should be inserted.</param>
        /// <param name="element">The object to insert.</param>
        public unsafe void Insert(int index, TRAKeyValuePair element)
        {
            if (index < 0 || index > Count) throw new IndexOutOfRangeException();
            byte* targetPtr = null;
            {
                
            {

        if(element.key!= null)
        {
            int strlen_1 = element.key.Length * 2;
            targetPtr += strlen_1+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(element.value!= null)
        {
            int strlen_1 = element.value.Length * 2;
            targetPtr += strlen_1+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            }
            int size = (int)targetPtr;
            targetPtr = m_ptr;
            
            for (int i = 0; i < index; i++)
            {
                {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
            }
            
            int offset = (int)(targetPtr - m_ptr);
            this.m_ptr = this.ResizeFunction(this.m_ptr - sizeof(int), offset + sizeof(int), size);
            *(int*)this.m_ptr += size;
            this.m_ptr += sizeof(int);
            targetPtr = this.m_ptr + offset;
            
            {

        if(element.key!= null)
        {
            int strlen_1 = element.key.Length * 2;
            *(int*)targetPtr = strlen_1;
            targetPtr += sizeof(int);
            fixed(char* pstr_1 = element.key)
            {
                Memory.Copy(pstr_1, targetPtr, strlen_1);
                targetPtr += strlen_1;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(element.value!= null)
        {
            int strlen_1 = element.value.Length * 2;
            *(int*)targetPtr = strlen_1;
            targetPtr += sizeof(int);
            fixed(char* pstr_1 = element.value)
            {
                Memory.Copy(pstr_1, targetPtr, strlen_1);
                targetPtr += strlen_1;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }
        }
        /// <summary>
        /// Inserts an element into a sorted list.
        /// </summary>
        /// <param name="element">The object to insert.</param>
        /// <param name="comparison"></param>
        public unsafe void Insert(TRAKeyValuePair element, Comparison<TRAKeyValuePair_Accessor> comparison)
        {
            byte* targetPtr = null;
            {
                
            {

        if(element.key!= null)
        {
            int strlen_1 = element.key.Length * 2;
            targetPtr += strlen_1+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(element.value!= null)
        {
            int strlen_1 = element.value.Length * 2;
            targetPtr += strlen_1+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            }
            int size = (int)targetPtr;
            targetPtr = m_ptr;
            byte* endPtr = m_ptr + length;
            while (targetPtr<endPtr)
            {
                
                {
                    elementAccessor.m_ptr = targetPtr + 4;
                    if (comparison(elementAccessor, element)<=0)
                    {
                        {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
                    }
                    else
                    {
                        break;
                    }
                }
                
            }
            int offset = (int)(targetPtr - m_ptr);
            this.m_ptr = this.ResizeFunction(this.m_ptr - sizeof(int), offset + sizeof(int), size);
            *(int*)this.m_ptr += size;
            this.m_ptr += sizeof(int);
            targetPtr = this.m_ptr + offset;
            
            {

        if(element.key!= null)
        {
            int strlen_1 = element.key.Length * 2;
            *(int*)targetPtr = strlen_1;
            targetPtr += sizeof(int);
            fixed(char* pstr_1 = element.key)
            {
                Memory.Copy(pstr_1, targetPtr, strlen_1);
                targetPtr += strlen_1;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(element.value!= null)
        {
            int strlen_1 = element.value.Length * 2;
            *(int*)targetPtr = strlen_1;
            targetPtr += sizeof(int);
            fixed(char* pstr_1 = element.value)
            {
                Memory.Copy(pstr_1, targetPtr, strlen_1);
                targetPtr += strlen_1;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }
        }
        /// <summary>
        /// Removes the element at the specified index of the List.
        /// </summary>
        /// <param name="index">The zero-based index of the element to remove.</param>
        public unsafe void RemoveAt(int index)
        {
            if (index < 0 || index >= Count) throw new IndexOutOfRangeException();
            byte* targetPtr = m_ptr;
            for (int i = 0; i < index; i++)
            {
                {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
            }
            int offset = (int)(targetPtr - m_ptr);
            byte* oldtargetPtr = targetPtr;
            {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
            int size = (int)(oldtargetPtr - targetPtr);
            this.m_ptr = this.ResizeFunction(this.m_ptr - sizeof(int), offset + sizeof(int), size);
            *(int*)this.m_ptr += size;
            this.m_ptr += sizeof(int);
        }
        /// <summary>
        /// Adds the elements of the specified collection to the end of the List
        /// </summary>
        /// <param name="collection">The collection whose elements should be added to the end of the List. The collection itself cannot be null.</param>
        public unsafe void AddRange(List<TRAKeyValuePair> collection)
        {
            if (collection == null) throw new ArgumentNullException("collection is null.");
            TRAKeyValuePair_AccessorListAccessor tcollection = collection;
            int delta = tcollection.length;
            m_ptr = ResizeFunction(m_ptr - 4, *(int*)(m_ptr - 4) + 4, delta);
            Memory.Copy(tcollection.m_ptr, m_ptr + *(int*)m_ptr + 4, delta);
            *(int*)m_ptr += delta;
            this.m_ptr += 4;
        }
        /// <summary>
        /// Adds the elements of the specified collection to the end of the List
        /// </summary>
        /// <param name="collection">The collection whose elements should be added to the end of the List. The collection itself cannot be null.</param>
        public unsafe void AddRange(TRAKeyValuePair_AccessorListAccessor collection)
        {
            if (collection == null) throw new ArgumentNullException("collection is null.");
            int delta = collection.length;
            if (collection.m_cellId != m_cellId)
            {
                m_ptr = ResizeFunction(m_ptr - 4, *(int*)(m_ptr - 4) + 4, delta);
                Memory.Copy(collection.m_ptr, m_ptr + *(int*)m_ptr + 4, delta);
                *(int*)m_ptr += delta;
            }
            else
            {
                byte[] tmpcell = new byte[delta];
                fixed (byte* tmpcellptr = tmpcell)
                {
                    Memory.Copy(collection.m_ptr, tmpcellptr, delta);
                    m_ptr = ResizeFunction(m_ptr - 4, *(int*)(m_ptr - 4) + 4, delta);
                    Memory.Copy(tmpcellptr, m_ptr + *(int*)m_ptr + 4, delta);
                    *(int*)m_ptr += delta;
                }
            }
            this.m_ptr += 4;
        }
        /// <summary>
        /// Removes all elements from the List
        /// </summary>
        public unsafe void Clear()
        {
            int delta = length;
            Memory.memset(m_ptr, 0, (ulong)delta);
            m_ptr = ResizeFunction(m_ptr - 4, 4, -delta);
            *(int*)m_ptr = 0;
            this.m_ptr += 4;
        }
        /// <summary>
        /// Determines whether an element is in the List
        /// </summary>
        /// <param name="item">The object to locate in the List.The value can be null for non-atom types</param>
        /// <returns>true if item is found in the List; otherwise, false.</returns>
        public unsafe bool Contains(TRAKeyValuePair_Accessor item)
        {
            bool ret = false;
            ForEach(x =>
            {
                if (item == x) ret = true;
            });
            return ret;
        }
        /// <summary>
        /// Determines whether the List contains elements that match the conditions defined by the specified predicate.
        /// </summary>
        /// <param name="match">The Predicate delegate that defines the conditions of the elements to search for.</param>
        /// <returns>true if the List contains one or more elements that match the conditions defined by the specified predicate; otherwise, false.</returns>
        public unsafe bool Exists(Predicate<TRAKeyValuePair_Accessor> match)
        {
            bool ret = false;
            ForEach(x =>
            {
                if (match(x)) ret = true;
            });
            return ret;
        }
        
        /// <summary>
        /// Copies the entire List to a compatible one-dimensional array, starting at the beginning of the ptr1 array.
        /// </summary>
        /// <param name="array">The one-dimensional Array that is the destination of the elements copied from List. The Array must have zero-based indexing.</param>
        public unsafe void CopyTo(TRAKeyValuePair[] array)
        {
            if (array == null) throw new ArgumentNullException("array is null.");
            if (array.Length < Count) throw new ArgumentException("The number of elements in the source List is greater than the number of elements that the destination array can contain.");
            ForEach((x, i) => array[i] = x);
        }
        /// <summary>
        /// Copies the entire List to a compatible one-dimensional array, starting at the specified index of the ptr1 array.
        /// </summary>
        /// <param name="array">The one-dimensional Array that is the destination of the elements copied from List. The Array must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
        public unsafe void CopyTo(TRAKeyValuePair[] array, int arrayIndex)
        {
            if (array == null) throw new ArgumentNullException("array is null.");
            if (arrayIndex < 0) throw new ArgumentOutOfRangeException("arrayIndex is less than 0.");
            if (array.Length - arrayIndex < Count) throw new ArgumentException("The number of elements in the source List is greater than the available space from arrayIndex to the end of the destination array.");
            ForEach((x, i) => array[i + arrayIndex] = x);
        }
        /// <summary>
        /// Copies a range of elements from the List to a compatible one-dimensional array, starting at the specified index of the ptr1 array.
        /// </summary>
        /// <param name="index">The zero-based index in the source List at which copying begins.</param>
        /// <param name="array">The one-dimensional Array that is the destination of the elements copied from List. The Array must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>;
        /// <param name="count">The number of elements to copy.</param>
        public unsafe void CopyTo(int index, TRAKeyValuePair[] array, int arrayIndex, int count)
        {
            if (array == null) throw new ArgumentNullException("array is null.");
            if (arrayIndex < 0 || index < 0 || count < 0) throw new ArgumentOutOfRangeException("arrayIndex is less than 0 or index is less than 0 or count is less than 0.");
            if (array.Length - arrayIndex < count) throw new ArgumentException("The number of elements from index to the end of the source List is greater than the available space from arrayIndex to the end of the destination array. ");
            if (index + count > Count) throw new ArgumentException("Source list does not have enough elements to copy.");
            int j = 0;
            for (int i = index; i < index + count; i++)
            {
                array[j + arrayIndex] = this[i];
                ++j;
            }
        }
          
        /// <summary>
        /// Inserts the elements of a collection into the List at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which the new elements should be inserted.</param>
        /// <param name="collection">The collection whose elements should be inserted into the List. The collection itself cannot be null, but it can contain elements that are null, if type T is a reference type.</param>
        public unsafe void InsertRange(int index, List<TRAKeyValuePair> collection)
        {
            if (collection == null) throw new ArgumentNullException("collection is null.");
            if (index < 0) throw new ArgumentOutOfRangeException("index is less than 0.");
            if (index > Count) throw new ArgumentOutOfRangeException("index is greater than Count.");
            TRAKeyValuePair_AccessorListAccessor tmpAccessor = collection;
            byte* targetPtr = m_ptr;
            for (int i = 0; i < index; i++)
            {
                {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
            }
            int offset = (int)(targetPtr - m_ptr);
            m_ptr = ResizeFunction(m_ptr - 4, offset + 4, tmpAccessor.length);
            Memory.Copy(tmpAccessor.m_ptr, m_ptr + offset + 4, tmpAccessor.length);
            *(int*)m_ptr += tmpAccessor.length;
            this.m_ptr += 4;
        }
        /// <summary>
        /// Removes a range of elements from the List.
        /// </summary>
        /// <param name="index">The zero-based starting index of the range of elements to remove.</param>
        /// <param name="count">The number of elements to remove.</param>
        public unsafe void RemoveRange(int index, int count)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index is less than 0.");
            if (index > Count) throw new ArgumentOutOfRangeException("index is greater than Count.");
            if (index + count > Count) throw new ArgumentException("index and count do not denote a valid range of elements in the List.");
            byte* targetPtr = m_ptr;
            for (int i = 0; i < index; i++)
            {
                {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
            }
            int offset = (int)(targetPtr - m_ptr);
            byte* oldtargetPtr = targetPtr;
            for (int i = 0; i < count; i++)
            {
                {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
            }
            int size = (int)(oldtargetPtr - targetPtr);
            m_ptr = ResizeFunction(m_ptr - 4, offset + 4, size);
            *(int*)m_ptr += size;
            this.m_ptr += 4;
        }
        public unsafe static implicit operator List<TRAKeyValuePair> (TRAKeyValuePair_AccessorListAccessor accessor)
        {
            if((object)accessor == null) return null;
            List<TRAKeyValuePair> list = new List<TRAKeyValuePair>();
            accessor.ForEach(element => list.Add(element));
            return list;
        }
        
        public unsafe static implicit operator TRAKeyValuePair_AccessorListAccessor(List<TRAKeyValuePair> field)
        {
            byte* targetPtr = null;
            
{

    targetPtr += sizeof(int);
    if(field!= null)
    {
        for(int iterator_1 = 0;iterator_1<field.Count;++iterator_1)
        {

            {

        if(field[iterator_1].key!= null)
        {
            int strlen_3 = field[iterator_1].key.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(field[iterator_1].value!= null)
        {
            int strlen_3 = field[iterator_1].value.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
        }
    }

}

            byte* tmpcellptr = BufferAllocator.AllocBuffer((int)targetPtr);
            Memory.memset(tmpcellptr, 0, (ulong)targetPtr);
            targetPtr = tmpcellptr;
            
{
byte *storedPtr_1 = targetPtr;

    targetPtr += sizeof(int);
    if(field!= null)
    {
        for(int iterator_1 = 0;iterator_1<field.Count;++iterator_1)
        {

            {

        if(field[iterator_1].key!= null)
        {
            int strlen_3 = field[iterator_1].key.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = field[iterator_1].key)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(field[iterator_1].value!= null)
        {
            int strlen_3 = field[iterator_1].value.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = field[iterator_1].value)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }
        }
    }
*(int*)storedPtr_1 = (int)(targetPtr - storedPtr_1 - 4);

}
TRAKeyValuePair_AccessorListAccessor ret;
            
            ret = new TRAKeyValuePair_AccessorListAccessor(tmpcellptr, null);
            
            return ret;
        }
        
        public static bool operator ==(TRAKeyValuePair_AccessorListAccessor a, TRAKeyValuePair_AccessorListAccessor b)
        {
            if (ReferenceEquals(a, b))
                return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;
            if (a.m_ptr == b.m_ptr) return true;
            if (a.length != b.length) return false;
            return Memory.Compare(a.m_ptr, b.m_ptr, a.length);
        }
        public static bool operator !=(TRAKeyValuePair_AccessorListAccessor a, TRAKeyValuePair_AccessorListAccessor b)
        {
            return !(a == b);
        }
    }
}

namespace TDW.TRAServer
{
    
    public unsafe class TRAKeyValuePair_AccessorListAccessorListAccessor : IEnumerable<TRAKeyValuePair_AccessorListAccessor>
    {
        internal byte* m_ptr;
        internal long m_cellId;
        internal ResizeFunctionDelegate ResizeFunction;
        internal TRAKeyValuePair_AccessorListAccessorListAccessor(byte* _CellPtr, ResizeFunctionDelegate func)
        {
            m_ptr = _CellPtr;
            ResizeFunction = func;
            m_ptr += 4;
                    elementAccessor = new TRAKeyValuePair_AccessorListAccessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.m_ptr = this.ResizeFunction(this.m_ptr-sizeof(int), ptr_offset + substructure_offset +sizeof(int), delta);
                    *(int*)this.m_ptr += delta;
                    this.m_ptr += sizeof(int);
                    return this.m_ptr + substructure_offset;
                });
        }
        internal int length
        {
            get
            {
                return *(int*)(m_ptr - 4);
            }
        }
        TRAKeyValuePair_AccessorListAccessor elementAccessor;
        
        /// <summary>
        /// Gets the number of elements actually contained in the List. 
        /// </summary>";
        public unsafe int Count
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                byte* endPtr = m_ptr + length;
                int ret = 0;
                while (targetPtr < endPtr)
                {
                    targetPtr += *(int*)targetPtr + sizeof(int);
                    ++ret;
                }
                return ret;
                
            }
        }
        /// <summary>
        /// Gets or sets the element at the specified index. 
        /// </summary>
        /// <param name="index">Given index</param>
        /// <returns>Corresponding element at the specified index</returns>";
        public unsafe TRAKeyValuePair_AccessorListAccessor this[int index]
        {
            get
            {
                
                {
                    
                    {
                        byte* targetPtr = m_ptr;
                        while (index-- > 0)
                        {
                            targetPtr += *(int*)targetPtr + sizeof(int);
                        }
                        
                        elementAccessor.m_ptr = targetPtr + 4;
                        
                    }
                    
                    elementAccessor.m_cellId = this.m_cellId;
                    return elementAccessor;
                }
                
            }
            set
            {
                
                {
                    if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                    elementAccessor.m_cellId = this.m_cellId;
                    byte* targetPtr = m_ptr;
                    
                    while (index-- > 0)
                    {
                        targetPtr += *(int*)targetPtr + sizeof(int);
                    }
                    
                int length = *(int*)(value.m_ptr - 4);
                int oldlength = *(int*)targetPtr;
                if (value.m_cellId != elementAccessor.m_cellId)
                {
                    //if not in the same Cell
                    elementAccessor.m_ptr = elementAccessor.ResizeFunction(targetPtr, 0, length - oldlength);
                    Memory.Copy(value.m_ptr - 4, elementAccessor.m_ptr, length + 4);
                }
                else
                {
                    byte[] tmpcell = new byte[length + 4];
                    fixed (byte* tmpcellptr = tmpcell)
                    {                        
                        Memory.Copy(value.m_ptr - 4, tmpcellptr, length + 4);
                        elementAccessor.m_ptr = elementAccessor.ResizeFunction(targetPtr, 0, length - oldlength);
                        Memory.Copy(tmpcellptr, elementAccessor.m_ptr, length + 4);
                    }
                }

                }
                
            }
        }
        /// <summary>
        /// Copies the elements to a new byte array
        /// </summary>
        /// <returns>Elements compactly arranged in a byte array.</returns>
        public unsafe byte[] ToByteArray()
        {
            byte[] ret = new byte[length];
            fixed (byte* retptr = ret)
            {
                Memory.Copy(m_ptr, retptr, length);
                return ret;
            }
        }
        /// <summary>
        /// Performs the specified action on each elements
        /// </summary>
        /// <param name="action">A lambda expression which has one parameter indicates element in List</param>
        public unsafe void ForEach(Action<TRAKeyValuePair_AccessorListAccessor> action)
        {
            byte* targetPtr = m_ptr;
            byte* endPtr = m_ptr + length;
            
            elementAccessor.m_cellId = this.m_cellId;
            
            while (targetPtr < endPtr)
            {
                
                {
                    elementAccessor.m_ptr = targetPtr + 4;
                    action(elementAccessor);
                    targetPtr += *(int*)targetPtr + sizeof(int);
                }
                
            }
        }
        /// <summary>
        /// Performs the specified action on each elements
        /// </summary>
        /// <param name="action">A lambda expression which has two parameters. First indicates element in the List and second the index of this element.</param>
        public unsafe void ForEach(Action<TRAKeyValuePair_AccessorListAccessor, int> action)
        {
            byte* targetPtr = m_ptr;
            byte* endPtr = m_ptr + length;
            for (int index = 0; targetPtr < endPtr; ++index)
            {
                
                {
                    elementAccessor.m_ptr = targetPtr + 4;
                    action(elementAccessor, index);
                    targetPtr += *(int*)targetPtr + sizeof(int);
                }
                
            }
        }
        internal unsafe struct _iterator
        {
            byte* targetPtr;
            byte* endPtr;
            TRAKeyValuePair_AccessorListAccessorListAccessor target;
            internal _iterator(TRAKeyValuePair_AccessorListAccessorListAccessor target)
            {
                targetPtr = target.m_ptr;
                endPtr = targetPtr + target.length;
                this.target = target;
            }
            internal bool good()
            {
                return (targetPtr < endPtr);
            }
            internal TRAKeyValuePair_AccessorListAccessor current()
            {
                
                {
                    target.elementAccessor.m_ptr = targetPtr + 4;
                    return target.elementAccessor;
                }
                
            }
            internal void move_next()
            {
                 
                {
                    targetPtr += *(int*)targetPtr + sizeof(int);
                }
                
            }
        }
        public IEnumerator<TRAKeyValuePair_AccessorListAccessor> GetEnumerator()
        {
            _iterator _it = new _iterator(this);
            while (_it.good())
            {
                yield return _it.current();
                _it.move_next();
            }
        }
        unsafe IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        /// <summary>
        /// Adds an item to the end of the List
        /// </summary>
        /// <param name="element">The object to be added to the end of the List.</param>
        public unsafe void Add(List<TRAKeyValuePair> element)
        {
            byte* targetPtr = null;
            {
                
{

    targetPtr += sizeof(int);
    if(element!= null)
    {
        for(int iterator_0 = 0;iterator_0<element.Count;++iterator_0)
        {

            {

        if(element[iterator_0].key!= null)
        {
            int strlen_2 = element[iterator_0].key.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(element[iterator_0].value!= null)
        {
            int strlen_2 = element[iterator_0].value.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
        }
    }

}

            }
            int size = (int)targetPtr;
            this.m_ptr = this.ResizeFunction(this.m_ptr - sizeof(int), *(int*)(this.m_ptr-sizeof(int))+sizeof(int), size);
            targetPtr = this.m_ptr + (*(int*)this.m_ptr)+sizeof(int);
            *(int*)this.m_ptr += size;
            this.m_ptr += sizeof(int);
            
{
byte *storedPtr_0 = targetPtr;

    targetPtr += sizeof(int);
    if(element!= null)
    {
        for(int iterator_0 = 0;iterator_0<element.Count;++iterator_0)
        {

            {

        if(element[iterator_0].key!= null)
        {
            int strlen_2 = element[iterator_0].key.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = element[iterator_0].key)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(element[iterator_0].value!= null)
        {
            int strlen_2 = element[iterator_0].value.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = element[iterator_0].value)
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
    }
*(int*)storedPtr_0 = (int)(targetPtr - storedPtr_0 - 4);

}

        }
        /// <summary>
        /// Inserts an element into the List at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which item should be inserted.</param>
        /// <param name="element">The object to insert.</param>
        public unsafe void Insert(int index, List<TRAKeyValuePair> element)
        {
            if (index < 0 || index > Count) throw new IndexOutOfRangeException();
            byte* targetPtr = null;
            {
                
{

    targetPtr += sizeof(int);
    if(element!= null)
    {
        for(int iterator_0 = 0;iterator_0<element.Count;++iterator_0)
        {

            {

        if(element[iterator_0].key!= null)
        {
            int strlen_2 = element[iterator_0].key.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(element[iterator_0].value!= null)
        {
            int strlen_2 = element[iterator_0].value.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
        }
    }

}

            }
            int size = (int)targetPtr;
            targetPtr = m_ptr;
            
            for (int i = 0; i < index; i++)
            {
                targetPtr += *(int*)targetPtr + sizeof(int);
            }
            
            int offset = (int)(targetPtr - m_ptr);
            this.m_ptr = this.ResizeFunction(this.m_ptr - sizeof(int), offset + sizeof(int), size);
            *(int*)this.m_ptr += size;
            this.m_ptr += sizeof(int);
            targetPtr = this.m_ptr + offset;
            
{
byte *storedPtr_0 = targetPtr;

    targetPtr += sizeof(int);
    if(element!= null)
    {
        for(int iterator_0 = 0;iterator_0<element.Count;++iterator_0)
        {

            {

        if(element[iterator_0].key!= null)
        {
            int strlen_2 = element[iterator_0].key.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = element[iterator_0].key)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(element[iterator_0].value!= null)
        {
            int strlen_2 = element[iterator_0].value.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = element[iterator_0].value)
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
    }
*(int*)storedPtr_0 = (int)(targetPtr - storedPtr_0 - 4);

}

        }
        /// <summary>
        /// Inserts an element into a sorted list.
        /// </summary>
        /// <param name="element">The object to insert.</param>
        /// <param name="comparison"></param>
        public unsafe void Insert(List<TRAKeyValuePair> element, Comparison<TRAKeyValuePair_AccessorListAccessor> comparison)
        {
            byte* targetPtr = null;
            {
                
{

    targetPtr += sizeof(int);
    if(element!= null)
    {
        for(int iterator_0 = 0;iterator_0<element.Count;++iterator_0)
        {

            {

        if(element[iterator_0].key!= null)
        {
            int strlen_2 = element[iterator_0].key.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(element[iterator_0].value!= null)
        {
            int strlen_2 = element[iterator_0].value.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
        }
    }

}

            }
            int size = (int)targetPtr;
            targetPtr = m_ptr;
            byte* endPtr = m_ptr + length;
            while (targetPtr<endPtr)
            {
                
            }
            int offset = (int)(targetPtr - m_ptr);
            this.m_ptr = this.ResizeFunction(this.m_ptr - sizeof(int), offset + sizeof(int), size);
            *(int*)this.m_ptr += size;
            this.m_ptr += sizeof(int);
            targetPtr = this.m_ptr + offset;
            
{
byte *storedPtr_0 = targetPtr;

    targetPtr += sizeof(int);
    if(element!= null)
    {
        for(int iterator_0 = 0;iterator_0<element.Count;++iterator_0)
        {

            {

        if(element[iterator_0].key!= null)
        {
            int strlen_2 = element[iterator_0].key.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = element[iterator_0].key)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(element[iterator_0].value!= null)
        {
            int strlen_2 = element[iterator_0].value.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = element[iterator_0].value)
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
    }
*(int*)storedPtr_0 = (int)(targetPtr - storedPtr_0 - 4);

}

        }
        /// <summary>
        /// Removes the element at the specified index of the List.
        /// </summary>
        /// <param name="index">The zero-based index of the element to remove.</param>
        public unsafe void RemoveAt(int index)
        {
            if (index < 0 || index >= Count) throw new IndexOutOfRangeException();
            byte* targetPtr = m_ptr;
            for (int i = 0; i < index; i++)
            {
                targetPtr += *(int*)targetPtr + sizeof(int);
            }
            int offset = (int)(targetPtr - m_ptr);
            byte* oldtargetPtr = targetPtr;
            targetPtr += *(int*)targetPtr + sizeof(int);
            int size = (int)(oldtargetPtr - targetPtr);
            this.m_ptr = this.ResizeFunction(this.m_ptr - sizeof(int), offset + sizeof(int), size);
            *(int*)this.m_ptr += size;
            this.m_ptr += sizeof(int);
        }
        /// <summary>
        /// Adds the elements of the specified collection to the end of the List
        /// </summary>
        /// <param name="collection">The collection whose elements should be added to the end of the List. The collection itself cannot be null.</param>
        public unsafe void AddRange(List<List<TRAKeyValuePair>> collection)
        {
            if (collection == null) throw new ArgumentNullException("collection is null.");
            TRAKeyValuePair_AccessorListAccessorListAccessor tcollection = collection;
            int delta = tcollection.length;
            m_ptr = ResizeFunction(m_ptr - 4, *(int*)(m_ptr - 4) + 4, delta);
            Memory.Copy(tcollection.m_ptr, m_ptr + *(int*)m_ptr + 4, delta);
            *(int*)m_ptr += delta;
            this.m_ptr += 4;
        }
        /// <summary>
        /// Adds the elements of the specified collection to the end of the List
        /// </summary>
        /// <param name="collection">The collection whose elements should be added to the end of the List. The collection itself cannot be null.</param>
        public unsafe void AddRange(TRAKeyValuePair_AccessorListAccessorListAccessor collection)
        {
            if (collection == null) throw new ArgumentNullException("collection is null.");
            int delta = collection.length;
            if (collection.m_cellId != m_cellId)
            {
                m_ptr = ResizeFunction(m_ptr - 4, *(int*)(m_ptr - 4) + 4, delta);
                Memory.Copy(collection.m_ptr, m_ptr + *(int*)m_ptr + 4, delta);
                *(int*)m_ptr += delta;
            }
            else
            {
                byte[] tmpcell = new byte[delta];
                fixed (byte* tmpcellptr = tmpcell)
                {
                    Memory.Copy(collection.m_ptr, tmpcellptr, delta);
                    m_ptr = ResizeFunction(m_ptr - 4, *(int*)(m_ptr - 4) + 4, delta);
                    Memory.Copy(tmpcellptr, m_ptr + *(int*)m_ptr + 4, delta);
                    *(int*)m_ptr += delta;
                }
            }
            this.m_ptr += 4;
        }
        /// <summary>
        /// Removes all elements from the List
        /// </summary>
        public unsafe void Clear()
        {
            int delta = length;
            Memory.memset(m_ptr, 0, (ulong)delta);
            m_ptr = ResizeFunction(m_ptr - 4, 4, -delta);
            *(int*)m_ptr = 0;
            this.m_ptr += 4;
        }
        /// <summary>
        /// Determines whether an element is in the List
        /// </summary>
        /// <param name="item">The object to locate in the List.The value can be null for non-atom types</param>
        /// <returns>true if item is found in the List; otherwise, false.</returns>
        public unsafe bool Contains(TRAKeyValuePair_AccessorListAccessor item)
        {
            bool ret = false;
            ForEach(x =>
            {
                if (item == x) ret = true;
            });
            return ret;
        }
        /// <summary>
        /// Determines whether the List contains elements that match the conditions defined by the specified predicate.
        /// </summary>
        /// <param name="match">The Predicate delegate that defines the conditions of the elements to search for.</param>
        /// <returns>true if the List contains one or more elements that match the conditions defined by the specified predicate; otherwise, false.</returns>
        public unsafe bool Exists(Predicate<TRAKeyValuePair_AccessorListAccessor> match)
        {
            bool ret = false;
            ForEach(x =>
            {
                if (match(x)) ret = true;
            });
            return ret;
        }
        
        /// <summary>
        /// Copies the entire List to a compatible one-dimensional array, starting at the beginning of the ptr1 array.
        /// </summary>
        /// <param name="array">The one-dimensional Array that is the destination of the elements copied from List. The Array must have zero-based indexing.</param>
        public unsafe void CopyTo(List<TRAKeyValuePair>[] array)
        {
            if (array == null) throw new ArgumentNullException("array is null.");
            if (array.Length < Count) throw new ArgumentException("The number of elements in the source List is greater than the number of elements that the destination array can contain.");
            ForEach((x, i) => array[i] = x);
        }
        /// <summary>
        /// Copies the entire List to a compatible one-dimensional array, starting at the specified index of the ptr1 array.
        /// </summary>
        /// <param name="array">The one-dimensional Array that is the destination of the elements copied from List. The Array must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
        public unsafe void CopyTo(List<TRAKeyValuePair>[] array, int arrayIndex)
        {
            if (array == null) throw new ArgumentNullException("array is null.");
            if (arrayIndex < 0) throw new ArgumentOutOfRangeException("arrayIndex is less than 0.");
            if (array.Length - arrayIndex < Count) throw new ArgumentException("The number of elements in the source List is greater than the available space from arrayIndex to the end of the destination array.");
            ForEach((x, i) => array[i + arrayIndex] = x);
        }
        /// <summary>
        /// Copies a range of elements from the List to a compatible one-dimensional array, starting at the specified index of the ptr1 array.
        /// </summary>
        /// <param name="index">The zero-based index in the source List at which copying begins.</param>
        /// <param name="array">The one-dimensional Array that is the destination of the elements copied from List. The Array must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>;
        /// <param name="count">The number of elements to copy.</param>
        public unsafe void CopyTo(int index, List<TRAKeyValuePair>[] array, int arrayIndex, int count)
        {
            if (array == null) throw new ArgumentNullException("array is null.");
            if (arrayIndex < 0 || index < 0 || count < 0) throw new ArgumentOutOfRangeException("arrayIndex is less than 0 or index is less than 0 or count is less than 0.");
            if (array.Length - arrayIndex < count) throw new ArgumentException("The number of elements from index to the end of the source List is greater than the available space from arrayIndex to the end of the destination array. ");
            if (index + count > Count) throw new ArgumentException("Source list does not have enough elements to copy.");
            int j = 0;
            for (int i = index; i < index + count; i++)
            {
                array[j + arrayIndex] = this[i];
                ++j;
            }
        }
          
        /// <summary>
        /// Inserts the elements of a collection into the List at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which the new elements should be inserted.</param>
        /// <param name="collection">The collection whose elements should be inserted into the List. The collection itself cannot be null, but it can contain elements that are null, if type T is a reference type.</param>
        public unsafe void InsertRange(int index, List<List<TRAKeyValuePair>> collection)
        {
            if (collection == null) throw new ArgumentNullException("collection is null.");
            if (index < 0) throw new ArgumentOutOfRangeException("index is less than 0.");
            if (index > Count) throw new ArgumentOutOfRangeException("index is greater than Count.");
            TRAKeyValuePair_AccessorListAccessorListAccessor tmpAccessor = collection;
            byte* targetPtr = m_ptr;
            for (int i = 0; i < index; i++)
            {
                targetPtr += *(int*)targetPtr + sizeof(int);
            }
            int offset = (int)(targetPtr - m_ptr);
            m_ptr = ResizeFunction(m_ptr - 4, offset + 4, tmpAccessor.length);
            Memory.Copy(tmpAccessor.m_ptr, m_ptr + offset + 4, tmpAccessor.length);
            *(int*)m_ptr += tmpAccessor.length;
            this.m_ptr += 4;
        }
        /// <summary>
        /// Removes a range of elements from the List.
        /// </summary>
        /// <param name="index">The zero-based starting index of the range of elements to remove.</param>
        /// <param name="count">The number of elements to remove.</param>
        public unsafe void RemoveRange(int index, int count)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index is less than 0.");
            if (index > Count) throw new ArgumentOutOfRangeException("index is greater than Count.");
            if (index + count > Count) throw new ArgumentException("index and count do not denote a valid range of elements in the List.");
            byte* targetPtr = m_ptr;
            for (int i = 0; i < index; i++)
            {
                targetPtr += *(int*)targetPtr + sizeof(int);
            }
            int offset = (int)(targetPtr - m_ptr);
            byte* oldtargetPtr = targetPtr;
            for (int i = 0; i < count; i++)
            {
                targetPtr += *(int*)targetPtr + sizeof(int);
            }
            int size = (int)(oldtargetPtr - targetPtr);
            m_ptr = ResizeFunction(m_ptr - 4, offset + 4, size);
            *(int*)m_ptr += size;
            this.m_ptr += 4;
        }
        public unsafe static implicit operator List<List<TRAKeyValuePair>> (TRAKeyValuePair_AccessorListAccessorListAccessor accessor)
        {
            if((object)accessor == null) return null;
            List<List<TRAKeyValuePair>> list = new List<List<TRAKeyValuePair>>();
            accessor.ForEach(element => list.Add(element));
            return list;
        }
        
        public unsafe static implicit operator TRAKeyValuePair_AccessorListAccessorListAccessor(List<List<TRAKeyValuePair>> field)
        {
            byte* targetPtr = null;
            
{

    targetPtr += sizeof(int);
    if(field!= null)
    {
        for(int iterator_1 = 0;iterator_1<field.Count;++iterator_1)
        {

{

    targetPtr += sizeof(int);
    if(field[iterator_1]!= null)
    {
        for(int iterator_2 = 0;iterator_2<field[iterator_1].Count;++iterator_2)
        {

            {

        if(field[iterator_1][iterator_2].key!= null)
        {
            int strlen_4 = field[iterator_1][iterator_2].key.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(field[iterator_1][iterator_2].value!= null)
        {
            int strlen_4 = field[iterator_1][iterator_2].value.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
        }
    }

}

        }
    }

}

            byte* tmpcellptr = BufferAllocator.AllocBuffer((int)targetPtr);
            Memory.memset(tmpcellptr, 0, (ulong)targetPtr);
            targetPtr = tmpcellptr;
            
{
byte *storedPtr_1 = targetPtr;

    targetPtr += sizeof(int);
    if(field!= null)
    {
        for(int iterator_1 = 0;iterator_1<field.Count;++iterator_1)
        {

{
byte *storedPtr_2 = targetPtr;

    targetPtr += sizeof(int);
    if(field[iterator_1]!= null)
    {
        for(int iterator_2 = 0;iterator_2<field[iterator_1].Count;++iterator_2)
        {

            {

        if(field[iterator_1][iterator_2].key!= null)
        {
            int strlen_4 = field[iterator_1][iterator_2].key.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = field[iterator_1][iterator_2].key)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(field[iterator_1][iterator_2].value!= null)
        {
            int strlen_4 = field[iterator_1][iterator_2].value.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = field[iterator_1][iterator_2].value)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }
        }
    }
*(int*)storedPtr_2 = (int)(targetPtr - storedPtr_2 - 4);

}

        }
    }
*(int*)storedPtr_1 = (int)(targetPtr - storedPtr_1 - 4);

}
TRAKeyValuePair_AccessorListAccessorListAccessor ret;
            
            ret = new TRAKeyValuePair_AccessorListAccessorListAccessor(tmpcellptr, null);
            
            return ret;
        }
        
        public static bool operator ==(TRAKeyValuePair_AccessorListAccessorListAccessor a, TRAKeyValuePair_AccessorListAccessorListAccessor b)
        {
            if (ReferenceEquals(a, b))
                return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;
            if (a.m_ptr == b.m_ptr) return true;
            if (a.length != b.length) return false;
            return Memory.Compare(a.m_ptr, b.m_ptr, a.length);
        }
        public static bool operator !=(TRAKeyValuePair_AccessorListAccessorListAccessor a, TRAKeyValuePair_AccessorListAccessorListAccessor b)
        {
            return !(a == b);
        }
    }
}

namespace TDW.TRAServer
{
    
    public unsafe class StringAccessorListAccessor : IEnumerable<StringAccessor>
    {
        internal byte* m_ptr;
        internal long m_cellId;
        internal ResizeFunctionDelegate ResizeFunction;
        internal StringAccessorListAccessor(byte* _CellPtr, ResizeFunctionDelegate func)
        {
            m_ptr = _CellPtr;
            ResizeFunction = func;
            m_ptr += 4;
                    elementAccessor = new StringAccessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.m_ptr = this.ResizeFunction(this.m_ptr-sizeof(int), ptr_offset + substructure_offset +sizeof(int), delta);
                    *(int*)this.m_ptr += delta;
                    this.m_ptr += sizeof(int);
                    return this.m_ptr + substructure_offset;
                });
        }
        internal int length
        {
            get
            {
                return *(int*)(m_ptr - 4);
            }
        }
        StringAccessor elementAccessor;
        
        /// <summary>
        /// Gets the number of elements actually contained in the List. 
        /// </summary>";
        public unsafe int Count
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                byte* endPtr = m_ptr + length;
                int ret = 0;
                while (targetPtr < endPtr)
                {
                    targetPtr += *(int*)targetPtr + sizeof(int);
                    ++ret;
                }
                return ret;
                
            }
        }
        /// <summary>
        /// Gets or sets the element at the specified index. 
        /// </summary>
        /// <param name="index">Given index</param>
        /// <returns>Corresponding element at the specified index</returns>";
        public unsafe StringAccessor this[int index]
        {
            get
            {
                
                {
                    
                    {
                        byte* targetPtr = m_ptr;
                        while (index-- > 0)
                        {
                            targetPtr += *(int*)targetPtr + sizeof(int);
                        }
                        
                        elementAccessor.m_ptr = targetPtr + 4;
                        
                    }
                    
                    elementAccessor.m_cellId = this.m_cellId;
                    return elementAccessor;
                }
                
            }
            set
            {
                
                {
                    if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                    elementAccessor.m_cellId = this.m_cellId;
                    byte* targetPtr = m_ptr;
                    
                    while (index-- > 0)
                    {
                        targetPtr += *(int*)targetPtr + sizeof(int);
                    }
                    
                int length = *(int*)(value.m_ptr - 4);
                int oldlength = *(int*)targetPtr;
                if (value.m_cellId != elementAccessor.m_cellId)
                {
                    //if not in the same Cell
                    elementAccessor.m_ptr = elementAccessor.ResizeFunction(targetPtr, 0, length - oldlength);
                    Memory.Copy(value.m_ptr - 4, elementAccessor.m_ptr, length + 4);
                }
                else
                {
                    byte[] tmpcell = new byte[length + 4];
                    fixed (byte* tmpcellptr = tmpcell)
                    {                        
                        Memory.Copy(value.m_ptr - 4, tmpcellptr, length + 4);
                        elementAccessor.m_ptr = elementAccessor.ResizeFunction(targetPtr, 0, length - oldlength);
                        Memory.Copy(tmpcellptr, elementAccessor.m_ptr, length + 4);
                    }
                }

                }
                
            }
        }
        /// <summary>
        /// Copies the elements to a new byte array
        /// </summary>
        /// <returns>Elements compactly arranged in a byte array.</returns>
        public unsafe byte[] ToByteArray()
        {
            byte[] ret = new byte[length];
            fixed (byte* retptr = ret)
            {
                Memory.Copy(m_ptr, retptr, length);
                return ret;
            }
        }
        /// <summary>
        /// Performs the specified action on each elements
        /// </summary>
        /// <param name="action">A lambda expression which has one parameter indicates element in List</param>
        public unsafe void ForEach(Action<StringAccessor> action)
        {
            byte* targetPtr = m_ptr;
            byte* endPtr = m_ptr + length;
            
            elementAccessor.m_cellId = this.m_cellId;
            
            while (targetPtr < endPtr)
            {
                
                {
                    elementAccessor.m_ptr = targetPtr + 4;
                    action(elementAccessor);
                    targetPtr += *(int*)targetPtr + sizeof(int);
                }
                
            }
        }
        /// <summary>
        /// Performs the specified action on each elements
        /// </summary>
        /// <param name="action">A lambda expression which has two parameters. First indicates element in the List and second the index of this element.</param>
        public unsafe void ForEach(Action<StringAccessor, int> action)
        {
            byte* targetPtr = m_ptr;
            byte* endPtr = m_ptr + length;
            for (int index = 0; targetPtr < endPtr; ++index)
            {
                
                {
                    elementAccessor.m_ptr = targetPtr + 4;
                    action(elementAccessor, index);
                    targetPtr += *(int*)targetPtr + sizeof(int);
                }
                
            }
        }
        internal unsafe struct _iterator
        {
            byte* targetPtr;
            byte* endPtr;
            StringAccessorListAccessor target;
            internal _iterator(StringAccessorListAccessor target)
            {
                targetPtr = target.m_ptr;
                endPtr = targetPtr + target.length;
                this.target = target;
            }
            internal bool good()
            {
                return (targetPtr < endPtr);
            }
            internal StringAccessor current()
            {
                
                {
                    target.elementAccessor.m_ptr = targetPtr + 4;
                    return target.elementAccessor;
                }
                
            }
            internal void move_next()
            {
                 
                {
                    targetPtr += *(int*)targetPtr + sizeof(int);
                }
                
            }
        }
        public IEnumerator<StringAccessor> GetEnumerator()
        {
            _iterator _it = new _iterator(this);
            while (_it.good())
            {
                yield return _it.current();
                _it.move_next();
            }
        }
        unsafe IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        /// <summary>
        /// Adds an item to the end of the List
        /// </summary>
        /// <param name="element">The object to be added to the end of the List.</param>
        public unsafe void Add(string element)
        {
            byte* targetPtr = null;
            {
                
        if(element!= null)
        {
            int strlen_0 = element.Length * 2;
            targetPtr += strlen_0+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            int size = (int)targetPtr;
            this.m_ptr = this.ResizeFunction(this.m_ptr - sizeof(int), *(int*)(this.m_ptr-sizeof(int))+sizeof(int), size);
            targetPtr = this.m_ptr + (*(int*)this.m_ptr)+sizeof(int);
            *(int*)this.m_ptr += size;
            this.m_ptr += sizeof(int);
            
        if(element!= null)
        {
            int strlen_0 = element.Length * 2;
            *(int*)targetPtr = strlen_0;
            targetPtr += sizeof(int);
            fixed(char* pstr_0 = element)
            {
                Memory.Copy(pstr_0, targetPtr, strlen_0);
                targetPtr += strlen_0;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        }
        /// <summary>
        /// Inserts an element into the List at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which item should be inserted.</param>
        /// <param name="element">The object to insert.</param>
        public unsafe void Insert(int index, string element)
        {
            if (index < 0 || index > Count) throw new IndexOutOfRangeException();
            byte* targetPtr = null;
            {
                
        if(element!= null)
        {
            int strlen_0 = element.Length * 2;
            targetPtr += strlen_0+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            int size = (int)targetPtr;
            targetPtr = m_ptr;
            
            for (int i = 0; i < index; i++)
            {
                targetPtr += *(int*)targetPtr + sizeof(int);
            }
            
            int offset = (int)(targetPtr - m_ptr);
            this.m_ptr = this.ResizeFunction(this.m_ptr - sizeof(int), offset + sizeof(int), size);
            *(int*)this.m_ptr += size;
            this.m_ptr += sizeof(int);
            targetPtr = this.m_ptr + offset;
            
        if(element!= null)
        {
            int strlen_0 = element.Length * 2;
            *(int*)targetPtr = strlen_0;
            targetPtr += sizeof(int);
            fixed(char* pstr_0 = element)
            {
                Memory.Copy(pstr_0, targetPtr, strlen_0);
                targetPtr += strlen_0;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        }
        /// <summary>
        /// Inserts an element into a sorted list.
        /// </summary>
        /// <param name="element">The object to insert.</param>
        /// <param name="comparison"></param>
        public unsafe void Insert(string element, Comparison<StringAccessor> comparison)
        {
            byte* targetPtr = null;
            {
                
        if(element!= null)
        {
            int strlen_0 = element.Length * 2;
            targetPtr += strlen_0+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            int size = (int)targetPtr;
            targetPtr = m_ptr;
            byte* endPtr = m_ptr + length;
            while (targetPtr<endPtr)
            {
                
            }
            int offset = (int)(targetPtr - m_ptr);
            this.m_ptr = this.ResizeFunction(this.m_ptr - sizeof(int), offset + sizeof(int), size);
            *(int*)this.m_ptr += size;
            this.m_ptr += sizeof(int);
            targetPtr = this.m_ptr + offset;
            
        if(element!= null)
        {
            int strlen_0 = element.Length * 2;
            *(int*)targetPtr = strlen_0;
            targetPtr += sizeof(int);
            fixed(char* pstr_0 = element)
            {
                Memory.Copy(pstr_0, targetPtr, strlen_0);
                targetPtr += strlen_0;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        }
        /// <summary>
        /// Removes the element at the specified index of the List.
        /// </summary>
        /// <param name="index">The zero-based index of the element to remove.</param>
        public unsafe void RemoveAt(int index)
        {
            if (index < 0 || index >= Count) throw new IndexOutOfRangeException();
            byte* targetPtr = m_ptr;
            for (int i = 0; i < index; i++)
            {
                targetPtr += *(int*)targetPtr + sizeof(int);
            }
            int offset = (int)(targetPtr - m_ptr);
            byte* oldtargetPtr = targetPtr;
            targetPtr += *(int*)targetPtr + sizeof(int);
            int size = (int)(oldtargetPtr - targetPtr);
            this.m_ptr = this.ResizeFunction(this.m_ptr - sizeof(int), offset + sizeof(int), size);
            *(int*)this.m_ptr += size;
            this.m_ptr += sizeof(int);
        }
        /// <summary>
        /// Adds the elements of the specified collection to the end of the List
        /// </summary>
        /// <param name="collection">The collection whose elements should be added to the end of the List. The collection itself cannot be null.</param>
        public unsafe void AddRange(List<string> collection)
        {
            if (collection == null) throw new ArgumentNullException("collection is null.");
            StringAccessorListAccessor tcollection = collection;
            int delta = tcollection.length;
            m_ptr = ResizeFunction(m_ptr - 4, *(int*)(m_ptr - 4) + 4, delta);
            Memory.Copy(tcollection.m_ptr, m_ptr + *(int*)m_ptr + 4, delta);
            *(int*)m_ptr += delta;
            this.m_ptr += 4;
        }
        /// <summary>
        /// Adds the elements of the specified collection to the end of the List
        /// </summary>
        /// <param name="collection">The collection whose elements should be added to the end of the List. The collection itself cannot be null.</param>
        public unsafe void AddRange(StringAccessorListAccessor collection)
        {
            if (collection == null) throw new ArgumentNullException("collection is null.");
            int delta = collection.length;
            if (collection.m_cellId != m_cellId)
            {
                m_ptr = ResizeFunction(m_ptr - 4, *(int*)(m_ptr - 4) + 4, delta);
                Memory.Copy(collection.m_ptr, m_ptr + *(int*)m_ptr + 4, delta);
                *(int*)m_ptr += delta;
            }
            else
            {
                byte[] tmpcell = new byte[delta];
                fixed (byte* tmpcellptr = tmpcell)
                {
                    Memory.Copy(collection.m_ptr, tmpcellptr, delta);
                    m_ptr = ResizeFunction(m_ptr - 4, *(int*)(m_ptr - 4) + 4, delta);
                    Memory.Copy(tmpcellptr, m_ptr + *(int*)m_ptr + 4, delta);
                    *(int*)m_ptr += delta;
                }
            }
            this.m_ptr += 4;
        }
        /// <summary>
        /// Removes all elements from the List
        /// </summary>
        public unsafe void Clear()
        {
            int delta = length;
            Memory.memset(m_ptr, 0, (ulong)delta);
            m_ptr = ResizeFunction(m_ptr - 4, 4, -delta);
            *(int*)m_ptr = 0;
            this.m_ptr += 4;
        }
        /// <summary>
        /// Determines whether an element is in the List
        /// </summary>
        /// <param name="item">The object to locate in the List.The value can be null for non-atom types</param>
        /// <returns>true if item is found in the List; otherwise, false.</returns>
        public unsafe bool Contains(StringAccessor item)
        {
            bool ret = false;
            ForEach(x =>
            {
                if (item == x) ret = true;
            });
            return ret;
        }
        /// <summary>
        /// Determines whether the List contains elements that match the conditions defined by the specified predicate.
        /// </summary>
        /// <param name="match">The Predicate delegate that defines the conditions of the elements to search for.</param>
        /// <returns>true if the List contains one or more elements that match the conditions defined by the specified predicate; otherwise, false.</returns>
        public unsafe bool Exists(Predicate<StringAccessor> match)
        {
            bool ret = false;
            ForEach(x =>
            {
                if (match(x)) ret = true;
            });
            return ret;
        }
        
        /// <summary>
        /// Copies the entire List to a compatible one-dimensional array, starting at the beginning of the ptr1 array.
        /// </summary>
        /// <param name="array">The one-dimensional Array that is the destination of the elements copied from List. The Array must have zero-based indexing.</param>
        public unsafe void CopyTo(string[] array)
        {
            if (array == null) throw new ArgumentNullException("array is null.");
            if (array.Length < Count) throw new ArgumentException("The number of elements in the source List is greater than the number of elements that the destination array can contain.");
            ForEach((x, i) => array[i] = x);
        }
        /// <summary>
        /// Copies the entire List to a compatible one-dimensional array, starting at the specified index of the ptr1 array.
        /// </summary>
        /// <param name="array">The one-dimensional Array that is the destination of the elements copied from List. The Array must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
        public unsafe void CopyTo(string[] array, int arrayIndex)
        {
            if (array == null) throw new ArgumentNullException("array is null.");
            if (arrayIndex < 0) throw new ArgumentOutOfRangeException("arrayIndex is less than 0.");
            if (array.Length - arrayIndex < Count) throw new ArgumentException("The number of elements in the source List is greater than the available space from arrayIndex to the end of the destination array.");
            ForEach((x, i) => array[i + arrayIndex] = x);
        }
        /// <summary>
        /// Copies a range of elements from the List to a compatible one-dimensional array, starting at the specified index of the ptr1 array.
        /// </summary>
        /// <param name="index">The zero-based index in the source List at which copying begins.</param>
        /// <param name="array">The one-dimensional Array that is the destination of the elements copied from List. The Array must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>;
        /// <param name="count">The number of elements to copy.</param>
        public unsafe void CopyTo(int index, string[] array, int arrayIndex, int count)
        {
            if (array == null) throw new ArgumentNullException("array is null.");
            if (arrayIndex < 0 || index < 0 || count < 0) throw new ArgumentOutOfRangeException("arrayIndex is less than 0 or index is less than 0 or count is less than 0.");
            if (array.Length - arrayIndex < count) throw new ArgumentException("The number of elements from index to the end of the source List is greater than the available space from arrayIndex to the end of the destination array. ");
            if (index + count > Count) throw new ArgumentException("Source list does not have enough elements to copy.");
            int j = 0;
            for (int i = index; i < index + count; i++)
            {
                array[j + arrayIndex] = this[i];
                ++j;
            }
        }
          
        /// <summary>
        /// Inserts the elements of a collection into the List at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which the new elements should be inserted.</param>
        /// <param name="collection">The collection whose elements should be inserted into the List. The collection itself cannot be null, but it can contain elements that are null, if type T is a reference type.</param>
        public unsafe void InsertRange(int index, List<string> collection)
        {
            if (collection == null) throw new ArgumentNullException("collection is null.");
            if (index < 0) throw new ArgumentOutOfRangeException("index is less than 0.");
            if (index > Count) throw new ArgumentOutOfRangeException("index is greater than Count.");
            StringAccessorListAccessor tmpAccessor = collection;
            byte* targetPtr = m_ptr;
            for (int i = 0; i < index; i++)
            {
                targetPtr += *(int*)targetPtr + sizeof(int);
            }
            int offset = (int)(targetPtr - m_ptr);
            m_ptr = ResizeFunction(m_ptr - 4, offset + 4, tmpAccessor.length);
            Memory.Copy(tmpAccessor.m_ptr, m_ptr + offset + 4, tmpAccessor.length);
            *(int*)m_ptr += tmpAccessor.length;
            this.m_ptr += 4;
        }
        /// <summary>
        /// Removes a range of elements from the List.
        /// </summary>
        /// <param name="index">The zero-based starting index of the range of elements to remove.</param>
        /// <param name="count">The number of elements to remove.</param>
        public unsafe void RemoveRange(int index, int count)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index is less than 0.");
            if (index > Count) throw new ArgumentOutOfRangeException("index is greater than Count.");
            if (index + count > Count) throw new ArgumentException("index and count do not denote a valid range of elements in the List.");
            byte* targetPtr = m_ptr;
            for (int i = 0; i < index; i++)
            {
                targetPtr += *(int*)targetPtr + sizeof(int);
            }
            int offset = (int)(targetPtr - m_ptr);
            byte* oldtargetPtr = targetPtr;
            for (int i = 0; i < count; i++)
            {
                targetPtr += *(int*)targetPtr + sizeof(int);
            }
            int size = (int)(oldtargetPtr - targetPtr);
            m_ptr = ResizeFunction(m_ptr - 4, offset + 4, size);
            *(int*)m_ptr += size;
            this.m_ptr += 4;
        }
        public unsafe static implicit operator List<string> (StringAccessorListAccessor accessor)
        {
            if((object)accessor == null) return null;
            List<string> list = new List<string>();
            accessor.ForEach(element => list.Add(element));
            return list;
        }
        
        public unsafe static implicit operator StringAccessorListAccessor(List<string> field)
        {
            byte* targetPtr = null;
            
{

    targetPtr += sizeof(int);
    if(field!= null)
    {
        for(int iterator_1 = 0;iterator_1<field.Count;++iterator_1)
        {

        if(field[iterator_1]!= null)
        {
            int strlen_2 = field[iterator_1].Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        }
    }

}

            byte* tmpcellptr = BufferAllocator.AllocBuffer((int)targetPtr);
            Memory.memset(tmpcellptr, 0, (ulong)targetPtr);
            targetPtr = tmpcellptr;
            
{
byte *storedPtr_1 = targetPtr;

    targetPtr += sizeof(int);
    if(field!= null)
    {
        for(int iterator_1 = 0;iterator_1<field.Count;++iterator_1)
        {

        if(field[iterator_1]!= null)
        {
            int strlen_2 = field[iterator_1].Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = field[iterator_1])
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
*(int*)storedPtr_1 = (int)(targetPtr - storedPtr_1 - 4);

}
StringAccessorListAccessor ret;
            
            ret = new StringAccessorListAccessor(tmpcellptr, null);
            
            return ret;
        }
        
        public static bool operator ==(StringAccessorListAccessor a, StringAccessorListAccessor b)
        {
            if (ReferenceEquals(a, b))
                return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;
            if (a.m_ptr == b.m_ptr) return true;
            if (a.length != b.length) return false;
            return Memory.Compare(a.m_ptr, b.m_ptr, a.length);
        }
        public static bool operator !=(StringAccessorListAccessor a, StringAccessorListAccessor b)
        {
            return !(a == b);
        }
    }
}

namespace TDW.TRAServer
{
    
    public unsafe class TRAClaim_AccessorListAccessor : IEnumerable<TRAClaim_Accessor>
    {
        internal byte* m_ptr;
        internal long m_cellId;
        internal ResizeFunctionDelegate ResizeFunction;
        internal TRAClaim_AccessorListAccessor(byte* _CellPtr, ResizeFunctionDelegate func)
        {
            m_ptr = _CellPtr;
            ResizeFunction = func;
            m_ptr += 4;
                    elementAccessor = new TRAClaim_Accessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.m_ptr = this.ResizeFunction(this.m_ptr-sizeof(int), ptr_offset + substructure_offset +sizeof(int), delta);
                    *(int*)this.m_ptr += delta;
                    this.m_ptr += sizeof(int);
                    return this.m_ptr + substructure_offset;
                });
        }
        internal int length
        {
            get
            {
                return *(int*)(m_ptr - 4);
            }
        }
        TRAClaim_Accessor elementAccessor;
        
        /// <summary>
        /// Gets the number of elements actually contained in the List. 
        /// </summary>";
        public unsafe int Count
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                byte* endPtr = m_ptr + length;
                int ret = 0;
                while (targetPtr < endPtr)
                {
                    {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_1 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_1 + 0) & 0x02)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_1 + 0) & 0x04)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
}
                    ++ret;
                }
                return ret;
                
            }
        }
        /// <summary>
        /// Gets or sets the element at the specified index. 
        /// </summary>
        /// <param name="index">Given index</param>
        /// <returns>Corresponding element at the specified index</returns>";
        public unsafe TRAClaim_Accessor this[int index]
        {
            get
            {
                
                {
                    
                    {
                        byte* targetPtr = m_ptr;
                        while (index-- > 0)
                        {
                            {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_1 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_1 + 0) & 0x02)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_1 + 0) & 0x04)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
}
                        }
                        
                        elementAccessor.m_ptr = targetPtr;
                        
                    }
                    
                    elementAccessor.m_cellId = this.m_cellId;
                    return elementAccessor;
                }
                
            }
            set
            {
                
                {
                    if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                    elementAccessor.m_cellId = this.m_cellId;
                    byte* targetPtr = m_ptr;
                    
                    while (index-- > 0)
                    {
                        {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_1 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_1 + 0) & 0x02)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_1 + 0) & 0x04)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
}
                    }
                    
                int offset = (int)(targetPtr - m_ptr);
                byte* oldtargetPtr = targetPtr;
                int oldlength = (int)(targetPtr - oldtargetPtr);
                targetPtr = value.m_ptr;
                int newlength = (int)(targetPtr - value.m_ptr);
                if (newlength != oldlength)
                {
                    if (value.m_cellId != this.m_cellId)
                    {
                        this.m_ptr = this.ResizeFunction(this.m_ptr, offset, newlength - oldlength);
                        Memory.Copy(value.m_ptr, this.m_ptr + offset, newlength);
                    }
                    else
                    {
                        byte[] tmpcell = new byte[newlength];
                        fixed(byte* tmpcellptr = tmpcell)
                        {
                            Memory.Copy(value.m_ptr, tmpcellptr, newlength);
                            this.m_ptr = this.ResizeFunction(this.m_ptr, offset, newlength - oldlength);
                            Memory.Copy(tmpcellptr, this.m_ptr + offset, newlength);
                        }
                    }
                }
                else
                {
                    Memory.Copy(value.m_ptr, oldtargetPtr, oldlength);
                }
                }
                
            }
        }
        /// <summary>
        /// Copies the elements to a new byte array
        /// </summary>
        /// <returns>Elements compactly arranged in a byte array.</returns>
        public unsafe byte[] ToByteArray()
        {
            byte[] ret = new byte[length];
            fixed (byte* retptr = ret)
            {
                Memory.Copy(m_ptr, retptr, length);
                return ret;
            }
        }
        /// <summary>
        /// Performs the specified action on each elements
        /// </summary>
        /// <param name="action">A lambda expression which has one parameter indicates element in List</param>
        public unsafe void ForEach(Action<TRAClaim_Accessor> action)
        {
            byte* targetPtr = m_ptr;
            byte* endPtr = m_ptr + length;
            
            elementAccessor.m_cellId = this.m_cellId;
            
            while (targetPtr < endPtr)
            {
                
                {
                    elementAccessor.m_ptr = targetPtr;
                    action(elementAccessor);
                    {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_1 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_1 + 0) & 0x02)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_1 + 0) & 0x04)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
}
                }
                
            }
        }
        /// <summary>
        /// Performs the specified action on each elements
        /// </summary>
        /// <param name="action">A lambda expression which has two parameters. First indicates element in the List and second the index of this element.</param>
        public unsafe void ForEach(Action<TRAClaim_Accessor, int> action)
        {
            byte* targetPtr = m_ptr;
            byte* endPtr = m_ptr + length;
            for (int index = 0; targetPtr < endPtr; ++index)
            {
                
                {
                    elementAccessor.m_ptr = targetPtr;
                    action(elementAccessor, index);
                    {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_1 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_1 + 0) & 0x02)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_1 + 0) & 0x04)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
}
                }
                
            }
        }
        internal unsafe struct _iterator
        {
            byte* targetPtr;
            byte* endPtr;
            TRAClaim_AccessorListAccessor target;
            internal _iterator(TRAClaim_AccessorListAccessor target)
            {
                targetPtr = target.m_ptr;
                endPtr = targetPtr + target.length;
                this.target = target;
            }
            internal bool good()
            {
                return (targetPtr < endPtr);
            }
            internal TRAClaim_Accessor current()
            {
                
                {
                    target.elementAccessor.m_ptr = targetPtr;
                    return target.elementAccessor;
                }
                
            }
            internal void move_next()
            {
                 
                {
                    {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_1 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_1 + 0) & 0x02)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_1 + 0) & 0x04)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
}
                }
                
            }
        }
        public IEnumerator<TRAClaim_Accessor> GetEnumerator()
        {
            _iterator _it = new _iterator(this);
            while (_it.good())
            {
                yield return _it.current();
                _it.move_next();
            }
        }
        unsafe IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        /// <summary>
        /// Adds an item to the end of the List
        /// </summary>
        /// <param name="element">The object to be added to the end of the List.</param>
        public unsafe void Add(TRAClaim element)
        {
            byte* targetPtr = null;
            {
                
            {
            targetPtr += 1;

        if(element.key!= null)
        {
            int strlen_1 = element.key.Length * 2;
            targetPtr += strlen_1+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            if( element.value!= null)
            {

        if(element.value!= null)
        {
            int strlen_1 = element.value.Length * 2;
            targetPtr += strlen_1+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            if( element.attribute!= null)
            {

{

    targetPtr += sizeof(int);
    if(element.attribute!= null)
    {
        for(int iterator_1 = 0;iterator_1<element.attribute.Count;++iterator_1)
        {

            {

        if(element.attribute[iterator_1].key!= null)
        {
            int strlen_3 = element.attribute[iterator_1].key.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(element.attribute[iterator_1].value!= null)
        {
            int strlen_3 = element.attribute[iterator_1].value.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
        }
    }

}

            }
            if( element.attributes!= null)
            {

{

    targetPtr += sizeof(int);
    if(element.attributes!= null)
    {
        for(int iterator_1 = 0;iterator_1<element.attributes.Count;++iterator_1)
        {

{

    targetPtr += sizeof(int);
    if(element.attributes[iterator_1]!= null)
    {
        for(int iterator_2 = 0;iterator_2<element.attributes[iterator_1].Count;++iterator_2)
        {

            {

        if(element.attributes[iterator_1][iterator_2].key!= null)
        {
            int strlen_4 = element.attributes[iterator_1][iterator_2].key.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(element.attributes[iterator_1][iterator_2].value!= null)
        {
            int strlen_4 = element.attributes[iterator_1][iterator_2].value.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
        }
    }

}

        }
    }

}

            }

            }
            }
            int size = (int)targetPtr;
            this.m_ptr = this.ResizeFunction(this.m_ptr - sizeof(int), *(int*)(this.m_ptr-sizeof(int))+sizeof(int), size);
            targetPtr = this.m_ptr + (*(int*)this.m_ptr)+sizeof(int);
            *(int*)this.m_ptr += size;
            this.m_ptr += sizeof(int);
            
            {
            byte* optheader_0 = targetPtr;
            *(optheader_0 + 0) = 0x00;            targetPtr += 1;

        if(element.key!= null)
        {
            int strlen_1 = element.key.Length * 2;
            *(int*)targetPtr = strlen_1;
            targetPtr += sizeof(int);
            fixed(char* pstr_1 = element.key)
            {
                Memory.Copy(pstr_1, targetPtr, strlen_1);
                targetPtr += strlen_1;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            if( element.value!= null)
            {

        if(element.value!= null)
        {
            int strlen_1 = element.value.Length * 2;
            *(int*)targetPtr = strlen_1;
            targetPtr += sizeof(int);
            fixed(char* pstr_1 = element.value)
            {
                Memory.Copy(pstr_1, targetPtr, strlen_1);
                targetPtr += strlen_1;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
*(optheader_0 + 0) |= 0x01;
            }
            if( element.attribute!= null)
            {

{
byte *storedPtr_1 = targetPtr;

    targetPtr += sizeof(int);
    if(element.attribute!= null)
    {
        for(int iterator_1 = 0;iterator_1<element.attribute.Count;++iterator_1)
        {

            {

        if(element.attribute[iterator_1].key!= null)
        {
            int strlen_3 = element.attribute[iterator_1].key.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = element.attribute[iterator_1].key)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(element.attribute[iterator_1].value!= null)
        {
            int strlen_3 = element.attribute[iterator_1].value.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = element.attribute[iterator_1].value)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }
        }
    }
*(int*)storedPtr_1 = (int)(targetPtr - storedPtr_1 - 4);

}
*(optheader_0 + 0) |= 0x02;
            }
            if( element.attributes!= null)
            {

{
byte *storedPtr_1 = targetPtr;

    targetPtr += sizeof(int);
    if(element.attributes!= null)
    {
        for(int iterator_1 = 0;iterator_1<element.attributes.Count;++iterator_1)
        {

{
byte *storedPtr_2 = targetPtr;

    targetPtr += sizeof(int);
    if(element.attributes[iterator_1]!= null)
    {
        for(int iterator_2 = 0;iterator_2<element.attributes[iterator_1].Count;++iterator_2)
        {

            {

        if(element.attributes[iterator_1][iterator_2].key!= null)
        {
            int strlen_4 = element.attributes[iterator_1][iterator_2].key.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = element.attributes[iterator_1][iterator_2].key)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(element.attributes[iterator_1][iterator_2].value!= null)
        {
            int strlen_4 = element.attributes[iterator_1][iterator_2].value.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = element.attributes[iterator_1][iterator_2].value)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }
        }
    }
*(int*)storedPtr_2 = (int)(targetPtr - storedPtr_2 - 4);

}

        }
    }
*(int*)storedPtr_1 = (int)(targetPtr - storedPtr_1 - 4);

}
*(optheader_0 + 0) |= 0x04;
            }

            }
        }
        /// <summary>
        /// Inserts an element into the List at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which item should be inserted.</param>
        /// <param name="element">The object to insert.</param>
        public unsafe void Insert(int index, TRAClaim element)
        {
            if (index < 0 || index > Count) throw new IndexOutOfRangeException();
            byte* targetPtr = null;
            {
                
            {
            targetPtr += 1;

        if(element.key!= null)
        {
            int strlen_1 = element.key.Length * 2;
            targetPtr += strlen_1+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            if( element.value!= null)
            {

        if(element.value!= null)
        {
            int strlen_1 = element.value.Length * 2;
            targetPtr += strlen_1+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            if( element.attribute!= null)
            {

{

    targetPtr += sizeof(int);
    if(element.attribute!= null)
    {
        for(int iterator_1 = 0;iterator_1<element.attribute.Count;++iterator_1)
        {

            {

        if(element.attribute[iterator_1].key!= null)
        {
            int strlen_3 = element.attribute[iterator_1].key.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(element.attribute[iterator_1].value!= null)
        {
            int strlen_3 = element.attribute[iterator_1].value.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
        }
    }

}

            }
            if( element.attributes!= null)
            {

{

    targetPtr += sizeof(int);
    if(element.attributes!= null)
    {
        for(int iterator_1 = 0;iterator_1<element.attributes.Count;++iterator_1)
        {

{

    targetPtr += sizeof(int);
    if(element.attributes[iterator_1]!= null)
    {
        for(int iterator_2 = 0;iterator_2<element.attributes[iterator_1].Count;++iterator_2)
        {

            {

        if(element.attributes[iterator_1][iterator_2].key!= null)
        {
            int strlen_4 = element.attributes[iterator_1][iterator_2].key.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(element.attributes[iterator_1][iterator_2].value!= null)
        {
            int strlen_4 = element.attributes[iterator_1][iterator_2].value.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
        }
    }

}

        }
    }

}

            }

            }
            }
            int size = (int)targetPtr;
            targetPtr = m_ptr;
            
            for (int i = 0; i < index; i++)
            {
                {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_1 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_1 + 0) & 0x02)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_1 + 0) & 0x04)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
}
            }
            
            int offset = (int)(targetPtr - m_ptr);
            this.m_ptr = this.ResizeFunction(this.m_ptr - sizeof(int), offset + sizeof(int), size);
            *(int*)this.m_ptr += size;
            this.m_ptr += sizeof(int);
            targetPtr = this.m_ptr + offset;
            
            {
            byte* optheader_0 = targetPtr;
            *(optheader_0 + 0) = 0x00;            targetPtr += 1;

        if(element.key!= null)
        {
            int strlen_1 = element.key.Length * 2;
            *(int*)targetPtr = strlen_1;
            targetPtr += sizeof(int);
            fixed(char* pstr_1 = element.key)
            {
                Memory.Copy(pstr_1, targetPtr, strlen_1);
                targetPtr += strlen_1;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            if( element.value!= null)
            {

        if(element.value!= null)
        {
            int strlen_1 = element.value.Length * 2;
            *(int*)targetPtr = strlen_1;
            targetPtr += sizeof(int);
            fixed(char* pstr_1 = element.value)
            {
                Memory.Copy(pstr_1, targetPtr, strlen_1);
                targetPtr += strlen_1;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
*(optheader_0 + 0) |= 0x01;
            }
            if( element.attribute!= null)
            {

{
byte *storedPtr_1 = targetPtr;

    targetPtr += sizeof(int);
    if(element.attribute!= null)
    {
        for(int iterator_1 = 0;iterator_1<element.attribute.Count;++iterator_1)
        {

            {

        if(element.attribute[iterator_1].key!= null)
        {
            int strlen_3 = element.attribute[iterator_1].key.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = element.attribute[iterator_1].key)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(element.attribute[iterator_1].value!= null)
        {
            int strlen_3 = element.attribute[iterator_1].value.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = element.attribute[iterator_1].value)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }
        }
    }
*(int*)storedPtr_1 = (int)(targetPtr - storedPtr_1 - 4);

}
*(optheader_0 + 0) |= 0x02;
            }
            if( element.attributes!= null)
            {

{
byte *storedPtr_1 = targetPtr;

    targetPtr += sizeof(int);
    if(element.attributes!= null)
    {
        for(int iterator_1 = 0;iterator_1<element.attributes.Count;++iterator_1)
        {

{
byte *storedPtr_2 = targetPtr;

    targetPtr += sizeof(int);
    if(element.attributes[iterator_1]!= null)
    {
        for(int iterator_2 = 0;iterator_2<element.attributes[iterator_1].Count;++iterator_2)
        {

            {

        if(element.attributes[iterator_1][iterator_2].key!= null)
        {
            int strlen_4 = element.attributes[iterator_1][iterator_2].key.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = element.attributes[iterator_1][iterator_2].key)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(element.attributes[iterator_1][iterator_2].value!= null)
        {
            int strlen_4 = element.attributes[iterator_1][iterator_2].value.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = element.attributes[iterator_1][iterator_2].value)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }
        }
    }
*(int*)storedPtr_2 = (int)(targetPtr - storedPtr_2 - 4);

}

        }
    }
*(int*)storedPtr_1 = (int)(targetPtr - storedPtr_1 - 4);

}
*(optheader_0 + 0) |= 0x04;
            }

            }
        }
        /// <summary>
        /// Inserts an element into a sorted list.
        /// </summary>
        /// <param name="element">The object to insert.</param>
        /// <param name="comparison"></param>
        public unsafe void Insert(TRAClaim element, Comparison<TRAClaim_Accessor> comparison)
        {
            byte* targetPtr = null;
            {
                
            {
            targetPtr += 1;

        if(element.key!= null)
        {
            int strlen_1 = element.key.Length * 2;
            targetPtr += strlen_1+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            if( element.value!= null)
            {

        if(element.value!= null)
        {
            int strlen_1 = element.value.Length * 2;
            targetPtr += strlen_1+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            if( element.attribute!= null)
            {

{

    targetPtr += sizeof(int);
    if(element.attribute!= null)
    {
        for(int iterator_1 = 0;iterator_1<element.attribute.Count;++iterator_1)
        {

            {

        if(element.attribute[iterator_1].key!= null)
        {
            int strlen_3 = element.attribute[iterator_1].key.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(element.attribute[iterator_1].value!= null)
        {
            int strlen_3 = element.attribute[iterator_1].value.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
        }
    }

}

            }
            if( element.attributes!= null)
            {

{

    targetPtr += sizeof(int);
    if(element.attributes!= null)
    {
        for(int iterator_1 = 0;iterator_1<element.attributes.Count;++iterator_1)
        {

{

    targetPtr += sizeof(int);
    if(element.attributes[iterator_1]!= null)
    {
        for(int iterator_2 = 0;iterator_2<element.attributes[iterator_1].Count;++iterator_2)
        {

            {

        if(element.attributes[iterator_1][iterator_2].key!= null)
        {
            int strlen_4 = element.attributes[iterator_1][iterator_2].key.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(element.attributes[iterator_1][iterator_2].value!= null)
        {
            int strlen_4 = element.attributes[iterator_1][iterator_2].value.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
        }
    }

}

        }
    }

}

            }

            }
            }
            int size = (int)targetPtr;
            targetPtr = m_ptr;
            byte* endPtr = m_ptr + length;
            while (targetPtr<endPtr)
            {
                
                {
                    elementAccessor.m_ptr = targetPtr + 4;
                    if (comparison(elementAccessor, element)<=0)
                    {
                        {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_1 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_1 + 0) & 0x02)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_1 + 0) & 0x04)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
}
                    }
                    else
                    {
                        break;
                    }
                }
                
            }
            int offset = (int)(targetPtr - m_ptr);
            this.m_ptr = this.ResizeFunction(this.m_ptr - sizeof(int), offset + sizeof(int), size);
            *(int*)this.m_ptr += size;
            this.m_ptr += sizeof(int);
            targetPtr = this.m_ptr + offset;
            
            {
            byte* optheader_0 = targetPtr;
            *(optheader_0 + 0) = 0x00;            targetPtr += 1;

        if(element.key!= null)
        {
            int strlen_1 = element.key.Length * 2;
            *(int*)targetPtr = strlen_1;
            targetPtr += sizeof(int);
            fixed(char* pstr_1 = element.key)
            {
                Memory.Copy(pstr_1, targetPtr, strlen_1);
                targetPtr += strlen_1;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            if( element.value!= null)
            {

        if(element.value!= null)
        {
            int strlen_1 = element.value.Length * 2;
            *(int*)targetPtr = strlen_1;
            targetPtr += sizeof(int);
            fixed(char* pstr_1 = element.value)
            {
                Memory.Copy(pstr_1, targetPtr, strlen_1);
                targetPtr += strlen_1;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
*(optheader_0 + 0) |= 0x01;
            }
            if( element.attribute!= null)
            {

{
byte *storedPtr_1 = targetPtr;

    targetPtr += sizeof(int);
    if(element.attribute!= null)
    {
        for(int iterator_1 = 0;iterator_1<element.attribute.Count;++iterator_1)
        {

            {

        if(element.attribute[iterator_1].key!= null)
        {
            int strlen_3 = element.attribute[iterator_1].key.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = element.attribute[iterator_1].key)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(element.attribute[iterator_1].value!= null)
        {
            int strlen_3 = element.attribute[iterator_1].value.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = element.attribute[iterator_1].value)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }
        }
    }
*(int*)storedPtr_1 = (int)(targetPtr - storedPtr_1 - 4);

}
*(optheader_0 + 0) |= 0x02;
            }
            if( element.attributes!= null)
            {

{
byte *storedPtr_1 = targetPtr;

    targetPtr += sizeof(int);
    if(element.attributes!= null)
    {
        for(int iterator_1 = 0;iterator_1<element.attributes.Count;++iterator_1)
        {

{
byte *storedPtr_2 = targetPtr;

    targetPtr += sizeof(int);
    if(element.attributes[iterator_1]!= null)
    {
        for(int iterator_2 = 0;iterator_2<element.attributes[iterator_1].Count;++iterator_2)
        {

            {

        if(element.attributes[iterator_1][iterator_2].key!= null)
        {
            int strlen_4 = element.attributes[iterator_1][iterator_2].key.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = element.attributes[iterator_1][iterator_2].key)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(element.attributes[iterator_1][iterator_2].value!= null)
        {
            int strlen_4 = element.attributes[iterator_1][iterator_2].value.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = element.attributes[iterator_1][iterator_2].value)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }
        }
    }
*(int*)storedPtr_2 = (int)(targetPtr - storedPtr_2 - 4);

}

        }
    }
*(int*)storedPtr_1 = (int)(targetPtr - storedPtr_1 - 4);

}
*(optheader_0 + 0) |= 0x04;
            }

            }
        }
        /// <summary>
        /// Removes the element at the specified index of the List.
        /// </summary>
        /// <param name="index">The zero-based index of the element to remove.</param>
        public unsafe void RemoveAt(int index)
        {
            if (index < 0 || index >= Count) throw new IndexOutOfRangeException();
            byte* targetPtr = m_ptr;
            for (int i = 0; i < index; i++)
            {
                {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_1 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_1 + 0) & 0x02)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_1 + 0) & 0x04)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
}
            }
            int offset = (int)(targetPtr - m_ptr);
            byte* oldtargetPtr = targetPtr;
            {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_1 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_1 + 0) & 0x02)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_1 + 0) & 0x04)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
}
            int size = (int)(oldtargetPtr - targetPtr);
            this.m_ptr = this.ResizeFunction(this.m_ptr - sizeof(int), offset + sizeof(int), size);
            *(int*)this.m_ptr += size;
            this.m_ptr += sizeof(int);
        }
        /// <summary>
        /// Adds the elements of the specified collection to the end of the List
        /// </summary>
        /// <param name="collection">The collection whose elements should be added to the end of the List. The collection itself cannot be null.</param>
        public unsafe void AddRange(List<TRAClaim> collection)
        {
            if (collection == null) throw new ArgumentNullException("collection is null.");
            TRAClaim_AccessorListAccessor tcollection = collection;
            int delta = tcollection.length;
            m_ptr = ResizeFunction(m_ptr - 4, *(int*)(m_ptr - 4) + 4, delta);
            Memory.Copy(tcollection.m_ptr, m_ptr + *(int*)m_ptr + 4, delta);
            *(int*)m_ptr += delta;
            this.m_ptr += 4;
        }
        /// <summary>
        /// Adds the elements of the specified collection to the end of the List
        /// </summary>
        /// <param name="collection">The collection whose elements should be added to the end of the List. The collection itself cannot be null.</param>
        public unsafe void AddRange(TRAClaim_AccessorListAccessor collection)
        {
            if (collection == null) throw new ArgumentNullException("collection is null.");
            int delta = collection.length;
            if (collection.m_cellId != m_cellId)
            {
                m_ptr = ResizeFunction(m_ptr - 4, *(int*)(m_ptr - 4) + 4, delta);
                Memory.Copy(collection.m_ptr, m_ptr + *(int*)m_ptr + 4, delta);
                *(int*)m_ptr += delta;
            }
            else
            {
                byte[] tmpcell = new byte[delta];
                fixed (byte* tmpcellptr = tmpcell)
                {
                    Memory.Copy(collection.m_ptr, tmpcellptr, delta);
                    m_ptr = ResizeFunction(m_ptr - 4, *(int*)(m_ptr - 4) + 4, delta);
                    Memory.Copy(tmpcellptr, m_ptr + *(int*)m_ptr + 4, delta);
                    *(int*)m_ptr += delta;
                }
            }
            this.m_ptr += 4;
        }
        /// <summary>
        /// Removes all elements from the List
        /// </summary>
        public unsafe void Clear()
        {
            int delta = length;
            Memory.memset(m_ptr, 0, (ulong)delta);
            m_ptr = ResizeFunction(m_ptr - 4, 4, -delta);
            *(int*)m_ptr = 0;
            this.m_ptr += 4;
        }
        /// <summary>
        /// Determines whether an element is in the List
        /// </summary>
        /// <param name="item">The object to locate in the List.The value can be null for non-atom types</param>
        /// <returns>true if item is found in the List; otherwise, false.</returns>
        public unsafe bool Contains(TRAClaim_Accessor item)
        {
            bool ret = false;
            ForEach(x =>
            {
                if (item == x) ret = true;
            });
            return ret;
        }
        /// <summary>
        /// Determines whether the List contains elements that match the conditions defined by the specified predicate.
        /// </summary>
        /// <param name="match">The Predicate delegate that defines the conditions of the elements to search for.</param>
        /// <returns>true if the List contains one or more elements that match the conditions defined by the specified predicate; otherwise, false.</returns>
        public unsafe bool Exists(Predicate<TRAClaim_Accessor> match)
        {
            bool ret = false;
            ForEach(x =>
            {
                if (match(x)) ret = true;
            });
            return ret;
        }
        
        /// <summary>
        /// Copies the entire List to a compatible one-dimensional array, starting at the beginning of the ptr1 array.
        /// </summary>
        /// <param name="array">The one-dimensional Array that is the destination of the elements copied from List. The Array must have zero-based indexing.</param>
        public unsafe void CopyTo(TRAClaim[] array)
        {
            if (array == null) throw new ArgumentNullException("array is null.");
            if (array.Length < Count) throw new ArgumentException("The number of elements in the source List is greater than the number of elements that the destination array can contain.");
            ForEach((x, i) => array[i] = x);
        }
        /// <summary>
        /// Copies the entire List to a compatible one-dimensional array, starting at the specified index of the ptr1 array.
        /// </summary>
        /// <param name="array">The one-dimensional Array that is the destination of the elements copied from List. The Array must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
        public unsafe void CopyTo(TRAClaim[] array, int arrayIndex)
        {
            if (array == null) throw new ArgumentNullException("array is null.");
            if (arrayIndex < 0) throw new ArgumentOutOfRangeException("arrayIndex is less than 0.");
            if (array.Length - arrayIndex < Count) throw new ArgumentException("The number of elements in the source List is greater than the available space from arrayIndex to the end of the destination array.");
            ForEach((x, i) => array[i + arrayIndex] = x);
        }
        /// <summary>
        /// Copies a range of elements from the List to a compatible one-dimensional array, starting at the specified index of the ptr1 array.
        /// </summary>
        /// <param name="index">The zero-based index in the source List at which copying begins.</param>
        /// <param name="array">The one-dimensional Array that is the destination of the elements copied from List. The Array must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>;
        /// <param name="count">The number of elements to copy.</param>
        public unsafe void CopyTo(int index, TRAClaim[] array, int arrayIndex, int count)
        {
            if (array == null) throw new ArgumentNullException("array is null.");
            if (arrayIndex < 0 || index < 0 || count < 0) throw new ArgumentOutOfRangeException("arrayIndex is less than 0 or index is less than 0 or count is less than 0.");
            if (array.Length - arrayIndex < count) throw new ArgumentException("The number of elements from index to the end of the source List is greater than the available space from arrayIndex to the end of the destination array. ");
            if (index + count > Count) throw new ArgumentException("Source list does not have enough elements to copy.");
            int j = 0;
            for (int i = index; i < index + count; i++)
            {
                array[j + arrayIndex] = this[i];
                ++j;
            }
        }
          
        /// <summary>
        /// Inserts the elements of a collection into the List at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which the new elements should be inserted.</param>
        /// <param name="collection">The collection whose elements should be inserted into the List. The collection itself cannot be null, but it can contain elements that are null, if type T is a reference type.</param>
        public unsafe void InsertRange(int index, List<TRAClaim> collection)
        {
            if (collection == null) throw new ArgumentNullException("collection is null.");
            if (index < 0) throw new ArgumentOutOfRangeException("index is less than 0.");
            if (index > Count) throw new ArgumentOutOfRangeException("index is greater than Count.");
            TRAClaim_AccessorListAccessor tmpAccessor = collection;
            byte* targetPtr = m_ptr;
            for (int i = 0; i < index; i++)
            {
                {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_1 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_1 + 0) & 0x02)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_1 + 0) & 0x04)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
}
            }
            int offset = (int)(targetPtr - m_ptr);
            m_ptr = ResizeFunction(m_ptr - 4, offset + 4, tmpAccessor.length);
            Memory.Copy(tmpAccessor.m_ptr, m_ptr + offset + 4, tmpAccessor.length);
            *(int*)m_ptr += tmpAccessor.length;
            this.m_ptr += 4;
        }
        /// <summary>
        /// Removes a range of elements from the List.
        /// </summary>
        /// <param name="index">The zero-based starting index of the range of elements to remove.</param>
        /// <param name="count">The number of elements to remove.</param>
        public unsafe void RemoveRange(int index, int count)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index is less than 0.");
            if (index > Count) throw new ArgumentOutOfRangeException("index is greater than Count.");
            if (index + count > Count) throw new ArgumentException("index and count do not denote a valid range of elements in the List.");
            byte* targetPtr = m_ptr;
            for (int i = 0; i < index; i++)
            {
                {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_1 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_1 + 0) & 0x02)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_1 + 0) & 0x04)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
}
            }
            int offset = (int)(targetPtr - m_ptr);
            byte* oldtargetPtr = targetPtr;
            for (int i = 0; i < count; i++)
            {
                {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_1 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_1 + 0) & 0x02)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }

                if ((0 != (*(optheader_1 + 0) & 0x04)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
}
            }
            int size = (int)(oldtargetPtr - targetPtr);
            m_ptr = ResizeFunction(m_ptr - 4, offset + 4, size);
            *(int*)m_ptr += size;
            this.m_ptr += 4;
        }
        public unsafe static implicit operator List<TRAClaim> (TRAClaim_AccessorListAccessor accessor)
        {
            if((object)accessor == null) return null;
            List<TRAClaim> list = new List<TRAClaim>();
            accessor.ForEach(element => list.Add(element));
            return list;
        }
        
        public unsafe static implicit operator TRAClaim_AccessorListAccessor(List<TRAClaim> field)
        {
            byte* targetPtr = null;
            
{

    targetPtr += sizeof(int);
    if(field!= null)
    {
        for(int iterator_1 = 0;iterator_1<field.Count;++iterator_1)
        {

            {
            targetPtr += 1;

        if(field[iterator_1].key!= null)
        {
            int strlen_3 = field[iterator_1].key.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            if( field[iterator_1].value!= null)
            {

        if(field[iterator_1].value!= null)
        {
            int strlen_3 = field[iterator_1].value.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            if( field[iterator_1].attribute!= null)
            {

{

    targetPtr += sizeof(int);
    if(field[iterator_1].attribute!= null)
    {
        for(int iterator_3 = 0;iterator_3<field[iterator_1].attribute.Count;++iterator_3)
        {

            {

        if(field[iterator_1].attribute[iterator_3].key!= null)
        {
            int strlen_5 = field[iterator_1].attribute[iterator_3].key.Length * 2;
            targetPtr += strlen_5+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(field[iterator_1].attribute[iterator_3].value!= null)
        {
            int strlen_5 = field[iterator_1].attribute[iterator_3].value.Length * 2;
            targetPtr += strlen_5+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
        }
    }

}

            }
            if( field[iterator_1].attributes!= null)
            {

{

    targetPtr += sizeof(int);
    if(field[iterator_1].attributes!= null)
    {
        for(int iterator_3 = 0;iterator_3<field[iterator_1].attributes.Count;++iterator_3)
        {

{

    targetPtr += sizeof(int);
    if(field[iterator_1].attributes[iterator_3]!= null)
    {
        for(int iterator_4 = 0;iterator_4<field[iterator_1].attributes[iterator_3].Count;++iterator_4)
        {

            {

        if(field[iterator_1].attributes[iterator_3][iterator_4].key!= null)
        {
            int strlen_6 = field[iterator_1].attributes[iterator_3][iterator_4].key.Length * 2;
            targetPtr += strlen_6+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(field[iterator_1].attributes[iterator_3][iterator_4].value!= null)
        {
            int strlen_6 = field[iterator_1].attributes[iterator_3][iterator_4].value.Length * 2;
            targetPtr += strlen_6+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
        }
    }

}

        }
    }

}

            }

            }
        }
    }

}

            byte* tmpcellptr = BufferAllocator.AllocBuffer((int)targetPtr);
            Memory.memset(tmpcellptr, 0, (ulong)targetPtr);
            targetPtr = tmpcellptr;
            
{
byte *storedPtr_1 = targetPtr;

    targetPtr += sizeof(int);
    if(field!= null)
    {
        for(int iterator_1 = 0;iterator_1<field.Count;++iterator_1)
        {

            {
            byte* optheader_2 = targetPtr;
            *(optheader_2 + 0) = 0x00;            targetPtr += 1;

        if(field[iterator_1].key!= null)
        {
            int strlen_3 = field[iterator_1].key.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = field[iterator_1].key)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            if( field[iterator_1].value!= null)
            {

        if(field[iterator_1].value!= null)
        {
            int strlen_3 = field[iterator_1].value.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = field[iterator_1].value)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
*(optheader_2 + 0) |= 0x01;
            }
            if( field[iterator_1].attribute!= null)
            {

{
byte *storedPtr_3 = targetPtr;

    targetPtr += sizeof(int);
    if(field[iterator_1].attribute!= null)
    {
        for(int iterator_3 = 0;iterator_3<field[iterator_1].attribute.Count;++iterator_3)
        {

            {

        if(field[iterator_1].attribute[iterator_3].key!= null)
        {
            int strlen_5 = field[iterator_1].attribute[iterator_3].key.Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = field[iterator_1].attribute[iterator_3].key)
            {
                Memory.Copy(pstr_5, targetPtr, strlen_5);
                targetPtr += strlen_5;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(field[iterator_1].attribute[iterator_3].value!= null)
        {
            int strlen_5 = field[iterator_1].attribute[iterator_3].value.Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = field[iterator_1].attribute[iterator_3].value)
            {
                Memory.Copy(pstr_5, targetPtr, strlen_5);
                targetPtr += strlen_5;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }
        }
    }
*(int*)storedPtr_3 = (int)(targetPtr - storedPtr_3 - 4);

}
*(optheader_2 + 0) |= 0x02;
            }
            if( field[iterator_1].attributes!= null)
            {

{
byte *storedPtr_3 = targetPtr;

    targetPtr += sizeof(int);
    if(field[iterator_1].attributes!= null)
    {
        for(int iterator_3 = 0;iterator_3<field[iterator_1].attributes.Count;++iterator_3)
        {

{
byte *storedPtr_4 = targetPtr;

    targetPtr += sizeof(int);
    if(field[iterator_1].attributes[iterator_3]!= null)
    {
        for(int iterator_4 = 0;iterator_4<field[iterator_1].attributes[iterator_3].Count;++iterator_4)
        {

            {

        if(field[iterator_1].attributes[iterator_3][iterator_4].key!= null)
        {
            int strlen_6 = field[iterator_1].attributes[iterator_3][iterator_4].key.Length * 2;
            *(int*)targetPtr = strlen_6;
            targetPtr += sizeof(int);
            fixed(char* pstr_6 = field[iterator_1].attributes[iterator_3][iterator_4].key)
            {
                Memory.Copy(pstr_6, targetPtr, strlen_6);
                targetPtr += strlen_6;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(field[iterator_1].attributes[iterator_3][iterator_4].value!= null)
        {
            int strlen_6 = field[iterator_1].attributes[iterator_3][iterator_4].value.Length * 2;
            *(int*)targetPtr = strlen_6;
            targetPtr += sizeof(int);
            fixed(char* pstr_6 = field[iterator_1].attributes[iterator_3][iterator_4].value)
            {
                Memory.Copy(pstr_6, targetPtr, strlen_6);
                targetPtr += strlen_6;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }
        }
    }
*(int*)storedPtr_4 = (int)(targetPtr - storedPtr_4 - 4);

}

        }
    }
*(int*)storedPtr_3 = (int)(targetPtr - storedPtr_3 - 4);

}
*(optheader_2 + 0) |= 0x04;
            }

            }
        }
    }
*(int*)storedPtr_1 = (int)(targetPtr - storedPtr_1 - 4);

}
TRAClaim_AccessorListAccessor ret;
            
            ret = new TRAClaim_AccessorListAccessor(tmpcellptr, null);
            
            return ret;
        }
        
        public static bool operator ==(TRAClaim_AccessorListAccessor a, TRAClaim_AccessorListAccessor b)
        {
            if (ReferenceEquals(a, b))
                return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;
            if (a.m_ptr == b.m_ptr) return true;
            if (a.length != b.length) return false;
            return Memory.Compare(a.m_ptr, b.m_ptr, a.length);
        }
        public static bool operator !=(TRAClaim_AccessorListAccessor a, TRAClaim_AccessorListAccessor b)
        {
            return !(a == b);
        }
    }
}

namespace TDW.TRAServer
{
    
    public unsafe class Cac_AllowanceCharge_AccessorListAccessor : IEnumerable<Cac_AllowanceCharge_Accessor>
    {
        internal byte* m_ptr;
        internal long m_cellId;
        internal ResizeFunctionDelegate ResizeFunction;
        internal Cac_AllowanceCharge_AccessorListAccessor(byte* _CellPtr, ResizeFunctionDelegate func)
        {
            m_ptr = _CellPtr;
            ResizeFunction = func;
            m_ptr += 4;
                    elementAccessor = new Cac_AllowanceCharge_Accessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.m_ptr = this.ResizeFunction(this.m_ptr-sizeof(int), ptr_offset + substructure_offset +sizeof(int), delta);
                    *(int*)this.m_ptr += delta;
                    this.m_ptr += sizeof(int);
                    return this.m_ptr + substructure_offset;
                });
        }
        internal int length
        {
            get
            {
                return *(int*)(m_ptr - 4);
            }
        }
        Cac_AllowanceCharge_Accessor elementAccessor;
        
        /// <summary>
        /// Gets the number of elements actually contained in the List. 
        /// </summary>";
        public unsafe int Count
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                byte* endPtr = m_ptr + length;
                int ret = 0;
                while (targetPtr < endPtr)
                {
                    {            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}}
                    ++ret;
                }
                return ret;
                
            }
        }
        /// <summary>
        /// Gets or sets the element at the specified index. 
        /// </summary>
        /// <param name="index">Given index</param>
        /// <returns>Corresponding element at the specified index</returns>";
        public unsafe Cac_AllowanceCharge_Accessor this[int index]
        {
            get
            {
                
                {
                    
                    {
                        byte* targetPtr = m_ptr;
                        while (index-- > 0)
                        {
                            {            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}}
                        }
                        
                        elementAccessor.m_ptr = targetPtr;
                        
                    }
                    
                    elementAccessor.m_cellId = this.m_cellId;
                    return elementAccessor;
                }
                
            }
            set
            {
                
                {
                    if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                    elementAccessor.m_cellId = this.m_cellId;
                    byte* targetPtr = m_ptr;
                    
                    while (index-- > 0)
                    {
                        {            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}}
                    }
                    
                int offset = (int)(targetPtr - m_ptr);
                byte* oldtargetPtr = targetPtr;
                int oldlength = (int)(targetPtr - oldtargetPtr);
                targetPtr = value.m_ptr;
                int newlength = (int)(targetPtr - value.m_ptr);
                if (newlength != oldlength)
                {
                    if (value.m_cellId != this.m_cellId)
                    {
                        this.m_ptr = this.ResizeFunction(this.m_ptr, offset, newlength - oldlength);
                        Memory.Copy(value.m_ptr, this.m_ptr + offset, newlength);
                    }
                    else
                    {
                        byte[] tmpcell = new byte[newlength];
                        fixed(byte* tmpcellptr = tmpcell)
                        {
                            Memory.Copy(value.m_ptr, tmpcellptr, newlength);
                            this.m_ptr = this.ResizeFunction(this.m_ptr, offset, newlength - oldlength);
                            Memory.Copy(tmpcellptr, this.m_ptr + offset, newlength);
                        }
                    }
                }
                else
                {
                    Memory.Copy(value.m_ptr, oldtargetPtr, oldlength);
                }
                }
                
            }
        }
        /// <summary>
        /// Copies the elements to a new byte array
        /// </summary>
        /// <returns>Elements compactly arranged in a byte array.</returns>
        public unsafe byte[] ToByteArray()
        {
            byte[] ret = new byte[length];
            fixed (byte* retptr = ret)
            {
                Memory.Copy(m_ptr, retptr, length);
                return ret;
            }
        }
        /// <summary>
        /// Performs the specified action on each elements
        /// </summary>
        /// <param name="action">A lambda expression which has one parameter indicates element in List</param>
        public unsafe void ForEach(Action<Cac_AllowanceCharge_Accessor> action)
        {
            byte* targetPtr = m_ptr;
            byte* endPtr = m_ptr + length;
            
            elementAccessor.m_cellId = this.m_cellId;
            
            while (targetPtr < endPtr)
            {
                
                {
                    elementAccessor.m_ptr = targetPtr;
                    action(elementAccessor);
                    {            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}}
                }
                
            }
        }
        /// <summary>
        /// Performs the specified action on each elements
        /// </summary>
        /// <param name="action">A lambda expression which has two parameters. First indicates element in the List and second the index of this element.</param>
        public unsafe void ForEach(Action<Cac_AllowanceCharge_Accessor, int> action)
        {
            byte* targetPtr = m_ptr;
            byte* endPtr = m_ptr + length;
            for (int index = 0; targetPtr < endPtr; ++index)
            {
                
                {
                    elementAccessor.m_ptr = targetPtr;
                    action(elementAccessor, index);
                    {            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}}
                }
                
            }
        }
        internal unsafe struct _iterator
        {
            byte* targetPtr;
            byte* endPtr;
            Cac_AllowanceCharge_AccessorListAccessor target;
            internal _iterator(Cac_AllowanceCharge_AccessorListAccessor target)
            {
                targetPtr = target.m_ptr;
                endPtr = targetPtr + target.length;
                this.target = target;
            }
            internal bool good()
            {
                return (targetPtr < endPtr);
            }
            internal Cac_AllowanceCharge_Accessor current()
            {
                
                {
                    target.elementAccessor.m_ptr = targetPtr;
                    return target.elementAccessor;
                }
                
            }
            internal void move_next()
            {
                 
                {
                    {            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}}
                }
                
            }
        }
        public IEnumerator<Cac_AllowanceCharge_Accessor> GetEnumerator()
        {
            _iterator _it = new _iterator(this);
            while (_it.good())
            {
                yield return _it.current();
                _it.move_next();
            }
        }
        unsafe IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        /// <summary>
        /// Adds an item to the end of the List
        /// </summary>
        /// <param name="element">The object to be added to the end of the List.</param>
        public unsafe void Add(Cac_AllowanceCharge element)
        {
            byte* targetPtr = null;
            {
                
            {
            targetPtr += 1;

        if(element.cbc_AllowanceChargeReason!= null)
        {
            int strlen_1 = element.cbc_AllowanceChargeReason.Length * 2;
            targetPtr += strlen_1+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            {

        if(element.cbc_Amount._CurrencyID!= null)
        {
            int strlen_2 = element.cbc_Amount._CurrencyID.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            }
            }
            int size = (int)targetPtr;
            this.m_ptr = this.ResizeFunction(this.m_ptr - sizeof(int), *(int*)(this.m_ptr-sizeof(int))+sizeof(int), size);
            targetPtr = this.m_ptr + (*(int*)this.m_ptr)+sizeof(int);
            *(int*)this.m_ptr += size;
            this.m_ptr += sizeof(int);
            
            {
            *(bool*)targetPtr = element.cbc_ChargeIndicator;
            targetPtr += 1;

        if(element.cbc_AllowanceChargeReason!= null)
        {
            int strlen_1 = element.cbc_AllowanceChargeReason.Length * 2;
            *(int*)targetPtr = strlen_1;
            targetPtr += sizeof(int);
            fixed(char* pstr_1 = element.cbc_AllowanceChargeReason)
            {
                Memory.Copy(pstr_1, targetPtr, strlen_1);
                targetPtr += strlen_1;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            {

        if(element.cbc_Amount._CurrencyID!= null)
        {
            int strlen_2 = element.cbc_Amount._CurrencyID.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = element.cbc_Amount._CurrencyID)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(double*)targetPtr = element.cbc_Amount.amount;
            targetPtr += 8;

            }
            }
        }
        /// <summary>
        /// Inserts an element into the List at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which item should be inserted.</param>
        /// <param name="element">The object to insert.</param>
        public unsafe void Insert(int index, Cac_AllowanceCharge element)
        {
            if (index < 0 || index > Count) throw new IndexOutOfRangeException();
            byte* targetPtr = null;
            {
                
            {
            targetPtr += 1;

        if(element.cbc_AllowanceChargeReason!= null)
        {
            int strlen_1 = element.cbc_AllowanceChargeReason.Length * 2;
            targetPtr += strlen_1+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            {

        if(element.cbc_Amount._CurrencyID!= null)
        {
            int strlen_2 = element.cbc_Amount._CurrencyID.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            }
            }
            int size = (int)targetPtr;
            targetPtr = m_ptr;
            
            for (int i = 0; i < index; i++)
            {
                {            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}}
            }
            
            int offset = (int)(targetPtr - m_ptr);
            this.m_ptr = this.ResizeFunction(this.m_ptr - sizeof(int), offset + sizeof(int), size);
            *(int*)this.m_ptr += size;
            this.m_ptr += sizeof(int);
            targetPtr = this.m_ptr + offset;
            
            {
            *(bool*)targetPtr = element.cbc_ChargeIndicator;
            targetPtr += 1;

        if(element.cbc_AllowanceChargeReason!= null)
        {
            int strlen_1 = element.cbc_AllowanceChargeReason.Length * 2;
            *(int*)targetPtr = strlen_1;
            targetPtr += sizeof(int);
            fixed(char* pstr_1 = element.cbc_AllowanceChargeReason)
            {
                Memory.Copy(pstr_1, targetPtr, strlen_1);
                targetPtr += strlen_1;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            {

        if(element.cbc_Amount._CurrencyID!= null)
        {
            int strlen_2 = element.cbc_Amount._CurrencyID.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = element.cbc_Amount._CurrencyID)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(double*)targetPtr = element.cbc_Amount.amount;
            targetPtr += 8;

            }
            }
        }
        /// <summary>
        /// Inserts an element into a sorted list.
        /// </summary>
        /// <param name="element">The object to insert.</param>
        /// <param name="comparison"></param>
        public unsafe void Insert(Cac_AllowanceCharge element, Comparison<Cac_AllowanceCharge_Accessor> comparison)
        {
            byte* targetPtr = null;
            {
                
            {
            targetPtr += 1;

        if(element.cbc_AllowanceChargeReason!= null)
        {
            int strlen_1 = element.cbc_AllowanceChargeReason.Length * 2;
            targetPtr += strlen_1+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            {

        if(element.cbc_Amount._CurrencyID!= null)
        {
            int strlen_2 = element.cbc_Amount._CurrencyID.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            }
            }
            int size = (int)targetPtr;
            targetPtr = m_ptr;
            byte* endPtr = m_ptr + length;
            while (targetPtr<endPtr)
            {
                
                {
                    elementAccessor.m_ptr = targetPtr + 4;
                    if (comparison(elementAccessor, element)<=0)
                    {
                        {            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}}
                    }
                    else
                    {
                        break;
                    }
                }
                
            }
            int offset = (int)(targetPtr - m_ptr);
            this.m_ptr = this.ResizeFunction(this.m_ptr - sizeof(int), offset + sizeof(int), size);
            *(int*)this.m_ptr += size;
            this.m_ptr += sizeof(int);
            targetPtr = this.m_ptr + offset;
            
            {
            *(bool*)targetPtr = element.cbc_ChargeIndicator;
            targetPtr += 1;

        if(element.cbc_AllowanceChargeReason!= null)
        {
            int strlen_1 = element.cbc_AllowanceChargeReason.Length * 2;
            *(int*)targetPtr = strlen_1;
            targetPtr += sizeof(int);
            fixed(char* pstr_1 = element.cbc_AllowanceChargeReason)
            {
                Memory.Copy(pstr_1, targetPtr, strlen_1);
                targetPtr += strlen_1;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            {

        if(element.cbc_Amount._CurrencyID!= null)
        {
            int strlen_2 = element.cbc_Amount._CurrencyID.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = element.cbc_Amount._CurrencyID)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(double*)targetPtr = element.cbc_Amount.amount;
            targetPtr += 8;

            }
            }
        }
        /// <summary>
        /// Removes the element at the specified index of the List.
        /// </summary>
        /// <param name="index">The zero-based index of the element to remove.</param>
        public unsafe void RemoveAt(int index)
        {
            if (index < 0 || index >= Count) throw new IndexOutOfRangeException();
            byte* targetPtr = m_ptr;
            for (int i = 0; i < index; i++)
            {
                {            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}}
            }
            int offset = (int)(targetPtr - m_ptr);
            byte* oldtargetPtr = targetPtr;
            {            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}}
            int size = (int)(oldtargetPtr - targetPtr);
            this.m_ptr = this.ResizeFunction(this.m_ptr - sizeof(int), offset + sizeof(int), size);
            *(int*)this.m_ptr += size;
            this.m_ptr += sizeof(int);
        }
        /// <summary>
        /// Adds the elements of the specified collection to the end of the List
        /// </summary>
        /// <param name="collection">The collection whose elements should be added to the end of the List. The collection itself cannot be null.</param>
        public unsafe void AddRange(List<Cac_AllowanceCharge> collection)
        {
            if (collection == null) throw new ArgumentNullException("collection is null.");
            Cac_AllowanceCharge_AccessorListAccessor tcollection = collection;
            int delta = tcollection.length;
            m_ptr = ResizeFunction(m_ptr - 4, *(int*)(m_ptr - 4) + 4, delta);
            Memory.Copy(tcollection.m_ptr, m_ptr + *(int*)m_ptr + 4, delta);
            *(int*)m_ptr += delta;
            this.m_ptr += 4;
        }
        /// <summary>
        /// Adds the elements of the specified collection to the end of the List
        /// </summary>
        /// <param name="collection">The collection whose elements should be added to the end of the List. The collection itself cannot be null.</param>
        public unsafe void AddRange(Cac_AllowanceCharge_AccessorListAccessor collection)
        {
            if (collection == null) throw new ArgumentNullException("collection is null.");
            int delta = collection.length;
            if (collection.m_cellId != m_cellId)
            {
                m_ptr = ResizeFunction(m_ptr - 4, *(int*)(m_ptr - 4) + 4, delta);
                Memory.Copy(collection.m_ptr, m_ptr + *(int*)m_ptr + 4, delta);
                *(int*)m_ptr += delta;
            }
            else
            {
                byte[] tmpcell = new byte[delta];
                fixed (byte* tmpcellptr = tmpcell)
                {
                    Memory.Copy(collection.m_ptr, tmpcellptr, delta);
                    m_ptr = ResizeFunction(m_ptr - 4, *(int*)(m_ptr - 4) + 4, delta);
                    Memory.Copy(tmpcellptr, m_ptr + *(int*)m_ptr + 4, delta);
                    *(int*)m_ptr += delta;
                }
            }
            this.m_ptr += 4;
        }
        /// <summary>
        /// Removes all elements from the List
        /// </summary>
        public unsafe void Clear()
        {
            int delta = length;
            Memory.memset(m_ptr, 0, (ulong)delta);
            m_ptr = ResizeFunction(m_ptr - 4, 4, -delta);
            *(int*)m_ptr = 0;
            this.m_ptr += 4;
        }
        /// <summary>
        /// Determines whether an element is in the List
        /// </summary>
        /// <param name="item">The object to locate in the List.The value can be null for non-atom types</param>
        /// <returns>true if item is found in the List; otherwise, false.</returns>
        public unsafe bool Contains(Cac_AllowanceCharge_Accessor item)
        {
            bool ret = false;
            ForEach(x =>
            {
                if (item == x) ret = true;
            });
            return ret;
        }
        /// <summary>
        /// Determines whether the List contains elements that match the conditions defined by the specified predicate.
        /// </summary>
        /// <param name="match">The Predicate delegate that defines the conditions of the elements to search for.</param>
        /// <returns>true if the List contains one or more elements that match the conditions defined by the specified predicate; otherwise, false.</returns>
        public unsafe bool Exists(Predicate<Cac_AllowanceCharge_Accessor> match)
        {
            bool ret = false;
            ForEach(x =>
            {
                if (match(x)) ret = true;
            });
            return ret;
        }
        
        /// <summary>
        /// Copies the entire List to a compatible one-dimensional array, starting at the beginning of the ptr1 array.
        /// </summary>
        /// <param name="array">The one-dimensional Array that is the destination of the elements copied from List. The Array must have zero-based indexing.</param>
        public unsafe void CopyTo(Cac_AllowanceCharge[] array)
        {
            if (array == null) throw new ArgumentNullException("array is null.");
            if (array.Length < Count) throw new ArgumentException("The number of elements in the source List is greater than the number of elements that the destination array can contain.");
            ForEach((x, i) => array[i] = x);
        }
        /// <summary>
        /// Copies the entire List to a compatible one-dimensional array, starting at the specified index of the ptr1 array.
        /// </summary>
        /// <param name="array">The one-dimensional Array that is the destination of the elements copied from List. The Array must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
        public unsafe void CopyTo(Cac_AllowanceCharge[] array, int arrayIndex)
        {
            if (array == null) throw new ArgumentNullException("array is null.");
            if (arrayIndex < 0) throw new ArgumentOutOfRangeException("arrayIndex is less than 0.");
            if (array.Length - arrayIndex < Count) throw new ArgumentException("The number of elements in the source List is greater than the available space from arrayIndex to the end of the destination array.");
            ForEach((x, i) => array[i + arrayIndex] = x);
        }
        /// <summary>
        /// Copies a range of elements from the List to a compatible one-dimensional array, starting at the specified index of the ptr1 array.
        /// </summary>
        /// <param name="index">The zero-based index in the source List at which copying begins.</param>
        /// <param name="array">The one-dimensional Array that is the destination of the elements copied from List. The Array must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>;
        /// <param name="count">The number of elements to copy.</param>
        public unsafe void CopyTo(int index, Cac_AllowanceCharge[] array, int arrayIndex, int count)
        {
            if (array == null) throw new ArgumentNullException("array is null.");
            if (arrayIndex < 0 || index < 0 || count < 0) throw new ArgumentOutOfRangeException("arrayIndex is less than 0 or index is less than 0 or count is less than 0.");
            if (array.Length - arrayIndex < count) throw new ArgumentException("The number of elements from index to the end of the source List is greater than the available space from arrayIndex to the end of the destination array. ");
            if (index + count > Count) throw new ArgumentException("Source list does not have enough elements to copy.");
            int j = 0;
            for (int i = index; i < index + count; i++)
            {
                array[j + arrayIndex] = this[i];
                ++j;
            }
        }
          
        /// <summary>
        /// Inserts the elements of a collection into the List at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which the new elements should be inserted.</param>
        /// <param name="collection">The collection whose elements should be inserted into the List. The collection itself cannot be null, but it can contain elements that are null, if type T is a reference type.</param>
        public unsafe void InsertRange(int index, List<Cac_AllowanceCharge> collection)
        {
            if (collection == null) throw new ArgumentNullException("collection is null.");
            if (index < 0) throw new ArgumentOutOfRangeException("index is less than 0.");
            if (index > Count) throw new ArgumentOutOfRangeException("index is greater than Count.");
            Cac_AllowanceCharge_AccessorListAccessor tmpAccessor = collection;
            byte* targetPtr = m_ptr;
            for (int i = 0; i < index; i++)
            {
                {            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}}
            }
            int offset = (int)(targetPtr - m_ptr);
            m_ptr = ResizeFunction(m_ptr - 4, offset + 4, tmpAccessor.length);
            Memory.Copy(tmpAccessor.m_ptr, m_ptr + offset + 4, tmpAccessor.length);
            *(int*)m_ptr += tmpAccessor.length;
            this.m_ptr += 4;
        }
        /// <summary>
        /// Removes a range of elements from the List.
        /// </summary>
        /// <param name="index">The zero-based starting index of the range of elements to remove.</param>
        /// <param name="count">The number of elements to remove.</param>
        public unsafe void RemoveRange(int index, int count)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index is less than 0.");
            if (index > Count) throw new ArgumentOutOfRangeException("index is greater than Count.");
            if (index + count > Count) throw new ArgumentException("index and count do not denote a valid range of elements in the List.");
            byte* targetPtr = m_ptr;
            for (int i = 0; i < index; i++)
            {
                {            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}}
            }
            int offset = (int)(targetPtr - m_ptr);
            byte* oldtargetPtr = targetPtr;
            for (int i = 0; i < count; i++)
            {
                {            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}}
            }
            int size = (int)(oldtargetPtr - targetPtr);
            m_ptr = ResizeFunction(m_ptr - 4, offset + 4, size);
            *(int*)m_ptr += size;
            this.m_ptr += 4;
        }
        public unsafe static implicit operator List<Cac_AllowanceCharge> (Cac_AllowanceCharge_AccessorListAccessor accessor)
        {
            if((object)accessor == null) return null;
            List<Cac_AllowanceCharge> list = new List<Cac_AllowanceCharge>();
            accessor.ForEach(element => list.Add(element));
            return list;
        }
        
        public unsafe static implicit operator Cac_AllowanceCharge_AccessorListAccessor(List<Cac_AllowanceCharge> field)
        {
            byte* targetPtr = null;
            
{

    targetPtr += sizeof(int);
    if(field!= null)
    {
        for(int iterator_1 = 0;iterator_1<field.Count;++iterator_1)
        {

            {
            targetPtr += 1;

        if(field[iterator_1].cbc_AllowanceChargeReason!= null)
        {
            int strlen_3 = field[iterator_1].cbc_AllowanceChargeReason.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            {

        if(field[iterator_1].cbc_Amount._CurrencyID!= null)
        {
            int strlen_4 = field[iterator_1].cbc_Amount._CurrencyID.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            }
        }
    }

}

            byte* tmpcellptr = BufferAllocator.AllocBuffer((int)targetPtr);
            Memory.memset(tmpcellptr, 0, (ulong)targetPtr);
            targetPtr = tmpcellptr;
            
{
byte *storedPtr_1 = targetPtr;

    targetPtr += sizeof(int);
    if(field!= null)
    {
        for(int iterator_1 = 0;iterator_1<field.Count;++iterator_1)
        {

            {
            *(bool*)targetPtr = field[iterator_1].cbc_ChargeIndicator;
            targetPtr += 1;

        if(field[iterator_1].cbc_AllowanceChargeReason!= null)
        {
            int strlen_3 = field[iterator_1].cbc_AllowanceChargeReason.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = field[iterator_1].cbc_AllowanceChargeReason)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            {

        if(field[iterator_1].cbc_Amount._CurrencyID!= null)
        {
            int strlen_4 = field[iterator_1].cbc_Amount._CurrencyID.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = field[iterator_1].cbc_Amount._CurrencyID)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(double*)targetPtr = field[iterator_1].cbc_Amount.amount;
            targetPtr += 8;

            }
            }
        }
    }
*(int*)storedPtr_1 = (int)(targetPtr - storedPtr_1 - 4);

}
Cac_AllowanceCharge_AccessorListAccessor ret;
            
            ret = new Cac_AllowanceCharge_AccessorListAccessor(tmpcellptr, null);
            
            return ret;
        }
        
        public static bool operator ==(Cac_AllowanceCharge_AccessorListAccessor a, Cac_AllowanceCharge_AccessorListAccessor b)
        {
            if (ReferenceEquals(a, b))
                return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;
            if (a.m_ptr == b.m_ptr) return true;
            if (a.length != b.length) return false;
            return Memory.Compare(a.m_ptr, b.m_ptr, a.length);
        }
        public static bool operator !=(Cac_AllowanceCharge_AccessorListAccessor a, Cac_AllowanceCharge_AccessorListAccessor b)
        {
            return !(a == b);
        }
    }
}

namespace TDW.TRAServer
{
    
    public unsafe class Cac_TaxSubtotal_AccessorListAccessor : IEnumerable<Cac_TaxSubtotal_Accessor>
    {
        internal byte* m_ptr;
        internal long m_cellId;
        internal ResizeFunctionDelegate ResizeFunction;
        internal Cac_TaxSubtotal_AccessorListAccessor(byte* _CellPtr, ResizeFunctionDelegate func)
        {
            m_ptr = _CellPtr;
            ResizeFunction = func;
            m_ptr += 4;
                    elementAccessor = new Cac_TaxSubtotal_Accessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.m_ptr = this.ResizeFunction(this.m_ptr-sizeof(int), ptr_offset + substructure_offset +sizeof(int), delta);
                    *(int*)this.m_ptr += delta;
                    this.m_ptr += sizeof(int);
                    return this.m_ptr + substructure_offset;
                });
        }
        internal int length
        {
            get
            {
                return *(int*)(m_ptr - 4);
            }
        }
        Cac_TaxSubtotal_Accessor elementAccessor;
        
        /// <summary>
        /// Gets the number of elements actually contained in the List. 
        /// </summary>";
        public unsafe int Count
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                byte* endPtr = m_ptr + length;
                int ret = 0;
                while (targetPtr < endPtr)
                {
                    {{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{{            byte* optheader_5 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_5 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
targetPtr += *(int*)targetPtr + sizeof(int);}            targetPtr += 8;
{{            byte* optheader_7 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_7 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
targetPtr += *(int*)targetPtr + sizeof(int);}}}}
                    ++ret;
                }
                return ret;
                
            }
        }
        /// <summary>
        /// Gets or sets the element at the specified index. 
        /// </summary>
        /// <param name="index">Given index</param>
        /// <returns>Corresponding element at the specified index</returns>";
        public unsafe Cac_TaxSubtotal_Accessor this[int index]
        {
            get
            {
                
                {
                    
                    {
                        byte* targetPtr = m_ptr;
                        while (index-- > 0)
                        {
                            {{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{{            byte* optheader_5 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_5 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
targetPtr += *(int*)targetPtr + sizeof(int);}            targetPtr += 8;
{{            byte* optheader_7 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_7 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
targetPtr += *(int*)targetPtr + sizeof(int);}}}}
                        }
                        
                        elementAccessor.m_ptr = targetPtr;
                        
                    }
                    
                    elementAccessor.m_cellId = this.m_cellId;
                    return elementAccessor;
                }
                
            }
            set
            {
                
                {
                    if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                    elementAccessor.m_cellId = this.m_cellId;
                    byte* targetPtr = m_ptr;
                    
                    while (index-- > 0)
                    {
                        {{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{{            byte* optheader_5 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_5 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
targetPtr += *(int*)targetPtr + sizeof(int);}            targetPtr += 8;
{{            byte* optheader_7 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_7 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
targetPtr += *(int*)targetPtr + sizeof(int);}}}}
                    }
                    
                int offset = (int)(targetPtr - m_ptr);
                byte* oldtargetPtr = targetPtr;
                int oldlength = (int)(targetPtr - oldtargetPtr);
                targetPtr = value.m_ptr;
                int newlength = (int)(targetPtr - value.m_ptr);
                if (newlength != oldlength)
                {
                    if (value.m_cellId != this.m_cellId)
                    {
                        this.m_ptr = this.ResizeFunction(this.m_ptr, offset, newlength - oldlength);
                        Memory.Copy(value.m_ptr, this.m_ptr + offset, newlength);
                    }
                    else
                    {
                        byte[] tmpcell = new byte[newlength];
                        fixed(byte* tmpcellptr = tmpcell)
                        {
                            Memory.Copy(value.m_ptr, tmpcellptr, newlength);
                            this.m_ptr = this.ResizeFunction(this.m_ptr, offset, newlength - oldlength);
                            Memory.Copy(tmpcellptr, this.m_ptr + offset, newlength);
                        }
                    }
                }
                else
                {
                    Memory.Copy(value.m_ptr, oldtargetPtr, oldlength);
                }
                }
                
            }
        }
        /// <summary>
        /// Copies the elements to a new byte array
        /// </summary>
        /// <returns>Elements compactly arranged in a byte array.</returns>
        public unsafe byte[] ToByteArray()
        {
            byte[] ret = new byte[length];
            fixed (byte* retptr = ret)
            {
                Memory.Copy(m_ptr, retptr, length);
                return ret;
            }
        }
        /// <summary>
        /// Performs the specified action on each elements
        /// </summary>
        /// <param name="action">A lambda expression which has one parameter indicates element in List</param>
        public unsafe void ForEach(Action<Cac_TaxSubtotal_Accessor> action)
        {
            byte* targetPtr = m_ptr;
            byte* endPtr = m_ptr + length;
            
            elementAccessor.m_cellId = this.m_cellId;
            
            while (targetPtr < endPtr)
            {
                
                {
                    elementAccessor.m_ptr = targetPtr;
                    action(elementAccessor);
                    {{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{{            byte* optheader_5 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_5 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
targetPtr += *(int*)targetPtr + sizeof(int);}            targetPtr += 8;
{{            byte* optheader_7 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_7 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
targetPtr += *(int*)targetPtr + sizeof(int);}}}}
                }
                
            }
        }
        /// <summary>
        /// Performs the specified action on each elements
        /// </summary>
        /// <param name="action">A lambda expression which has two parameters. First indicates element in the List and second the index of this element.</param>
        public unsafe void ForEach(Action<Cac_TaxSubtotal_Accessor, int> action)
        {
            byte* targetPtr = m_ptr;
            byte* endPtr = m_ptr + length;
            for (int index = 0; targetPtr < endPtr; ++index)
            {
                
                {
                    elementAccessor.m_ptr = targetPtr;
                    action(elementAccessor, index);
                    {{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{{            byte* optheader_5 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_5 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
targetPtr += *(int*)targetPtr + sizeof(int);}            targetPtr += 8;
{{            byte* optheader_7 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_7 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
targetPtr += *(int*)targetPtr + sizeof(int);}}}}
                }
                
            }
        }
        internal unsafe struct _iterator
        {
            byte* targetPtr;
            byte* endPtr;
            Cac_TaxSubtotal_AccessorListAccessor target;
            internal _iterator(Cac_TaxSubtotal_AccessorListAccessor target)
            {
                targetPtr = target.m_ptr;
                endPtr = targetPtr + target.length;
                this.target = target;
            }
            internal bool good()
            {
                return (targetPtr < endPtr);
            }
            internal Cac_TaxSubtotal_Accessor current()
            {
                
                {
                    target.elementAccessor.m_ptr = targetPtr;
                    return target.elementAccessor;
                }
                
            }
            internal void move_next()
            {
                 
                {
                    {{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{{            byte* optheader_5 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_5 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
targetPtr += *(int*)targetPtr + sizeof(int);}            targetPtr += 8;
{{            byte* optheader_7 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_7 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
targetPtr += *(int*)targetPtr + sizeof(int);}}}}
                }
                
            }
        }
        public IEnumerator<Cac_TaxSubtotal_Accessor> GetEnumerator()
        {
            _iterator _it = new _iterator(this);
            while (_it.good())
            {
                yield return _it.current();
                _it.move_next();
            }
        }
        unsafe IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        /// <summary>
        /// Adds an item to the end of the List
        /// </summary>
        /// <param name="element">The object to be added to the end of the List.</param>
        public unsafe void Add(Cac_TaxSubtotal element)
        {
            byte* targetPtr = null;
            {
                
            {

            {

        if(element.cbc_TaxableAmount._CurrencyID!= null)
        {
            int strlen_2 = element.cbc_TaxableAmount._CurrencyID.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            {

        if(element.cbc_TaxAmount._CurrencyID!= null)
        {
            int strlen_2 = element.cbc_TaxAmount._CurrencyID.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            {

            {
            targetPtr += 1;

        if(element.cac_TaxCategory.cbc_ID._schemeID!= null)
        {
            int strlen_3 = element.cac_TaxCategory.cbc_ID._schemeID.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            if( element.cac_TaxCategory.cbc_ID._schemeAgencyID!= null)
            {

        if(element.cac_TaxCategory.cbc_ID._schemeAgencyID!= null)
        {
            int strlen_3 = element.cac_TaxCategory.cbc_ID._schemeAgencyID.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }

        if(element.cac_TaxCategory.cbc_ID.code!= null)
        {
            int strlen_3 = element.cac_TaxCategory.cbc_ID.code.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }            targetPtr += 8;

            {

            {
            targetPtr += 1;

        if(element.cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeID!= null)
        {
            int strlen_4 = element.cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeID.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            if( element.cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeAgencyID!= null)
            {

        if(element.cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeAgencyID!= null)
        {
            int strlen_4 = element.cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeAgencyID.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }

        if(element.cac_TaxCategory.cac_TaxScheme.cbc_ID.code!= null)
        {
            int strlen_4 = element.cac_TaxCategory.cac_TaxScheme.cbc_ID.code.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            }
            }
            }
            }
            int size = (int)targetPtr;
            this.m_ptr = this.ResizeFunction(this.m_ptr - sizeof(int), *(int*)(this.m_ptr-sizeof(int))+sizeof(int), size);
            targetPtr = this.m_ptr + (*(int*)this.m_ptr)+sizeof(int);
            *(int*)this.m_ptr += size;
            this.m_ptr += sizeof(int);
            
            {

            {

        if(element.cbc_TaxableAmount._CurrencyID!= null)
        {
            int strlen_2 = element.cbc_TaxableAmount._CurrencyID.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = element.cbc_TaxableAmount._CurrencyID)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(double*)targetPtr = element.cbc_TaxableAmount.amount;
            targetPtr += 8;

            }
            {

        if(element.cbc_TaxAmount._CurrencyID!= null)
        {
            int strlen_2 = element.cbc_TaxAmount._CurrencyID.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = element.cbc_TaxAmount._CurrencyID)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(double*)targetPtr = element.cbc_TaxAmount.amount;
            targetPtr += 8;

            }
            {

            {
            byte* optheader_2 = targetPtr;
            *(optheader_2 + 0) = 0x00;            targetPtr += 1;

        if(element.cac_TaxCategory.cbc_ID._schemeID!= null)
        {
            int strlen_3 = element.cac_TaxCategory.cbc_ID._schemeID.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = element.cac_TaxCategory.cbc_ID._schemeID)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            if( element.cac_TaxCategory.cbc_ID._schemeAgencyID!= null)
            {

        if(element.cac_TaxCategory.cbc_ID._schemeAgencyID!= null)
        {
            int strlen_3 = element.cac_TaxCategory.cbc_ID._schemeAgencyID.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = element.cac_TaxCategory.cbc_ID._schemeAgencyID)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
*(optheader_2 + 0) |= 0x01;
            }

        if(element.cac_TaxCategory.cbc_ID.code!= null)
        {
            int strlen_3 = element.cac_TaxCategory.cbc_ID.code.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = element.cac_TaxCategory.cbc_ID.code)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }            *(double*)targetPtr = element.cac_TaxCategory.cbc_Percent;
            targetPtr += 8;

            {

            {
            byte* optheader_3 = targetPtr;
            *(optheader_3 + 0) = 0x00;            targetPtr += 1;

        if(element.cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeID!= null)
        {
            int strlen_4 = element.cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeID.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = element.cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeID)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            if( element.cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeAgencyID!= null)
            {

        if(element.cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeAgencyID!= null)
        {
            int strlen_4 = element.cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeAgencyID.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = element.cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeAgencyID)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
*(optheader_3 + 0) |= 0x01;
            }

        if(element.cac_TaxCategory.cac_TaxScheme.cbc_ID.code!= null)
        {
            int strlen_4 = element.cac_TaxCategory.cac_TaxScheme.cbc_ID.code.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = element.cac_TaxCategory.cac_TaxScheme.cbc_ID.code)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }
            }
            }
            }
        }
        /// <summary>
        /// Inserts an element into the List at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which item should be inserted.</param>
        /// <param name="element">The object to insert.</param>
        public unsafe void Insert(int index, Cac_TaxSubtotal element)
        {
            if (index < 0 || index > Count) throw new IndexOutOfRangeException();
            byte* targetPtr = null;
            {
                
            {

            {

        if(element.cbc_TaxableAmount._CurrencyID!= null)
        {
            int strlen_2 = element.cbc_TaxableAmount._CurrencyID.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            {

        if(element.cbc_TaxAmount._CurrencyID!= null)
        {
            int strlen_2 = element.cbc_TaxAmount._CurrencyID.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            {

            {
            targetPtr += 1;

        if(element.cac_TaxCategory.cbc_ID._schemeID!= null)
        {
            int strlen_3 = element.cac_TaxCategory.cbc_ID._schemeID.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            if( element.cac_TaxCategory.cbc_ID._schemeAgencyID!= null)
            {

        if(element.cac_TaxCategory.cbc_ID._schemeAgencyID!= null)
        {
            int strlen_3 = element.cac_TaxCategory.cbc_ID._schemeAgencyID.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }

        if(element.cac_TaxCategory.cbc_ID.code!= null)
        {
            int strlen_3 = element.cac_TaxCategory.cbc_ID.code.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }            targetPtr += 8;

            {

            {
            targetPtr += 1;

        if(element.cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeID!= null)
        {
            int strlen_4 = element.cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeID.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            if( element.cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeAgencyID!= null)
            {

        if(element.cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeAgencyID!= null)
        {
            int strlen_4 = element.cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeAgencyID.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }

        if(element.cac_TaxCategory.cac_TaxScheme.cbc_ID.code!= null)
        {
            int strlen_4 = element.cac_TaxCategory.cac_TaxScheme.cbc_ID.code.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            }
            }
            }
            }
            int size = (int)targetPtr;
            targetPtr = m_ptr;
            
            for (int i = 0; i < index; i++)
            {
                {{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{{            byte* optheader_5 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_5 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
targetPtr += *(int*)targetPtr + sizeof(int);}            targetPtr += 8;
{{            byte* optheader_7 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_7 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
targetPtr += *(int*)targetPtr + sizeof(int);}}}}
            }
            
            int offset = (int)(targetPtr - m_ptr);
            this.m_ptr = this.ResizeFunction(this.m_ptr - sizeof(int), offset + sizeof(int), size);
            *(int*)this.m_ptr += size;
            this.m_ptr += sizeof(int);
            targetPtr = this.m_ptr + offset;
            
            {

            {

        if(element.cbc_TaxableAmount._CurrencyID!= null)
        {
            int strlen_2 = element.cbc_TaxableAmount._CurrencyID.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = element.cbc_TaxableAmount._CurrencyID)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(double*)targetPtr = element.cbc_TaxableAmount.amount;
            targetPtr += 8;

            }
            {

        if(element.cbc_TaxAmount._CurrencyID!= null)
        {
            int strlen_2 = element.cbc_TaxAmount._CurrencyID.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = element.cbc_TaxAmount._CurrencyID)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(double*)targetPtr = element.cbc_TaxAmount.amount;
            targetPtr += 8;

            }
            {

            {
            byte* optheader_2 = targetPtr;
            *(optheader_2 + 0) = 0x00;            targetPtr += 1;

        if(element.cac_TaxCategory.cbc_ID._schemeID!= null)
        {
            int strlen_3 = element.cac_TaxCategory.cbc_ID._schemeID.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = element.cac_TaxCategory.cbc_ID._schemeID)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            if( element.cac_TaxCategory.cbc_ID._schemeAgencyID!= null)
            {

        if(element.cac_TaxCategory.cbc_ID._schemeAgencyID!= null)
        {
            int strlen_3 = element.cac_TaxCategory.cbc_ID._schemeAgencyID.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = element.cac_TaxCategory.cbc_ID._schemeAgencyID)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
*(optheader_2 + 0) |= 0x01;
            }

        if(element.cac_TaxCategory.cbc_ID.code!= null)
        {
            int strlen_3 = element.cac_TaxCategory.cbc_ID.code.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = element.cac_TaxCategory.cbc_ID.code)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }            *(double*)targetPtr = element.cac_TaxCategory.cbc_Percent;
            targetPtr += 8;

            {

            {
            byte* optheader_3 = targetPtr;
            *(optheader_3 + 0) = 0x00;            targetPtr += 1;

        if(element.cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeID!= null)
        {
            int strlen_4 = element.cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeID.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = element.cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeID)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            if( element.cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeAgencyID!= null)
            {

        if(element.cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeAgencyID!= null)
        {
            int strlen_4 = element.cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeAgencyID.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = element.cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeAgencyID)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
*(optheader_3 + 0) |= 0x01;
            }

        if(element.cac_TaxCategory.cac_TaxScheme.cbc_ID.code!= null)
        {
            int strlen_4 = element.cac_TaxCategory.cac_TaxScheme.cbc_ID.code.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = element.cac_TaxCategory.cac_TaxScheme.cbc_ID.code)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }
            }
            }
            }
        }
        /// <summary>
        /// Inserts an element into a sorted list.
        /// </summary>
        /// <param name="element">The object to insert.</param>
        /// <param name="comparison"></param>
        public unsafe void Insert(Cac_TaxSubtotal element, Comparison<Cac_TaxSubtotal_Accessor> comparison)
        {
            byte* targetPtr = null;
            {
                
            {

            {

        if(element.cbc_TaxableAmount._CurrencyID!= null)
        {
            int strlen_2 = element.cbc_TaxableAmount._CurrencyID.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            {

        if(element.cbc_TaxAmount._CurrencyID!= null)
        {
            int strlen_2 = element.cbc_TaxAmount._CurrencyID.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            {

            {
            targetPtr += 1;

        if(element.cac_TaxCategory.cbc_ID._schemeID!= null)
        {
            int strlen_3 = element.cac_TaxCategory.cbc_ID._schemeID.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            if( element.cac_TaxCategory.cbc_ID._schemeAgencyID!= null)
            {

        if(element.cac_TaxCategory.cbc_ID._schemeAgencyID!= null)
        {
            int strlen_3 = element.cac_TaxCategory.cbc_ID._schemeAgencyID.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }

        if(element.cac_TaxCategory.cbc_ID.code!= null)
        {
            int strlen_3 = element.cac_TaxCategory.cbc_ID.code.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }            targetPtr += 8;

            {

            {
            targetPtr += 1;

        if(element.cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeID!= null)
        {
            int strlen_4 = element.cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeID.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            if( element.cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeAgencyID!= null)
            {

        if(element.cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeAgencyID!= null)
        {
            int strlen_4 = element.cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeAgencyID.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }

        if(element.cac_TaxCategory.cac_TaxScheme.cbc_ID.code!= null)
        {
            int strlen_4 = element.cac_TaxCategory.cac_TaxScheme.cbc_ID.code.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            }
            }
            }
            }
            int size = (int)targetPtr;
            targetPtr = m_ptr;
            byte* endPtr = m_ptr + length;
            while (targetPtr<endPtr)
            {
                
                {
                    elementAccessor.m_ptr = targetPtr + 4;
                    if (comparison(elementAccessor, element)<=0)
                    {
                        {{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{{            byte* optheader_5 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_5 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
targetPtr += *(int*)targetPtr + sizeof(int);}            targetPtr += 8;
{{            byte* optheader_7 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_7 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
targetPtr += *(int*)targetPtr + sizeof(int);}}}}
                    }
                    else
                    {
                        break;
                    }
                }
                
            }
            int offset = (int)(targetPtr - m_ptr);
            this.m_ptr = this.ResizeFunction(this.m_ptr - sizeof(int), offset + sizeof(int), size);
            *(int*)this.m_ptr += size;
            this.m_ptr += sizeof(int);
            targetPtr = this.m_ptr + offset;
            
            {

            {

        if(element.cbc_TaxableAmount._CurrencyID!= null)
        {
            int strlen_2 = element.cbc_TaxableAmount._CurrencyID.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = element.cbc_TaxableAmount._CurrencyID)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(double*)targetPtr = element.cbc_TaxableAmount.amount;
            targetPtr += 8;

            }
            {

        if(element.cbc_TaxAmount._CurrencyID!= null)
        {
            int strlen_2 = element.cbc_TaxAmount._CurrencyID.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = element.cbc_TaxAmount._CurrencyID)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(double*)targetPtr = element.cbc_TaxAmount.amount;
            targetPtr += 8;

            }
            {

            {
            byte* optheader_2 = targetPtr;
            *(optheader_2 + 0) = 0x00;            targetPtr += 1;

        if(element.cac_TaxCategory.cbc_ID._schemeID!= null)
        {
            int strlen_3 = element.cac_TaxCategory.cbc_ID._schemeID.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = element.cac_TaxCategory.cbc_ID._schemeID)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            if( element.cac_TaxCategory.cbc_ID._schemeAgencyID!= null)
            {

        if(element.cac_TaxCategory.cbc_ID._schemeAgencyID!= null)
        {
            int strlen_3 = element.cac_TaxCategory.cbc_ID._schemeAgencyID.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = element.cac_TaxCategory.cbc_ID._schemeAgencyID)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
*(optheader_2 + 0) |= 0x01;
            }

        if(element.cac_TaxCategory.cbc_ID.code!= null)
        {
            int strlen_3 = element.cac_TaxCategory.cbc_ID.code.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = element.cac_TaxCategory.cbc_ID.code)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }            *(double*)targetPtr = element.cac_TaxCategory.cbc_Percent;
            targetPtr += 8;

            {

            {
            byte* optheader_3 = targetPtr;
            *(optheader_3 + 0) = 0x00;            targetPtr += 1;

        if(element.cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeID!= null)
        {
            int strlen_4 = element.cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeID.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = element.cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeID)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            if( element.cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeAgencyID!= null)
            {

        if(element.cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeAgencyID!= null)
        {
            int strlen_4 = element.cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeAgencyID.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = element.cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeAgencyID)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
*(optheader_3 + 0) |= 0x01;
            }

        if(element.cac_TaxCategory.cac_TaxScheme.cbc_ID.code!= null)
        {
            int strlen_4 = element.cac_TaxCategory.cac_TaxScheme.cbc_ID.code.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = element.cac_TaxCategory.cac_TaxScheme.cbc_ID.code)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }
            }
            }
            }
        }
        /// <summary>
        /// Removes the element at the specified index of the List.
        /// </summary>
        /// <param name="index">The zero-based index of the element to remove.</param>
        public unsafe void RemoveAt(int index)
        {
            if (index < 0 || index >= Count) throw new IndexOutOfRangeException();
            byte* targetPtr = m_ptr;
            for (int i = 0; i < index; i++)
            {
                {{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{{            byte* optheader_5 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_5 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
targetPtr += *(int*)targetPtr + sizeof(int);}            targetPtr += 8;
{{            byte* optheader_7 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_7 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
targetPtr += *(int*)targetPtr + sizeof(int);}}}}
            }
            int offset = (int)(targetPtr - m_ptr);
            byte* oldtargetPtr = targetPtr;
            {{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{{            byte* optheader_5 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_5 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
targetPtr += *(int*)targetPtr + sizeof(int);}            targetPtr += 8;
{{            byte* optheader_7 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_7 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
targetPtr += *(int*)targetPtr + sizeof(int);}}}}
            int size = (int)(oldtargetPtr - targetPtr);
            this.m_ptr = this.ResizeFunction(this.m_ptr - sizeof(int), offset + sizeof(int), size);
            *(int*)this.m_ptr += size;
            this.m_ptr += sizeof(int);
        }
        /// <summary>
        /// Adds the elements of the specified collection to the end of the List
        /// </summary>
        /// <param name="collection">The collection whose elements should be added to the end of the List. The collection itself cannot be null.</param>
        public unsafe void AddRange(List<Cac_TaxSubtotal> collection)
        {
            if (collection == null) throw new ArgumentNullException("collection is null.");
            Cac_TaxSubtotal_AccessorListAccessor tcollection = collection;
            int delta = tcollection.length;
            m_ptr = ResizeFunction(m_ptr - 4, *(int*)(m_ptr - 4) + 4, delta);
            Memory.Copy(tcollection.m_ptr, m_ptr + *(int*)m_ptr + 4, delta);
            *(int*)m_ptr += delta;
            this.m_ptr += 4;
        }
        /// <summary>
        /// Adds the elements of the specified collection to the end of the List
        /// </summary>
        /// <param name="collection">The collection whose elements should be added to the end of the List. The collection itself cannot be null.</param>
        public unsafe void AddRange(Cac_TaxSubtotal_AccessorListAccessor collection)
        {
            if (collection == null) throw new ArgumentNullException("collection is null.");
            int delta = collection.length;
            if (collection.m_cellId != m_cellId)
            {
                m_ptr = ResizeFunction(m_ptr - 4, *(int*)(m_ptr - 4) + 4, delta);
                Memory.Copy(collection.m_ptr, m_ptr + *(int*)m_ptr + 4, delta);
                *(int*)m_ptr += delta;
            }
            else
            {
                byte[] tmpcell = new byte[delta];
                fixed (byte* tmpcellptr = tmpcell)
                {
                    Memory.Copy(collection.m_ptr, tmpcellptr, delta);
                    m_ptr = ResizeFunction(m_ptr - 4, *(int*)(m_ptr - 4) + 4, delta);
                    Memory.Copy(tmpcellptr, m_ptr + *(int*)m_ptr + 4, delta);
                    *(int*)m_ptr += delta;
                }
            }
            this.m_ptr += 4;
        }
        /// <summary>
        /// Removes all elements from the List
        /// </summary>
        public unsafe void Clear()
        {
            int delta = length;
            Memory.memset(m_ptr, 0, (ulong)delta);
            m_ptr = ResizeFunction(m_ptr - 4, 4, -delta);
            *(int*)m_ptr = 0;
            this.m_ptr += 4;
        }
        /// <summary>
        /// Determines whether an element is in the List
        /// </summary>
        /// <param name="item">The object to locate in the List.The value can be null for non-atom types</param>
        /// <returns>true if item is found in the List; otherwise, false.</returns>
        public unsafe bool Contains(Cac_TaxSubtotal_Accessor item)
        {
            bool ret = false;
            ForEach(x =>
            {
                if (item == x) ret = true;
            });
            return ret;
        }
        /// <summary>
        /// Determines whether the List contains elements that match the conditions defined by the specified predicate.
        /// </summary>
        /// <param name="match">The Predicate delegate that defines the conditions of the elements to search for.</param>
        /// <returns>true if the List contains one or more elements that match the conditions defined by the specified predicate; otherwise, false.</returns>
        public unsafe bool Exists(Predicate<Cac_TaxSubtotal_Accessor> match)
        {
            bool ret = false;
            ForEach(x =>
            {
                if (match(x)) ret = true;
            });
            return ret;
        }
        
        /// <summary>
        /// Copies the entire List to a compatible one-dimensional array, starting at the beginning of the ptr1 array.
        /// </summary>
        /// <param name="array">The one-dimensional Array that is the destination of the elements copied from List. The Array must have zero-based indexing.</param>
        public unsafe void CopyTo(Cac_TaxSubtotal[] array)
        {
            if (array == null) throw new ArgumentNullException("array is null.");
            if (array.Length < Count) throw new ArgumentException("The number of elements in the source List is greater than the number of elements that the destination array can contain.");
            ForEach((x, i) => array[i] = x);
        }
        /// <summary>
        /// Copies the entire List to a compatible one-dimensional array, starting at the specified index of the ptr1 array.
        /// </summary>
        /// <param name="array">The one-dimensional Array that is the destination of the elements copied from List. The Array must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
        public unsafe void CopyTo(Cac_TaxSubtotal[] array, int arrayIndex)
        {
            if (array == null) throw new ArgumentNullException("array is null.");
            if (arrayIndex < 0) throw new ArgumentOutOfRangeException("arrayIndex is less than 0.");
            if (array.Length - arrayIndex < Count) throw new ArgumentException("The number of elements in the source List is greater than the available space from arrayIndex to the end of the destination array.");
            ForEach((x, i) => array[i + arrayIndex] = x);
        }
        /// <summary>
        /// Copies a range of elements from the List to a compatible one-dimensional array, starting at the specified index of the ptr1 array.
        /// </summary>
        /// <param name="index">The zero-based index in the source List at which copying begins.</param>
        /// <param name="array">The one-dimensional Array that is the destination of the elements copied from List. The Array must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>;
        /// <param name="count">The number of elements to copy.</param>
        public unsafe void CopyTo(int index, Cac_TaxSubtotal[] array, int arrayIndex, int count)
        {
            if (array == null) throw new ArgumentNullException("array is null.");
            if (arrayIndex < 0 || index < 0 || count < 0) throw new ArgumentOutOfRangeException("arrayIndex is less than 0 or index is less than 0 or count is less than 0.");
            if (array.Length - arrayIndex < count) throw new ArgumentException("The number of elements from index to the end of the source List is greater than the available space from arrayIndex to the end of the destination array. ");
            if (index + count > Count) throw new ArgumentException("Source list does not have enough elements to copy.");
            int j = 0;
            for (int i = index; i < index + count; i++)
            {
                array[j + arrayIndex] = this[i];
                ++j;
            }
        }
          
        /// <summary>
        /// Inserts the elements of a collection into the List at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which the new elements should be inserted.</param>
        /// <param name="collection">The collection whose elements should be inserted into the List. The collection itself cannot be null, but it can contain elements that are null, if type T is a reference type.</param>
        public unsafe void InsertRange(int index, List<Cac_TaxSubtotal> collection)
        {
            if (collection == null) throw new ArgumentNullException("collection is null.");
            if (index < 0) throw new ArgumentOutOfRangeException("index is less than 0.");
            if (index > Count) throw new ArgumentOutOfRangeException("index is greater than Count.");
            Cac_TaxSubtotal_AccessorListAccessor tmpAccessor = collection;
            byte* targetPtr = m_ptr;
            for (int i = 0; i < index; i++)
            {
                {{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{{            byte* optheader_5 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_5 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
targetPtr += *(int*)targetPtr + sizeof(int);}            targetPtr += 8;
{{            byte* optheader_7 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_7 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
targetPtr += *(int*)targetPtr + sizeof(int);}}}}
            }
            int offset = (int)(targetPtr - m_ptr);
            m_ptr = ResizeFunction(m_ptr - 4, offset + 4, tmpAccessor.length);
            Memory.Copy(tmpAccessor.m_ptr, m_ptr + offset + 4, tmpAccessor.length);
            *(int*)m_ptr += tmpAccessor.length;
            this.m_ptr += 4;
        }
        /// <summary>
        /// Removes a range of elements from the List.
        /// </summary>
        /// <param name="index">The zero-based starting index of the range of elements to remove.</param>
        /// <param name="count">The number of elements to remove.</param>
        public unsafe void RemoveRange(int index, int count)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index is less than 0.");
            if (index > Count) throw new ArgumentOutOfRangeException("index is greater than Count.");
            if (index + count > Count) throw new ArgumentException("index and count do not denote a valid range of elements in the List.");
            byte* targetPtr = m_ptr;
            for (int i = 0; i < index; i++)
            {
                {{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{{            byte* optheader_5 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_5 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
targetPtr += *(int*)targetPtr + sizeof(int);}            targetPtr += 8;
{{            byte* optheader_7 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_7 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
targetPtr += *(int*)targetPtr + sizeof(int);}}}}
            }
            int offset = (int)(targetPtr - m_ptr);
            byte* oldtargetPtr = targetPtr;
            for (int i = 0; i < count; i++)
            {
                {{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{{            byte* optheader_5 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_5 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
targetPtr += *(int*)targetPtr + sizeof(int);}            targetPtr += 8;
{{            byte* optheader_7 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_7 + 0) & 0x01)))
                {
targetPtr += *(int*)targetPtr + sizeof(int);
                }
targetPtr += *(int*)targetPtr + sizeof(int);}}}}
            }
            int size = (int)(oldtargetPtr - targetPtr);
            m_ptr = ResizeFunction(m_ptr - 4, offset + 4, size);
            *(int*)m_ptr += size;
            this.m_ptr += 4;
        }
        public unsafe static implicit operator List<Cac_TaxSubtotal> (Cac_TaxSubtotal_AccessorListAccessor accessor)
        {
            if((object)accessor == null) return null;
            List<Cac_TaxSubtotal> list = new List<Cac_TaxSubtotal>();
            accessor.ForEach(element => list.Add(element));
            return list;
        }
        
        public unsafe static implicit operator Cac_TaxSubtotal_AccessorListAccessor(List<Cac_TaxSubtotal> field)
        {
            byte* targetPtr = null;
            
{

    targetPtr += sizeof(int);
    if(field!= null)
    {
        for(int iterator_1 = 0;iterator_1<field.Count;++iterator_1)
        {

            {

            {

        if(field[iterator_1].cbc_TaxableAmount._CurrencyID!= null)
        {
            int strlen_4 = field[iterator_1].cbc_TaxableAmount._CurrencyID.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            {

        if(field[iterator_1].cbc_TaxAmount._CurrencyID!= null)
        {
            int strlen_4 = field[iterator_1].cbc_TaxAmount._CurrencyID.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            {

            {
            targetPtr += 1;

        if(field[iterator_1].cac_TaxCategory.cbc_ID._schemeID!= null)
        {
            int strlen_5 = field[iterator_1].cac_TaxCategory.cbc_ID._schemeID.Length * 2;
            targetPtr += strlen_5+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            if( field[iterator_1].cac_TaxCategory.cbc_ID._schemeAgencyID!= null)
            {

        if(field[iterator_1].cac_TaxCategory.cbc_ID._schemeAgencyID!= null)
        {
            int strlen_5 = field[iterator_1].cac_TaxCategory.cbc_ID._schemeAgencyID.Length * 2;
            targetPtr += strlen_5+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }

        if(field[iterator_1].cac_TaxCategory.cbc_ID.code!= null)
        {
            int strlen_5 = field[iterator_1].cac_TaxCategory.cbc_ID.code.Length * 2;
            targetPtr += strlen_5+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }            targetPtr += 8;

            {

            {
            targetPtr += 1;

        if(field[iterator_1].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeID!= null)
        {
            int strlen_6 = field[iterator_1].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeID.Length * 2;
            targetPtr += strlen_6+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            if( field[iterator_1].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeAgencyID!= null)
            {

        if(field[iterator_1].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeAgencyID!= null)
        {
            int strlen_6 = field[iterator_1].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeAgencyID.Length * 2;
            targetPtr += strlen_6+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }

        if(field[iterator_1].cac_TaxCategory.cac_TaxScheme.cbc_ID.code!= null)
        {
            int strlen_6 = field[iterator_1].cac_TaxCategory.cac_TaxScheme.cbc_ID.code.Length * 2;
            targetPtr += strlen_6+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            }
            }
            }
        }
    }

}

            byte* tmpcellptr = BufferAllocator.AllocBuffer((int)targetPtr);
            Memory.memset(tmpcellptr, 0, (ulong)targetPtr);
            targetPtr = tmpcellptr;
            
{
byte *storedPtr_1 = targetPtr;

    targetPtr += sizeof(int);
    if(field!= null)
    {
        for(int iterator_1 = 0;iterator_1<field.Count;++iterator_1)
        {

            {

            {

        if(field[iterator_1].cbc_TaxableAmount._CurrencyID!= null)
        {
            int strlen_4 = field[iterator_1].cbc_TaxableAmount._CurrencyID.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = field[iterator_1].cbc_TaxableAmount._CurrencyID)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(double*)targetPtr = field[iterator_1].cbc_TaxableAmount.amount;
            targetPtr += 8;

            }
            {

        if(field[iterator_1].cbc_TaxAmount._CurrencyID!= null)
        {
            int strlen_4 = field[iterator_1].cbc_TaxAmount._CurrencyID.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = field[iterator_1].cbc_TaxAmount._CurrencyID)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(double*)targetPtr = field[iterator_1].cbc_TaxAmount.amount;
            targetPtr += 8;

            }
            {

            {
            byte* optheader_4 = targetPtr;
            *(optheader_4 + 0) = 0x00;            targetPtr += 1;

        if(field[iterator_1].cac_TaxCategory.cbc_ID._schemeID!= null)
        {
            int strlen_5 = field[iterator_1].cac_TaxCategory.cbc_ID._schemeID.Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = field[iterator_1].cac_TaxCategory.cbc_ID._schemeID)
            {
                Memory.Copy(pstr_5, targetPtr, strlen_5);
                targetPtr += strlen_5;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            if( field[iterator_1].cac_TaxCategory.cbc_ID._schemeAgencyID!= null)
            {

        if(field[iterator_1].cac_TaxCategory.cbc_ID._schemeAgencyID!= null)
        {
            int strlen_5 = field[iterator_1].cac_TaxCategory.cbc_ID._schemeAgencyID.Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = field[iterator_1].cac_TaxCategory.cbc_ID._schemeAgencyID)
            {
                Memory.Copy(pstr_5, targetPtr, strlen_5);
                targetPtr += strlen_5;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
*(optheader_4 + 0) |= 0x01;
            }

        if(field[iterator_1].cac_TaxCategory.cbc_ID.code!= null)
        {
            int strlen_5 = field[iterator_1].cac_TaxCategory.cbc_ID.code.Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = field[iterator_1].cac_TaxCategory.cbc_ID.code)
            {
                Memory.Copy(pstr_5, targetPtr, strlen_5);
                targetPtr += strlen_5;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }            *(double*)targetPtr = field[iterator_1].cac_TaxCategory.cbc_Percent;
            targetPtr += 8;

            {

            {
            byte* optheader_5 = targetPtr;
            *(optheader_5 + 0) = 0x00;            targetPtr += 1;

        if(field[iterator_1].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeID!= null)
        {
            int strlen_6 = field[iterator_1].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeID.Length * 2;
            *(int*)targetPtr = strlen_6;
            targetPtr += sizeof(int);
            fixed(char* pstr_6 = field[iterator_1].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeID)
            {
                Memory.Copy(pstr_6, targetPtr, strlen_6);
                targetPtr += strlen_6;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            if( field[iterator_1].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeAgencyID!= null)
            {

        if(field[iterator_1].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeAgencyID!= null)
        {
            int strlen_6 = field[iterator_1].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeAgencyID.Length * 2;
            *(int*)targetPtr = strlen_6;
            targetPtr += sizeof(int);
            fixed(char* pstr_6 = field[iterator_1].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeAgencyID)
            {
                Memory.Copy(pstr_6, targetPtr, strlen_6);
                targetPtr += strlen_6;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
*(optheader_5 + 0) |= 0x01;
            }

        if(field[iterator_1].cac_TaxCategory.cac_TaxScheme.cbc_ID.code!= null)
        {
            int strlen_6 = field[iterator_1].cac_TaxCategory.cac_TaxScheme.cbc_ID.code.Length * 2;
            *(int*)targetPtr = strlen_6;
            targetPtr += sizeof(int);
            fixed(char* pstr_6 = field[iterator_1].cac_TaxCategory.cac_TaxScheme.cbc_ID.code)
            {
                Memory.Copy(pstr_6, targetPtr, strlen_6);
                targetPtr += strlen_6;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }
            }
            }
            }
        }
    }
*(int*)storedPtr_1 = (int)(targetPtr - storedPtr_1 - 4);

}
Cac_TaxSubtotal_AccessorListAccessor ret;
            
            ret = new Cac_TaxSubtotal_AccessorListAccessor(tmpcellptr, null);
            
            return ret;
        }
        
        public static bool operator ==(Cac_TaxSubtotal_AccessorListAccessor a, Cac_TaxSubtotal_AccessorListAccessor b)
        {
            if (ReferenceEquals(a, b))
                return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;
            if (a.m_ptr == b.m_ptr) return true;
            if (a.length != b.length) return false;
            return Memory.Compare(a.m_ptr, b.m_ptr, a.length);
        }
        public static bool operator !=(Cac_TaxSubtotal_AccessorListAccessor a, Cac_TaxSubtotal_AccessorListAccessor b)
        {
            return !(a == b);
        }
    }
}

namespace TDW.TRAServer
{
    
    public unsafe class Cbc_ListCode_AccessorListAccessor : IEnumerable<Cbc_ListCode_Accessor>
    {
        internal byte* m_ptr;
        internal long m_cellId;
        internal ResizeFunctionDelegate ResizeFunction;
        internal Cbc_ListCode_AccessorListAccessor(byte* _CellPtr, ResizeFunctionDelegate func)
        {
            m_ptr = _CellPtr;
            ResizeFunction = func;
            m_ptr += 4;
                    elementAccessor = new Cbc_ListCode_Accessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.m_ptr = this.ResizeFunction(this.m_ptr-sizeof(int), ptr_offset + substructure_offset +sizeof(int), delta);
                    *(int*)this.m_ptr += delta;
                    this.m_ptr += sizeof(int);
                    return this.m_ptr + substructure_offset;
                });
        }
        internal int length
        {
            get
            {
                return *(int*)(m_ptr - 4);
            }
        }
        Cbc_ListCode_Accessor elementAccessor;
        
        /// <summary>
        /// Gets the number of elements actually contained in the List. 
        /// </summary>";
        public unsafe int Count
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                byte* endPtr = m_ptr + length;
                int ret = 0;
                while (targetPtr < endPtr)
                {
                    {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
                    ++ret;
                }
                return ret;
                
            }
        }
        /// <summary>
        /// Gets or sets the element at the specified index. 
        /// </summary>
        /// <param name="index">Given index</param>
        /// <returns>Corresponding element at the specified index</returns>";
        public unsafe Cbc_ListCode_Accessor this[int index]
        {
            get
            {
                
                {
                    
                    {
                        byte* targetPtr = m_ptr;
                        while (index-- > 0)
                        {
                            {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
                        }
                        
                        elementAccessor.m_ptr = targetPtr;
                        
                    }
                    
                    elementAccessor.m_cellId = this.m_cellId;
                    return elementAccessor;
                }
                
            }
            set
            {
                
                {
                    if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                    elementAccessor.m_cellId = this.m_cellId;
                    byte* targetPtr = m_ptr;
                    
                    while (index-- > 0)
                    {
                        {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
                    }
                    
                int offset = (int)(targetPtr - m_ptr);
                byte* oldtargetPtr = targetPtr;
                int oldlength = (int)(targetPtr - oldtargetPtr);
                targetPtr = value.m_ptr;
                int newlength = (int)(targetPtr - value.m_ptr);
                if (newlength != oldlength)
                {
                    if (value.m_cellId != this.m_cellId)
                    {
                        this.m_ptr = this.ResizeFunction(this.m_ptr, offset, newlength - oldlength);
                        Memory.Copy(value.m_ptr, this.m_ptr + offset, newlength);
                    }
                    else
                    {
                        byte[] tmpcell = new byte[newlength];
                        fixed(byte* tmpcellptr = tmpcell)
                        {
                            Memory.Copy(value.m_ptr, tmpcellptr, newlength);
                            this.m_ptr = this.ResizeFunction(this.m_ptr, offset, newlength - oldlength);
                            Memory.Copy(tmpcellptr, this.m_ptr + offset, newlength);
                        }
                    }
                }
                else
                {
                    Memory.Copy(value.m_ptr, oldtargetPtr, oldlength);
                }
                }
                
            }
        }
        /// <summary>
        /// Copies the elements to a new byte array
        /// </summary>
        /// <returns>Elements compactly arranged in a byte array.</returns>
        public unsafe byte[] ToByteArray()
        {
            byte[] ret = new byte[length];
            fixed (byte* retptr = ret)
            {
                Memory.Copy(m_ptr, retptr, length);
                return ret;
            }
        }
        /// <summary>
        /// Performs the specified action on each elements
        /// </summary>
        /// <param name="action">A lambda expression which has one parameter indicates element in List</param>
        public unsafe void ForEach(Action<Cbc_ListCode_Accessor> action)
        {
            byte* targetPtr = m_ptr;
            byte* endPtr = m_ptr + length;
            
            elementAccessor.m_cellId = this.m_cellId;
            
            while (targetPtr < endPtr)
            {
                
                {
                    elementAccessor.m_ptr = targetPtr;
                    action(elementAccessor);
                    {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
                }
                
            }
        }
        /// <summary>
        /// Performs the specified action on each elements
        /// </summary>
        /// <param name="action">A lambda expression which has two parameters. First indicates element in the List and second the index of this element.</param>
        public unsafe void ForEach(Action<Cbc_ListCode_Accessor, int> action)
        {
            byte* targetPtr = m_ptr;
            byte* endPtr = m_ptr + length;
            for (int index = 0; targetPtr < endPtr; ++index)
            {
                
                {
                    elementAccessor.m_ptr = targetPtr;
                    action(elementAccessor, index);
                    {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
                }
                
            }
        }
        internal unsafe struct _iterator
        {
            byte* targetPtr;
            byte* endPtr;
            Cbc_ListCode_AccessorListAccessor target;
            internal _iterator(Cbc_ListCode_AccessorListAccessor target)
            {
                targetPtr = target.m_ptr;
                endPtr = targetPtr + target.length;
                this.target = target;
            }
            internal bool good()
            {
                return (targetPtr < endPtr);
            }
            internal Cbc_ListCode_Accessor current()
            {
                
                {
                    target.elementAccessor.m_ptr = targetPtr;
                    return target.elementAccessor;
                }
                
            }
            internal void move_next()
            {
                 
                {
                    {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
                }
                
            }
        }
        public IEnumerator<Cbc_ListCode_Accessor> GetEnumerator()
        {
            _iterator _it = new _iterator(this);
            while (_it.good())
            {
                yield return _it.current();
                _it.move_next();
            }
        }
        unsafe IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        /// <summary>
        /// Adds an item to the end of the List
        /// </summary>
        /// <param name="element">The object to be added to the end of the List.</param>
        public unsafe void Add(Cbc_ListCode element)
        {
            byte* targetPtr = null;
            {
                
            {

        if(element._listID!= null)
        {
            int strlen_1 = element._listID.Length * 2;
            targetPtr += strlen_1+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(element._listAgencyID!= null)
        {
            int strlen_1 = element._listAgencyID.Length * 2;
            targetPtr += strlen_1+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(element.code!= null)
        {
            int strlen_1 = element.code.Length * 2;
            targetPtr += strlen_1+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            }
            int size = (int)targetPtr;
            this.m_ptr = this.ResizeFunction(this.m_ptr - sizeof(int), *(int*)(this.m_ptr-sizeof(int))+sizeof(int), size);
            targetPtr = this.m_ptr + (*(int*)this.m_ptr)+sizeof(int);
            *(int*)this.m_ptr += size;
            this.m_ptr += sizeof(int);
            
            {

        if(element._listID!= null)
        {
            int strlen_1 = element._listID.Length * 2;
            *(int*)targetPtr = strlen_1;
            targetPtr += sizeof(int);
            fixed(char* pstr_1 = element._listID)
            {
                Memory.Copy(pstr_1, targetPtr, strlen_1);
                targetPtr += strlen_1;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(element._listAgencyID!= null)
        {
            int strlen_1 = element._listAgencyID.Length * 2;
            *(int*)targetPtr = strlen_1;
            targetPtr += sizeof(int);
            fixed(char* pstr_1 = element._listAgencyID)
            {
                Memory.Copy(pstr_1, targetPtr, strlen_1);
                targetPtr += strlen_1;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(element.code!= null)
        {
            int strlen_1 = element.code.Length * 2;
            *(int*)targetPtr = strlen_1;
            targetPtr += sizeof(int);
            fixed(char* pstr_1 = element.code)
            {
                Memory.Copy(pstr_1, targetPtr, strlen_1);
                targetPtr += strlen_1;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }
        }
        /// <summary>
        /// Inserts an element into the List at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which item should be inserted.</param>
        /// <param name="element">The object to insert.</param>
        public unsafe void Insert(int index, Cbc_ListCode element)
        {
            if (index < 0 || index > Count) throw new IndexOutOfRangeException();
            byte* targetPtr = null;
            {
                
            {

        if(element._listID!= null)
        {
            int strlen_1 = element._listID.Length * 2;
            targetPtr += strlen_1+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(element._listAgencyID!= null)
        {
            int strlen_1 = element._listAgencyID.Length * 2;
            targetPtr += strlen_1+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(element.code!= null)
        {
            int strlen_1 = element.code.Length * 2;
            targetPtr += strlen_1+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            }
            int size = (int)targetPtr;
            targetPtr = m_ptr;
            
            for (int i = 0; i < index; i++)
            {
                {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
            }
            
            int offset = (int)(targetPtr - m_ptr);
            this.m_ptr = this.ResizeFunction(this.m_ptr - sizeof(int), offset + sizeof(int), size);
            *(int*)this.m_ptr += size;
            this.m_ptr += sizeof(int);
            targetPtr = this.m_ptr + offset;
            
            {

        if(element._listID!= null)
        {
            int strlen_1 = element._listID.Length * 2;
            *(int*)targetPtr = strlen_1;
            targetPtr += sizeof(int);
            fixed(char* pstr_1 = element._listID)
            {
                Memory.Copy(pstr_1, targetPtr, strlen_1);
                targetPtr += strlen_1;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(element._listAgencyID!= null)
        {
            int strlen_1 = element._listAgencyID.Length * 2;
            *(int*)targetPtr = strlen_1;
            targetPtr += sizeof(int);
            fixed(char* pstr_1 = element._listAgencyID)
            {
                Memory.Copy(pstr_1, targetPtr, strlen_1);
                targetPtr += strlen_1;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(element.code!= null)
        {
            int strlen_1 = element.code.Length * 2;
            *(int*)targetPtr = strlen_1;
            targetPtr += sizeof(int);
            fixed(char* pstr_1 = element.code)
            {
                Memory.Copy(pstr_1, targetPtr, strlen_1);
                targetPtr += strlen_1;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }
        }
        /// <summary>
        /// Inserts an element into a sorted list.
        /// </summary>
        /// <param name="element">The object to insert.</param>
        /// <param name="comparison"></param>
        public unsafe void Insert(Cbc_ListCode element, Comparison<Cbc_ListCode_Accessor> comparison)
        {
            byte* targetPtr = null;
            {
                
            {

        if(element._listID!= null)
        {
            int strlen_1 = element._listID.Length * 2;
            targetPtr += strlen_1+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(element._listAgencyID!= null)
        {
            int strlen_1 = element._listAgencyID.Length * 2;
            targetPtr += strlen_1+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(element.code!= null)
        {
            int strlen_1 = element.code.Length * 2;
            targetPtr += strlen_1+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            }
            int size = (int)targetPtr;
            targetPtr = m_ptr;
            byte* endPtr = m_ptr + length;
            while (targetPtr<endPtr)
            {
                
                {
                    elementAccessor.m_ptr = targetPtr + 4;
                    if (comparison(elementAccessor, element)<=0)
                    {
                        {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
                    }
                    else
                    {
                        break;
                    }
                }
                
            }
            int offset = (int)(targetPtr - m_ptr);
            this.m_ptr = this.ResizeFunction(this.m_ptr - sizeof(int), offset + sizeof(int), size);
            *(int*)this.m_ptr += size;
            this.m_ptr += sizeof(int);
            targetPtr = this.m_ptr + offset;
            
            {

        if(element._listID!= null)
        {
            int strlen_1 = element._listID.Length * 2;
            *(int*)targetPtr = strlen_1;
            targetPtr += sizeof(int);
            fixed(char* pstr_1 = element._listID)
            {
                Memory.Copy(pstr_1, targetPtr, strlen_1);
                targetPtr += strlen_1;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(element._listAgencyID!= null)
        {
            int strlen_1 = element._listAgencyID.Length * 2;
            *(int*)targetPtr = strlen_1;
            targetPtr += sizeof(int);
            fixed(char* pstr_1 = element._listAgencyID)
            {
                Memory.Copy(pstr_1, targetPtr, strlen_1);
                targetPtr += strlen_1;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(element.code!= null)
        {
            int strlen_1 = element.code.Length * 2;
            *(int*)targetPtr = strlen_1;
            targetPtr += sizeof(int);
            fixed(char* pstr_1 = element.code)
            {
                Memory.Copy(pstr_1, targetPtr, strlen_1);
                targetPtr += strlen_1;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }
        }
        /// <summary>
        /// Removes the element at the specified index of the List.
        /// </summary>
        /// <param name="index">The zero-based index of the element to remove.</param>
        public unsafe void RemoveAt(int index)
        {
            if (index < 0 || index >= Count) throw new IndexOutOfRangeException();
            byte* targetPtr = m_ptr;
            for (int i = 0; i < index; i++)
            {
                {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
            }
            int offset = (int)(targetPtr - m_ptr);
            byte* oldtargetPtr = targetPtr;
            {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
            int size = (int)(oldtargetPtr - targetPtr);
            this.m_ptr = this.ResizeFunction(this.m_ptr - sizeof(int), offset + sizeof(int), size);
            *(int*)this.m_ptr += size;
            this.m_ptr += sizeof(int);
        }
        /// <summary>
        /// Adds the elements of the specified collection to the end of the List
        /// </summary>
        /// <param name="collection">The collection whose elements should be added to the end of the List. The collection itself cannot be null.</param>
        public unsafe void AddRange(List<Cbc_ListCode> collection)
        {
            if (collection == null) throw new ArgumentNullException("collection is null.");
            Cbc_ListCode_AccessorListAccessor tcollection = collection;
            int delta = tcollection.length;
            m_ptr = ResizeFunction(m_ptr - 4, *(int*)(m_ptr - 4) + 4, delta);
            Memory.Copy(tcollection.m_ptr, m_ptr + *(int*)m_ptr + 4, delta);
            *(int*)m_ptr += delta;
            this.m_ptr += 4;
        }
        /// <summary>
        /// Adds the elements of the specified collection to the end of the List
        /// </summary>
        /// <param name="collection">The collection whose elements should be added to the end of the List. The collection itself cannot be null.</param>
        public unsafe void AddRange(Cbc_ListCode_AccessorListAccessor collection)
        {
            if (collection == null) throw new ArgumentNullException("collection is null.");
            int delta = collection.length;
            if (collection.m_cellId != m_cellId)
            {
                m_ptr = ResizeFunction(m_ptr - 4, *(int*)(m_ptr - 4) + 4, delta);
                Memory.Copy(collection.m_ptr, m_ptr + *(int*)m_ptr + 4, delta);
                *(int*)m_ptr += delta;
            }
            else
            {
                byte[] tmpcell = new byte[delta];
                fixed (byte* tmpcellptr = tmpcell)
                {
                    Memory.Copy(collection.m_ptr, tmpcellptr, delta);
                    m_ptr = ResizeFunction(m_ptr - 4, *(int*)(m_ptr - 4) + 4, delta);
                    Memory.Copy(tmpcellptr, m_ptr + *(int*)m_ptr + 4, delta);
                    *(int*)m_ptr += delta;
                }
            }
            this.m_ptr += 4;
        }
        /// <summary>
        /// Removes all elements from the List
        /// </summary>
        public unsafe void Clear()
        {
            int delta = length;
            Memory.memset(m_ptr, 0, (ulong)delta);
            m_ptr = ResizeFunction(m_ptr - 4, 4, -delta);
            *(int*)m_ptr = 0;
            this.m_ptr += 4;
        }
        /// <summary>
        /// Determines whether an element is in the List
        /// </summary>
        /// <param name="item">The object to locate in the List.The value can be null for non-atom types</param>
        /// <returns>true if item is found in the List; otherwise, false.</returns>
        public unsafe bool Contains(Cbc_ListCode_Accessor item)
        {
            bool ret = false;
            ForEach(x =>
            {
                if (item == x) ret = true;
            });
            return ret;
        }
        /// <summary>
        /// Determines whether the List contains elements that match the conditions defined by the specified predicate.
        /// </summary>
        /// <param name="match">The Predicate delegate that defines the conditions of the elements to search for.</param>
        /// <returns>true if the List contains one or more elements that match the conditions defined by the specified predicate; otherwise, false.</returns>
        public unsafe bool Exists(Predicate<Cbc_ListCode_Accessor> match)
        {
            bool ret = false;
            ForEach(x =>
            {
                if (match(x)) ret = true;
            });
            return ret;
        }
        
        /// <summary>
        /// Copies the entire List to a compatible one-dimensional array, starting at the beginning of the ptr1 array.
        /// </summary>
        /// <param name="array">The one-dimensional Array that is the destination of the elements copied from List. The Array must have zero-based indexing.</param>
        public unsafe void CopyTo(Cbc_ListCode[] array)
        {
            if (array == null) throw new ArgumentNullException("array is null.");
            if (array.Length < Count) throw new ArgumentException("The number of elements in the source List is greater than the number of elements that the destination array can contain.");
            ForEach((x, i) => array[i] = x);
        }
        /// <summary>
        /// Copies the entire List to a compatible one-dimensional array, starting at the specified index of the ptr1 array.
        /// </summary>
        /// <param name="array">The one-dimensional Array that is the destination of the elements copied from List. The Array must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
        public unsafe void CopyTo(Cbc_ListCode[] array, int arrayIndex)
        {
            if (array == null) throw new ArgumentNullException("array is null.");
            if (arrayIndex < 0) throw new ArgumentOutOfRangeException("arrayIndex is less than 0.");
            if (array.Length - arrayIndex < Count) throw new ArgumentException("The number of elements in the source List is greater than the available space from arrayIndex to the end of the destination array.");
            ForEach((x, i) => array[i + arrayIndex] = x);
        }
        /// <summary>
        /// Copies a range of elements from the List to a compatible one-dimensional array, starting at the specified index of the ptr1 array.
        /// </summary>
        /// <param name="index">The zero-based index in the source List at which copying begins.</param>
        /// <param name="array">The one-dimensional Array that is the destination of the elements copied from List. The Array must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>;
        /// <param name="count">The number of elements to copy.</param>
        public unsafe void CopyTo(int index, Cbc_ListCode[] array, int arrayIndex, int count)
        {
            if (array == null) throw new ArgumentNullException("array is null.");
            if (arrayIndex < 0 || index < 0 || count < 0) throw new ArgumentOutOfRangeException("arrayIndex is less than 0 or index is less than 0 or count is less than 0.");
            if (array.Length - arrayIndex < count) throw new ArgumentException("The number of elements from index to the end of the source List is greater than the available space from arrayIndex to the end of the destination array. ");
            if (index + count > Count) throw new ArgumentException("Source list does not have enough elements to copy.");
            int j = 0;
            for (int i = index; i < index + count; i++)
            {
                array[j + arrayIndex] = this[i];
                ++j;
            }
        }
          
        /// <summary>
        /// Inserts the elements of a collection into the List at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which the new elements should be inserted.</param>
        /// <param name="collection">The collection whose elements should be inserted into the List. The collection itself cannot be null, but it can contain elements that are null, if type T is a reference type.</param>
        public unsafe void InsertRange(int index, List<Cbc_ListCode> collection)
        {
            if (collection == null) throw new ArgumentNullException("collection is null.");
            if (index < 0) throw new ArgumentOutOfRangeException("index is less than 0.");
            if (index > Count) throw new ArgumentOutOfRangeException("index is greater than Count.");
            Cbc_ListCode_AccessorListAccessor tmpAccessor = collection;
            byte* targetPtr = m_ptr;
            for (int i = 0; i < index; i++)
            {
                {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
            }
            int offset = (int)(targetPtr - m_ptr);
            m_ptr = ResizeFunction(m_ptr - 4, offset + 4, tmpAccessor.length);
            Memory.Copy(tmpAccessor.m_ptr, m_ptr + offset + 4, tmpAccessor.length);
            *(int*)m_ptr += tmpAccessor.length;
            this.m_ptr += 4;
        }
        /// <summary>
        /// Removes a range of elements from the List.
        /// </summary>
        /// <param name="index">The zero-based starting index of the range of elements to remove.</param>
        /// <param name="count">The number of elements to remove.</param>
        public unsafe void RemoveRange(int index, int count)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index is less than 0.");
            if (index > Count) throw new ArgumentOutOfRangeException("index is greater than Count.");
            if (index + count > Count) throw new ArgumentException("index and count do not denote a valid range of elements in the List.");
            byte* targetPtr = m_ptr;
            for (int i = 0; i < index; i++)
            {
                {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
            }
            int offset = (int)(targetPtr - m_ptr);
            byte* oldtargetPtr = targetPtr;
            for (int i = 0; i < count; i++)
            {
                {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
            }
            int size = (int)(oldtargetPtr - targetPtr);
            m_ptr = ResizeFunction(m_ptr - 4, offset + 4, size);
            *(int*)m_ptr += size;
            this.m_ptr += 4;
        }
        public unsafe static implicit operator List<Cbc_ListCode> (Cbc_ListCode_AccessorListAccessor accessor)
        {
            if((object)accessor == null) return null;
            List<Cbc_ListCode> list = new List<Cbc_ListCode>();
            accessor.ForEach(element => list.Add(element));
            return list;
        }
        
        public unsafe static implicit operator Cbc_ListCode_AccessorListAccessor(List<Cbc_ListCode> field)
        {
            byte* targetPtr = null;
            
{

    targetPtr += sizeof(int);
    if(field!= null)
    {
        for(int iterator_1 = 0;iterator_1<field.Count;++iterator_1)
        {

            {

        if(field[iterator_1]._listID!= null)
        {
            int strlen_3 = field[iterator_1]._listID.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(field[iterator_1]._listAgencyID!= null)
        {
            int strlen_3 = field[iterator_1]._listAgencyID.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(field[iterator_1].code!= null)
        {
            int strlen_3 = field[iterator_1].code.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
        }
    }

}

            byte* tmpcellptr = BufferAllocator.AllocBuffer((int)targetPtr);
            Memory.memset(tmpcellptr, 0, (ulong)targetPtr);
            targetPtr = tmpcellptr;
            
{
byte *storedPtr_1 = targetPtr;

    targetPtr += sizeof(int);
    if(field!= null)
    {
        for(int iterator_1 = 0;iterator_1<field.Count;++iterator_1)
        {

            {

        if(field[iterator_1]._listID!= null)
        {
            int strlen_3 = field[iterator_1]._listID.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = field[iterator_1]._listID)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(field[iterator_1]._listAgencyID!= null)
        {
            int strlen_3 = field[iterator_1]._listAgencyID.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = field[iterator_1]._listAgencyID)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(field[iterator_1].code!= null)
        {
            int strlen_3 = field[iterator_1].code.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = field[iterator_1].code)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }
        }
    }
*(int*)storedPtr_1 = (int)(targetPtr - storedPtr_1 - 4);

}
Cbc_ListCode_AccessorListAccessor ret;
            
            ret = new Cbc_ListCode_AccessorListAccessor(tmpcellptr, null);
            
            return ret;
        }
        
        public static bool operator ==(Cbc_ListCode_AccessorListAccessor a, Cbc_ListCode_AccessorListAccessor b)
        {
            if (ReferenceEquals(a, b))
                return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;
            if (a.m_ptr == b.m_ptr) return true;
            if (a.length != b.length) return false;
            return Memory.Compare(a.m_ptr, b.m_ptr, a.length);
        }
        public static bool operator !=(Cbc_ListCode_AccessorListAccessor a, Cbc_ListCode_AccessorListAccessor b)
        {
            return !(a == b);
        }
    }
}

namespace TDW.TRAServer
{
    
    public unsafe class Cac_DocumentReference_AccessorListAccessor : IEnumerable<Cac_DocumentReference_Accessor>
    {
        internal byte* m_ptr;
        internal long m_cellId;
        internal ResizeFunctionDelegate ResizeFunction;
        internal Cac_DocumentReference_AccessorListAccessor(byte* _CellPtr, ResizeFunctionDelegate func)
        {
            m_ptr = _CellPtr;
            ResizeFunction = func;
            m_ptr += 4;
                    elementAccessor = new Cac_DocumentReference_Accessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.m_ptr = this.ResizeFunction(this.m_ptr-sizeof(int), ptr_offset + substructure_offset +sizeof(int), delta);
                    *(int*)this.m_ptr += delta;
                    this.m_ptr += sizeof(int);
                    return this.m_ptr + substructure_offset;
                });
        }
        internal int length
        {
            get
            {
                return *(int*)(m_ptr - 4);
            }
        }
        Cac_DocumentReference_Accessor elementAccessor;
        
        /// <summary>
        /// Gets the number of elements actually contained in the List. 
        /// </summary>";
        public unsafe int Count
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                byte* endPtr = m_ptr + length;
                int ret = 0;
                while (targetPtr < endPtr)
                {
                    {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_1 + 0) & 0x01)))
                {
{targetPtr += *(int*)targetPtr + sizeof(int);}
                }
}
                    ++ret;
                }
                return ret;
                
            }
        }
        /// <summary>
        /// Gets or sets the element at the specified index. 
        /// </summary>
        /// <param name="index">Given index</param>
        /// <returns>Corresponding element at the specified index</returns>";
        public unsafe Cac_DocumentReference_Accessor this[int index]
        {
            get
            {
                
                {
                    
                    {
                        byte* targetPtr = m_ptr;
                        while (index-- > 0)
                        {
                            {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_1 + 0) & 0x01)))
                {
{targetPtr += *(int*)targetPtr + sizeof(int);}
                }
}
                        }
                        
                        elementAccessor.m_ptr = targetPtr;
                        
                    }
                    
                    elementAccessor.m_cellId = this.m_cellId;
                    return elementAccessor;
                }
                
            }
            set
            {
                
                {
                    if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                    elementAccessor.m_cellId = this.m_cellId;
                    byte* targetPtr = m_ptr;
                    
                    while (index-- > 0)
                    {
                        {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_1 + 0) & 0x01)))
                {
{targetPtr += *(int*)targetPtr + sizeof(int);}
                }
}
                    }
                    
                int offset = (int)(targetPtr - m_ptr);
                byte* oldtargetPtr = targetPtr;
                int oldlength = (int)(targetPtr - oldtargetPtr);
                targetPtr = value.m_ptr;
                int newlength = (int)(targetPtr - value.m_ptr);
                if (newlength != oldlength)
                {
                    if (value.m_cellId != this.m_cellId)
                    {
                        this.m_ptr = this.ResizeFunction(this.m_ptr, offset, newlength - oldlength);
                        Memory.Copy(value.m_ptr, this.m_ptr + offset, newlength);
                    }
                    else
                    {
                        byte[] tmpcell = new byte[newlength];
                        fixed(byte* tmpcellptr = tmpcell)
                        {
                            Memory.Copy(value.m_ptr, tmpcellptr, newlength);
                            this.m_ptr = this.ResizeFunction(this.m_ptr, offset, newlength - oldlength);
                            Memory.Copy(tmpcellptr, this.m_ptr + offset, newlength);
                        }
                    }
                }
                else
                {
                    Memory.Copy(value.m_ptr, oldtargetPtr, oldlength);
                }
                }
                
            }
        }
        /// <summary>
        /// Copies the elements to a new byte array
        /// </summary>
        /// <returns>Elements compactly arranged in a byte array.</returns>
        public unsafe byte[] ToByteArray()
        {
            byte[] ret = new byte[length];
            fixed (byte* retptr = ret)
            {
                Memory.Copy(m_ptr, retptr, length);
                return ret;
            }
        }
        /// <summary>
        /// Performs the specified action on each elements
        /// </summary>
        /// <param name="action">A lambda expression which has one parameter indicates element in List</param>
        public unsafe void ForEach(Action<Cac_DocumentReference_Accessor> action)
        {
            byte* targetPtr = m_ptr;
            byte* endPtr = m_ptr + length;
            
            elementAccessor.m_cellId = this.m_cellId;
            
            while (targetPtr < endPtr)
            {
                
                {
                    elementAccessor.m_ptr = targetPtr;
                    action(elementAccessor);
                    {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_1 + 0) & 0x01)))
                {
{targetPtr += *(int*)targetPtr + sizeof(int);}
                }
}
                }
                
            }
        }
        /// <summary>
        /// Performs the specified action on each elements
        /// </summary>
        /// <param name="action">A lambda expression which has two parameters. First indicates element in the List and second the index of this element.</param>
        public unsafe void ForEach(Action<Cac_DocumentReference_Accessor, int> action)
        {
            byte* targetPtr = m_ptr;
            byte* endPtr = m_ptr + length;
            for (int index = 0; targetPtr < endPtr; ++index)
            {
                
                {
                    elementAccessor.m_ptr = targetPtr;
                    action(elementAccessor, index);
                    {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_1 + 0) & 0x01)))
                {
{targetPtr += *(int*)targetPtr + sizeof(int);}
                }
}
                }
                
            }
        }
        internal unsafe struct _iterator
        {
            byte* targetPtr;
            byte* endPtr;
            Cac_DocumentReference_AccessorListAccessor target;
            internal _iterator(Cac_DocumentReference_AccessorListAccessor target)
            {
                targetPtr = target.m_ptr;
                endPtr = targetPtr + target.length;
                this.target = target;
            }
            internal bool good()
            {
                return (targetPtr < endPtr);
            }
            internal Cac_DocumentReference_Accessor current()
            {
                
                {
                    target.elementAccessor.m_ptr = targetPtr;
                    return target.elementAccessor;
                }
                
            }
            internal void move_next()
            {
                 
                {
                    {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_1 + 0) & 0x01)))
                {
{targetPtr += *(int*)targetPtr + sizeof(int);}
                }
}
                }
                
            }
        }
        public IEnumerator<Cac_DocumentReference_Accessor> GetEnumerator()
        {
            _iterator _it = new _iterator(this);
            while (_it.good())
            {
                yield return _it.current();
                _it.move_next();
            }
        }
        unsafe IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        /// <summary>
        /// Adds an item to the end of the List
        /// </summary>
        /// <param name="element">The object to be added to the end of the List.</param>
        public unsafe void Add(Cac_DocumentReference element)
        {
            byte* targetPtr = null;
            {
                
            {
            targetPtr += 1;

        if(element.ID!= null)
        {
            int strlen_1 = element.ID.Length * 2;
            targetPtr += strlen_1+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(element.DocumentType!= null)
        {
            int strlen_1 = element.DocumentType.Length * 2;
            targetPtr += strlen_1+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            if( element.cac_Attachment!= null)
            {

            {

        if(element.cac_Attachment.Value.cac_ExternalReferenceUdid!= null)
        {
            int strlen_2 = element.cac_Attachment.Value.cac_ExternalReferenceUdid.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            }

            }
            }
            int size = (int)targetPtr;
            this.m_ptr = this.ResizeFunction(this.m_ptr - sizeof(int), *(int*)(this.m_ptr-sizeof(int))+sizeof(int), size);
            targetPtr = this.m_ptr + (*(int*)this.m_ptr)+sizeof(int);
            *(int*)this.m_ptr += size;
            this.m_ptr += sizeof(int);
            
            {
            byte* optheader_0 = targetPtr;
            *(optheader_0 + 0) = 0x00;            targetPtr += 1;

        if(element.ID!= null)
        {
            int strlen_1 = element.ID.Length * 2;
            *(int*)targetPtr = strlen_1;
            targetPtr += sizeof(int);
            fixed(char* pstr_1 = element.ID)
            {
                Memory.Copy(pstr_1, targetPtr, strlen_1);
                targetPtr += strlen_1;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(element.DocumentType!= null)
        {
            int strlen_1 = element.DocumentType.Length * 2;
            *(int*)targetPtr = strlen_1;
            targetPtr += sizeof(int);
            fixed(char* pstr_1 = element.DocumentType)
            {
                Memory.Copy(pstr_1, targetPtr, strlen_1);
                targetPtr += strlen_1;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            if( element.cac_Attachment!= null)
            {

            {

        if(element.cac_Attachment.Value.cac_ExternalReferenceUdid!= null)
        {
            int strlen_2 = element.cac_Attachment.Value.cac_ExternalReferenceUdid.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = element.cac_Attachment.Value.cac_ExternalReferenceUdid)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }*(optheader_0 + 0) |= 0x01;
            }

            }
        }
        /// <summary>
        /// Inserts an element into the List at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which item should be inserted.</param>
        /// <param name="element">The object to insert.</param>
        public unsafe void Insert(int index, Cac_DocumentReference element)
        {
            if (index < 0 || index > Count) throw new IndexOutOfRangeException();
            byte* targetPtr = null;
            {
                
            {
            targetPtr += 1;

        if(element.ID!= null)
        {
            int strlen_1 = element.ID.Length * 2;
            targetPtr += strlen_1+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(element.DocumentType!= null)
        {
            int strlen_1 = element.DocumentType.Length * 2;
            targetPtr += strlen_1+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            if( element.cac_Attachment!= null)
            {

            {

        if(element.cac_Attachment.Value.cac_ExternalReferenceUdid!= null)
        {
            int strlen_2 = element.cac_Attachment.Value.cac_ExternalReferenceUdid.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            }

            }
            }
            int size = (int)targetPtr;
            targetPtr = m_ptr;
            
            for (int i = 0; i < index; i++)
            {
                {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_1 + 0) & 0x01)))
                {
{targetPtr += *(int*)targetPtr + sizeof(int);}
                }
}
            }
            
            int offset = (int)(targetPtr - m_ptr);
            this.m_ptr = this.ResizeFunction(this.m_ptr - sizeof(int), offset + sizeof(int), size);
            *(int*)this.m_ptr += size;
            this.m_ptr += sizeof(int);
            targetPtr = this.m_ptr + offset;
            
            {
            byte* optheader_0 = targetPtr;
            *(optheader_0 + 0) = 0x00;            targetPtr += 1;

        if(element.ID!= null)
        {
            int strlen_1 = element.ID.Length * 2;
            *(int*)targetPtr = strlen_1;
            targetPtr += sizeof(int);
            fixed(char* pstr_1 = element.ID)
            {
                Memory.Copy(pstr_1, targetPtr, strlen_1);
                targetPtr += strlen_1;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(element.DocumentType!= null)
        {
            int strlen_1 = element.DocumentType.Length * 2;
            *(int*)targetPtr = strlen_1;
            targetPtr += sizeof(int);
            fixed(char* pstr_1 = element.DocumentType)
            {
                Memory.Copy(pstr_1, targetPtr, strlen_1);
                targetPtr += strlen_1;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            if( element.cac_Attachment!= null)
            {

            {

        if(element.cac_Attachment.Value.cac_ExternalReferenceUdid!= null)
        {
            int strlen_2 = element.cac_Attachment.Value.cac_ExternalReferenceUdid.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = element.cac_Attachment.Value.cac_ExternalReferenceUdid)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }*(optheader_0 + 0) |= 0x01;
            }

            }
        }
        /// <summary>
        /// Inserts an element into a sorted list.
        /// </summary>
        /// <param name="element">The object to insert.</param>
        /// <param name="comparison"></param>
        public unsafe void Insert(Cac_DocumentReference element, Comparison<Cac_DocumentReference_Accessor> comparison)
        {
            byte* targetPtr = null;
            {
                
            {
            targetPtr += 1;

        if(element.ID!= null)
        {
            int strlen_1 = element.ID.Length * 2;
            targetPtr += strlen_1+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(element.DocumentType!= null)
        {
            int strlen_1 = element.DocumentType.Length * 2;
            targetPtr += strlen_1+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            if( element.cac_Attachment!= null)
            {

            {

        if(element.cac_Attachment.Value.cac_ExternalReferenceUdid!= null)
        {
            int strlen_2 = element.cac_Attachment.Value.cac_ExternalReferenceUdid.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            }

            }
            }
            int size = (int)targetPtr;
            targetPtr = m_ptr;
            byte* endPtr = m_ptr + length;
            while (targetPtr<endPtr)
            {
                
                {
                    elementAccessor.m_ptr = targetPtr + 4;
                    if (comparison(elementAccessor, element)<=0)
                    {
                        {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_1 + 0) & 0x01)))
                {
{targetPtr += *(int*)targetPtr + sizeof(int);}
                }
}
                    }
                    else
                    {
                        break;
                    }
                }
                
            }
            int offset = (int)(targetPtr - m_ptr);
            this.m_ptr = this.ResizeFunction(this.m_ptr - sizeof(int), offset + sizeof(int), size);
            *(int*)this.m_ptr += size;
            this.m_ptr += sizeof(int);
            targetPtr = this.m_ptr + offset;
            
            {
            byte* optheader_0 = targetPtr;
            *(optheader_0 + 0) = 0x00;            targetPtr += 1;

        if(element.ID!= null)
        {
            int strlen_1 = element.ID.Length * 2;
            *(int*)targetPtr = strlen_1;
            targetPtr += sizeof(int);
            fixed(char* pstr_1 = element.ID)
            {
                Memory.Copy(pstr_1, targetPtr, strlen_1);
                targetPtr += strlen_1;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(element.DocumentType!= null)
        {
            int strlen_1 = element.DocumentType.Length * 2;
            *(int*)targetPtr = strlen_1;
            targetPtr += sizeof(int);
            fixed(char* pstr_1 = element.DocumentType)
            {
                Memory.Copy(pstr_1, targetPtr, strlen_1);
                targetPtr += strlen_1;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            if( element.cac_Attachment!= null)
            {

            {

        if(element.cac_Attachment.Value.cac_ExternalReferenceUdid!= null)
        {
            int strlen_2 = element.cac_Attachment.Value.cac_ExternalReferenceUdid.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = element.cac_Attachment.Value.cac_ExternalReferenceUdid)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }*(optheader_0 + 0) |= 0x01;
            }

            }
        }
        /// <summary>
        /// Removes the element at the specified index of the List.
        /// </summary>
        /// <param name="index">The zero-based index of the element to remove.</param>
        public unsafe void RemoveAt(int index)
        {
            if (index < 0 || index >= Count) throw new IndexOutOfRangeException();
            byte* targetPtr = m_ptr;
            for (int i = 0; i < index; i++)
            {
                {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_1 + 0) & 0x01)))
                {
{targetPtr += *(int*)targetPtr + sizeof(int);}
                }
}
            }
            int offset = (int)(targetPtr - m_ptr);
            byte* oldtargetPtr = targetPtr;
            {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_1 + 0) & 0x01)))
                {
{targetPtr += *(int*)targetPtr + sizeof(int);}
                }
}
            int size = (int)(oldtargetPtr - targetPtr);
            this.m_ptr = this.ResizeFunction(this.m_ptr - sizeof(int), offset + sizeof(int), size);
            *(int*)this.m_ptr += size;
            this.m_ptr += sizeof(int);
        }
        /// <summary>
        /// Adds the elements of the specified collection to the end of the List
        /// </summary>
        /// <param name="collection">The collection whose elements should be added to the end of the List. The collection itself cannot be null.</param>
        public unsafe void AddRange(List<Cac_DocumentReference> collection)
        {
            if (collection == null) throw new ArgumentNullException("collection is null.");
            Cac_DocumentReference_AccessorListAccessor tcollection = collection;
            int delta = tcollection.length;
            m_ptr = ResizeFunction(m_ptr - 4, *(int*)(m_ptr - 4) + 4, delta);
            Memory.Copy(tcollection.m_ptr, m_ptr + *(int*)m_ptr + 4, delta);
            *(int*)m_ptr += delta;
            this.m_ptr += 4;
        }
        /// <summary>
        /// Adds the elements of the specified collection to the end of the List
        /// </summary>
        /// <param name="collection">The collection whose elements should be added to the end of the List. The collection itself cannot be null.</param>
        public unsafe void AddRange(Cac_DocumentReference_AccessorListAccessor collection)
        {
            if (collection == null) throw new ArgumentNullException("collection is null.");
            int delta = collection.length;
            if (collection.m_cellId != m_cellId)
            {
                m_ptr = ResizeFunction(m_ptr - 4, *(int*)(m_ptr - 4) + 4, delta);
                Memory.Copy(collection.m_ptr, m_ptr + *(int*)m_ptr + 4, delta);
                *(int*)m_ptr += delta;
            }
            else
            {
                byte[] tmpcell = new byte[delta];
                fixed (byte* tmpcellptr = tmpcell)
                {
                    Memory.Copy(collection.m_ptr, tmpcellptr, delta);
                    m_ptr = ResizeFunction(m_ptr - 4, *(int*)(m_ptr - 4) + 4, delta);
                    Memory.Copy(tmpcellptr, m_ptr + *(int*)m_ptr + 4, delta);
                    *(int*)m_ptr += delta;
                }
            }
            this.m_ptr += 4;
        }
        /// <summary>
        /// Removes all elements from the List
        /// </summary>
        public unsafe void Clear()
        {
            int delta = length;
            Memory.memset(m_ptr, 0, (ulong)delta);
            m_ptr = ResizeFunction(m_ptr - 4, 4, -delta);
            *(int*)m_ptr = 0;
            this.m_ptr += 4;
        }
        /// <summary>
        /// Determines whether an element is in the List
        /// </summary>
        /// <param name="item">The object to locate in the List.The value can be null for non-atom types</param>
        /// <returns>true if item is found in the List; otherwise, false.</returns>
        public unsafe bool Contains(Cac_DocumentReference_Accessor item)
        {
            bool ret = false;
            ForEach(x =>
            {
                if (item == x) ret = true;
            });
            return ret;
        }
        /// <summary>
        /// Determines whether the List contains elements that match the conditions defined by the specified predicate.
        /// </summary>
        /// <param name="match">The Predicate delegate that defines the conditions of the elements to search for.</param>
        /// <returns>true if the List contains one or more elements that match the conditions defined by the specified predicate; otherwise, false.</returns>
        public unsafe bool Exists(Predicate<Cac_DocumentReference_Accessor> match)
        {
            bool ret = false;
            ForEach(x =>
            {
                if (match(x)) ret = true;
            });
            return ret;
        }
        
        /// <summary>
        /// Copies the entire List to a compatible one-dimensional array, starting at the beginning of the ptr1 array.
        /// </summary>
        /// <param name="array">The one-dimensional Array that is the destination of the elements copied from List. The Array must have zero-based indexing.</param>
        public unsafe void CopyTo(Cac_DocumentReference[] array)
        {
            if (array == null) throw new ArgumentNullException("array is null.");
            if (array.Length < Count) throw new ArgumentException("The number of elements in the source List is greater than the number of elements that the destination array can contain.");
            ForEach((x, i) => array[i] = x);
        }
        /// <summary>
        /// Copies the entire List to a compatible one-dimensional array, starting at the specified index of the ptr1 array.
        /// </summary>
        /// <param name="array">The one-dimensional Array that is the destination of the elements copied from List. The Array must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
        public unsafe void CopyTo(Cac_DocumentReference[] array, int arrayIndex)
        {
            if (array == null) throw new ArgumentNullException("array is null.");
            if (arrayIndex < 0) throw new ArgumentOutOfRangeException("arrayIndex is less than 0.");
            if (array.Length - arrayIndex < Count) throw new ArgumentException("The number of elements in the source List is greater than the available space from arrayIndex to the end of the destination array.");
            ForEach((x, i) => array[i + arrayIndex] = x);
        }
        /// <summary>
        /// Copies a range of elements from the List to a compatible one-dimensional array, starting at the specified index of the ptr1 array.
        /// </summary>
        /// <param name="index">The zero-based index in the source List at which copying begins.</param>
        /// <param name="array">The one-dimensional Array that is the destination of the elements copied from List. The Array must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>;
        /// <param name="count">The number of elements to copy.</param>
        public unsafe void CopyTo(int index, Cac_DocumentReference[] array, int arrayIndex, int count)
        {
            if (array == null) throw new ArgumentNullException("array is null.");
            if (arrayIndex < 0 || index < 0 || count < 0) throw new ArgumentOutOfRangeException("arrayIndex is less than 0 or index is less than 0 or count is less than 0.");
            if (array.Length - arrayIndex < count) throw new ArgumentException("The number of elements from index to the end of the source List is greater than the available space from arrayIndex to the end of the destination array. ");
            if (index + count > Count) throw new ArgumentException("Source list does not have enough elements to copy.");
            int j = 0;
            for (int i = index; i < index + count; i++)
            {
                array[j + arrayIndex] = this[i];
                ++j;
            }
        }
          
        /// <summary>
        /// Inserts the elements of a collection into the List at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which the new elements should be inserted.</param>
        /// <param name="collection">The collection whose elements should be inserted into the List. The collection itself cannot be null, but it can contain elements that are null, if type T is a reference type.</param>
        public unsafe void InsertRange(int index, List<Cac_DocumentReference> collection)
        {
            if (collection == null) throw new ArgumentNullException("collection is null.");
            if (index < 0) throw new ArgumentOutOfRangeException("index is less than 0.");
            if (index > Count) throw new ArgumentOutOfRangeException("index is greater than Count.");
            Cac_DocumentReference_AccessorListAccessor tmpAccessor = collection;
            byte* targetPtr = m_ptr;
            for (int i = 0; i < index; i++)
            {
                {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_1 + 0) & 0x01)))
                {
{targetPtr += *(int*)targetPtr + sizeof(int);}
                }
}
            }
            int offset = (int)(targetPtr - m_ptr);
            m_ptr = ResizeFunction(m_ptr - 4, offset + 4, tmpAccessor.length);
            Memory.Copy(tmpAccessor.m_ptr, m_ptr + offset + 4, tmpAccessor.length);
            *(int*)m_ptr += tmpAccessor.length;
            this.m_ptr += 4;
        }
        /// <summary>
        /// Removes a range of elements from the List.
        /// </summary>
        /// <param name="index">The zero-based starting index of the range of elements to remove.</param>
        /// <param name="count">The number of elements to remove.</param>
        public unsafe void RemoveRange(int index, int count)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index is less than 0.");
            if (index > Count) throw new ArgumentOutOfRangeException("index is greater than Count.");
            if (index + count > Count) throw new ArgumentException("index and count do not denote a valid range of elements in the List.");
            byte* targetPtr = m_ptr;
            for (int i = 0; i < index; i++)
            {
                {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_1 + 0) & 0x01)))
                {
{targetPtr += *(int*)targetPtr + sizeof(int);}
                }
}
            }
            int offset = (int)(targetPtr - m_ptr);
            byte* oldtargetPtr = targetPtr;
            for (int i = 0; i < count; i++)
            {
                {            byte* optheader_1 = targetPtr;
            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);
                if ((0 != (*(optheader_1 + 0) & 0x01)))
                {
{targetPtr += *(int*)targetPtr + sizeof(int);}
                }
}
            }
            int size = (int)(oldtargetPtr - targetPtr);
            m_ptr = ResizeFunction(m_ptr - 4, offset + 4, size);
            *(int*)m_ptr += size;
            this.m_ptr += 4;
        }
        public unsafe static implicit operator List<Cac_DocumentReference> (Cac_DocumentReference_AccessorListAccessor accessor)
        {
            if((object)accessor == null) return null;
            List<Cac_DocumentReference> list = new List<Cac_DocumentReference>();
            accessor.ForEach(element => list.Add(element));
            return list;
        }
        
        public unsafe static implicit operator Cac_DocumentReference_AccessorListAccessor(List<Cac_DocumentReference> field)
        {
            byte* targetPtr = null;
            
{

    targetPtr += sizeof(int);
    if(field!= null)
    {
        for(int iterator_1 = 0;iterator_1<field.Count;++iterator_1)
        {

            {
            targetPtr += 1;

        if(field[iterator_1].ID!= null)
        {
            int strlen_3 = field[iterator_1].ID.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(field[iterator_1].DocumentType!= null)
        {
            int strlen_3 = field[iterator_1].DocumentType.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            if( field[iterator_1].cac_Attachment!= null)
            {

            {

        if(field[iterator_1].cac_Attachment.Value.cac_ExternalReferenceUdid!= null)
        {
            int strlen_4 = field[iterator_1].cac_Attachment.Value.cac_ExternalReferenceUdid.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            }

            }
        }
    }

}

            byte* tmpcellptr = BufferAllocator.AllocBuffer((int)targetPtr);
            Memory.memset(tmpcellptr, 0, (ulong)targetPtr);
            targetPtr = tmpcellptr;
            
{
byte *storedPtr_1 = targetPtr;

    targetPtr += sizeof(int);
    if(field!= null)
    {
        for(int iterator_1 = 0;iterator_1<field.Count;++iterator_1)
        {

            {
            byte* optheader_2 = targetPtr;
            *(optheader_2 + 0) = 0x00;            targetPtr += 1;

        if(field[iterator_1].ID!= null)
        {
            int strlen_3 = field[iterator_1].ID.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = field[iterator_1].ID)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(field[iterator_1].DocumentType!= null)
        {
            int strlen_3 = field[iterator_1].DocumentType.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = field[iterator_1].DocumentType)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            if( field[iterator_1].cac_Attachment!= null)
            {

            {

        if(field[iterator_1].cac_Attachment.Value.cac_ExternalReferenceUdid!= null)
        {
            int strlen_4 = field[iterator_1].cac_Attachment.Value.cac_ExternalReferenceUdid.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = field[iterator_1].cac_Attachment.Value.cac_ExternalReferenceUdid)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }*(optheader_2 + 0) |= 0x01;
            }

            }
        }
    }
*(int*)storedPtr_1 = (int)(targetPtr - storedPtr_1 - 4);

}
Cac_DocumentReference_AccessorListAccessor ret;
            
            ret = new Cac_DocumentReference_AccessorListAccessor(tmpcellptr, null);
            
            return ret;
        }
        
        public static bool operator ==(Cac_DocumentReference_AccessorListAccessor a, Cac_DocumentReference_AccessorListAccessor b)
        {
            if (ReferenceEquals(a, b))
                return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;
            if (a.m_ptr == b.m_ptr) return true;
            if (a.length != b.length) return false;
            return Memory.Compare(a.m_ptr, b.m_ptr, a.length);
        }
        public static bool operator !=(Cac_DocumentReference_AccessorListAccessor a, Cac_DocumentReference_AccessorListAccessor b)
        {
            return !(a == b);
        }
    }
}

namespace TDW.TRAServer
{
    
    public unsafe class Cac_InvoiceLine_AccessorListAccessor : IEnumerable<Cac_InvoiceLine_Accessor>
    {
        internal byte* m_ptr;
        internal long m_cellId;
        internal ResizeFunctionDelegate ResizeFunction;
        internal Cac_InvoiceLine_AccessorListAccessor(byte* _CellPtr, ResizeFunctionDelegate func)
        {
            m_ptr = _CellPtr;
            ResizeFunction = func;
            m_ptr += 4;
                    elementAccessor = new Cac_InvoiceLine_Accessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.m_ptr = this.ResizeFunction(this.m_ptr-sizeof(int), ptr_offset + substructure_offset +sizeof(int), delta);
                    *(int*)this.m_ptr += delta;
                    this.m_ptr += sizeof(int);
                    return this.m_ptr + substructure_offset;
                });
        }
        internal int length
        {
            get
            {
                return *(int*)(m_ptr - 4);
            }
        }
        Cac_InvoiceLine_Accessor elementAccessor;
        
        /// <summary>
        /// Gets the number of elements actually contained in the List. 
        /// </summary>";
        public unsafe int Count
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                byte* endPtr = m_ptr + length;
                int ret = 0;
                while (targetPtr < endPtr)
                {
                    {targetPtr += *(int*)targetPtr + sizeof(int);{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}targetPtr += *(int*)targetPtr + sizeof(int);{targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);{{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);{{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}}}}
                    ++ret;
                }
                return ret;
                
            }
        }
        /// <summary>
        /// Gets or sets the element at the specified index. 
        /// </summary>
        /// <param name="index">Given index</param>
        /// <returns>Corresponding element at the specified index</returns>";
        public unsafe Cac_InvoiceLine_Accessor this[int index]
        {
            get
            {
                
                {
                    
                    {
                        byte* targetPtr = m_ptr;
                        while (index-- > 0)
                        {
                            {targetPtr += *(int*)targetPtr + sizeof(int);{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}targetPtr += *(int*)targetPtr + sizeof(int);{targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);{{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);{{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}}}}
                        }
                        
                        elementAccessor.m_ptr = targetPtr;
                        
                    }
                    
                    elementAccessor.m_cellId = this.m_cellId;
                    return elementAccessor;
                }
                
            }
            set
            {
                
                {
                    if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                    elementAccessor.m_cellId = this.m_cellId;
                    byte* targetPtr = m_ptr;
                    
                    while (index-- > 0)
                    {
                        {targetPtr += *(int*)targetPtr + sizeof(int);{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}targetPtr += *(int*)targetPtr + sizeof(int);{targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);{{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);{{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}}}}
                    }
                    
                int offset = (int)(targetPtr - m_ptr);
                byte* oldtargetPtr = targetPtr;
                int oldlength = (int)(targetPtr - oldtargetPtr);
                targetPtr = value.m_ptr;
                int newlength = (int)(targetPtr - value.m_ptr);
                if (newlength != oldlength)
                {
                    if (value.m_cellId != this.m_cellId)
                    {
                        this.m_ptr = this.ResizeFunction(this.m_ptr, offset, newlength - oldlength);
                        Memory.Copy(value.m_ptr, this.m_ptr + offset, newlength);
                    }
                    else
                    {
                        byte[] tmpcell = new byte[newlength];
                        fixed(byte* tmpcellptr = tmpcell)
                        {
                            Memory.Copy(value.m_ptr, tmpcellptr, newlength);
                            this.m_ptr = this.ResizeFunction(this.m_ptr, offset, newlength - oldlength);
                            Memory.Copy(tmpcellptr, this.m_ptr + offset, newlength);
                        }
                    }
                }
                else
                {
                    Memory.Copy(value.m_ptr, oldtargetPtr, oldlength);
                }
                }
                
            }
        }
        /// <summary>
        /// Copies the elements to a new byte array
        /// </summary>
        /// <returns>Elements compactly arranged in a byte array.</returns>
        public unsafe byte[] ToByteArray()
        {
            byte[] ret = new byte[length];
            fixed (byte* retptr = ret)
            {
                Memory.Copy(m_ptr, retptr, length);
                return ret;
            }
        }
        /// <summary>
        /// Performs the specified action on each elements
        /// </summary>
        /// <param name="action">A lambda expression which has one parameter indicates element in List</param>
        public unsafe void ForEach(Action<Cac_InvoiceLine_Accessor> action)
        {
            byte* targetPtr = m_ptr;
            byte* endPtr = m_ptr + length;
            
            elementAccessor.m_cellId = this.m_cellId;
            
            while (targetPtr < endPtr)
            {
                
                {
                    elementAccessor.m_ptr = targetPtr;
                    action(elementAccessor);
                    {targetPtr += *(int*)targetPtr + sizeof(int);{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}targetPtr += *(int*)targetPtr + sizeof(int);{targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);{{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);{{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}}}}
                }
                
            }
        }
        /// <summary>
        /// Performs the specified action on each elements
        /// </summary>
        /// <param name="action">A lambda expression which has two parameters. First indicates element in the List and second the index of this element.</param>
        public unsafe void ForEach(Action<Cac_InvoiceLine_Accessor, int> action)
        {
            byte* targetPtr = m_ptr;
            byte* endPtr = m_ptr + length;
            for (int index = 0; targetPtr < endPtr; ++index)
            {
                
                {
                    elementAccessor.m_ptr = targetPtr;
                    action(elementAccessor, index);
                    {targetPtr += *(int*)targetPtr + sizeof(int);{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}targetPtr += *(int*)targetPtr + sizeof(int);{targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);{{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);{{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}}}}
                }
                
            }
        }
        internal unsafe struct _iterator
        {
            byte* targetPtr;
            byte* endPtr;
            Cac_InvoiceLine_AccessorListAccessor target;
            internal _iterator(Cac_InvoiceLine_AccessorListAccessor target)
            {
                targetPtr = target.m_ptr;
                endPtr = targetPtr + target.length;
                this.target = target;
            }
            internal bool good()
            {
                return (targetPtr < endPtr);
            }
            internal Cac_InvoiceLine_Accessor current()
            {
                
                {
                    target.elementAccessor.m_ptr = targetPtr;
                    return target.elementAccessor;
                }
                
            }
            internal void move_next()
            {
                 
                {
                    {targetPtr += *(int*)targetPtr + sizeof(int);{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}targetPtr += *(int*)targetPtr + sizeof(int);{targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);{{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);{{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}}}}
                }
                
            }
        }
        public IEnumerator<Cac_InvoiceLine_Accessor> GetEnumerator()
        {
            _iterator _it = new _iterator(this);
            while (_it.good())
            {
                yield return _it.current();
                _it.move_next();
            }
        }
        unsafe IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        /// <summary>
        /// Adds an item to the end of the List
        /// </summary>
        /// <param name="element">The object to be added to the end of the List.</param>
        public unsafe void Add(Cac_InvoiceLine element)
        {
            byte* targetPtr = null;
            {
                
            {

        if(element.cbc_ID!= null)
        {
            int strlen_1 = element.cbc_ID.Length * 2;
            targetPtr += strlen_1+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            {
            targetPtr += 1;

        if(element.cbc_Note.note!= null)
        {
            int strlen_2 = element.cbc_Note.note.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            {

        if(element.cbc_InvoicedQuantity._unitCode!= null)
        {
            int strlen_2 = element.cbc_InvoicedQuantity._unitCode.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            {

        if(element.cbc_LineExtensionAmount._CurrencyID!= null)
        {
            int strlen_2 = element.cbc_LineExtensionAmount._CurrencyID.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
        if(element.cbc_AccountingCost!= null)
        {
            int strlen_1 = element.cbc_AccountingCost.Length * 2;
            targetPtr += strlen_1+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            {

        if(element.cac_OrderLineReference.cbc_LineID!= null)
        {
            int strlen_2 = element.cac_OrderLineReference.cbc_LineID.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
{

    targetPtr += sizeof(int);
    if(element.cac_AllowanceCharges!= null)
    {
        for(int iterator_1 = 0;iterator_1<element.cac_AllowanceCharges.Count;++iterator_1)
        {

            {
            targetPtr += 1;

        if(element.cac_AllowanceCharges[iterator_1].cbc_AllowanceChargeReason!= null)
        {
            int strlen_3 = element.cac_AllowanceCharges[iterator_1].cbc_AllowanceChargeReason.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            {

        if(element.cac_AllowanceCharges[iterator_1].cbc_Amount._CurrencyID!= null)
        {
            int strlen_4 = element.cac_AllowanceCharges[iterator_1].cbc_Amount._CurrencyID.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            }
        }
    }

}

            {

            {

        if(element.cac_TaxTotal.cbc_TaxAmount._CurrencyID!= null)
        {
            int strlen_3 = element.cac_TaxTotal.cbc_TaxAmount._CurrencyID.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
{

    targetPtr += sizeof(int);
    if(element.cac_TaxTotal.cac_TaxSubtotals!= null)
    {
        for(int iterator_2 = 0;iterator_2<element.cac_TaxTotal.cac_TaxSubtotals.Count;++iterator_2)
        {

            {

            {

        if(element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cbc_TaxableAmount._CurrencyID!= null)
        {
            int strlen_5 = element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cbc_TaxableAmount._CurrencyID.Length * 2;
            targetPtr += strlen_5+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            {

        if(element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cbc_TaxAmount._CurrencyID!= null)
        {
            int strlen_5 = element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cbc_TaxAmount._CurrencyID.Length * 2;
            targetPtr += strlen_5+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            {

            {
            targetPtr += 1;

        if(element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cbc_ID._schemeID!= null)
        {
            int strlen_6 = element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cbc_ID._schemeID.Length * 2;
            targetPtr += strlen_6+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            if( element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cbc_ID._schemeAgencyID!= null)
            {

        if(element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cbc_ID._schemeAgencyID!= null)
        {
            int strlen_6 = element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cbc_ID._schemeAgencyID.Length * 2;
            targetPtr += strlen_6+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }

        if(element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cbc_ID.code!= null)
        {
            int strlen_6 = element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cbc_ID.code.Length * 2;
            targetPtr += strlen_6+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }            targetPtr += 8;

            {

            {
            targetPtr += 1;

        if(element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeID!= null)
        {
            int strlen_7 = element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeID.Length * 2;
            targetPtr += strlen_7+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            if( element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeAgencyID!= null)
            {

        if(element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeAgencyID!= null)
        {
            int strlen_7 = element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeAgencyID.Length * 2;
            targetPtr += strlen_7+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }

        if(element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cac_TaxScheme.cbc_ID.code!= null)
        {
            int strlen_7 = element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cac_TaxScheme.cbc_ID.code.Length * 2;
            targetPtr += strlen_7+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            }
            }
            }
        }
    }

}

            }
        if(element.cac_ItemUdid!= null)
        {
            int strlen_1 = element.cac_ItemUdid.Length * 2;
            targetPtr += strlen_1+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            {

            {

        if(element.cac_Price.cbc_PriceAmount._CurrencyID!= null)
        {
            int strlen_3 = element.cac_Price.cbc_PriceAmount._CurrencyID.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            {

        if(element.cac_Price.cbc_BaseQuantity._unitCode!= null)
        {
            int strlen_3 = element.cac_Price.cbc_BaseQuantity._unitCode.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            {
            targetPtr += 1;

        if(element.cac_Price.cac_AllowanceCharge.cbc_AllowanceChargeReason!= null)
        {
            int strlen_3 = element.cac_Price.cac_AllowanceCharge.cbc_AllowanceChargeReason.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            {

        if(element.cac_Price.cac_AllowanceCharge.cbc_Amount._CurrencyID!= null)
        {
            int strlen_4 = element.cac_Price.cac_AllowanceCharge.cbc_Amount._CurrencyID.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            }
            }
            }
            }
            int size = (int)targetPtr;
            this.m_ptr = this.ResizeFunction(this.m_ptr - sizeof(int), *(int*)(this.m_ptr-sizeof(int))+sizeof(int), size);
            targetPtr = this.m_ptr + (*(int*)this.m_ptr)+sizeof(int);
            *(int*)this.m_ptr += size;
            this.m_ptr += sizeof(int);
            
            {

        if(element.cbc_ID!= null)
        {
            int strlen_1 = element.cbc_ID.Length * 2;
            *(int*)targetPtr = strlen_1;
            targetPtr += sizeof(int);
            fixed(char* pstr_1 = element.cbc_ID)
            {
                Memory.Copy(pstr_1, targetPtr, strlen_1);
                targetPtr += strlen_1;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            {
            *(ISO639_1_LanguageCodes*)targetPtr = element.cbc_Note._languageID;
            targetPtr += 1;

        if(element.cbc_Note.note!= null)
        {
            int strlen_2 = element.cbc_Note.note.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = element.cbc_Note.note)
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
            {

        if(element.cbc_InvoicedQuantity._unitCode!= null)
        {
            int strlen_2 = element.cbc_InvoicedQuantity._unitCode.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = element.cbc_InvoicedQuantity._unitCode)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(long*)targetPtr = element.cbc_InvoicedQuantity.quantity;
            targetPtr += 8;

            }
            {

        if(element.cbc_LineExtensionAmount._CurrencyID!= null)
        {
            int strlen_2 = element.cbc_LineExtensionAmount._CurrencyID.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = element.cbc_LineExtensionAmount._CurrencyID)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(double*)targetPtr = element.cbc_LineExtensionAmount.amount;
            targetPtr += 8;

            }
        if(element.cbc_AccountingCost!= null)
        {
            int strlen_1 = element.cbc_AccountingCost.Length * 2;
            *(int*)targetPtr = strlen_1;
            targetPtr += sizeof(int);
            fixed(char* pstr_1 = element.cbc_AccountingCost)
            {
                Memory.Copy(pstr_1, targetPtr, strlen_1);
                targetPtr += strlen_1;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            {

        if(element.cac_OrderLineReference.cbc_LineID!= null)
        {
            int strlen_2 = element.cac_OrderLineReference.cbc_LineID.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = element.cac_OrderLineReference.cbc_LineID)
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
{
byte *storedPtr_1 = targetPtr;

    targetPtr += sizeof(int);
    if(element.cac_AllowanceCharges!= null)
    {
        for(int iterator_1 = 0;iterator_1<element.cac_AllowanceCharges.Count;++iterator_1)
        {

            {
            *(bool*)targetPtr = element.cac_AllowanceCharges[iterator_1].cbc_ChargeIndicator;
            targetPtr += 1;

        if(element.cac_AllowanceCharges[iterator_1].cbc_AllowanceChargeReason!= null)
        {
            int strlen_3 = element.cac_AllowanceCharges[iterator_1].cbc_AllowanceChargeReason.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = element.cac_AllowanceCharges[iterator_1].cbc_AllowanceChargeReason)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            {

        if(element.cac_AllowanceCharges[iterator_1].cbc_Amount._CurrencyID!= null)
        {
            int strlen_4 = element.cac_AllowanceCharges[iterator_1].cbc_Amount._CurrencyID.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = element.cac_AllowanceCharges[iterator_1].cbc_Amount._CurrencyID)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(double*)targetPtr = element.cac_AllowanceCharges[iterator_1].cbc_Amount.amount;
            targetPtr += 8;

            }
            }
        }
    }
*(int*)storedPtr_1 = (int)(targetPtr - storedPtr_1 - 4);

}

            {

            {

        if(element.cac_TaxTotal.cbc_TaxAmount._CurrencyID!= null)
        {
            int strlen_3 = element.cac_TaxTotal.cbc_TaxAmount._CurrencyID.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = element.cac_TaxTotal.cbc_TaxAmount._CurrencyID)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(double*)targetPtr = element.cac_TaxTotal.cbc_TaxAmount.amount;
            targetPtr += 8;

            }
{
byte *storedPtr_2 = targetPtr;

    targetPtr += sizeof(int);
    if(element.cac_TaxTotal.cac_TaxSubtotals!= null)
    {
        for(int iterator_2 = 0;iterator_2<element.cac_TaxTotal.cac_TaxSubtotals.Count;++iterator_2)
        {

            {

            {

        if(element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cbc_TaxableAmount._CurrencyID!= null)
        {
            int strlen_5 = element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cbc_TaxableAmount._CurrencyID.Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cbc_TaxableAmount._CurrencyID)
            {
                Memory.Copy(pstr_5, targetPtr, strlen_5);
                targetPtr += strlen_5;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(double*)targetPtr = element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cbc_TaxableAmount.amount;
            targetPtr += 8;

            }
            {

        if(element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cbc_TaxAmount._CurrencyID!= null)
        {
            int strlen_5 = element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cbc_TaxAmount._CurrencyID.Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cbc_TaxAmount._CurrencyID)
            {
                Memory.Copy(pstr_5, targetPtr, strlen_5);
                targetPtr += strlen_5;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(double*)targetPtr = element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cbc_TaxAmount.amount;
            targetPtr += 8;

            }
            {

            {
            byte* optheader_5 = targetPtr;
            *(optheader_5 + 0) = 0x00;            targetPtr += 1;

        if(element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cbc_ID._schemeID!= null)
        {
            int strlen_6 = element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cbc_ID._schemeID.Length * 2;
            *(int*)targetPtr = strlen_6;
            targetPtr += sizeof(int);
            fixed(char* pstr_6 = element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cbc_ID._schemeID)
            {
                Memory.Copy(pstr_6, targetPtr, strlen_6);
                targetPtr += strlen_6;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            if( element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cbc_ID._schemeAgencyID!= null)
            {

        if(element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cbc_ID._schemeAgencyID!= null)
        {
            int strlen_6 = element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cbc_ID._schemeAgencyID.Length * 2;
            *(int*)targetPtr = strlen_6;
            targetPtr += sizeof(int);
            fixed(char* pstr_6 = element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cbc_ID._schemeAgencyID)
            {
                Memory.Copy(pstr_6, targetPtr, strlen_6);
                targetPtr += strlen_6;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
*(optheader_5 + 0) |= 0x01;
            }

        if(element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cbc_ID.code!= null)
        {
            int strlen_6 = element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cbc_ID.code.Length * 2;
            *(int*)targetPtr = strlen_6;
            targetPtr += sizeof(int);
            fixed(char* pstr_6 = element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cbc_ID.code)
            {
                Memory.Copy(pstr_6, targetPtr, strlen_6);
                targetPtr += strlen_6;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }            *(double*)targetPtr = element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cbc_Percent;
            targetPtr += 8;

            {

            {
            byte* optheader_6 = targetPtr;
            *(optheader_6 + 0) = 0x00;            targetPtr += 1;

        if(element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeID!= null)
        {
            int strlen_7 = element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeID.Length * 2;
            *(int*)targetPtr = strlen_7;
            targetPtr += sizeof(int);
            fixed(char* pstr_7 = element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeID)
            {
                Memory.Copy(pstr_7, targetPtr, strlen_7);
                targetPtr += strlen_7;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            if( element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeAgencyID!= null)
            {

        if(element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeAgencyID!= null)
        {
            int strlen_7 = element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeAgencyID.Length * 2;
            *(int*)targetPtr = strlen_7;
            targetPtr += sizeof(int);
            fixed(char* pstr_7 = element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeAgencyID)
            {
                Memory.Copy(pstr_7, targetPtr, strlen_7);
                targetPtr += strlen_7;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
*(optheader_6 + 0) |= 0x01;
            }

        if(element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cac_TaxScheme.cbc_ID.code!= null)
        {
            int strlen_7 = element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cac_TaxScheme.cbc_ID.code.Length * 2;
            *(int*)targetPtr = strlen_7;
            targetPtr += sizeof(int);
            fixed(char* pstr_7 = element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cac_TaxScheme.cbc_ID.code)
            {
                Memory.Copy(pstr_7, targetPtr, strlen_7);
                targetPtr += strlen_7;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }
            }
            }
            }
        }
    }
*(int*)storedPtr_2 = (int)(targetPtr - storedPtr_2 - 4);

}

            }
        if(element.cac_ItemUdid!= null)
        {
            int strlen_1 = element.cac_ItemUdid.Length * 2;
            *(int*)targetPtr = strlen_1;
            targetPtr += sizeof(int);
            fixed(char* pstr_1 = element.cac_ItemUdid)
            {
                Memory.Copy(pstr_1, targetPtr, strlen_1);
                targetPtr += strlen_1;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            {

            {

        if(element.cac_Price.cbc_PriceAmount._CurrencyID!= null)
        {
            int strlen_3 = element.cac_Price.cbc_PriceAmount._CurrencyID.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = element.cac_Price.cbc_PriceAmount._CurrencyID)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(double*)targetPtr = element.cac_Price.cbc_PriceAmount.amount;
            targetPtr += 8;

            }
            {

        if(element.cac_Price.cbc_BaseQuantity._unitCode!= null)
        {
            int strlen_3 = element.cac_Price.cbc_BaseQuantity._unitCode.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = element.cac_Price.cbc_BaseQuantity._unitCode)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(long*)targetPtr = element.cac_Price.cbc_BaseQuantity.quantity;
            targetPtr += 8;

            }
            {
            *(bool*)targetPtr = element.cac_Price.cac_AllowanceCharge.cbc_ChargeIndicator;
            targetPtr += 1;

        if(element.cac_Price.cac_AllowanceCharge.cbc_AllowanceChargeReason!= null)
        {
            int strlen_3 = element.cac_Price.cac_AllowanceCharge.cbc_AllowanceChargeReason.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = element.cac_Price.cac_AllowanceCharge.cbc_AllowanceChargeReason)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            {

        if(element.cac_Price.cac_AllowanceCharge.cbc_Amount._CurrencyID!= null)
        {
            int strlen_4 = element.cac_Price.cac_AllowanceCharge.cbc_Amount._CurrencyID.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = element.cac_Price.cac_AllowanceCharge.cbc_Amount._CurrencyID)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(double*)targetPtr = element.cac_Price.cac_AllowanceCharge.cbc_Amount.amount;
            targetPtr += 8;

            }
            }
            }
            }
        }
        /// <summary>
        /// Inserts an element into the List at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which item should be inserted.</param>
        /// <param name="element">The object to insert.</param>
        public unsafe void Insert(int index, Cac_InvoiceLine element)
        {
            if (index < 0 || index > Count) throw new IndexOutOfRangeException();
            byte* targetPtr = null;
            {
                
            {

        if(element.cbc_ID!= null)
        {
            int strlen_1 = element.cbc_ID.Length * 2;
            targetPtr += strlen_1+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            {
            targetPtr += 1;

        if(element.cbc_Note.note!= null)
        {
            int strlen_2 = element.cbc_Note.note.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            {

        if(element.cbc_InvoicedQuantity._unitCode!= null)
        {
            int strlen_2 = element.cbc_InvoicedQuantity._unitCode.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            {

        if(element.cbc_LineExtensionAmount._CurrencyID!= null)
        {
            int strlen_2 = element.cbc_LineExtensionAmount._CurrencyID.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
        if(element.cbc_AccountingCost!= null)
        {
            int strlen_1 = element.cbc_AccountingCost.Length * 2;
            targetPtr += strlen_1+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            {

        if(element.cac_OrderLineReference.cbc_LineID!= null)
        {
            int strlen_2 = element.cac_OrderLineReference.cbc_LineID.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
{

    targetPtr += sizeof(int);
    if(element.cac_AllowanceCharges!= null)
    {
        for(int iterator_1 = 0;iterator_1<element.cac_AllowanceCharges.Count;++iterator_1)
        {

            {
            targetPtr += 1;

        if(element.cac_AllowanceCharges[iterator_1].cbc_AllowanceChargeReason!= null)
        {
            int strlen_3 = element.cac_AllowanceCharges[iterator_1].cbc_AllowanceChargeReason.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            {

        if(element.cac_AllowanceCharges[iterator_1].cbc_Amount._CurrencyID!= null)
        {
            int strlen_4 = element.cac_AllowanceCharges[iterator_1].cbc_Amount._CurrencyID.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            }
        }
    }

}

            {

            {

        if(element.cac_TaxTotal.cbc_TaxAmount._CurrencyID!= null)
        {
            int strlen_3 = element.cac_TaxTotal.cbc_TaxAmount._CurrencyID.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
{

    targetPtr += sizeof(int);
    if(element.cac_TaxTotal.cac_TaxSubtotals!= null)
    {
        for(int iterator_2 = 0;iterator_2<element.cac_TaxTotal.cac_TaxSubtotals.Count;++iterator_2)
        {

            {

            {

        if(element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cbc_TaxableAmount._CurrencyID!= null)
        {
            int strlen_5 = element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cbc_TaxableAmount._CurrencyID.Length * 2;
            targetPtr += strlen_5+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            {

        if(element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cbc_TaxAmount._CurrencyID!= null)
        {
            int strlen_5 = element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cbc_TaxAmount._CurrencyID.Length * 2;
            targetPtr += strlen_5+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            {

            {
            targetPtr += 1;

        if(element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cbc_ID._schemeID!= null)
        {
            int strlen_6 = element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cbc_ID._schemeID.Length * 2;
            targetPtr += strlen_6+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            if( element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cbc_ID._schemeAgencyID!= null)
            {

        if(element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cbc_ID._schemeAgencyID!= null)
        {
            int strlen_6 = element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cbc_ID._schemeAgencyID.Length * 2;
            targetPtr += strlen_6+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }

        if(element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cbc_ID.code!= null)
        {
            int strlen_6 = element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cbc_ID.code.Length * 2;
            targetPtr += strlen_6+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }            targetPtr += 8;

            {

            {
            targetPtr += 1;

        if(element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeID!= null)
        {
            int strlen_7 = element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeID.Length * 2;
            targetPtr += strlen_7+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            if( element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeAgencyID!= null)
            {

        if(element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeAgencyID!= null)
        {
            int strlen_7 = element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeAgencyID.Length * 2;
            targetPtr += strlen_7+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }

        if(element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cac_TaxScheme.cbc_ID.code!= null)
        {
            int strlen_7 = element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cac_TaxScheme.cbc_ID.code.Length * 2;
            targetPtr += strlen_7+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            }
            }
            }
        }
    }

}

            }
        if(element.cac_ItemUdid!= null)
        {
            int strlen_1 = element.cac_ItemUdid.Length * 2;
            targetPtr += strlen_1+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            {

            {

        if(element.cac_Price.cbc_PriceAmount._CurrencyID!= null)
        {
            int strlen_3 = element.cac_Price.cbc_PriceAmount._CurrencyID.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            {

        if(element.cac_Price.cbc_BaseQuantity._unitCode!= null)
        {
            int strlen_3 = element.cac_Price.cbc_BaseQuantity._unitCode.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            {
            targetPtr += 1;

        if(element.cac_Price.cac_AllowanceCharge.cbc_AllowanceChargeReason!= null)
        {
            int strlen_3 = element.cac_Price.cac_AllowanceCharge.cbc_AllowanceChargeReason.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            {

        if(element.cac_Price.cac_AllowanceCharge.cbc_Amount._CurrencyID!= null)
        {
            int strlen_4 = element.cac_Price.cac_AllowanceCharge.cbc_Amount._CurrencyID.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            }
            }
            }
            }
            int size = (int)targetPtr;
            targetPtr = m_ptr;
            
            for (int i = 0; i < index; i++)
            {
                {targetPtr += *(int*)targetPtr + sizeof(int);{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}targetPtr += *(int*)targetPtr + sizeof(int);{targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);{{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);{{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}}}}
            }
            
            int offset = (int)(targetPtr - m_ptr);
            this.m_ptr = this.ResizeFunction(this.m_ptr - sizeof(int), offset + sizeof(int), size);
            *(int*)this.m_ptr += size;
            this.m_ptr += sizeof(int);
            targetPtr = this.m_ptr + offset;
            
            {

        if(element.cbc_ID!= null)
        {
            int strlen_1 = element.cbc_ID.Length * 2;
            *(int*)targetPtr = strlen_1;
            targetPtr += sizeof(int);
            fixed(char* pstr_1 = element.cbc_ID)
            {
                Memory.Copy(pstr_1, targetPtr, strlen_1);
                targetPtr += strlen_1;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            {
            *(ISO639_1_LanguageCodes*)targetPtr = element.cbc_Note._languageID;
            targetPtr += 1;

        if(element.cbc_Note.note!= null)
        {
            int strlen_2 = element.cbc_Note.note.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = element.cbc_Note.note)
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
            {

        if(element.cbc_InvoicedQuantity._unitCode!= null)
        {
            int strlen_2 = element.cbc_InvoicedQuantity._unitCode.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = element.cbc_InvoicedQuantity._unitCode)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(long*)targetPtr = element.cbc_InvoicedQuantity.quantity;
            targetPtr += 8;

            }
            {

        if(element.cbc_LineExtensionAmount._CurrencyID!= null)
        {
            int strlen_2 = element.cbc_LineExtensionAmount._CurrencyID.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = element.cbc_LineExtensionAmount._CurrencyID)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(double*)targetPtr = element.cbc_LineExtensionAmount.amount;
            targetPtr += 8;

            }
        if(element.cbc_AccountingCost!= null)
        {
            int strlen_1 = element.cbc_AccountingCost.Length * 2;
            *(int*)targetPtr = strlen_1;
            targetPtr += sizeof(int);
            fixed(char* pstr_1 = element.cbc_AccountingCost)
            {
                Memory.Copy(pstr_1, targetPtr, strlen_1);
                targetPtr += strlen_1;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            {

        if(element.cac_OrderLineReference.cbc_LineID!= null)
        {
            int strlen_2 = element.cac_OrderLineReference.cbc_LineID.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = element.cac_OrderLineReference.cbc_LineID)
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
{
byte *storedPtr_1 = targetPtr;

    targetPtr += sizeof(int);
    if(element.cac_AllowanceCharges!= null)
    {
        for(int iterator_1 = 0;iterator_1<element.cac_AllowanceCharges.Count;++iterator_1)
        {

            {
            *(bool*)targetPtr = element.cac_AllowanceCharges[iterator_1].cbc_ChargeIndicator;
            targetPtr += 1;

        if(element.cac_AllowanceCharges[iterator_1].cbc_AllowanceChargeReason!= null)
        {
            int strlen_3 = element.cac_AllowanceCharges[iterator_1].cbc_AllowanceChargeReason.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = element.cac_AllowanceCharges[iterator_1].cbc_AllowanceChargeReason)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            {

        if(element.cac_AllowanceCharges[iterator_1].cbc_Amount._CurrencyID!= null)
        {
            int strlen_4 = element.cac_AllowanceCharges[iterator_1].cbc_Amount._CurrencyID.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = element.cac_AllowanceCharges[iterator_1].cbc_Amount._CurrencyID)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(double*)targetPtr = element.cac_AllowanceCharges[iterator_1].cbc_Amount.amount;
            targetPtr += 8;

            }
            }
        }
    }
*(int*)storedPtr_1 = (int)(targetPtr - storedPtr_1 - 4);

}

            {

            {

        if(element.cac_TaxTotal.cbc_TaxAmount._CurrencyID!= null)
        {
            int strlen_3 = element.cac_TaxTotal.cbc_TaxAmount._CurrencyID.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = element.cac_TaxTotal.cbc_TaxAmount._CurrencyID)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(double*)targetPtr = element.cac_TaxTotal.cbc_TaxAmount.amount;
            targetPtr += 8;

            }
{
byte *storedPtr_2 = targetPtr;

    targetPtr += sizeof(int);
    if(element.cac_TaxTotal.cac_TaxSubtotals!= null)
    {
        for(int iterator_2 = 0;iterator_2<element.cac_TaxTotal.cac_TaxSubtotals.Count;++iterator_2)
        {

            {

            {

        if(element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cbc_TaxableAmount._CurrencyID!= null)
        {
            int strlen_5 = element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cbc_TaxableAmount._CurrencyID.Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cbc_TaxableAmount._CurrencyID)
            {
                Memory.Copy(pstr_5, targetPtr, strlen_5);
                targetPtr += strlen_5;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(double*)targetPtr = element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cbc_TaxableAmount.amount;
            targetPtr += 8;

            }
            {

        if(element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cbc_TaxAmount._CurrencyID!= null)
        {
            int strlen_5 = element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cbc_TaxAmount._CurrencyID.Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cbc_TaxAmount._CurrencyID)
            {
                Memory.Copy(pstr_5, targetPtr, strlen_5);
                targetPtr += strlen_5;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(double*)targetPtr = element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cbc_TaxAmount.amount;
            targetPtr += 8;

            }
            {

            {
            byte* optheader_5 = targetPtr;
            *(optheader_5 + 0) = 0x00;            targetPtr += 1;

        if(element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cbc_ID._schemeID!= null)
        {
            int strlen_6 = element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cbc_ID._schemeID.Length * 2;
            *(int*)targetPtr = strlen_6;
            targetPtr += sizeof(int);
            fixed(char* pstr_6 = element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cbc_ID._schemeID)
            {
                Memory.Copy(pstr_6, targetPtr, strlen_6);
                targetPtr += strlen_6;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            if( element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cbc_ID._schemeAgencyID!= null)
            {

        if(element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cbc_ID._schemeAgencyID!= null)
        {
            int strlen_6 = element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cbc_ID._schemeAgencyID.Length * 2;
            *(int*)targetPtr = strlen_6;
            targetPtr += sizeof(int);
            fixed(char* pstr_6 = element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cbc_ID._schemeAgencyID)
            {
                Memory.Copy(pstr_6, targetPtr, strlen_6);
                targetPtr += strlen_6;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
*(optheader_5 + 0) |= 0x01;
            }

        if(element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cbc_ID.code!= null)
        {
            int strlen_6 = element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cbc_ID.code.Length * 2;
            *(int*)targetPtr = strlen_6;
            targetPtr += sizeof(int);
            fixed(char* pstr_6 = element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cbc_ID.code)
            {
                Memory.Copy(pstr_6, targetPtr, strlen_6);
                targetPtr += strlen_6;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }            *(double*)targetPtr = element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cbc_Percent;
            targetPtr += 8;

            {

            {
            byte* optheader_6 = targetPtr;
            *(optheader_6 + 0) = 0x00;            targetPtr += 1;

        if(element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeID!= null)
        {
            int strlen_7 = element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeID.Length * 2;
            *(int*)targetPtr = strlen_7;
            targetPtr += sizeof(int);
            fixed(char* pstr_7 = element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeID)
            {
                Memory.Copy(pstr_7, targetPtr, strlen_7);
                targetPtr += strlen_7;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            if( element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeAgencyID!= null)
            {

        if(element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeAgencyID!= null)
        {
            int strlen_7 = element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeAgencyID.Length * 2;
            *(int*)targetPtr = strlen_7;
            targetPtr += sizeof(int);
            fixed(char* pstr_7 = element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeAgencyID)
            {
                Memory.Copy(pstr_7, targetPtr, strlen_7);
                targetPtr += strlen_7;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
*(optheader_6 + 0) |= 0x01;
            }

        if(element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cac_TaxScheme.cbc_ID.code!= null)
        {
            int strlen_7 = element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cac_TaxScheme.cbc_ID.code.Length * 2;
            *(int*)targetPtr = strlen_7;
            targetPtr += sizeof(int);
            fixed(char* pstr_7 = element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cac_TaxScheme.cbc_ID.code)
            {
                Memory.Copy(pstr_7, targetPtr, strlen_7);
                targetPtr += strlen_7;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }
            }
            }
            }
        }
    }
*(int*)storedPtr_2 = (int)(targetPtr - storedPtr_2 - 4);

}

            }
        if(element.cac_ItemUdid!= null)
        {
            int strlen_1 = element.cac_ItemUdid.Length * 2;
            *(int*)targetPtr = strlen_1;
            targetPtr += sizeof(int);
            fixed(char* pstr_1 = element.cac_ItemUdid)
            {
                Memory.Copy(pstr_1, targetPtr, strlen_1);
                targetPtr += strlen_1;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            {

            {

        if(element.cac_Price.cbc_PriceAmount._CurrencyID!= null)
        {
            int strlen_3 = element.cac_Price.cbc_PriceAmount._CurrencyID.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = element.cac_Price.cbc_PriceAmount._CurrencyID)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(double*)targetPtr = element.cac_Price.cbc_PriceAmount.amount;
            targetPtr += 8;

            }
            {

        if(element.cac_Price.cbc_BaseQuantity._unitCode!= null)
        {
            int strlen_3 = element.cac_Price.cbc_BaseQuantity._unitCode.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = element.cac_Price.cbc_BaseQuantity._unitCode)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(long*)targetPtr = element.cac_Price.cbc_BaseQuantity.quantity;
            targetPtr += 8;

            }
            {
            *(bool*)targetPtr = element.cac_Price.cac_AllowanceCharge.cbc_ChargeIndicator;
            targetPtr += 1;

        if(element.cac_Price.cac_AllowanceCharge.cbc_AllowanceChargeReason!= null)
        {
            int strlen_3 = element.cac_Price.cac_AllowanceCharge.cbc_AllowanceChargeReason.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = element.cac_Price.cac_AllowanceCharge.cbc_AllowanceChargeReason)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            {

        if(element.cac_Price.cac_AllowanceCharge.cbc_Amount._CurrencyID!= null)
        {
            int strlen_4 = element.cac_Price.cac_AllowanceCharge.cbc_Amount._CurrencyID.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = element.cac_Price.cac_AllowanceCharge.cbc_Amount._CurrencyID)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(double*)targetPtr = element.cac_Price.cac_AllowanceCharge.cbc_Amount.amount;
            targetPtr += 8;

            }
            }
            }
            }
        }
        /// <summary>
        /// Inserts an element into a sorted list.
        /// </summary>
        /// <param name="element">The object to insert.</param>
        /// <param name="comparison"></param>
        public unsafe void Insert(Cac_InvoiceLine element, Comparison<Cac_InvoiceLine_Accessor> comparison)
        {
            byte* targetPtr = null;
            {
                
            {

        if(element.cbc_ID!= null)
        {
            int strlen_1 = element.cbc_ID.Length * 2;
            targetPtr += strlen_1+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            {
            targetPtr += 1;

        if(element.cbc_Note.note!= null)
        {
            int strlen_2 = element.cbc_Note.note.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            {

        if(element.cbc_InvoicedQuantity._unitCode!= null)
        {
            int strlen_2 = element.cbc_InvoicedQuantity._unitCode.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            {

        if(element.cbc_LineExtensionAmount._CurrencyID!= null)
        {
            int strlen_2 = element.cbc_LineExtensionAmount._CurrencyID.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
        if(element.cbc_AccountingCost!= null)
        {
            int strlen_1 = element.cbc_AccountingCost.Length * 2;
            targetPtr += strlen_1+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            {

        if(element.cac_OrderLineReference.cbc_LineID!= null)
        {
            int strlen_2 = element.cac_OrderLineReference.cbc_LineID.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
{

    targetPtr += sizeof(int);
    if(element.cac_AllowanceCharges!= null)
    {
        for(int iterator_1 = 0;iterator_1<element.cac_AllowanceCharges.Count;++iterator_1)
        {

            {
            targetPtr += 1;

        if(element.cac_AllowanceCharges[iterator_1].cbc_AllowanceChargeReason!= null)
        {
            int strlen_3 = element.cac_AllowanceCharges[iterator_1].cbc_AllowanceChargeReason.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            {

        if(element.cac_AllowanceCharges[iterator_1].cbc_Amount._CurrencyID!= null)
        {
            int strlen_4 = element.cac_AllowanceCharges[iterator_1].cbc_Amount._CurrencyID.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            }
        }
    }

}

            {

            {

        if(element.cac_TaxTotal.cbc_TaxAmount._CurrencyID!= null)
        {
            int strlen_3 = element.cac_TaxTotal.cbc_TaxAmount._CurrencyID.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
{

    targetPtr += sizeof(int);
    if(element.cac_TaxTotal.cac_TaxSubtotals!= null)
    {
        for(int iterator_2 = 0;iterator_2<element.cac_TaxTotal.cac_TaxSubtotals.Count;++iterator_2)
        {

            {

            {

        if(element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cbc_TaxableAmount._CurrencyID!= null)
        {
            int strlen_5 = element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cbc_TaxableAmount._CurrencyID.Length * 2;
            targetPtr += strlen_5+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            {

        if(element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cbc_TaxAmount._CurrencyID!= null)
        {
            int strlen_5 = element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cbc_TaxAmount._CurrencyID.Length * 2;
            targetPtr += strlen_5+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            {

            {
            targetPtr += 1;

        if(element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cbc_ID._schemeID!= null)
        {
            int strlen_6 = element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cbc_ID._schemeID.Length * 2;
            targetPtr += strlen_6+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            if( element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cbc_ID._schemeAgencyID!= null)
            {

        if(element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cbc_ID._schemeAgencyID!= null)
        {
            int strlen_6 = element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cbc_ID._schemeAgencyID.Length * 2;
            targetPtr += strlen_6+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }

        if(element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cbc_ID.code!= null)
        {
            int strlen_6 = element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cbc_ID.code.Length * 2;
            targetPtr += strlen_6+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }            targetPtr += 8;

            {

            {
            targetPtr += 1;

        if(element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeID!= null)
        {
            int strlen_7 = element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeID.Length * 2;
            targetPtr += strlen_7+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            if( element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeAgencyID!= null)
            {

        if(element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeAgencyID!= null)
        {
            int strlen_7 = element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeAgencyID.Length * 2;
            targetPtr += strlen_7+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }

        if(element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cac_TaxScheme.cbc_ID.code!= null)
        {
            int strlen_7 = element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cac_TaxScheme.cbc_ID.code.Length * 2;
            targetPtr += strlen_7+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            }
            }
            }
        }
    }

}

            }
        if(element.cac_ItemUdid!= null)
        {
            int strlen_1 = element.cac_ItemUdid.Length * 2;
            targetPtr += strlen_1+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            {

            {

        if(element.cac_Price.cbc_PriceAmount._CurrencyID!= null)
        {
            int strlen_3 = element.cac_Price.cbc_PriceAmount._CurrencyID.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            {

        if(element.cac_Price.cbc_BaseQuantity._unitCode!= null)
        {
            int strlen_3 = element.cac_Price.cbc_BaseQuantity._unitCode.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            {
            targetPtr += 1;

        if(element.cac_Price.cac_AllowanceCharge.cbc_AllowanceChargeReason!= null)
        {
            int strlen_3 = element.cac_Price.cac_AllowanceCharge.cbc_AllowanceChargeReason.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            {

        if(element.cac_Price.cac_AllowanceCharge.cbc_Amount._CurrencyID!= null)
        {
            int strlen_4 = element.cac_Price.cac_AllowanceCharge.cbc_Amount._CurrencyID.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            }
            }
            }
            }
            int size = (int)targetPtr;
            targetPtr = m_ptr;
            byte* endPtr = m_ptr + length;
            while (targetPtr<endPtr)
            {
                
                {
                    elementAccessor.m_ptr = targetPtr + 4;
                    if (comparison(elementAccessor, element)<=0)
                    {
                        {targetPtr += *(int*)targetPtr + sizeof(int);{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}targetPtr += *(int*)targetPtr + sizeof(int);{targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);{{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);{{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}}}}
                    }
                    else
                    {
                        break;
                    }
                }
                
            }
            int offset = (int)(targetPtr - m_ptr);
            this.m_ptr = this.ResizeFunction(this.m_ptr - sizeof(int), offset + sizeof(int), size);
            *(int*)this.m_ptr += size;
            this.m_ptr += sizeof(int);
            targetPtr = this.m_ptr + offset;
            
            {

        if(element.cbc_ID!= null)
        {
            int strlen_1 = element.cbc_ID.Length * 2;
            *(int*)targetPtr = strlen_1;
            targetPtr += sizeof(int);
            fixed(char* pstr_1 = element.cbc_ID)
            {
                Memory.Copy(pstr_1, targetPtr, strlen_1);
                targetPtr += strlen_1;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            {
            *(ISO639_1_LanguageCodes*)targetPtr = element.cbc_Note._languageID;
            targetPtr += 1;

        if(element.cbc_Note.note!= null)
        {
            int strlen_2 = element.cbc_Note.note.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = element.cbc_Note.note)
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
            {

        if(element.cbc_InvoicedQuantity._unitCode!= null)
        {
            int strlen_2 = element.cbc_InvoicedQuantity._unitCode.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = element.cbc_InvoicedQuantity._unitCode)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(long*)targetPtr = element.cbc_InvoicedQuantity.quantity;
            targetPtr += 8;

            }
            {

        if(element.cbc_LineExtensionAmount._CurrencyID!= null)
        {
            int strlen_2 = element.cbc_LineExtensionAmount._CurrencyID.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = element.cbc_LineExtensionAmount._CurrencyID)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(double*)targetPtr = element.cbc_LineExtensionAmount.amount;
            targetPtr += 8;

            }
        if(element.cbc_AccountingCost!= null)
        {
            int strlen_1 = element.cbc_AccountingCost.Length * 2;
            *(int*)targetPtr = strlen_1;
            targetPtr += sizeof(int);
            fixed(char* pstr_1 = element.cbc_AccountingCost)
            {
                Memory.Copy(pstr_1, targetPtr, strlen_1);
                targetPtr += strlen_1;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            {

        if(element.cac_OrderLineReference.cbc_LineID!= null)
        {
            int strlen_2 = element.cac_OrderLineReference.cbc_LineID.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = element.cac_OrderLineReference.cbc_LineID)
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
{
byte *storedPtr_1 = targetPtr;

    targetPtr += sizeof(int);
    if(element.cac_AllowanceCharges!= null)
    {
        for(int iterator_1 = 0;iterator_1<element.cac_AllowanceCharges.Count;++iterator_1)
        {

            {
            *(bool*)targetPtr = element.cac_AllowanceCharges[iterator_1].cbc_ChargeIndicator;
            targetPtr += 1;

        if(element.cac_AllowanceCharges[iterator_1].cbc_AllowanceChargeReason!= null)
        {
            int strlen_3 = element.cac_AllowanceCharges[iterator_1].cbc_AllowanceChargeReason.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = element.cac_AllowanceCharges[iterator_1].cbc_AllowanceChargeReason)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            {

        if(element.cac_AllowanceCharges[iterator_1].cbc_Amount._CurrencyID!= null)
        {
            int strlen_4 = element.cac_AllowanceCharges[iterator_1].cbc_Amount._CurrencyID.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = element.cac_AllowanceCharges[iterator_1].cbc_Amount._CurrencyID)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(double*)targetPtr = element.cac_AllowanceCharges[iterator_1].cbc_Amount.amount;
            targetPtr += 8;

            }
            }
        }
    }
*(int*)storedPtr_1 = (int)(targetPtr - storedPtr_1 - 4);

}

            {

            {

        if(element.cac_TaxTotal.cbc_TaxAmount._CurrencyID!= null)
        {
            int strlen_3 = element.cac_TaxTotal.cbc_TaxAmount._CurrencyID.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = element.cac_TaxTotal.cbc_TaxAmount._CurrencyID)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(double*)targetPtr = element.cac_TaxTotal.cbc_TaxAmount.amount;
            targetPtr += 8;

            }
{
byte *storedPtr_2 = targetPtr;

    targetPtr += sizeof(int);
    if(element.cac_TaxTotal.cac_TaxSubtotals!= null)
    {
        for(int iterator_2 = 0;iterator_2<element.cac_TaxTotal.cac_TaxSubtotals.Count;++iterator_2)
        {

            {

            {

        if(element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cbc_TaxableAmount._CurrencyID!= null)
        {
            int strlen_5 = element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cbc_TaxableAmount._CurrencyID.Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cbc_TaxableAmount._CurrencyID)
            {
                Memory.Copy(pstr_5, targetPtr, strlen_5);
                targetPtr += strlen_5;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(double*)targetPtr = element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cbc_TaxableAmount.amount;
            targetPtr += 8;

            }
            {

        if(element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cbc_TaxAmount._CurrencyID!= null)
        {
            int strlen_5 = element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cbc_TaxAmount._CurrencyID.Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cbc_TaxAmount._CurrencyID)
            {
                Memory.Copy(pstr_5, targetPtr, strlen_5);
                targetPtr += strlen_5;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(double*)targetPtr = element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cbc_TaxAmount.amount;
            targetPtr += 8;

            }
            {

            {
            byte* optheader_5 = targetPtr;
            *(optheader_5 + 0) = 0x00;            targetPtr += 1;

        if(element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cbc_ID._schemeID!= null)
        {
            int strlen_6 = element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cbc_ID._schemeID.Length * 2;
            *(int*)targetPtr = strlen_6;
            targetPtr += sizeof(int);
            fixed(char* pstr_6 = element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cbc_ID._schemeID)
            {
                Memory.Copy(pstr_6, targetPtr, strlen_6);
                targetPtr += strlen_6;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            if( element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cbc_ID._schemeAgencyID!= null)
            {

        if(element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cbc_ID._schemeAgencyID!= null)
        {
            int strlen_6 = element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cbc_ID._schemeAgencyID.Length * 2;
            *(int*)targetPtr = strlen_6;
            targetPtr += sizeof(int);
            fixed(char* pstr_6 = element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cbc_ID._schemeAgencyID)
            {
                Memory.Copy(pstr_6, targetPtr, strlen_6);
                targetPtr += strlen_6;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
*(optheader_5 + 0) |= 0x01;
            }

        if(element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cbc_ID.code!= null)
        {
            int strlen_6 = element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cbc_ID.code.Length * 2;
            *(int*)targetPtr = strlen_6;
            targetPtr += sizeof(int);
            fixed(char* pstr_6 = element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cbc_ID.code)
            {
                Memory.Copy(pstr_6, targetPtr, strlen_6);
                targetPtr += strlen_6;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }            *(double*)targetPtr = element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cbc_Percent;
            targetPtr += 8;

            {

            {
            byte* optheader_6 = targetPtr;
            *(optheader_6 + 0) = 0x00;            targetPtr += 1;

        if(element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeID!= null)
        {
            int strlen_7 = element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeID.Length * 2;
            *(int*)targetPtr = strlen_7;
            targetPtr += sizeof(int);
            fixed(char* pstr_7 = element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeID)
            {
                Memory.Copy(pstr_7, targetPtr, strlen_7);
                targetPtr += strlen_7;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            if( element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeAgencyID!= null)
            {

        if(element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeAgencyID!= null)
        {
            int strlen_7 = element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeAgencyID.Length * 2;
            *(int*)targetPtr = strlen_7;
            targetPtr += sizeof(int);
            fixed(char* pstr_7 = element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeAgencyID)
            {
                Memory.Copy(pstr_7, targetPtr, strlen_7);
                targetPtr += strlen_7;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
*(optheader_6 + 0) |= 0x01;
            }

        if(element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cac_TaxScheme.cbc_ID.code!= null)
        {
            int strlen_7 = element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cac_TaxScheme.cbc_ID.code.Length * 2;
            *(int*)targetPtr = strlen_7;
            targetPtr += sizeof(int);
            fixed(char* pstr_7 = element.cac_TaxTotal.cac_TaxSubtotals[iterator_2].cac_TaxCategory.cac_TaxScheme.cbc_ID.code)
            {
                Memory.Copy(pstr_7, targetPtr, strlen_7);
                targetPtr += strlen_7;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }
            }
            }
            }
        }
    }
*(int*)storedPtr_2 = (int)(targetPtr - storedPtr_2 - 4);

}

            }
        if(element.cac_ItemUdid!= null)
        {
            int strlen_1 = element.cac_ItemUdid.Length * 2;
            *(int*)targetPtr = strlen_1;
            targetPtr += sizeof(int);
            fixed(char* pstr_1 = element.cac_ItemUdid)
            {
                Memory.Copy(pstr_1, targetPtr, strlen_1);
                targetPtr += strlen_1;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            {

            {

        if(element.cac_Price.cbc_PriceAmount._CurrencyID!= null)
        {
            int strlen_3 = element.cac_Price.cbc_PriceAmount._CurrencyID.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = element.cac_Price.cbc_PriceAmount._CurrencyID)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(double*)targetPtr = element.cac_Price.cbc_PriceAmount.amount;
            targetPtr += 8;

            }
            {

        if(element.cac_Price.cbc_BaseQuantity._unitCode!= null)
        {
            int strlen_3 = element.cac_Price.cbc_BaseQuantity._unitCode.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = element.cac_Price.cbc_BaseQuantity._unitCode)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(long*)targetPtr = element.cac_Price.cbc_BaseQuantity.quantity;
            targetPtr += 8;

            }
            {
            *(bool*)targetPtr = element.cac_Price.cac_AllowanceCharge.cbc_ChargeIndicator;
            targetPtr += 1;

        if(element.cac_Price.cac_AllowanceCharge.cbc_AllowanceChargeReason!= null)
        {
            int strlen_3 = element.cac_Price.cac_AllowanceCharge.cbc_AllowanceChargeReason.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = element.cac_Price.cac_AllowanceCharge.cbc_AllowanceChargeReason)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            {

        if(element.cac_Price.cac_AllowanceCharge.cbc_Amount._CurrencyID!= null)
        {
            int strlen_4 = element.cac_Price.cac_AllowanceCharge.cbc_Amount._CurrencyID.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = element.cac_Price.cac_AllowanceCharge.cbc_Amount._CurrencyID)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(double*)targetPtr = element.cac_Price.cac_AllowanceCharge.cbc_Amount.amount;
            targetPtr += 8;

            }
            }
            }
            }
        }
        /// <summary>
        /// Removes the element at the specified index of the List.
        /// </summary>
        /// <param name="index">The zero-based index of the element to remove.</param>
        public unsafe void RemoveAt(int index)
        {
            if (index < 0 || index >= Count) throw new IndexOutOfRangeException();
            byte* targetPtr = m_ptr;
            for (int i = 0; i < index; i++)
            {
                {targetPtr += *(int*)targetPtr + sizeof(int);{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}targetPtr += *(int*)targetPtr + sizeof(int);{targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);{{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);{{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}}}}
            }
            int offset = (int)(targetPtr - m_ptr);
            byte* oldtargetPtr = targetPtr;
            {targetPtr += *(int*)targetPtr + sizeof(int);{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}targetPtr += *(int*)targetPtr + sizeof(int);{targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);{{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);{{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}}}}
            int size = (int)(oldtargetPtr - targetPtr);
            this.m_ptr = this.ResizeFunction(this.m_ptr - sizeof(int), offset + sizeof(int), size);
            *(int*)this.m_ptr += size;
            this.m_ptr += sizeof(int);
        }
        /// <summary>
        /// Adds the elements of the specified collection to the end of the List
        /// </summary>
        /// <param name="collection">The collection whose elements should be added to the end of the List. The collection itself cannot be null.</param>
        public unsafe void AddRange(List<Cac_InvoiceLine> collection)
        {
            if (collection == null) throw new ArgumentNullException("collection is null.");
            Cac_InvoiceLine_AccessorListAccessor tcollection = collection;
            int delta = tcollection.length;
            m_ptr = ResizeFunction(m_ptr - 4, *(int*)(m_ptr - 4) + 4, delta);
            Memory.Copy(tcollection.m_ptr, m_ptr + *(int*)m_ptr + 4, delta);
            *(int*)m_ptr += delta;
            this.m_ptr += 4;
        }
        /// <summary>
        /// Adds the elements of the specified collection to the end of the List
        /// </summary>
        /// <param name="collection">The collection whose elements should be added to the end of the List. The collection itself cannot be null.</param>
        public unsafe void AddRange(Cac_InvoiceLine_AccessorListAccessor collection)
        {
            if (collection == null) throw new ArgumentNullException("collection is null.");
            int delta = collection.length;
            if (collection.m_cellId != m_cellId)
            {
                m_ptr = ResizeFunction(m_ptr - 4, *(int*)(m_ptr - 4) + 4, delta);
                Memory.Copy(collection.m_ptr, m_ptr + *(int*)m_ptr + 4, delta);
                *(int*)m_ptr += delta;
            }
            else
            {
                byte[] tmpcell = new byte[delta];
                fixed (byte* tmpcellptr = tmpcell)
                {
                    Memory.Copy(collection.m_ptr, tmpcellptr, delta);
                    m_ptr = ResizeFunction(m_ptr - 4, *(int*)(m_ptr - 4) + 4, delta);
                    Memory.Copy(tmpcellptr, m_ptr + *(int*)m_ptr + 4, delta);
                    *(int*)m_ptr += delta;
                }
            }
            this.m_ptr += 4;
        }
        /// <summary>
        /// Removes all elements from the List
        /// </summary>
        public unsafe void Clear()
        {
            int delta = length;
            Memory.memset(m_ptr, 0, (ulong)delta);
            m_ptr = ResizeFunction(m_ptr - 4, 4, -delta);
            *(int*)m_ptr = 0;
            this.m_ptr += 4;
        }
        /// <summary>
        /// Determines whether an element is in the List
        /// </summary>
        /// <param name="item">The object to locate in the List.The value can be null for non-atom types</param>
        /// <returns>true if item is found in the List; otherwise, false.</returns>
        public unsafe bool Contains(Cac_InvoiceLine_Accessor item)
        {
            bool ret = false;
            ForEach(x =>
            {
                if (item == x) ret = true;
            });
            return ret;
        }
        /// <summary>
        /// Determines whether the List contains elements that match the conditions defined by the specified predicate.
        /// </summary>
        /// <param name="match">The Predicate delegate that defines the conditions of the elements to search for.</param>
        /// <returns>true if the List contains one or more elements that match the conditions defined by the specified predicate; otherwise, false.</returns>
        public unsafe bool Exists(Predicate<Cac_InvoiceLine_Accessor> match)
        {
            bool ret = false;
            ForEach(x =>
            {
                if (match(x)) ret = true;
            });
            return ret;
        }
        
        /// <summary>
        /// Copies the entire List to a compatible one-dimensional array, starting at the beginning of the ptr1 array.
        /// </summary>
        /// <param name="array">The one-dimensional Array that is the destination of the elements copied from List. The Array must have zero-based indexing.</param>
        public unsafe void CopyTo(Cac_InvoiceLine[] array)
        {
            if (array == null) throw new ArgumentNullException("array is null.");
            if (array.Length < Count) throw new ArgumentException("The number of elements in the source List is greater than the number of elements that the destination array can contain.");
            ForEach((x, i) => array[i] = x);
        }
        /// <summary>
        /// Copies the entire List to a compatible one-dimensional array, starting at the specified index of the ptr1 array.
        /// </summary>
        /// <param name="array">The one-dimensional Array that is the destination of the elements copied from List. The Array must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
        public unsafe void CopyTo(Cac_InvoiceLine[] array, int arrayIndex)
        {
            if (array == null) throw new ArgumentNullException("array is null.");
            if (arrayIndex < 0) throw new ArgumentOutOfRangeException("arrayIndex is less than 0.");
            if (array.Length - arrayIndex < Count) throw new ArgumentException("The number of elements in the source List is greater than the available space from arrayIndex to the end of the destination array.");
            ForEach((x, i) => array[i + arrayIndex] = x);
        }
        /// <summary>
        /// Copies a range of elements from the List to a compatible one-dimensional array, starting at the specified index of the ptr1 array.
        /// </summary>
        /// <param name="index">The zero-based index in the source List at which copying begins.</param>
        /// <param name="array">The one-dimensional Array that is the destination of the elements copied from List. The Array must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>;
        /// <param name="count">The number of elements to copy.</param>
        public unsafe void CopyTo(int index, Cac_InvoiceLine[] array, int arrayIndex, int count)
        {
            if (array == null) throw new ArgumentNullException("array is null.");
            if (arrayIndex < 0 || index < 0 || count < 0) throw new ArgumentOutOfRangeException("arrayIndex is less than 0 or index is less than 0 or count is less than 0.");
            if (array.Length - arrayIndex < count) throw new ArgumentException("The number of elements from index to the end of the source List is greater than the available space from arrayIndex to the end of the destination array. ");
            if (index + count > Count) throw new ArgumentException("Source list does not have enough elements to copy.");
            int j = 0;
            for (int i = index; i < index + count; i++)
            {
                array[j + arrayIndex] = this[i];
                ++j;
            }
        }
          
        /// <summary>
        /// Inserts the elements of a collection into the List at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which the new elements should be inserted.</param>
        /// <param name="collection">The collection whose elements should be inserted into the List. The collection itself cannot be null, but it can contain elements that are null, if type T is a reference type.</param>
        public unsafe void InsertRange(int index, List<Cac_InvoiceLine> collection)
        {
            if (collection == null) throw new ArgumentNullException("collection is null.");
            if (index < 0) throw new ArgumentOutOfRangeException("index is less than 0.");
            if (index > Count) throw new ArgumentOutOfRangeException("index is greater than Count.");
            Cac_InvoiceLine_AccessorListAccessor tmpAccessor = collection;
            byte* targetPtr = m_ptr;
            for (int i = 0; i < index; i++)
            {
                {targetPtr += *(int*)targetPtr + sizeof(int);{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}targetPtr += *(int*)targetPtr + sizeof(int);{targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);{{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);{{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}}}}
            }
            int offset = (int)(targetPtr - m_ptr);
            m_ptr = ResizeFunction(m_ptr - 4, offset + 4, tmpAccessor.length);
            Memory.Copy(tmpAccessor.m_ptr, m_ptr + offset + 4, tmpAccessor.length);
            *(int*)m_ptr += tmpAccessor.length;
            this.m_ptr += 4;
        }
        /// <summary>
        /// Removes a range of elements from the List.
        /// </summary>
        /// <param name="index">The zero-based starting index of the range of elements to remove.</param>
        /// <param name="count">The number of elements to remove.</param>
        public unsafe void RemoveRange(int index, int count)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index is less than 0.");
            if (index > Count) throw new ArgumentOutOfRangeException("index is greater than Count.");
            if (index + count > Count) throw new ArgumentException("index and count do not denote a valid range of elements in the List.");
            byte* targetPtr = m_ptr;
            for (int i = 0; i < index; i++)
            {
                {targetPtr += *(int*)targetPtr + sizeof(int);{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}targetPtr += *(int*)targetPtr + sizeof(int);{targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);{{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);{{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}}}}
            }
            int offset = (int)(targetPtr - m_ptr);
            byte* oldtargetPtr = targetPtr;
            for (int i = 0; i < count; i++)
            {
                {targetPtr += *(int*)targetPtr + sizeof(int);{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}targetPtr += *(int*)targetPtr + sizeof(int);{targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);{{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}targetPtr += *(int*)targetPtr + sizeof(int);}targetPtr += *(int*)targetPtr + sizeof(int);{{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{            targetPtr += 1;
targetPtr += *(int*)targetPtr + sizeof(int);{targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}}}}
            }
            int size = (int)(oldtargetPtr - targetPtr);
            m_ptr = ResizeFunction(m_ptr - 4, offset + 4, size);
            *(int*)m_ptr += size;
            this.m_ptr += 4;
        }
        public unsafe static implicit operator List<Cac_InvoiceLine> (Cac_InvoiceLine_AccessorListAccessor accessor)
        {
            if((object)accessor == null) return null;
            List<Cac_InvoiceLine> list = new List<Cac_InvoiceLine>();
            accessor.ForEach(element => list.Add(element));
            return list;
        }
        
        public unsafe static implicit operator Cac_InvoiceLine_AccessorListAccessor(List<Cac_InvoiceLine> field)
        {
            byte* targetPtr = null;
            
{

    targetPtr += sizeof(int);
    if(field!= null)
    {
        for(int iterator_1 = 0;iterator_1<field.Count;++iterator_1)
        {

            {

        if(field[iterator_1].cbc_ID!= null)
        {
            int strlen_3 = field[iterator_1].cbc_ID.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            {
            targetPtr += 1;

        if(field[iterator_1].cbc_Note.note!= null)
        {
            int strlen_4 = field[iterator_1].cbc_Note.note.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            {

        if(field[iterator_1].cbc_InvoicedQuantity._unitCode!= null)
        {
            int strlen_4 = field[iterator_1].cbc_InvoicedQuantity._unitCode.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            {

        if(field[iterator_1].cbc_LineExtensionAmount._CurrencyID!= null)
        {
            int strlen_4 = field[iterator_1].cbc_LineExtensionAmount._CurrencyID.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
        if(field[iterator_1].cbc_AccountingCost!= null)
        {
            int strlen_3 = field[iterator_1].cbc_AccountingCost.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            {

        if(field[iterator_1].cac_OrderLineReference.cbc_LineID!= null)
        {
            int strlen_4 = field[iterator_1].cac_OrderLineReference.cbc_LineID.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
{

    targetPtr += sizeof(int);
    if(field[iterator_1].cac_AllowanceCharges!= null)
    {
        for(int iterator_3 = 0;iterator_3<field[iterator_1].cac_AllowanceCharges.Count;++iterator_3)
        {

            {
            targetPtr += 1;

        if(field[iterator_1].cac_AllowanceCharges[iterator_3].cbc_AllowanceChargeReason!= null)
        {
            int strlen_5 = field[iterator_1].cac_AllowanceCharges[iterator_3].cbc_AllowanceChargeReason.Length * 2;
            targetPtr += strlen_5+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            {

        if(field[iterator_1].cac_AllowanceCharges[iterator_3].cbc_Amount._CurrencyID!= null)
        {
            int strlen_6 = field[iterator_1].cac_AllowanceCharges[iterator_3].cbc_Amount._CurrencyID.Length * 2;
            targetPtr += strlen_6+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            }
        }
    }

}

            {

            {

        if(field[iterator_1].cac_TaxTotal.cbc_TaxAmount._CurrencyID!= null)
        {
            int strlen_5 = field[iterator_1].cac_TaxTotal.cbc_TaxAmount._CurrencyID.Length * 2;
            targetPtr += strlen_5+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
{

    targetPtr += sizeof(int);
    if(field[iterator_1].cac_TaxTotal.cac_TaxSubtotals!= null)
    {
        for(int iterator_4 = 0;iterator_4<field[iterator_1].cac_TaxTotal.cac_TaxSubtotals.Count;++iterator_4)
        {

            {

            {

        if(field[iterator_1].cac_TaxTotal.cac_TaxSubtotals[iterator_4].cbc_TaxableAmount._CurrencyID!= null)
        {
            int strlen_7 = field[iterator_1].cac_TaxTotal.cac_TaxSubtotals[iterator_4].cbc_TaxableAmount._CurrencyID.Length * 2;
            targetPtr += strlen_7+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            {

        if(field[iterator_1].cac_TaxTotal.cac_TaxSubtotals[iterator_4].cbc_TaxAmount._CurrencyID!= null)
        {
            int strlen_7 = field[iterator_1].cac_TaxTotal.cac_TaxSubtotals[iterator_4].cbc_TaxAmount._CurrencyID.Length * 2;
            targetPtr += strlen_7+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            {

            {
            targetPtr += 1;

        if(field[iterator_1].cac_TaxTotal.cac_TaxSubtotals[iterator_4].cac_TaxCategory.cbc_ID._schemeID!= null)
        {
            int strlen_8 = field[iterator_1].cac_TaxTotal.cac_TaxSubtotals[iterator_4].cac_TaxCategory.cbc_ID._schemeID.Length * 2;
            targetPtr += strlen_8+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            if( field[iterator_1].cac_TaxTotal.cac_TaxSubtotals[iterator_4].cac_TaxCategory.cbc_ID._schemeAgencyID!= null)
            {

        if(field[iterator_1].cac_TaxTotal.cac_TaxSubtotals[iterator_4].cac_TaxCategory.cbc_ID._schemeAgencyID!= null)
        {
            int strlen_8 = field[iterator_1].cac_TaxTotal.cac_TaxSubtotals[iterator_4].cac_TaxCategory.cbc_ID._schemeAgencyID.Length * 2;
            targetPtr += strlen_8+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }

        if(field[iterator_1].cac_TaxTotal.cac_TaxSubtotals[iterator_4].cac_TaxCategory.cbc_ID.code!= null)
        {
            int strlen_8 = field[iterator_1].cac_TaxTotal.cac_TaxSubtotals[iterator_4].cac_TaxCategory.cbc_ID.code.Length * 2;
            targetPtr += strlen_8+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }            targetPtr += 8;

            {

            {
            targetPtr += 1;

        if(field[iterator_1].cac_TaxTotal.cac_TaxSubtotals[iterator_4].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeID!= null)
        {
            int strlen_9 = field[iterator_1].cac_TaxTotal.cac_TaxSubtotals[iterator_4].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeID.Length * 2;
            targetPtr += strlen_9+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            if( field[iterator_1].cac_TaxTotal.cac_TaxSubtotals[iterator_4].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeAgencyID!= null)
            {

        if(field[iterator_1].cac_TaxTotal.cac_TaxSubtotals[iterator_4].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeAgencyID!= null)
        {
            int strlen_9 = field[iterator_1].cac_TaxTotal.cac_TaxSubtotals[iterator_4].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeAgencyID.Length * 2;
            targetPtr += strlen_9+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }

        if(field[iterator_1].cac_TaxTotal.cac_TaxSubtotals[iterator_4].cac_TaxCategory.cac_TaxScheme.cbc_ID.code!= null)
        {
            int strlen_9 = field[iterator_1].cac_TaxTotal.cac_TaxSubtotals[iterator_4].cac_TaxCategory.cac_TaxScheme.cbc_ID.code.Length * 2;
            targetPtr += strlen_9+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            }
            }
            }
        }
    }

}

            }
        if(field[iterator_1].cac_ItemUdid!= null)
        {
            int strlen_3 = field[iterator_1].cac_ItemUdid.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            {

            {

        if(field[iterator_1].cac_Price.cbc_PriceAmount._CurrencyID!= null)
        {
            int strlen_5 = field[iterator_1].cac_Price.cbc_PriceAmount._CurrencyID.Length * 2;
            targetPtr += strlen_5+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            {

        if(field[iterator_1].cac_Price.cbc_BaseQuantity._unitCode!= null)
        {
            int strlen_5 = field[iterator_1].cac_Price.cbc_BaseQuantity._unitCode.Length * 2;
            targetPtr += strlen_5+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            {
            targetPtr += 1;

        if(field[iterator_1].cac_Price.cac_AllowanceCharge.cbc_AllowanceChargeReason!= null)
        {
            int strlen_5 = field[iterator_1].cac_Price.cac_AllowanceCharge.cbc_AllowanceChargeReason.Length * 2;
            targetPtr += strlen_5+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            {

        if(field[iterator_1].cac_Price.cac_AllowanceCharge.cbc_Amount._CurrencyID!= null)
        {
            int strlen_6 = field[iterator_1].cac_Price.cac_AllowanceCharge.cbc_Amount._CurrencyID.Length * 2;
            targetPtr += strlen_6+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            }
            }
            }
        }
    }

}

            byte* tmpcellptr = BufferAllocator.AllocBuffer((int)targetPtr);
            Memory.memset(tmpcellptr, 0, (ulong)targetPtr);
            targetPtr = tmpcellptr;
            
{
byte *storedPtr_1 = targetPtr;

    targetPtr += sizeof(int);
    if(field!= null)
    {
        for(int iterator_1 = 0;iterator_1<field.Count;++iterator_1)
        {

            {

        if(field[iterator_1].cbc_ID!= null)
        {
            int strlen_3 = field[iterator_1].cbc_ID.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = field[iterator_1].cbc_ID)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            {
            *(ISO639_1_LanguageCodes*)targetPtr = field[iterator_1].cbc_Note._languageID;
            targetPtr += 1;

        if(field[iterator_1].cbc_Note.note!= null)
        {
            int strlen_4 = field[iterator_1].cbc_Note.note.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = field[iterator_1].cbc_Note.note)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }
            {

        if(field[iterator_1].cbc_InvoicedQuantity._unitCode!= null)
        {
            int strlen_4 = field[iterator_1].cbc_InvoicedQuantity._unitCode.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = field[iterator_1].cbc_InvoicedQuantity._unitCode)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(long*)targetPtr = field[iterator_1].cbc_InvoicedQuantity.quantity;
            targetPtr += 8;

            }
            {

        if(field[iterator_1].cbc_LineExtensionAmount._CurrencyID!= null)
        {
            int strlen_4 = field[iterator_1].cbc_LineExtensionAmount._CurrencyID.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = field[iterator_1].cbc_LineExtensionAmount._CurrencyID)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(double*)targetPtr = field[iterator_1].cbc_LineExtensionAmount.amount;
            targetPtr += 8;

            }
        if(field[iterator_1].cbc_AccountingCost!= null)
        {
            int strlen_3 = field[iterator_1].cbc_AccountingCost.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = field[iterator_1].cbc_AccountingCost)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            {

        if(field[iterator_1].cac_OrderLineReference.cbc_LineID!= null)
        {
            int strlen_4 = field[iterator_1].cac_OrderLineReference.cbc_LineID.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = field[iterator_1].cac_OrderLineReference.cbc_LineID)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }
{
byte *storedPtr_3 = targetPtr;

    targetPtr += sizeof(int);
    if(field[iterator_1].cac_AllowanceCharges!= null)
    {
        for(int iterator_3 = 0;iterator_3<field[iterator_1].cac_AllowanceCharges.Count;++iterator_3)
        {

            {
            *(bool*)targetPtr = field[iterator_1].cac_AllowanceCharges[iterator_3].cbc_ChargeIndicator;
            targetPtr += 1;

        if(field[iterator_1].cac_AllowanceCharges[iterator_3].cbc_AllowanceChargeReason!= null)
        {
            int strlen_5 = field[iterator_1].cac_AllowanceCharges[iterator_3].cbc_AllowanceChargeReason.Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = field[iterator_1].cac_AllowanceCharges[iterator_3].cbc_AllowanceChargeReason)
            {
                Memory.Copy(pstr_5, targetPtr, strlen_5);
                targetPtr += strlen_5;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            {

        if(field[iterator_1].cac_AllowanceCharges[iterator_3].cbc_Amount._CurrencyID!= null)
        {
            int strlen_6 = field[iterator_1].cac_AllowanceCharges[iterator_3].cbc_Amount._CurrencyID.Length * 2;
            *(int*)targetPtr = strlen_6;
            targetPtr += sizeof(int);
            fixed(char* pstr_6 = field[iterator_1].cac_AllowanceCharges[iterator_3].cbc_Amount._CurrencyID)
            {
                Memory.Copy(pstr_6, targetPtr, strlen_6);
                targetPtr += strlen_6;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(double*)targetPtr = field[iterator_1].cac_AllowanceCharges[iterator_3].cbc_Amount.amount;
            targetPtr += 8;

            }
            }
        }
    }
*(int*)storedPtr_3 = (int)(targetPtr - storedPtr_3 - 4);

}

            {

            {

        if(field[iterator_1].cac_TaxTotal.cbc_TaxAmount._CurrencyID!= null)
        {
            int strlen_5 = field[iterator_1].cac_TaxTotal.cbc_TaxAmount._CurrencyID.Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = field[iterator_1].cac_TaxTotal.cbc_TaxAmount._CurrencyID)
            {
                Memory.Copy(pstr_5, targetPtr, strlen_5);
                targetPtr += strlen_5;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(double*)targetPtr = field[iterator_1].cac_TaxTotal.cbc_TaxAmount.amount;
            targetPtr += 8;

            }
{
byte *storedPtr_4 = targetPtr;

    targetPtr += sizeof(int);
    if(field[iterator_1].cac_TaxTotal.cac_TaxSubtotals!= null)
    {
        for(int iterator_4 = 0;iterator_4<field[iterator_1].cac_TaxTotal.cac_TaxSubtotals.Count;++iterator_4)
        {

            {

            {

        if(field[iterator_1].cac_TaxTotal.cac_TaxSubtotals[iterator_4].cbc_TaxableAmount._CurrencyID!= null)
        {
            int strlen_7 = field[iterator_1].cac_TaxTotal.cac_TaxSubtotals[iterator_4].cbc_TaxableAmount._CurrencyID.Length * 2;
            *(int*)targetPtr = strlen_7;
            targetPtr += sizeof(int);
            fixed(char* pstr_7 = field[iterator_1].cac_TaxTotal.cac_TaxSubtotals[iterator_4].cbc_TaxableAmount._CurrencyID)
            {
                Memory.Copy(pstr_7, targetPtr, strlen_7);
                targetPtr += strlen_7;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(double*)targetPtr = field[iterator_1].cac_TaxTotal.cac_TaxSubtotals[iterator_4].cbc_TaxableAmount.amount;
            targetPtr += 8;

            }
            {

        if(field[iterator_1].cac_TaxTotal.cac_TaxSubtotals[iterator_4].cbc_TaxAmount._CurrencyID!= null)
        {
            int strlen_7 = field[iterator_1].cac_TaxTotal.cac_TaxSubtotals[iterator_4].cbc_TaxAmount._CurrencyID.Length * 2;
            *(int*)targetPtr = strlen_7;
            targetPtr += sizeof(int);
            fixed(char* pstr_7 = field[iterator_1].cac_TaxTotal.cac_TaxSubtotals[iterator_4].cbc_TaxAmount._CurrencyID)
            {
                Memory.Copy(pstr_7, targetPtr, strlen_7);
                targetPtr += strlen_7;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(double*)targetPtr = field[iterator_1].cac_TaxTotal.cac_TaxSubtotals[iterator_4].cbc_TaxAmount.amount;
            targetPtr += 8;

            }
            {

            {
            byte* optheader_7 = targetPtr;
            *(optheader_7 + 0) = 0x00;            targetPtr += 1;

        if(field[iterator_1].cac_TaxTotal.cac_TaxSubtotals[iterator_4].cac_TaxCategory.cbc_ID._schemeID!= null)
        {
            int strlen_8 = field[iterator_1].cac_TaxTotal.cac_TaxSubtotals[iterator_4].cac_TaxCategory.cbc_ID._schemeID.Length * 2;
            *(int*)targetPtr = strlen_8;
            targetPtr += sizeof(int);
            fixed(char* pstr_8 = field[iterator_1].cac_TaxTotal.cac_TaxSubtotals[iterator_4].cac_TaxCategory.cbc_ID._schemeID)
            {
                Memory.Copy(pstr_8, targetPtr, strlen_8);
                targetPtr += strlen_8;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            if( field[iterator_1].cac_TaxTotal.cac_TaxSubtotals[iterator_4].cac_TaxCategory.cbc_ID._schemeAgencyID!= null)
            {

        if(field[iterator_1].cac_TaxTotal.cac_TaxSubtotals[iterator_4].cac_TaxCategory.cbc_ID._schemeAgencyID!= null)
        {
            int strlen_8 = field[iterator_1].cac_TaxTotal.cac_TaxSubtotals[iterator_4].cac_TaxCategory.cbc_ID._schemeAgencyID.Length * 2;
            *(int*)targetPtr = strlen_8;
            targetPtr += sizeof(int);
            fixed(char* pstr_8 = field[iterator_1].cac_TaxTotal.cac_TaxSubtotals[iterator_4].cac_TaxCategory.cbc_ID._schemeAgencyID)
            {
                Memory.Copy(pstr_8, targetPtr, strlen_8);
                targetPtr += strlen_8;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
*(optheader_7 + 0) |= 0x01;
            }

        if(field[iterator_1].cac_TaxTotal.cac_TaxSubtotals[iterator_4].cac_TaxCategory.cbc_ID.code!= null)
        {
            int strlen_8 = field[iterator_1].cac_TaxTotal.cac_TaxSubtotals[iterator_4].cac_TaxCategory.cbc_ID.code.Length * 2;
            *(int*)targetPtr = strlen_8;
            targetPtr += sizeof(int);
            fixed(char* pstr_8 = field[iterator_1].cac_TaxTotal.cac_TaxSubtotals[iterator_4].cac_TaxCategory.cbc_ID.code)
            {
                Memory.Copy(pstr_8, targetPtr, strlen_8);
                targetPtr += strlen_8;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }            *(double*)targetPtr = field[iterator_1].cac_TaxTotal.cac_TaxSubtotals[iterator_4].cac_TaxCategory.cbc_Percent;
            targetPtr += 8;

            {

            {
            byte* optheader_8 = targetPtr;
            *(optheader_8 + 0) = 0x00;            targetPtr += 1;

        if(field[iterator_1].cac_TaxTotal.cac_TaxSubtotals[iterator_4].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeID!= null)
        {
            int strlen_9 = field[iterator_1].cac_TaxTotal.cac_TaxSubtotals[iterator_4].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeID.Length * 2;
            *(int*)targetPtr = strlen_9;
            targetPtr += sizeof(int);
            fixed(char* pstr_9 = field[iterator_1].cac_TaxTotal.cac_TaxSubtotals[iterator_4].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeID)
            {
                Memory.Copy(pstr_9, targetPtr, strlen_9);
                targetPtr += strlen_9;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            if( field[iterator_1].cac_TaxTotal.cac_TaxSubtotals[iterator_4].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeAgencyID!= null)
            {

        if(field[iterator_1].cac_TaxTotal.cac_TaxSubtotals[iterator_4].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeAgencyID!= null)
        {
            int strlen_9 = field[iterator_1].cac_TaxTotal.cac_TaxSubtotals[iterator_4].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeAgencyID.Length * 2;
            *(int*)targetPtr = strlen_9;
            targetPtr += sizeof(int);
            fixed(char* pstr_9 = field[iterator_1].cac_TaxTotal.cac_TaxSubtotals[iterator_4].cac_TaxCategory.cac_TaxScheme.cbc_ID._schemeAgencyID)
            {
                Memory.Copy(pstr_9, targetPtr, strlen_9);
                targetPtr += strlen_9;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
*(optheader_8 + 0) |= 0x01;
            }

        if(field[iterator_1].cac_TaxTotal.cac_TaxSubtotals[iterator_4].cac_TaxCategory.cac_TaxScheme.cbc_ID.code!= null)
        {
            int strlen_9 = field[iterator_1].cac_TaxTotal.cac_TaxSubtotals[iterator_4].cac_TaxCategory.cac_TaxScheme.cbc_ID.code.Length * 2;
            *(int*)targetPtr = strlen_9;
            targetPtr += sizeof(int);
            fixed(char* pstr_9 = field[iterator_1].cac_TaxTotal.cac_TaxSubtotals[iterator_4].cac_TaxCategory.cac_TaxScheme.cbc_ID.code)
            {
                Memory.Copy(pstr_9, targetPtr, strlen_9);
                targetPtr += strlen_9;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }
            }
            }
            }
        }
    }
*(int*)storedPtr_4 = (int)(targetPtr - storedPtr_4 - 4);

}

            }
        if(field[iterator_1].cac_ItemUdid!= null)
        {
            int strlen_3 = field[iterator_1].cac_ItemUdid.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = field[iterator_1].cac_ItemUdid)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            {

            {

        if(field[iterator_1].cac_Price.cbc_PriceAmount._CurrencyID!= null)
        {
            int strlen_5 = field[iterator_1].cac_Price.cbc_PriceAmount._CurrencyID.Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = field[iterator_1].cac_Price.cbc_PriceAmount._CurrencyID)
            {
                Memory.Copy(pstr_5, targetPtr, strlen_5);
                targetPtr += strlen_5;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(double*)targetPtr = field[iterator_1].cac_Price.cbc_PriceAmount.amount;
            targetPtr += 8;

            }
            {

        if(field[iterator_1].cac_Price.cbc_BaseQuantity._unitCode!= null)
        {
            int strlen_5 = field[iterator_1].cac_Price.cbc_BaseQuantity._unitCode.Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = field[iterator_1].cac_Price.cbc_BaseQuantity._unitCode)
            {
                Memory.Copy(pstr_5, targetPtr, strlen_5);
                targetPtr += strlen_5;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(long*)targetPtr = field[iterator_1].cac_Price.cbc_BaseQuantity.quantity;
            targetPtr += 8;

            }
            {
            *(bool*)targetPtr = field[iterator_1].cac_Price.cac_AllowanceCharge.cbc_ChargeIndicator;
            targetPtr += 1;

        if(field[iterator_1].cac_Price.cac_AllowanceCharge.cbc_AllowanceChargeReason!= null)
        {
            int strlen_5 = field[iterator_1].cac_Price.cac_AllowanceCharge.cbc_AllowanceChargeReason.Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = field[iterator_1].cac_Price.cac_AllowanceCharge.cbc_AllowanceChargeReason)
            {
                Memory.Copy(pstr_5, targetPtr, strlen_5);
                targetPtr += strlen_5;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            {

        if(field[iterator_1].cac_Price.cac_AllowanceCharge.cbc_Amount._CurrencyID!= null)
        {
            int strlen_6 = field[iterator_1].cac_Price.cac_AllowanceCharge.cbc_Amount._CurrencyID.Length * 2;
            *(int*)targetPtr = strlen_6;
            targetPtr += sizeof(int);
            fixed(char* pstr_6 = field[iterator_1].cac_Price.cac_AllowanceCharge.cbc_Amount._CurrencyID)
            {
                Memory.Copy(pstr_6, targetPtr, strlen_6);
                targetPtr += strlen_6;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(double*)targetPtr = field[iterator_1].cac_Price.cac_AllowanceCharge.cbc_Amount.amount;
            targetPtr += 8;

            }
            }
            }
            }
        }
    }
*(int*)storedPtr_1 = (int)(targetPtr - storedPtr_1 - 4);

}
Cac_InvoiceLine_AccessorListAccessor ret;
            
            ret = new Cac_InvoiceLine_AccessorListAccessor(tmpcellptr, null);
            
            return ret;
        }
        
        public static bool operator ==(Cac_InvoiceLine_AccessorListAccessor a, Cac_InvoiceLine_AccessorListAccessor b)
        {
            if (ReferenceEquals(a, b))
                return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;
            if (a.m_ptr == b.m_ptr) return true;
            if (a.length != b.length) return false;
            return Memory.Compare(a.m_ptr, b.m_ptr, a.length);
        }
        public static bool operator !=(Cac_InvoiceLine_AccessorListAccessor a, Cac_InvoiceLine_AccessorListAccessor b)
        {
            return !(a == b);
        }
    }
}

#pragma warning restore 162,168,649,660,661,1522
