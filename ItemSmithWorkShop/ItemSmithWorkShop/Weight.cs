using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItemSmithWorkShop
{
	//		Weight
	//			Hardness
	//			Hit Points
	public class Weight
	{
		public int hardness;
		public int hitPoints;

		public Weight(int durability, int hits)
		{
			hardness = durability;
			hitPoints = hits;
		}
	}
}
