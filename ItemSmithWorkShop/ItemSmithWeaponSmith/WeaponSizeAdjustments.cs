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
		public double BasePrice { get; set; }

		const string fine = "Fine";
		const string diminutive = "Diminutive";
		const string tiny = "Tiny";
		const string small = "Small";
		const string medium = "Medium";
		const string large = "Large";
		const string huge = "Huge";
		const string gargantuan = "Gargantuan";
		const string colossal = "Colossal";

		public WeaponSizeAdjustments() { }

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
			Dictionary<string, int> sizing = new Dictionary<string, int>{
			{fine, 0}, {diminutive, 1}, {tiny, 2}, {small, 3}, {medium, 4}, {large, 5}, {huge, 6}, {gargantuan, 7}, {colossal, 8}};

			int sizingIndex = sizing[weaponSize];

			string[] damage1D2 = new[] { "No Meaningful Damage", "No Meaningful Damage", "No Meaningful Damage", "1", "1d2", "1d3", "1d4", "1d6", "1d8" };
			string[] damage1D3 = new[] { "No Meaningful Damage", "No Meaningful Damage", "1", "1d2", "1d3", "1d4", "1d6", "1d8", "2d6" };
			string[] damage1D4 = new[] { "No Meaningful Damage", "1", "1d2", "1d3", "1d4", "1d6", "1d8", "2d6", "3d6" };
			string[] damage1D6 = new[] { "1", "1d2", "1d3", "1d4", "1d6", "1d8", "2d6", "3d6", "4d6" };
			string[] damage2D4 = new[] { "1d2", "1d3", "1d4", "1d6", "2d4", "2d6", "3d6", "4d6", "6d6" };
			string[] damage1D8 = new[] { "1d2", "1d3", "1d4", "1d6", "1d8", "2d6", "3d6", "4d6", "6d6" };
			string[] damage1D10 = new[] { "1d3", "1d4", "1d6", "1d8", "1d10", "2d8", "3d8", "4d8", "6d8" };
			string[] damage1D12 = new[] { "1d4", "1d6", "1d8", "1d10", "1d12", "3d6", "4d6", "6d6", "8d6" };
			string[] damage2D6 = new[] { "1d4", "1d6", "1d8", "1d10", "2d6", "3d6", "4d6", "6d6", "8d6" };

			Dictionary<string, string[]> sizeModification = new Dictionary<string, string[]>{
						 {"1d2", damage1D2}, {"1d3", damage1D3}, {"1d4", damage1D4}, {"1d6", damage1D6},
						 {"2d4", damage2D4}, {"1d8", damage1D8}, {"1d10", damage1D10}, {"1d12", damage1D12},
						 {"2d6", damage2D6}
			};

			WeaponDamage = sizeModification[WeaponDamage][sizingIndex].ToString();
			WeaponName = String.Format("{0} ({1})", WeaponName, weaponSize);
		}

		public void AdjustHardnessHitPointsForSize(string weaponSize)
		{
			Dictionary<string, double> hardnessHitPointsAdjustment = new Dictionary<string, double>(StringComparer.OrdinalIgnoreCase) { 
			{fine, 0.0625}, {diminutive, 0.125}, {tiny, 0.25}, {small, 0.5}, {medium, 1}, {large, 2}, {huge, 4}, {gargantuan, 8}, {colossal, 16}
			};


			if (hardnessHitPointsAdjustment.ContainsKey(weaponSize))
			{
				WeaponHardness = (WeaponHardness * hardnessHitPointsAdjustment[weaponSize]);
				WeaponHitPoints = (WeaponHitPoints * hardnessHitPointsAdjustment[weaponSize]);
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

		//public void AdjustWeightForSize(string weaponSize)
		//{
		//    Dictionary<string, double> weightAdjustment = new Dictionary<string, double>(StringComparer.OrdinalIgnoreCase) { 
		//    {fine, 0.0625}, {diminutive, 0.125}, {tiny, 0.25}, {small, 0.5}, {medium, 1}, {large, 2}, {huge, 4}, {gargantuan, 8}, {colossal, 16}
		//    };

		//    if (weightAdjustment.ContainsKey(weaponSize))
		//    {
		//        WeaponWeight *= weightAdjustment[weaponSize];
		//    }
		//}

		public void AdjustWeightForSize(string weaponSize)
		{
			Dictionary<string, int> sizing = new Dictionary<string, int>{
		    {fine, 0}, {diminutive, 1}, {tiny, 2}, {small, 3}, {medium, 4}, {large, 5}, {huge, 6}, {gargantuan, 7}, {colossal, 8}};

			int sizeIndex = sizing[weaponSize];

			if (sizeIndex < 4)
			{
				WeaponWeight *= 0.5;
			}
			else if (sizeIndex > 4)
			{
				WeaponWeight *= 2;
			}
		}

		public void AdjsutCostForSize(string weaponSize)
		{
			Dictionary<string, int> sizing = new Dictionary<string, int>{
		    {fine, 0}, {diminutive, 1}, {tiny, 2}, {small, 3}, {medium, 4}, {large, 5}, {huge, 6}, {gargantuan, 7}, {colossal, 8}};

			int sizeIndex = sizing[weaponSize];

			if (sizeIndex > 4)
			{
				BasePrice *= 2;
			}

		}
	}
}
