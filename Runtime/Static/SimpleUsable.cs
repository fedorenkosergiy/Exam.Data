using System;
using System.Collections.Generic;

namespace Exam.Data.Static
{
	[Serializable]
	public class SimpleUsable : Usable
	{
		[NonSerialized]
		private ISet<object> users;

		private ISet<object> Users => users ??= new HashSet<object>();
		public bool IsUsed => Users.IsNotEmpty();

		public bool StartUsing(object user) => Users.Add(user);

		public bool StopUsing(object user) => Users.Remove(user);
	}
}
