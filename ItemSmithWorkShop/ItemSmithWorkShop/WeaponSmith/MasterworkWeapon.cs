using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItemSmithWorkShop.WeaponSmith
{
	public class MasterworkWeapon
	{
		private static List<GenericWeapon> weaponHeadList = new List<GenericWeapon>();
		private static double singleWeaponMasterworkCost = 300;

		internal static void MakeMasterwork(GenericWeapon singleWeapon)
		{
			SetMasterworkProperties(singleWeapon);
		}

		internal static void MakeMasterwork(GenericDoubleWeapon doubleWeapon)
		{
			weaponHeadList.Add(doubleWeapon.FirstWeaponPart);
			weaponHeadList.Add(doubleWeapon.SecondWeaponPart);

			SetMasterworkProperties(doubleWeapon);
		}

		private static void SetMasterworkProperties(GenericDoubleWeapon doubleWeapon)
		{
			foreach (var weaponHead in weaponHeadList)
			{
				SetMasterworkProperties(weaponHead);
			}
		}

		private static void SetMasterworkProperties(GenericWeapon singleWeapon)
		{
			singleWeapon.IsMasterwork = true;
			singleWeapon.MasterWorkLabel = " [Masterwork]";
			singleWeapon.ToHitModifier = 1;
			singleWeapon.WeaponText = singleWeapon.WeaponText + string.Format("\n\tThis {0} is masterwork quality!", singleWeapon.WeaponType.ToLower());
			CalculateWeaponCosts.SetMasterworkCost(singleWeaponMasterworkCost);
			singleWeapon.TotalWeaponCost += CalculateWeaponCosts.GetMasterworkCost();
		}
	}
}
