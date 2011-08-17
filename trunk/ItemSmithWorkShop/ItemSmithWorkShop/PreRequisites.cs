﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItemSmithWorkShop
{
	//		Pre-requisites
	//			Proficiency
	//			Category
	//			Attack Type
	public class PreRequisites
	{
		public string weaponProficiency;
		public string weaponCategory;
		public string attackType;

		public PreRequisites(string proficiency, string category, string type)
		{
			weaponProficiency = proficiency;
			weaponCategory = category;
			attackType = type;
		}

		public override string ToString()
		{
			return String.Format("Weapon Proficiency:\t{0}\rWeapon Category:\t{1} {2}", weaponProficiency, weaponCategory, attackType);
		}
		// Display the proficiency
	}
}