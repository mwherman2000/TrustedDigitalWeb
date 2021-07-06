#pragma warning disable 162,168,649,660,661,1522
using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using Trinity.Core.Lib;
using Trinity.TSL;
using Trinity.TSL.Lib;

namespace TDW.VDAServer
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

#pragma warning restore 162,168,649,660,661,1522
