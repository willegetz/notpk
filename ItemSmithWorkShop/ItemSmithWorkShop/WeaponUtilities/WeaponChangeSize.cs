using System.Collections.Generic;
using AdventureItems;
namespace ItemSmithWorkShop.WeaponUtilities
{
	public class WeaponChangeSize : AdventureItem
	{
		private static string damageKey;
		private static string sizeKey;
		private static Dictionary<string, double> scaleMultiplier;
		private static Dictionary<string, string> d4DamageScale;
		private static Dictionary<string, Dictionary<string, string>> scaledDamage;
		private static WeaponItem sizedWeapon;
		private static double sizeMultiplier;
		private static string newDamage;

		internal static WeaponItem ChangeWeaponSize(WeaponItem weapon, string size)
		{
			sizeKey = size;
			sizedWeapon = weapon;
			damageKey = weapon.GetDamage();
			GetSizingValues();
			SetNewSizingProperties();
			return sizedWeapon;
		}

		static WeaponChangeSize()
		{
			LoadSizingDictionaries();
		}

		private static void GetSizingValues()
		{
			sizeMultiplier = scaleMultiplier[sizeKey];
			newDamage = scaledDamage[damageKey][sizeKey];
		}

		private static void SetNewSizingProperties()
		{
			sizedWeapon.SetName(sizeKey);

			if (sizeKey == "Small")
			{
				sizedWeapon.SetCost(1);
			}
			else
			{
				sizedWeapon.SetCost(sizeMultiplier);
			}

			sizedWeapon.SetDamage(newDamage);
			sizedWeapon.SetWeight(sizeMultiplier);
			sizedWeapon.SetHardness(sizeMultiplier);
			sizedWeapon.SetHitPoints(sizeMultiplier);
			
		}

		private static void LoadSizingDictionaries()
		{
			scaleMultiplier = new Dictionary<string, double>
			{
				{"Small", 0.5}, {"Large", 2},
			};

			d4DamageScale = new Dictionary<string, string>
			{
				{"Small", "1d3"}, {"Large", "1d6"}
			};

			scaledDamage = new Dictionary<string, Dictionary<string, string>>
			{
				{"1d4", d4DamageScale},
			};
		}
	}
}
