using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItemSmithWorkShop
{
	public class Weapon
	{
		public string weaponName;
		public string requisite;

		public PreRequisites preRequisite;
		public Cost cost;

		public Weapon(string name)
		{
			weaponName = name;
		}

		public override string ToString()
		{
			return String.Format("Weapon Name:\t\t{0} {1}", weaponName);
		}
	}
}
