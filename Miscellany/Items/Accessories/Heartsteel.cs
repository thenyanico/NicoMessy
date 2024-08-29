using NicoMessy.Miscellany.Systems;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace NicoMessy.Miscellany.Items.Accessories
	{
	public class Heartsteel : ModItem
		{

        // This is the NO BUFF ACCESSORY base template, cuz im lazy.

        // By declaring these here, changing the values will alter the effect, and the tooltip
        public static readonly int HeartsteelRegen = 5;
		public static readonly float HeartsteelHP = 0.1f;
		public static readonly float HeartsteelDMGReduc = 0.1f;
		public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs((int)(HeartsteelHP * 100), HeartsteelRegen, (int)(HeartsteelDMGReduc * 100));

		public override void SetDefaults()
			{

			// Sprite Stuff
			Item.width = 30;
			Item.height = 32;
			Item.rare = ItemRarityID.Lime;
			Item.accessory = true;

			// Others
			Item.value = Item.sellPrice(0, 33, 11, 40);
			}

		public int HeartsteelStacks = 0;
		public override void UpdateAccessory(Player player, bool hideVisual)
			{
			base.UpdateAccessory(player, hideVisual);

			player.statLifeMax2 += (int)(player.statLifeMax * HeartsteelHP);
			player.lifeRegen += HeartsteelRegen;
			player.GetModPlayer<MessyPlayer>().HeartsteelEquipped = true;
			player.GetModPlayer<MessyPlayer>().LeagueItemsEquipped += 1;

			}

		public override void AddRecipes()
			{
			// Recipe of item

			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Ruby, 10);
			recipe.AddIngredient(ItemID.LifeCrystal, 1);
			recipe.AddRecipeGroup("NicoMessy:MythrilBars", 16);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();

			}
		}
	}