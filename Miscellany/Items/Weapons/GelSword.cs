using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using System;
using NicoMessy.Miscellany.Items.Materials;

namespace NicoMessy.Miscellany.Items.Weapons
{
	public class GelSword : ModItem
	{
		public override void SetDefaults()
		{
			// Damage
			Item.damage = 21;
			Item.DamageType = DamageClass.Melee;
            Item.useTime = 24;
            Item.useAnimation = 24;
            Item.knockBack = 0.9f;
            Item.crit = 5;

            // Sprite Stuff
            Item.width = 40;
			Item.height = 40;
            Item.scale = 1f;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.rare = ItemRarityID.Green;
			
			// Others
			Item.value = Item.sellPrice(0,3,31,15);
			Item.UseSound = SoundID.Item1;
		}
        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(BuffID.Slimed, 600);

            if (Main.rand.NextBool(6))
            {
                target.AddBuff(BuffID.Slow, 360);
            }
        }
        public override void AddRecipes()
		{
			// Recipe of item

			Recipe recipe = CreateRecipe();
			recipe.AddIngredient<TenderGel>(50);
			recipe.AddIngredient(ItemID.Gel, 50);
            recipe.AddIngredient<BasicWhat>(1);
			recipe.AddRecipeGroup("NicoMessy:GoldBars", 8);
            recipe.AddTile(TileID.Solidifier);
			recipe.Register();
		}
	}
}