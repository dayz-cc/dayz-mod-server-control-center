using System;
using System.Collections;
using System.Collections.Generic;

namespace NLog.Internal
{
	/// <summary>
	/// Provides untyped IDictionary interface on top of generic IDictionary.
	/// </summary>
	/// <typeparam name="TKey">The type of the key.</typeparam>
	/// <typeparam name="TValue">The type of the value.</typeparam>
	// Token: 0x02000055 RID: 85
	internal class DictionaryAdapter<TKey, TValue> : IDictionary, ICollection, IEnumerable
	{
		/// <summary>
		/// Initializes a new instance of the DictionaryAdapter class.
		/// </summary>
		/// <param name="implementation">The implementation.</param>
		// Token: 0x0600022B RID: 555 RVA: 0x000097FF File Offset: 0x000079FF
		public DictionaryAdapter(IDictionary<TKey, TValue> implementation)
		{
			this.implementation = implementation;
		}

		/// <summary>
		/// Gets an <see cref="T:System.Collections.ICollection" /> object containing the values in the <see cref="T:System.Collections.IDictionary" /> object.
		/// </summary>
		/// <value></value>
		/// <returns>
		/// An <see cref="T:System.Collections.ICollection" /> object containing the values in the <see cref="T:System.Collections.IDictionary" /> object.
		/// </returns>
		// Token: 0x17000068 RID: 104
		// (get) Token: 0x0600022C RID: 556 RVA: 0x00009814 File Offset: 0x00007A14
		public ICollection Values
		{
			get
			{
				return new List<TValue>(this.implementation.Values);
			}
		}

		/// <summary>
		/// Gets the number of elements contained in the <see cref="T:System.Collections.ICollection" />.
		/// </summary>
		/// <value></value>
		/// <returns>
		/// The number of elements contained in the <see cref="T:System.Collections.ICollection" />.
		/// </returns>
		// Token: 0x17000069 RID: 105
		// (get) Token: 0x0600022D RID: 557 RVA: 0x00009838 File Offset: 0x00007A38
		public int Count
		{
			get
			{
				return this.implementation.Count;
			}
		}

		/// <summary>
		/// Gets a value indicating whether access to the <see cref="T:System.Collections.ICollection" /> is synchronized (thread safe).
		/// </summary>
		/// <value></value>
		/// <returns>true if access to the <see cref="T:System.Collections.ICollection" /> is synchronized (thread safe); otherwise, false.
		/// </returns>
		// Token: 0x1700006A RID: 106
		// (get) Token: 0x0600022E RID: 558 RVA: 0x00009858 File Offset: 0x00007A58
		public bool IsSynchronized
		{
			get
			{
				return false;
			}
		}

		/// <summary>
		/// Gets an object that can be used to synchronize access to the <see cref="T:System.Collections.ICollection" />.
		/// </summary>
		/// <value></value>
		/// <returns>
		/// An object that can be used to synchronize access to the <see cref="T:System.Collections.ICollection" />.
		/// </returns>
		// Token: 0x1700006B RID: 107
		// (get) Token: 0x0600022F RID: 559 RVA: 0x0000986C File Offset: 0x00007A6C
		public object SyncRoot
		{
			get
			{
				return this.implementation;
			}
		}

		/// <summary>
		/// Gets a value indicating whether the <see cref="T:System.Collections.IDictionary" /> object has a fixed size.
		/// </summary>
		/// <value></value>
		/// <returns>true if the <see cref="T:System.Collections.IDictionary" /> object has a fixed size; otherwise, false.
		/// </returns>
		// Token: 0x1700006C RID: 108
		// (get) Token: 0x06000230 RID: 560 RVA: 0x00009884 File Offset: 0x00007A84
		public bool IsFixedSize
		{
			get
			{
				return false;
			}
		}

		/// <summary>
		/// Gets a value indicating whether the <see cref="T:System.Collections.IDictionary" /> object is read-only.
		/// </summary>
		/// <value></value>
		/// <returns>true if the <see cref="T:System.Collections.IDictionary" /> object is read-only; otherwise, false.
		/// </returns>
		// Token: 0x1700006D RID: 109
		// (get) Token: 0x06000231 RID: 561 RVA: 0x00009898 File Offset: 0x00007A98
		public bool IsReadOnly
		{
			get
			{
				return this.implementation.IsReadOnly;
			}
		}

