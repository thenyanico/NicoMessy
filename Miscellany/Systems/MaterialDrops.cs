using NicoMessy.Miscellany.Items.Materials;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace NicoMessy.Miscellany.Systems
	{
	public class MaterialDrops : GlobalNPC
		{
		public override void ModifyGlobalLoot(GlobalLoot globalLoot)
			{
			globalLoot.Add(ItemDropRule.Common(ModContent.ItemType<MessyEssence>(), 1500));
			}
		public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
			{
			if (npc.type == NPCID.KingSlime || npc.type == NPCID.QueenSlimeBoss) // From what mob it drops
				{
				// Add(ItemDropRule.Common( *what it drops*, *how rare*, *minimum amount*, *maximum amount*));
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<TenderGel>(), 1, 6, 12));
				}

            if (npc.type == NPCID.Pinky)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<TenderGel>(), 100, 1, 3));
            }
        }
		}
	}