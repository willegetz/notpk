namespace ItemSmithWorkShop
{
	public class NameOfWeapon
	{
		public string WeaponName { get; set; }

		public NameOfWeapon(string name)
		{
			WeaponName = name;
		}

		public override string ToString()
		{
			return string.Format("Weapon Name: {0}", WeaponName);
		}
	}
}
