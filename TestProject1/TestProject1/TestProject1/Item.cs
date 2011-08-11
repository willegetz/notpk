using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestProject1
{
	class Item
	{
		public string ItemName { get; set; }
		public string MonetaryCost { get; set; }
		public string BaseDamage { get; set; }
		public string DamageType { get; set; }
		public string ThreatRange { get; set; }

		public override string ToString()
		{
			return String.Format("Item Name:\t\t{0}" + "\r" + "Item Cost:\t\t{1}" + "\r" + "Base Damage:\t{2}" + "\r" + "Damage Type(s):\t{3}" + "\r" + "Threat Range:\t{4}", ItemName, MonetaryCost, BaseDamage, DamageType, ThreatRange);
		}

		public void GetItemStatistics(string itemName, string itemCost, string itemBaseDamage, string itemDamageType, string itemThreatRange)
		{
			ItemName = itemName;
			MonetaryCost = itemCost;
			BaseDamage = itemBaseDamage;
			ThreatRange = itemThreatRange;
			DamageType = itemDamageType;
		}
	}
}
