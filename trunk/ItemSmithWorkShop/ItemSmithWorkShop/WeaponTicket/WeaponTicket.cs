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
		private List<string> headerRow;

		public WeaponTicket()
		{
			orderTicket = new List<LineItem>();
			columns = new List<int>();
			headerRow = new List<string>()
			{
				{"Name"}, {"Category"}, {"Proficiency"}, {"Damage"}, {"Damage Type"}, {"Threat"}, {"Critical"},
			};
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

		private int DetermineColumnWidth()
		{
			return columns.Max();
		}

		private string GetHeaderRow(int columnWidth)
		{
			var sb = new StringBuilder();

			foreach (var header in headerRow)
			{
				sb.Append(string.Format("{0}|", header.PadLeft(columnWidth)));
			}
			return sb.ToString();
		}

		public override string ToString()
		{
			var sb = new StringBuilder();

			var columnWidth = DetermineColumnWidth() + 1;
			
			sb.AppendLine(GetHeaderRow(columnWidth) + Environment.NewLine);

			foreach (var item in orderTicket)
			{
				item.ColumnWidth = columnWidth;
				sb.AppendLine(String.Format("{0}", item));
			}
			return sb.ToString();
		}
	}
}
