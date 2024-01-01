using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;

namespace NicoMessy.Miscellany.Items.Weapons
{
	public class BasicWhat : ModItem
	{
        // The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.NicoMessy.hjson file.

		// This is the WEAPON base template, cuz im lazy.
		public override void SetDefaults()
		{
			// Damage
			Item.damage = 14;
			Item.DamageType = DamageClass.Melee;
            Item.useTime = 28;
            Item.useAnimation = 28;
            Item.knockBack = 1.4f;
            Item.crit = 14;

            // Sprite Stuff
            Item.width = 40;
			Item.height = 40;
            Item.scale = 0.9f;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.rare = ItemRarityID.Blue;
			
			// Others
			Item.value = Item.sellPrice(0,0,1,44);
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}
		public override void AddRecipes()
		{
			// Recipe of item

			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.StoneBlock, 144);
            recipe.AddIngredient(ItemID.IronOre, 144);
            recipe.AddIngredient(ItemID.IronBar, 144);
            recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}

    }
}