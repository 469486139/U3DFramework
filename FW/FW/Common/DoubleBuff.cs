using System;
using System.Collections.Generic;
using System.Text;

namespace FW.Common
{
	public class DoubleBuff<T>
	{
		List<T> frontBuff = new List<T>();
		List<T> backBuff = new List<T>();
		bool dirty = false;

		public void Add(T t)
		{
			if(!frontBuff.Contains(t))
			{
				frontBuff.Add(t);
				dirty = true;
			}
		}

		public void Remove(T t)
		{
			if (frontBuff.Remove(t))
			{
				dirty = true;
			}
		}

		public bool Contain(T t)
		{
			return frontBuff.Contains(t);
		}

		public List<T>.Enumerator GetEnumerator()
		{
			if(dirty)
			{
				ReCopy();
				dirty = false;
			}
			return backBuff.GetEnumerator();
		}

		void ReCopy()
		{
			backBuff.Clear();
			backBuff.AddRange(frontBuff);
		}
	}
}
