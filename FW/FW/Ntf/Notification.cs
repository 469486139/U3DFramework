using FW.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace FW.Ntf
{
	public interface INotification<Key>
	{
		void Regist(Key key, Action<object> msgHandler);
		void UnRegist(Key key, Action<object> msgHandler);
		void Send(Key key, object msg);
	}

	public class Notification<Key> : INotification<Key>
	{
		Dictionary<Key, DoubleBuff<Action<object>>> handlers = new Dictionary<Key, DoubleBuff<Action<object>>>();

		public void Regist(Key key, Action<object> msgHandler)
		{
			DoubleBuff<Action<object>> buffer = null;

			if (handlers.TryGetValue(key, out buffer))
			{
				if(!buffer.Contain(msgHandler))
				{
					buffer.Add(msgHandler);
				}
			}
			else
			{
				buffer = new DoubleBuff<Action<object>>();
				buffer.Add(msgHandler);
				handlers.Add(key, buffer);
			}
		}

		public void Send(Key key, object msg)
		{
			DoubleBuff<Action<object>> buffer = null;

			if (!handlers.TryGetValue(key, out buffer))
			{
				return;
			}

			foreach (var handler in buffer)
			{
				handler.Invoke(msg);
			}
		}

		public void UnRegist(Key key, Action<object> msgHandler)
		{
			DoubleBuff<Action<object>> buffer = null;

			if (!handlers.TryGetValue(key, out buffer))
			{
				return;
			}

			buffer.Remove(msgHandler);
		}
	}
}
