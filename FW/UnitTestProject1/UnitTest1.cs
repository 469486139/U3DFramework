using System;
using FW.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{
			DoubleBuff<uint> buffer = new DoubleBuff<uint>();

			Assert.IsFalse(buffer.Contain(1));
			buffer.Add(1);
			Assert.IsTrue(buffer.Contain(1));
			buffer.Remove(1);
			Assert.IsFalse(buffer.Contain(1));

			for (uint i = 0; i < 10; i++)
				buffer.Add(i);

			int cnt = 0;
			foreach (var item in buffer)
			{
				Assert.IsTrue(item == (uint)cnt);
				buffer.Add(item + 10);
				cnt++;
			}

			Assert.IsTrue(buffer.Contain(19));
			Assert.IsFalse(buffer.Contain(20));
		}
	}
}
