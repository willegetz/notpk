using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItemSmithWorkShop.WeaponOrder
{
	class WeaponTicket
	{
		private List<LineItem> orderTicket;

		public WeaponTicket()
		{
			orderTicket = new List<LineItem>();
		}

		internal void AddLineItem(WeaponHead weaponHead)
		{
			orderTicket.Add(weaponHead);
		}

		public override string ToString()
		{
			var sb = new StringBuilder();
			foreach (var item in orderTicket)
			{
				sb.Append(item + Environment.NewLine);
			}
			return sb.ToString();
		}
	}
}