		/// <summary>
		/// Gets an <see cref="T:System.Collections.ICollection" /> object containing the keys of the <see cref="T:System.Collections.IDictionary" /> object.
		/// </summary>
		/// <value></value>
		/// <returns>
		/// An <see cref="T:System.Collections.ICollection" /> object containing the keys of the <see cref="T:System.Collections.IDictionary" /> object.
		/// </returns>
		// Token: 0x1700006E RID: 110
		// (get) Token: 0x06000232 RID: 562 RVA: 0x000098B8 File Offset: 0x00007AB8
		public ICollection Keys
		{
			get
			{
				return new List<TKey>(this.implementation.Keys);
			}
		}

		/// <summary>
		/// Gets or sets the <see cref="T:System.Object" /> with the specified key.
		/// </summary>
		/// <param name="key">Dictionary key.</param>
		/// <returns>Value corresponding to key or null if not found</returns>
		// Token: 0x1700006F RID: 111
		public object this[object key]
		{
			get
			{
				TValue tvalue;
				object obj;
				if (this.implementation.TryGetValue((TKey)((object)key), out tvalue))
				{
					obj = tvalue;
				}
				else
				{
					obj = null;
				}
				return obj;
			}
			set
			{
				this.implementation[(TKey)((object)key)] = (TValue)((object)value);
			}
		}

		/// <summary>
		/// Adds an element with the provided key and value to the <see cref="T:System.Collections.IDictionary" /> object.
		/// </summary>
		/// <param name="key">The <see cref="T:System.Object" /> to use as the key of the element to add.</param>
		/// <param name="value">The <see cref="T:System.Object" /> to use as the value of the element to add.</param>
		// Token: 0x06000235 RID: 565 RVA: 0x0000992F File Offset: 0x00007B2F
		public void Add(object key, object value)
		{
			this.implementation.Add((TKey)((object)key), (TValue)((object)value));
		}

		/// <summary>
		/// Removes all elements from the <see cref="T:System.Collections.IDictionary" /> object.
		/// </summary>
		// Token: 0x06000236 RID: 566 RVA: 0x0000994A File Offset: 0x00007B4A
		public void Clear()
		{
			this.implementation.Clear();
		}

		/// <summary>
		/// Determines whether the <see cref="T:System.Collections.IDictionary" /> object contains an element with the specified key.
		/// </summary>
		/// <param name="key">The key to locate in the <see cref="T:System.Collections.IDictionary" /> object.</param>
		/// <returns>
		/// True if the <see cref="T:System.Collections.IDictionary" /> contains an element with the key; otherwise, false.
		/// </returns>
		// Token: 0x06000237 RID: 567 RVA: 0x0000995C File Offset: 0x00007B5C
		public bool Contains(object key)
		{
			return this.implementation.ContainsKey((TKey)((object)key));
		}

		/// <summary>
		/// Returns an <see cref="T:System.Collections.IDictionaryEnumerator" /> object for the <see cref="T:System.Collections.IDictionary" /> object.
		/// </summary>
		/// <returns>
		/// An <see cref="T:System.Collections.IDictionaryEnumerator" /> object for the <see cref="T:System.Collections.IDictionary" /> object.
		/// </returns>
		// Token: 0x06000238 RID: 568 RVA: 0x00009980 File Offset: 0x00007B80
		public IDictionaryEnumerator GetEnumerator()
		{
			return new DictionaryAdapter<TKey, TValue>.MyEnumerator(this.implementation.GetEnumerator());
		}

		/// <summary>
		/// Removes the element with the specified key from the <see cref="T:System.Collections.IDictionary" /> object.
		/// </summary>
		/// <param name="key">The key of the element to remove.</param>
		// Token: 0x06000239 RID: 569 RVA: 0x000099A2 File Offset: 0x00007BA2
		public void Remove(object key)
		{
			this.implementation.Remove((TKey)((object)key));
		}

