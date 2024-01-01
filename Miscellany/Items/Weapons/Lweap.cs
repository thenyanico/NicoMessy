using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using NicoMessy.Miscellany.Items.Materials;

namespace NicoMessy.Miscellany.Items.Weapons
{
	public class Lweap : ModItem
	{
        public override void SetDefaults()
		{
            // Damage
            Item.damage = 12345;
            Item.mana = 123;
			Item.DamageType = DamageClass.Magic;
            Item.useTime = 14;
            Item.useAnimation = 14;
            Item.knockBack = 1.4f;
            Item.crit = 14;

			// Projectile Call
			Item.shoot = ModContent.ProjectileType<Lproj>();
            Item.shootSpeed = 7f;

            // Sprite Stuff
            Item.width = 24;
			Item.height = 32;
            Item.scale = 0.9f;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.holdStyle = ItemHoldStyleID.HoldLamp;
            Item.rare = ItemRarityID.Expert;
			
			// Others
			Item.value = Item.sellPrice(0,0,1,44);
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}

		//public override void AddRecipes()
		//{
			// Recipe of item

			//Recipe recipe = CreateRecipe();
			//recipe.AddIngredient(ItemID.AlphabetStatueL, 1234);
            //recipe.AddIngredient(ItemID.IceBlock, 1234);
            //recipe.AddIngredient(ItemID.LihzahrdBrick, 1234);
            //recipe.AddIngredient<MessyEssence>(1234);
            //recipe.AddIngredient<TenderGel>(5678);
            //recipe.AddTile(TileID.MythrilAnvil);
			//recipe.Register();
		//}

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.NextBool(3)) // With 1/3 chance per tick (60 ticks = 1 second)...
            {
                // ...spawning dust
                Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), // Position to spawn
                hitbox.Width, hitbox.Height, // Width and Height
                DustID.Cloud, // Dust type. Check https://terraria.wiki.gg/wiki/Dust_IDs
                0, 0, // Velocity X and Velocity Y of the dust, I set to 0 to prevent dust from moving
                75); // Dust transparency, 0 - full visibility, 255 - full transparency

            }
        }
    }

	public class Lproj : ModProjectile
	{
		public override string Texture => "NicoMessy/Miscellany/Items/Weapons/Lweap";
        public override void SetDefaults()
        {

            Projectile.width = 12;
            Projectile.height = 16;
            Projectile.aiStyle = -1;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.penetrate = 1;
            Projectile.timeLeft = 240;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.extraUpdates = 0;

            
        }

        public override void AI()
        {
            float num132 = (float)Math.Sqrt((double)(Projectile.velocity.X * Projectile.velocity.X + Projectile.velocity.Y * Projectile.velocity.Y));
            float num133 = Projectile.localAI[0];
            if (num133 == 0f)
            {
                Projectile.localAI[0] = num132;
                num133 = num132;
            }
            float num134 = Projectile.position.X;
            float num135 = Projectile.position.Y;
            float num136 = 300f;
            bool flag3 = false;
            int num137 = 0;
            if (Projectile.ai[1] == 0f)
            {
                for (int num138 = 0; num138 < 200; num138++)
                {
                    if (Main.npc[num138].CanBeChasedBy(this, false) && (Projectile.ai[1] == 0f || Projectile.ai[1] == (float)(num138 + 1)))
                    {
                        float num139 = Main.npc[num138].position.X + (float)(Main.npc[num138].width / 2);
                        float num140 = Main.npc[num138].position.Y + (float)(Main.npc[num138].height / 2);
                        float num141 = Math.Abs(Projectile.position.X + (float)(Projectile.width / 2) - num139) + Math.Abs(Projectile.position.Y + (float)(Projectile.height / 2) - num140);
                        if (num141 < num136 && Collision.CanHit(new Vector2(Projectile.position.X + (float)(Projectile.width / 2), Projectile.position.Y + (float)(Projectile.height / 2)), 1, 1, Main.npc[num138].position, Main.npc[num138].width, Main.npc[num138].height))
                        {
                            num136 = num141;
                            num134 = num139;
                            num135 = num140;
                            flag3 = true;
                            num137 = num138;
                        }
                    }
                }
                if (flag3)
                {
                    Projectile.ai[1] = (float)(num137 + 1);
                }
                flag3 = false;
            }
            if (Projectile.ai[1] > 0f)
            {
                int num142 = (int)(Projectile.ai[1] - 1f);
                if (Main.npc[num142].active && Main.npc[num142].CanBeChasedBy(this, true) && !Main.npc[num142].dontTakeDamage)
                {
                    float num143 = Main.npc[num142].position.X + (float)(Main.npc[num142].width / 2);
                    float num144 = Main.npc[num142].position.Y + (float)(Main.npc[num142].height / 2);
                    if (Math.Abs(Projectile.position.X + (float)(Projectile.width / 2) - num143) + Math.Abs(Projectile.position.Y + (float)(Projectile.height / 2) - num144) < 1000f)
                    {
                        flag3 = true;
                        num134 = Main.npc[num142].position.X + (float)(Main.npc[num142].width / 2);
                        num135 = Main.npc[num142].position.Y + (float)(Main.npc[num142].height / 2);
                    }
                }
                else
                {
                    Projectile.ai[1] = 0f;
                }
            }
            if (!Projectile.friendly)
            {
                flag3 = false;
            }
            if (flag3)
            {
                float num145 = num133;
                Vector2 vector10 = new Vector2(Projectile.position.X + (float)Projectile.width * 0.5f, Projectile.position.Y + (float)Projectile.height * 0.5f);
                float num146 = num134 - vector10.X;
                float num147 = num135 - vector10.Y;
                float num148 = (float)Math.Sqrt((double)(num146 * num146 + num147 * num147));
                num148 = num145 / num148;
                num146 *= num148;
                num147 *= num148;
                int num149 = 8;
                Projectile.velocity.X = (Projectile.velocity.X * (float)(num149 - 1) + num146) / (float)num149;
                Projectile.velocity.Y = (Projectile.velocity.Y * (float)(num149 - 1) + num147) / (float)num149;
            }
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(BuffID.Chilled, 150); // Initial Chilled should not last too long

            // If Target hit has Chilled
            if (target.HasBuff(BuffID.Chilled))
            {
                // Remove Chilled debuff
                target.DelBuff(target.FindBuffIndex(BuffID.Chilled));

                // Add the Frozen debuff
                target.AddBuff(BuffID.Frozen, 240);
            }
        }
    }
}