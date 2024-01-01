using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace NicoMessy.Miscellany.Systems
{
    public class GenericRecipeGroups : ModSystem
    {
        public override void AddRecipeGroups()
        {
            RecipeGroup group = new RecipeGroup(() => "Evil Bars", new int[]
            {
                ItemID.DemoniteBar,
                ItemID.CrimtaneBar
            });
            RecipeGroup.RegisterGroup("NicoMessy:EvilBars", group);

            group = new RecipeGroup(() => "Unique Evil Boss Drops", new int[]
            {
                ItemID.ShadowScale,
                ItemID.TissueSample
            });
            RecipeGroup.RegisterGroup("NicoMessy:EvilBossDrops", group);

            group = new RecipeGroup(() => "Copper Bars", new int[]
            {
                ItemID.CopperBar,
                ItemID.TinBar
            });
            RecipeGroup.RegisterGroup("NicoMessy:CopperBars", group);

            group = new RecipeGroup(() => "Silver Tier Bars", new int[]
           {
                ItemID.SilverBar,
                ItemID.TungstenBar
           });
            RecipeGroup.RegisterGroup("NicoMessy:SilverBars", group);

            group = new RecipeGroup(() => "Gold Tier Bars", new int[]
            {
                ItemID.GoldBar,
                ItemID.PlatinumBar
            });
            RecipeGroup.RegisterGroup("NicoMessy:GoldBars", group);

            group = new RecipeGroup(() => "Cobalt Tier Bars", new int[]
            {
                ItemID.CobaltBar,
                ItemID.PalladiumBar
            });
            RecipeGroup.RegisterGroup("NicoMessy:CobaltBars", group);

            group = new RecipeGroup(() => "Mythril Tier Bars", new int[]
            {
                ItemID.MythrilBar,
                ItemID.OrichalcumBar
            });
            RecipeGroup.RegisterGroup("NicoMessy:MythrilBars", group);

            group = new RecipeGroup(() => "Titanium Tier Bars", new int[]
            {
                ItemID.TitaniumBar,
                ItemID.AdamantiteBar
            });
            RecipeGroup.RegisterGroup("NicoMessy:TitaniumBars", group);

        }
    }
}