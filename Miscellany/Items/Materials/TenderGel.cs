using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NicoMessy.Miscellany.Items.Materials
	{
	public class TenderGel : ModItem
		{
		public override void SetDefaults()
			{
			Item.width = 16; // Width of an item sprite
			Item.height = 16; // Height of an item sprite
			Item.maxStack = 9999; // How many items can be in one inventory slot
			Item.value = Item.sellPrice(0, 0, 7, 50);
			Item.rare = ItemRarityID.Blue;
			}
		}
	}