using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonBuildersGuidebook1Tests
{
	public class FakeProduct
	{
		public string Category { get; set; }
		public int Quantity { get; set; }
		public double Price { get; set; }

		public override string ToString()
		{
			var sb = new StringBuilder();
			sb.AppendLine(string.Format("Category: '{0}'", Category));
			sb.AppendLine(string.Format("Quantity: '{0}'", Quantity));
			sb.AppendLine(string.Format("Price: '{0:C}'", Price));
			return sb.ToString();
		}
	}
}
