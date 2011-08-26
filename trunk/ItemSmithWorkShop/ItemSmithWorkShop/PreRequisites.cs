using System;
using System.Collections.Generic;

namespace ItemSmithWorkShop
{
	//		Pre-requisites
	//			Proficiency
	//			Category
	//			Attack Type
	public class PreRequisites
	{

		public IList<String> requirements = new List<String>();

		public string weaponProficiency;
		public string weaponCategory;
		public string attackType;

		public PreRequisites(string proficiency, string category, string type)
		{
			requirements.Add(proficiency);
			requirements.Add(category);
			requirements.Add(type);

			weaponProficiency = proficiency;
			weaponCategory = category;
			attackType = type;
		}

		public override string ToString()
		{
			return String.Format("Weapon Proficiency: {0}\nWeapon Category: {1}\nAttack Type: {2}", weaponProficiency, weaponCategory, attackType);
		}
		// Display the proficiency
	}
}
