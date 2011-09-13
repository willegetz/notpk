namespace ItemSmithWorkShop
{
	//		Material Type
	//			Cost adjustment
	public class WeaponMake
	{
		public int AdjustedCost { get; set; }
		public int AdjustedWeight { get; set; }
		public string MasterWorkToHit { get; set; }
		public string MasterWorkMark { get; set; }
		public string MaterialType { get; set; }
		public string WeightType { get; set; }
		
		private bool IsMasterWork { get; set; }
		private string masterWorkMark = "Masterwork";
		private int masterWorkCost = 300;
		private int toHitModifier = 1;
		private int costAdjustment;

		public WeaponMake(string material, int adjustment, int weight, string measurement)
		{
			MaterialType = material + " ";
			AdjustedCost = adjustment;
			AdjustedWeight = weight;
			WeightType = measurement;
		}

		public void IsMasterWorkQualifier(bool qualifier)
		{
			IsMasterWork = qualifier;
			MasterWorkWeapon();
		}

		private void MasterWorkWeapon()
		{
			if (IsMasterWork)
			{
				AdjustedCost += masterWorkCost;
				MasterWorkMark = masterWorkMark + " ";
				MasterWorkToHit = "+" + toHitModifier;
			}
		}

		public override string ToString()
		{
			return string.Format("Adjusted Cost: {0}\nMasterWorkMark: {1}\nTo Hit Modifier: {2}\nMaterialType: {3}\nWeight {4}", AdjustedCost, MasterWorkMark, MasterWorkToHit, MaterialType, AdjustedWeight);
		}
	}
}
