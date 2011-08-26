namespace ItemSmithWorkShop
{
	public class Weapon
	{
		public string WeaponName { get; set; }

		public Weapon(string name)
		{
			WeaponName = name;
		}

		public override string ToString()
		{
			return string.Format("Weapon Name: {0}", WeaponName);
		}
	}
}
