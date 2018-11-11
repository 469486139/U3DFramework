using System;
using FW.Ntf;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
	[TestClass]
	public class UnitTest2
	{
		[TestMethod]
		public void TestMethod1()
		{
			Notification<uint> ntf = new Notification<uint>();
			int times_1 = 0;
			void Cb1(object o)
			{
				times_1++;
			}

			int times_2 = 0;
			void Cb2(object o)
			{
				times_2++;
			}

			ntf.Regist(1, Cb1);
			ntf.Regist(1, Cb1);
			ntf.Regist(2, Cb1);
			ntf.Regist(2, Cb2);

			ntf.Send(1, null);
			ntf.Send(2, null);

			Assert.IsTrue(times_1 == 2);
			Assert.IsTrue(times_2 == 1);
		}
	}
}
