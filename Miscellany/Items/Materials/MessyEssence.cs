using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NicoMessy.Miscellany.Items.Materials
	{
	public class MessyEssence : ModItem
		{
		// This is the MATERIALS base template, cuz im lazy.
		public override void SetDefaults()
			{
			Item.width = 32; // Width of an item sprite
			Item.height = 32; // Height of an item sprite
			Item.maxStack = 9999; // How many items can be in one inventory slot
			Item.value = Item.sellPrice(0, 0, 12, 25);
			Item.rare = ItemRarityID.Green;
			}
		}
	}