		/// <summary>
		/// Copies the elements of the <see cref="T:System.Collections.ICollection" /> to an <see cref="T:System.Array" />, starting at a particular <see cref="T:System.Array" /> index.
		/// </summary>
		/// <param name="array">The one-dimensional <see cref="T:System.Array" /> that is the destination of the elements copied from <see cref="T:System.Collections.ICollection" />. The <see cref="T:System.Array" /> must have zero-based indexing.</param>
		/// <param name="index">The zero-based index in <paramref name="array" /> at which copying begins.</param>
		// Token: 0x0600023A RID: 570 RVA: 0x000099B7 File Offset: 0x00007BB7
		public void CopyTo(Array array, int index)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Returns an enumerator that iterates through a collection.
		/// </summary>
		/// <returns>
		/// An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.
		/// </returns>
		// Token: 0x0600023B RID: 571 RVA: 0x000099C0 File Offset: 0x00007BC0
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		// Token: 0x040000A0 RID: 160
		private readonly IDictionary<TKey, TValue> implementation;

		/// <summary>
		/// Wrapper IDictionaryEnumerator.
		/// </summary>
		// Token: 0x02000056 RID: 86
		private class MyEnumerator : IDictionaryEnumerator, IEnumerator
		{
			/// <summary>
			/// Initializes a new instance of the <see cref="T:NLog.Internal.DictionaryAdapter`2.MyEnumerator" /> class.
			/// </summary>
			/// <param name="wrapped">The wrapped.</param>
			// Token: 0x0600023C RID: 572 RVA: 0x000099D8 File Offset: 0x00007BD8
			public MyEnumerator(IEnumerator<KeyValuePair<TKey, TValue>> wrapped)
			{
				this.wrapped = wrapped;
			}

			/// <summary>
			/// Gets both the key and the value of the current dictionary entry.
			/// </summary>
			/// <value></value>
			/// <returns>
			/// A <see cref="T:System.Collections.DictionaryEntry" /> containing both the key and the value of the current dictionary entry.
			/// </returns>
			// Token: 0x17000070 RID: 112
			// (get) Token: 0x0600023D RID: 573 RVA: 0x000099EC File Offset: 0x00007BEC
			public DictionaryEntry Entry
			{
				get
				{
					KeyValuePair<TKey, TValue> keyValuePair = this.wrapped.Current;
					object obj = keyValuePair.Key;
					keyValuePair = this.wrapped.Current;
					return new DictionaryEntry(obj, keyValuePair.Value);
				}
			}

			/// <summary>
			/// Gets the key of the current dictionary entry.
			/// </summary>
			/// <value></value>
			/// <returns>
			/// The key of the current element of the enumeration.
			/// </returns>
			// Token: 0x17000071 RID: 113
			// (get) Token: 0x0600023E RID: 574 RVA: 0x00009A34 File Offset: 0x00007C34
			public object Key
			{
				get
				{
					KeyValuePair<TKey, TValue> keyValuePair = this.wrapped.Current;
					return keyValuePair.Key;
				}
			}

			/// <summary>
			/// Gets the value of the current dictionary entry.
			/// </summary>
			/// <value></value>
			/// <returns>
			/// The value of the current element of the enumeration.
			/// </returns>
			// Token: 0x17000072 RID: 114
			// (get) Token: 0x0600023F RID: 575 RVA: 0x00009A60 File Offset: 0x00007C60
			public object Value
			{
				get
				{
					KeyValuePair<TKey, TValue> keyValuePair = this.wrapped.Current;
					return keyValuePair.Value;
				}
			}

			/// <summary>
			/// Gets the current element in the collection.
			/// </summary>
			/// <value></value>
			/// <returns>
			/// The current element in the collection.
			/// </returns>
			// Token: 0x17000073 RID: 115
			// (get) Token: 0x06000240 RID: 576 RVA: 0x00009A8C File Offset: 0x00007C8C
			public object Current
			{
				get
				{
					return this.Entry;
				}
			}

			/// <summary>
			/// Advances the enumerator to the next element of the collection.
			/// </summary>
			/// <returns>
			/// True if the enumerator was successfully advanced to the next element; false if the enumerator has passed the end of the collection.
			/// </returns>
			// Token: 0x06000241 RID: 577 RVA: 0x00009AAC File Offset: 0x00007CAC
			public bool MoveNext()
			{
				return this.wrapped.MoveNext();
			}

			/// <summary>
			/// Sets the enumerator to its initial position, which is before the first element in the collection.
			/// </summary>
			// Token: 0x06000242 RID: 578 RVA: 0x00009AC9 File Offset: 0x00007CC9
			public void Reset()
			{
				this.wrapped.Reset();
			}

			// Token: 0x040000A1 RID: 161
			private IEnumerator<KeyValuePair<TKey, TValue>> wrapped;
		}
	}
}
