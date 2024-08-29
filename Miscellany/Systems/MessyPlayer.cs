using NicoMessy.Miscellany.Buffs;
using Terraria;
using Terraria.ModLoader;
using Terraria.WorldBuilding;

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

		// // League of Legends
		public bool HeartsteelEquipped;
		public readonly float HeartsteelDmgReduc = 0.2f;

		public int LeagueItemsEquipped = 0;

		// // "Miscellany"

		public bool ColonThreeEquipped;


		// Overrides
		public override void ModifyHurt(ref Player.HurtModifiers modifiers)
		{
			// League of Legends
			if (HeartsteelEquipped)
			{
				modifiers.FinalDamage *= 1f - HeartsteelDmgReduc;
			}
		}

        public override void OnHitByNPC(NPC npc, Player.HurtInfo hurtInfo)
        {
			// required base
            base.OnHitByNPC(npc, hurtInfo);

			// "Miscellany"
			if (ColonThreeEquipped)
			{
				Player.AddBuff(ModContent.BuffType<Zoomies>(), 3);
			}
        }

    }
	}