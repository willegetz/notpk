using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItemSmithWeaponSmith
{
	public abstract class WeaponSizeAdjustments
	{
		public string WeaponDamage { get; set; }
		public string WeaponName { get; set; }
		public double WeaponHardness { get; set; }
		public double WeaponHitPoints { get; set; }
		public double WeaponWeight { get; set; }

		public void CheckForNull(string weaponSize)
		{
			if (weaponSize == null)
			{
				return;
			}
			else
			{
				SelectWeaponDamageToScale(weaponSize);
				AdjustHardnessHitPointsForSize(weaponSize);
				AdjustWeightForSize(weaponSize);
				AdjsutCostForSize(weaponSize);
			}
		}

		public void SelectWeaponDamageToScale(string weaponSize)
		{
			switch (WeaponDamage)
			{
				case "1d2":
					ScaleDamageFrom1d2(weaponSize);
					break;
				case "1d3":
					ScaleDamageFrom1d3(weaponSize);
					break;
				case "1d4":
					ScaleDamageFrom1d4(weaponSize);
					break;
				case "1d6":
					ScaleDamageFrom1d6(weaponSize);
					break;
				case "2d4":
					ScaleDamageFrom2d4(weaponSize);
					break;
				case "1d8":
					ScaleDamageFrom1d8(weaponSize);
					break;
				case "1d10":
					ScaleDamageFrom1d10(weaponSize);
					break;
				case "1d12":
					ScaleDamageFrom1d12(weaponSize);
					break;
				case "2d6":
					ScaleDamageFrom2d6(weaponSize);
					break;
				default:
					return;
			}
		}

		public void ScaleDamageFrom1d2(string weaponSize)
		{
			Dictionary<string, string> damageAdjustment = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
			var sb = new StringBuilder();

			damageAdjustment.Add("Fine", "No Meaningful Damage");
			damageAdjustment.Add("Diminutive", "No Meaningful Damage");
			damageAdjustment.Add("Tiny", "No Meaningful Damage");
			damageAdjustment.Add("Small", "1");
			damageAdjustment.Add("Medium", "1d2");
			damageAdjustment.Add("Large", "1d3");
			damageAdjustment.Add("Huge", "1d4");
			damageAdjustment.Add("Gargantuan", "1d6");
			damageAdjustment.Add("Colossal", "1d8");

			if (damageAdjustment.ContainsKey(weaponSize))
			{
				WeaponDamage = damageAdjustment[weaponSize];
				WeaponName = String.Format("{0} ({1})", WeaponName, weaponSize);
			}
		}

		public void ScaleDamageFrom1d3(string weaponSize)
		{
			Dictionary<string, string> damageAdjustment = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
			var sb = new StringBuilder();

			damageAdjustment.Add("Fine", "No Meaningful Damage");
			damageAdjustment.Add("Diminutive", "No Meaningful Damage");
			damageAdjustment.Add("Tiny", "1");
			damageAdjustment.Add("Small", "1d2");
			damageAdjustment.Add("Medium", "1d3");
			damageAdjustment.Add("Large", "1d4");
			damageAdjustment.Add("Huge", "1d6");
			damageAdjustment.Add("Gargantuan", "1d8");
			damageAdjustment.Add("Colossal", "2d6");

			if (damageAdjustment.ContainsKey(weaponSize))
			{
				WeaponDamage = damageAdjustment[weaponSize];
				WeaponName = String.Format("{0} ({1})", WeaponName, weaponSize);
			}
		}

		public void ScaleDamageFrom1d4(string weaponSize)
		{
			Dictionary<string, string> damageAdjustment = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
			var sb = new StringBuilder();

			damageAdjustment.Add("Fine", "No Meaningful Damage");
			damageAdjustment.Add("Diminutive", "1");
			damageAdjustment.Add("Tiny", "1d2");
			damageAdjustment.Add("Small", "1d3");
			damageAdjustment.Add("Medium", "1d4");
			damageAdjustment.Add("Large", "1d6");
			damageAdjustment.Add("Huge", "1d8");
			damageAdjustment.Add("Gargantuan", "2d6");
			damageAdjustment.Add("Colossal", "3d6");

			if (damageAdjustment.ContainsKey(weaponSize))
			{
				WeaponDamage = damageAdjustment[weaponSize];
				WeaponName = String.Format("{0} ({1})", WeaponName, weaponSize);
			}
		}

		public void ScaleDamageFrom1d6(string weaponSize)
		{
			Dictionary<string, string> damageAdjustment = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
			var sb = new StringBuilder();

			damageAdjustment.Add("Fine", "1");
			damageAdjustment.Add("Diminutive", "1d2");
			damageAdjustment.Add("Tiny", "1d3");
			damageAdjustment.Add("Small", "1d4");
			damageAdjustment.Add("Medium", "1d6");
			damageAdjustment.Add("Large", "1d8");
			damageAdjustment.Add("Huge", "2d6");
			damageAdjustment.Add("Gargantuan", "3d6");
			damageAdjustment.Add("Colossal", "4d6");

			if (damageAdjustment.ContainsKey(weaponSize))
			{
				WeaponDamage = damageAdjustment[weaponSize];
				WeaponName = String.Format("{0} ({1})", WeaponName, weaponSize);
			}
		}

		public void ScaleDamageFrom2d4(string weaponSize)
		{
			Dictionary<string, string> damageAdjustment = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
			var sb = new StringBuilder();

			damageAdjustment.Add("Fine", "1d2");
			damageAdjustment.Add("Diminutive", "1d3");
			damageAdjustment.Add("Tiny", "1d4");
			damageAdjustment.Add("Small", "1d6");
			damageAdjustment.Add("Medium", "2d4");
			damageAdjustment.Add("Large", "2d6");
			damageAdjustment.Add("Huge", "3d6");
			damageAdjustment.Add("Gargantuan", "4d6");
			damageAdjustment.Add("Colossal", "6d6");

			if (damageAdjustment.ContainsKey(weaponSize))
			{
				WeaponDamage = damageAdjustment[weaponSize];
				WeaponName = String.Format("{0} ({1})", WeaponName, weaponSize);
			}
		}

		public void ScaleDamageFrom1d8(string weaponSize)
		{
			Dictionary<string, string> damageAdjustment = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
			var sb = new StringBuilder();

			damageAdjustment.Add("Fine", "1d2");
			damageAdjustment.Add("Diminutive", "1d3");
			damageAdjustment.Add("Tiny", "1d4");
			damageAdjustment.Add("Small", "1d6");
			damageAdjustment.Add("Medium", "1d8");
			damageAdjustment.Add("Large", "2d6");
			damageAdjustment.Add("Huge", "3d6");
			damageAdjustment.Add("Gargantuan", "4d6");
			damageAdjustment.Add("Colossal", "6d6");

			if (damageAdjustment.ContainsKey(weaponSize))
			{
				WeaponDamage = damageAdjustment[weaponSize];
				WeaponName = String.Format("{0} ({1})", WeaponName, weaponSize);
			}
		}

		public void ScaleDamageFrom1d10(string weaponSize)
		{
			Dictionary<string, string> damageAdjustment = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
			var sb = new StringBuilder();

			damageAdjustment.Add("Fine", "1d3");
			damageAdjustment.Add("Diminutive", "1d4");
			damageAdjustment.Add("Tiny", "1d6");
			damageAdjustment.Add("Small", "1d8");
			damageAdjustment.Add("Medium", "1d10");
			damageAdjustment.Add("Large", "2d8");
			damageAdjustment.Add("Huge", "3d8");
			damageAdjustment.Add("Gargantuan", "4d8");
			damageAdjustment.Add("Colossal", "6d8");

			if (damageAdjustment.ContainsKey(weaponSize))
			{
				WeaponDamage = damageAdjustment[weaponSize];
				WeaponName = String.Format("{0} ({1})", WeaponName, weaponSize);
			}
		}

		public void ScaleDamageFrom1d12(string weaponSize)
		{
			Dictionary<string, string> damageAdjustment = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
			var sb = new StringBuilder();

			damageAdjustment.Add("Fine", "1d4");
			damageAdjustment.Add("Diminutive", "1d6");
			damageAdjustment.Add("Tiny", "1d8");
			damageAdjustment.Add("Small", "1d10");
			damageAdjustment.Add("Medium", "1d12");
			damageAdjustment.Add("Large", "3d6");
			damageAdjustment.Add("Huge", "4d6");
			damageAdjustment.Add("Gargantuan", "6d6");
			damageAdjustment.Add("Colossal", "8d6");

			if (damageAdjustment.ContainsKey(weaponSize))
			{
				WeaponDamage = damageAdjustment[weaponSize];
				WeaponName = String.Format("{0} ({1})", WeaponName, weaponSize);
			}
		}

		public void ScaleDamageFrom2d6(string weaponSize)
		{
			Dictionary<string, string> damageAdjustment = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
			var sb = new StringBuilder();

			damageAdjustment.Add("Fine", "1d4");
			damageAdjustment.Add("Diminutive", "1d6");
			damageAdjustment.Add("Tiny", "1d8");
			damageAdjustment.Add("Small", "1d10");
			damageAdjustment.Add("Medium", "2d6");
			damageAdjustment.Add("Large", "3d6");
			damageAdjustment.Add("Huge", "4d6");
			damageAdjustment.Add("Gargantuan", "6d6");
			damageAdjustment.Add("Colossal", "8d6");

			if (damageAdjustment.ContainsKey(weaponSize))
			{
				WeaponDamage = damageAdjustment[weaponSize];
				WeaponName = String.Format("{0} ({1})", WeaponName, weaponSize);
			}
		}

		public void AdjustHardnessHitPointsForSize(string weaponSize)
		{
			Dictionary<string, double> hardnessHitPointsAdjustment = new Dictionary<string, double>(StringComparer.OrdinalIgnoreCase);

			hardnessHitPointsAdjustment.Add("Fine", 0.0625);
			hardnessHitPointsAdjustment.Add("Diminutive", 0.125);
			hardnessHitPointsAdjustment.Add("Tiny", 0.25);
			hardnessHitPointsAdjustment.Add("Small", 0.5);
			hardnessHitPointsAdjustment.Add("Medium", 1);
			hardnessHitPointsAdjustment.Add("Large", 2);
			hardnessHitPointsAdjustment.Add("Huge", 4);
			hardnessHitPointsAdjustment.Add("Gargantuan", 8);
			hardnessHitPointsAdjustment.Add("Colossal", 16);

			if (hardnessHitPointsAdjustment.ContainsKey(weaponSize))
			{
				WeaponHardness = (WeaponHardness * hardnessHitPointsAdjustment[weaponSize]);
				WeaponHitPoints = (WeaponHitPoints * hardnessHitPointsAdjustment[weaponSize]);
			}
			else
			{
				WeaponHardness = 10;
				WeaponHitPoints = 2;
			}
			if (WeaponHardness < 1)
			{
				WeaponHardness = 1;
			}
			if (WeaponHitPoints < 1)
			{
				WeaponHitPoints = 1;
			}
		}

		public void AdjustWeightForSize(string weaponSize)
		{
			Dictionary<string, double> weightAdjustment = new Dictionary<string, double>(StringComparer.OrdinalIgnoreCase);

			weightAdjustment.Add("Small", 0.5);
			weightAdjustment.Add("Large", 2);

			if (weightAdjustment.ContainsKey(weaponSize))
			{
				WeaponWeight *= weightAdjustment[weaponSize];
			}
		}

		public void AdjsutCostForSize(string weaponSize)
		{
			Dictionary<string, double> costAdjustment = new Dictionary<string, double>(StringComparer.OrdinalIgnoreCase);

			costAdjustment.Add("Large", 2);
		}
	}
}
