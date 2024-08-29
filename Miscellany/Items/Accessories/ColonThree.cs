using NicoMessy.Miscellany.Systems;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace NicoMessy.Miscellany.Items.Accessories
	{
	public class ColonThree : ModItem
		{

        // This is the BUFF ACCESSORY base template, cuz im lazy.

        // By declaring these here, changing the values will alter the effect, and the tooltip
        public static readonly float ColonThreeHP = 0.8f;
        public static readonly int ColonThreeRegen = 100;
        public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs((int)(ColonThreeHP * 100), ColonThreeRegen);

		public override void SetDefaults()
			{

			// Sprite Stuff
			Item.width = 28;
			Item.height = 27;
			Item.rare = ItemRarityID.Expert;
			Item.accessory = true;

			// Others
			Item.value = Item.sellPrice(0, 99, 99, 99);
			}

		public override void UpdateAccessory(Player player, bool hideVisual)
			{
			base.UpdateAccessory(player, hideVisual);

			player.statLifeMax2 -= (int)(player.statLifeMax * ColonThreeHP);
			player.lifeRegen += ColonThreeRegen;
			player.GetModPlayer<MessyPlayer>().ColonThreeEquipped = true;

			}

		public override void AddRecipes()
			{
			// Recipe of item

			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.AlphabetStatue3, 333);
			recipe.AddRecipeGroup(ItemID.PlatinumCoin, 3);
			recipe.AddTile(TileID.DemonAltar);
			recipe.Register();

			}
		}
	}