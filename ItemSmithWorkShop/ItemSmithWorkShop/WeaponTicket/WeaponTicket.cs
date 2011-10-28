using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItemSmithWorkShop.WeaponOrder
{
	class WeaponTicket
	{
		private List<LineItem> orderTicket;
		private List<int> columns;

		public WeaponTicket()
		{
			orderTicket = new List<LineItem>();
			columns = new List<int>();
		}

		internal void AddLineItem(WeaponHead weaponHead)
		{
			orderTicket.Add(weaponHead);
			AddToColumnLength(weaponHead.columnLengths);
		}

		private void AddToColumnLength(List<int> list)
		{
			columns.AddRange(list);
		}

		public override string ToString()
		{
			var sb = new StringBuilder();
			foreach (var item in orderTicket)
			{
				sb.Append(item + "\n\n");
			}
			return sb.ToString();
		}
	}
}
