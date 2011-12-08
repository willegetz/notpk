using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdventureItems;

namespace ItemSmithWorkShop
{
	public class WeaponSizing
	{
		const string fine = "Fine";
		const string diminutive = "Diminutive";
		const string tiny = "Tiny";
		const string small = "Small";
		const string medium = "Medium";
		const string large = "Large";
		const string huge = "Huge";
		const string gargantuan = "Gargantuan";
		const string colossal = "Colossal";

		private List<string> SizeIndex { get; set; }
		private Dictionary<string, Dictionary<string, string>> DamageScale { get; set; }
		private Dictionary<string, double> scale;
		
		public string NewDamage { get; set; }
		public double Multiplier { get; set; }

		public WeaponSizing()
		{
			scale = new Dictionary<string, double>
			{
				{fine, 0.0625}, {diminutive, 0.125}, {tiny, 0.25}, {small, 0.5}, {medium, 1}, {large, 2}, {huge, 4}, {gargantuan, 8}, {colossal, 16},
			};

			Dictionary<string, string> damage1D2 = new Dictionary<string, string>
			{
				{fine, "No Meaningful Damage"}, {diminutive, "No Meaningful Damage"}, {tiny, "No Meaningful Damage"},
				{small, "1"}, {medium, "1d2"}, {large, "1d3"}, {huge, "1d4"}, {gargantuan, "1d6"}, {colossal, "1d8"}, 
			};
			Dictionary<string, string> damage1D3 = new Dictionary<string, string>
			{
				{fine, "No Meaningful Damage"}, {diminutive, "No Meaningful Damage"}, {tiny, "1"},
				{small, "1d2"}, {medium, "1d3"}, {large, "1d4"}, {huge, "1d6"}, {gargantuan, "1d8"}, {colossal, "2d6"}, 
			}; 
			Dictionary<string, string> damage1D4 = new Dictionary<string, string>
			{
				{fine, "No Meaningful Damage"}, {diminutive, "1"}, {tiny, "1d2"},
				{small, "1d3"}, {medium, "1d4"}, {large, "1d6"}, {huge, "1d8"}, {gargantuan, "2d6"}, {colossal, "3d6"}, 
			};
			Dictionary<string, string> damage1D6 = new Dictionary<string, string>
			{
				{fine, "1"}, {diminutive, "1d2"}, {tiny, "1d3"},
				{small, "1d4"}, {medium, "1d6"}, {large, "1d8"}, {huge, "2d6"}, {gargantuan, "3d6"}, {colossal, "4d6"}, 
			};
			Dictionary<string, string> damage2D4 = new Dictionary<string, string>
			{
				{fine, "1d2"}, {diminutive, "1d3"}, {tiny, "1d4"},
				{small, "1d6"}, {medium, "2d4"}, {large, "2d6"}, {huge, "3d6"}, {gargantuan, "4d6"}, {colossal, "6d6"}, 
			};
			Dictionary<string, string> damage1D8 = new Dictionary<string, string>
			{
				{fine, "1d2"}, {diminutive, "1d3"}, {tiny, "1d4"},
				{small, "1d6"}, {medium, "1d8"}, {large, "2d6"}, {huge, "3d6"}, {gargantuan, "4d6"}, {colossal, "6d6"}, 
			};
			Dictionary<string, string> damage1D10 = new Dictionary<string, string>
			{
				{fine, "1d3"}, {diminutive, "1d4"}, {tiny, "1d6"},
				{small, "1d8"}, {medium, "1d10"}, {large, "2d8"}, {huge, "3d8"}, {gargantuan, "4d8"}, {colossal, "6d8"}, 
			};
			Dictionary<string, string> damage1D12 = new Dictionary<string, string>
			{
				{fine, "1d4"}, {diminutive, "1d6"}, {tiny, "1d8"},
				{small, "1d10"}, {medium, "1d12"}, {large, "3d6"}, {huge, "4d6"}, {gargantuan, "6d6"}, {colossal, "8d6"}, 
			};
			Dictionary<string, string> damage2D6 = new Dictionary<string, string>
			{

				{fine, "1d4"}, {diminutive, "1d6"}, {tiny, "1d8"},
				{small, "1d10"}, {medium, "2d6"}, {large, "3d6"}, {huge, "4d6"}, {gargantuan, "6d6"}, {colossal, "8d6"}, 
			};


			DamageScale = new Dictionary<string, Dictionary<string, string>>{
						 {"1d2", damage1D2}, {"1d3", damage1D3}, {"1d4", damage1D4}, {"1d6", damage1D6},
						 {"2d4", damage2D4}, {"1d8", damage1D8}, {"1d10", damage1D10}, {"1d12", damage1D12},
						 {"2d6", damage2D6},
			};
		}

		public void SetSizingValues(string damage, string size)
		{
			if (DamageScale.ContainsKey(damage))
			{
				GetNewSizingData(damage, size);
			}
			else if (string.IsNullOrEmpty(damage))
			{
				GetNullSizingData();
			}
			else
			{
				GetOutOfRangeSizingData(damage, size);
			}
		}

		public void GetNewSizingData(string damage, string size)
		{
			NewDamage = DamageScale[damage][size];
			Multiplier = scale[size];
		}

		public void GetNullSizingData()
		{
			NewDamage = "";
			Multiplier = 0;
		}

		public void GetOutOfRangeSizingData(string damage, string size)
		{
			int stringIndex;
			var multiHeadString = new StringBuilder();
			string[] multiHeadedWeapon = damage.Split('/');

			foreach (var item in multiHeadedWeapon)
			{
				string index = item.ToString();
				multiHeadString.Append(DamageScale[index][size] + "/");
			}

			stringIndex = multiHeadString.Length - 1;
			multiHeadString.Remove(stringIndex, 1);
			NewDamage = multiHeadString.ToString();
			Multiplier = scale[size];
		}


		internal void SetSizingValues(WeaponData data, string size)
		{
			SetSizingValues(data.WeaponDamage, size);

			data.WeaponDamage = NewDamage;

			if (size == "Small")
			{
				data.BasePrice = data.BasePrice;
			}
			else
			{
				data.BasePrice = data.BasePrice * Multiplier;
			}
			
			if ((data.WeaponHardness * Multiplier) <= 1)
			{
				data.WeaponHardness = Math.Ceiling(data.WeaponHardness* Multiplier);
			}
			else
			{
				data.WeaponHardness = data.WeaponHardness * Multiplier;
			}

			if ((data.WeaponHitPoints * Multiplier) <= 1)
			{
				data.WeaponHitPoints = Math.Ceiling(data.WeaponHitPoints * Multiplier);
			}
			else
			{
				data.WeaponHitPoints = data.WeaponHitPoints * Multiplier;
			}
		}
	}
}