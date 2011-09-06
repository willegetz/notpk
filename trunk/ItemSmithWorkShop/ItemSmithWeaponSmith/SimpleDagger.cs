using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItemSmithWeaponSmith
{
	public class SimpleDagger : WeaponSizeAdjustments
	{
		private double masterworkCostModifier;
		public int BasePrice { get; set; }

		//public string WeaponName { get; set; }

		public string WeaponProficiencyRequirement
		{
			get
			{
				return "Light Weapon";
			}
		}

		public string WeaponCategory
		{
			get
			{
				return "Melee";
			}
		}

		//public string WeaponDamage
		//{
		//    get;
		//    set;
		//}

		public string WeaponThreatRange
		{
			get
			{
				return "19-20";
			}
		}

		public string WeaponCritical
		{
			get
			{
				return "x2";
			}
		}

		public string WeaponDamageType
		{
			get
			{
				return "Piercing or Slashing";
			}
		}

		public double WeaponCost
		{
			get;
			set;
		}

		//public double WeaponWeight
		//{
		//    get;
		//    set;
		//}

		//public double WeaponHardness
		//{
		//    get;
		//    set;
		//}

		//public double WeaponHitPoints
		//{
		//    get;
		//    set;
		//}

		public string WeaponText { get; set; }
		public bool IsMasterwork { get; private set; }
		public int ToHitModifier { get; set; }
		public string AdditionalText { get; set; }

		public void IsMasterworkQualifier(bool value)
		{
			if (value)
			{
				IsMasterwork = true;
				MasterworkProperties();
			}
		}

		private void MasterworkProperties()
		{
			WeaponName = "Masterwork " + WeaponName;
			ToHitModifier = 1;
			WeaponText = WeaponText + "\n\tThis dagger is masterwork quality!";
			masterworkCostModifier = 300;
		}

		//private void DetermineWeaponDamage(string weaponSize)
		//{
		//    Dictionary<string, string> damageAdjustment = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
		//    var sb = new StringBuilder();

		//    damageAdjustment.Add("Fine", "No Meaningful Damage");
		//    damageAdjustment.Add("Diminutive", "1");
		//    damageAdjustment.Add("Tiny", "1d2");
		//    damageAdjustment.Add("Small", "1d3");
		//    damageAdjustment.Add("Medium", "1d4");
		//    damageAdjustment.Add("Large", "1d6");
		//    damageAdjustment.Add("Huge", "1d8");
		//    damageAdjustment.Add("Gargantuan", "2d6");
		//    damageAdjustment.Add("Colossal", "3d6");

		//    if (damageAdjustment.ContainsKey(weaponSize))
		//    {
		//        WeaponDamage = damageAdjustment[weaponSize];
		//        WeaponName = String.Format("{0} ({1})", WeaponName, weaponSize);
		//    }
		//}

		//public void AdjustHardnessHitPointsForSize(string weaponSize)
		//{
		//    Dictionary<string, double> hardnessHitPointsAdjustment = new Dictionary<string, double>(StringComparer.OrdinalIgnoreCase);

		//    hardnessHitPointsAdjustment.Add("Fine", 0.0625);
		//    hardnessHitPointsAdjustment.Add("Diminutive", 0.125);
		//    hardnessHitPointsAdjustment.Add("Tiny", 0.25);
		//    hardnessHitPointsAdjustment.Add("Small", 0.5);
		//    hardnessHitPointsAdjustment.Add("Medium", 1);
		//    hardnessHitPointsAdjustment.Add("Large", 2);
		//    hardnessHitPointsAdjustment.Add("Huge", 4);
		//    hardnessHitPointsAdjustment.Add("Gargantuan", 8);
		//    hardnessHitPointsAdjustment.Add("Colossal", 16);

		//    if (hardnessHitPointsAdjustment.ContainsKey(weaponSize))
		//    {
		//        WeaponHardness = (WeaponHardness * hardnessHitPointsAdjustment[weaponSize]);
		//        WeaponHitPoints = (WeaponHitPoints * hardnessHitPointsAdjustment[weaponSize]);
		//    }
		//    else
		//    {
		//        WeaponHardness = 10;
		//        WeaponHitPoints = 2;
		//    }
		//    if (WeaponHardness < 1)
		//    {
		//        WeaponHardness = 1;
		//    }
		//    if (WeaponHitPoints < 1)
		//    {
		//        WeaponHitPoints = 1;
		//    }
		//}

		//public void AdjustWeightForSize(string weaponSize)
		//{
		//    Dictionary<string, double> weightAdjustment = new Dictionary<string, double>(StringComparer.OrdinalIgnoreCase);

		//    weightAdjustment.Add("Small", 0.5);
		//    weightAdjustment.Add("Large", 2);

		//    if (weightAdjustment.ContainsKey(weaponSize))
		//    {
		//        WeaponWeight *= weightAdjustment[weaponSize];
		//    }
		//}

		//public void AdjsutCostForSize(string weaponSize)
		//{
		//    Dictionary<string, double> costAdjustment = new Dictionary<string, double>(StringComparer.OrdinalIgnoreCase);

		//    costAdjustment.Add("Large", 2);
		//}

		public SimpleDagger(string weaponSize)
		{
			WeaponName = "Dagger";
			WeaponDamage = "1d4";
			WeaponHardness = 10;
			WeaponHitPoints = 2;
			WeaponWeight = 1;
			WeaponText = "The dagger is a common secondary weapon. You get a +2 bonus on\n\tSleight of Hand checks made to conceal a dagger on your body.";
			BasePrice = 2;
			CheckForNull(weaponSize);
			WeaponCost = BasePrice;
		}

		//private void CheckForNull(string weaponSize)
		//{
		//    if (weaponSize == null)
		//    {
		//        return;
		//    }
		//    else
		//    {
		//        DetermineWeaponDamage(weaponSize);
		//        AdjustHardnessHitPointsForSize(weaponSize);
		//        AdjustWeightForSize(weaponSize);
		//        AdjsutCostForSize(weaponSize);
		//    }
		//}

		private string WeaponToDisplay()
		{
			var buildWeapon = new StringBuilder();

			buildWeapon.Append(WeaponName + "\n");
			buildWeapon.Append(String.Format("{0} Weapon\n{1} Proficiency\n", WeaponCategory, WeaponProficiencyRequirement));
			if (ToHitModifier != 0)
			{
				buildWeapon.Append(String.Format("To Hit: +{0}\n", ToHitModifier));
			}
			buildWeapon.Append(String.Format("Damage: {0} [{1} {2}] {3}\n", WeaponDamage, WeaponThreatRange, WeaponCritical, WeaponDamageType));
			buildWeapon.Append(String.Format("Hardness: {0}\nHit Points: {1}\nWeight: {2} pound(s)\n", WeaponHardness, WeaponHitPoints, WeaponWeight));
			buildWeapon.Append(String.Format("{0} gold pieces\n", (WeaponCost + masterworkCostModifier)));
			buildWeapon.Append(String.Format("\nWeapon Text:\n\t{0}", WeaponText));
			if (!String.IsNullOrEmpty(AdditionalText))
			{
				buildWeapon.Append(String.Format("\n\nAdditional Text:\n\t{0}", AdditionalText));
			}

			return buildWeapon.ToString();
		}

		public override string ToString()
		{
			return WeaponToDisplay();
		}
	}
}
