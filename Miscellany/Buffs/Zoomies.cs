using Terraria;
using Terraria.ModLoader;
using System;
using Terraria.ID;

namespace NicoMessy.Miscellany.Buffs
{
    public class Zoomies : ModBuff
    {
        public override void SetStaticDefaults()
        {

            // Indicate whether the buff is a debuff (false means it's a beneficial buff)
            Main.buffNoSave[Type] = true;
            Main.debuff[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;

            BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            // 3x move speed buff because why not
            player.moveSpeed += 3f;
        }
    }
}
