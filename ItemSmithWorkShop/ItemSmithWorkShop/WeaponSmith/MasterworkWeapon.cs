using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItemSmithWorkShop.WeaponSmith
{
	public class MasterworkWeapon
	{
		private static double singleWeaponMasterworkCost = 300;

		internal static void MakeMasterwork(GenericWeapon testDagger)
		{
			SetMasterworkProperties(testDagger);
		}

		private static void SetMasterworkProperties(GenericWeapon testDagger)
		{
			testDagger.IsMasterwork = true;
			testDagger.MasterWorkLabel = " [Masterwork]";
			testDagger.ToHitModifier = 1;
			testDagger.WeaponText = testDagger.WeaponText + string.Format("\n\tThis {0} is masterwork quality!", testDagger.WeaponType.ToLower());
			testDagger.MasterworkCost = singleWeaponMasterworkCost;
		}
	}
}
