using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using NicoMessy.Miscellany.Items.Materials;
using NicoMessy.Miscellany.Systems;
using Microsoft.CodeAnalysis;

namespace NicoMessy.Miscellany.Items.Weapons
	{
	public class GusBalloon : ModItem
		{
		public override void SetDefaults()
			{
			// Damage
			Item.damage = 61;
			Item.mana = 12;
			Item.DamageType = DamageClass.Magic;
			Item.useTime = 17;
			Item.useAnimation = 17;
			Item.knockBack = 0.2f;
			Item.crit = 6;

			// Projectile Call
			Item.shoot = ModContent.ProjectileType<BalloonProj>();
			Item.shootSpeed = 8.8f;

			// Sprite Stuff
			Item.width = 30;
			Item.height = 38;
			Item.scale = 0.9f;
			Item.useStyle = ItemUseStyleID.HoldUp;
			Item.holdStyle = ItemHoldStyleID.None;
			Item.rare = ItemRarityID.Yellow;

			// Others
			Item.value = Item.sellPrice(0, 2, 76, 0);
			Item.UseSound = new SoundStyle("NicoMessy/Miscellany/Sounds/GusBalloon_atk")
				{
				Volume = 0.7f
				};
			Item.autoReuse = true;
			}
		public override void AddRecipes()
			{
			//Recipe of item

			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.ShinyRedBalloon, 1);
			recipe.AddIngredient(ItemID.Ectoplasm, 10);
			recipe.AddIngredient<MessyEssence>(5);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
			}

		public class BalloonProj : ModProjectile
			{
			public override string Texture => "NicoMessy/Miscellany/Projectiles/GusBalloonProj";

			public override void SetStaticDefaults()
			{
				Main.projFrames[Projectile.type] = 4;
			}
			public override void SetDefaults()
				{

				Projectile.width = 32;
				Projectile.height = 18;
				Projectile.aiStyle = -1;
				Projectile.friendly = true;
				Projectile.hostile = false;
				Projectile.DamageType = DamageClass.Magic;
				Projectile.penetrate = 1;
				Projectile.timeLeft = 360;
				Projectile.ignoreWater = true;
				Projectile.tileCollide = true;
				Projectile.extraUpdates = 0;

				}
			public override void AI()
				{
				// Lighting
				Lighting.AddLight(Projectile.Center, 0.1f, 0.4f, 1f);

				// Rotation
				Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;

				// Animation
				int frameSpeed = 2; //How fast you want it to animate
				Projectile.frameCounter++;
				if (Projectile.frameCounter >= frameSpeed)
					{
					Projectile.frameCounter = 0;
					Projectile.frame++;
					if (Projectile.frame >= Main.projFrames[Projectile.type])
						{
						Projectile.frame = 0;
						}
					}

				// Dust
				if (Main.rand.NextBool(3))
					{
					int choice = Main.rand.Next(1);
					if (choice == 0)
						{
						choice = 16;
						}
					else
						{
						choice = 192;
						}
					// Spawn the dust
					Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, choice, Projectile.velocity.X * 0.25f, Projectile.velocity.Y * 0.25f, 150, default(Color), 0.7f);
					}
				}

			public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
				{
				SoundEngine.PlaySound(AudioInit.BalloonHit, Projectile.Center);

				target.AddBuff(BuffID.Slow, 120);
				}
			public override void OnKill(int timeLeft)
				{
				if (Projectile.damage <= 1)
					{
					SoundEngine.PlaySound(AudioInit.BalloonMiss, Projectile.Center);
					}
				}
			}
		}
	}