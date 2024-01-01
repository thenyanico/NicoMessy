using Terraria;
using Terraria.ModLoader;

namespace NicoMessy.Miscellany.Systems
	{
	/*
     
    The code in here was using the mod Len's Randoms as reference.

     */
	public class MessyPlayer : ModPlayer
		{
		public static MessyPlayer Modplayer(Player player)
			{
			return player.GetModPlayer<MessyPlayer>();
			}

		// Accessories
		public bool HeartsteelEquipped;
		public readonly float HeartsteelDmgReduc = 0.2f;

		public int LeagueItemsEquipped = 0;

		// Overrides
		public override void ModifyHurt(ref Player.HurtModifiers modifiers)
			{
			if (HeartsteelEquipped)
				{
				modifiers.FinalDamage *= 1f - HeartsteelDmgReduc;
				}
			}

		}
	}