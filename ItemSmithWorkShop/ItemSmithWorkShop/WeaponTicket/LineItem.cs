using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItemSmithWorkShop.WeaponOrder
{
	class LineItem
	{
		public string weaponName;
		public string category;
		public string proficiency;

		public int weaponNameLength;
		public int categoryLength;
		public int proficiencyLength;

		public virtual string WeaponName { get; set; }
		public virtual string Category { get; set; }
		public virtual string ProficiencyRequirement { get; set; }

		public virtual string Damage()
		{
			return string.Empty;
		}

		public virtual string DamageType()
		{
			return string.Empty;
		}

		public virtual string ThreatRange()
		{
			return string.Empty;
		}

		public virtual string CriticalMultiplier()
		{
			return string.Empty;
		}
	}
}
