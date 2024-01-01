using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
using NicoMessy.Miscellany.Items.Materials;

namespace NicoMessy.Miscellany.Systems
{
    public class MaterialDrops : GlobalNPC
    {
        public override void ModifyGlobalLoot(GlobalLoot globalLoot)
        {
            globalLoot.Add(ItemDropRule.Common(ModContent.ItemType<MessyEssence>(), 750));
        }
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            if (npc.type == NPCID.KingSlime || npc.type == NPCID.QueenSlimeBoss) // From what mob it drops
            { 
                // Add(ItemDropRule.Common( *what it drops*, *how rare*, *minimum amount*, *maximum amount*));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<TenderGel>(), 1, 10, 20));
            }
        }
    }
}