using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NicoMessy.Miscellany.Items.Materials;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NicoMessy.Miscellany.Items.Weapons
    {
    public class Microphone : ModItem
        {

        public Vector2 usePos = default(Vector2);
        public override void SetStaticDefaults()
            {
            Item.staff[Type] = true; // This makes the useStyle animate as a staff instead of as a gun.
            }
        public override void SetDefaults()
            {
            // Damage
            Item.damage = 40;
            Item.mana = 27;
            Item.DamageType = DamageClass.Magic;
            Item.useTime = 12;
            Item.reuseDelay = 9;
            Item.useAnimation = 45;
            Item.knockBack = 0.4f;
            Item.crit = 12;

            // Projectile Call
            Item.shoot = ProjectileID.PurificationPowder; // For some reason, all the guns in the vanilla source have this.
            Item.shootSpeed = 11.7f;

            // Sprite Stuff
            Item.width = 32;
            Item.height = 32;
            Item.scale = 1.1f;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.holdStyle = ItemHoldStyleID.None;
            Item.rare = ItemRarityID.LightRed;

            // Others
            Item.value = Item.sellPrice(0, 12, 23, 21);
            Item.UseSound = SoundID.Item26;
            Item.autoReuse = true;
            }
        //This actually allows the thing to shoot something that isn't Purification Powder
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
            {
            type = Main.rand.Next(new int[] { ModContent.ProjectileType<Arrowleft>(), ModContent.ProjectileType<Arrowdown>(), ModContent.ProjectileType<Arrowup>(), ModContent.ProjectileType<Arrowright>() });

            /*Grox's Code*/
            usePos = Main.MouseWorld - player.position;
            position.X = Main.MouseWorld.X; //Makes the position equal to your mouse
            position.X += Main.rand.Next(new int[] {-120, -60, 60, 120}); // fnf pathways?!
			//position.X += MathHelper.Lerp(-120f, 120f, (float)Main.rand.NextDouble()); Allows you have the projectile spawn at random in the x direction
			position.Y -= 500; //Make the projectile spawn 500 pixels above you (About 32 tiles)
            velocity.Y = (float)(Item.shootSpeed); //Makes it fall down
            velocity.X = 0; //Makes it not stray from direct path to ground
            /*End of Grox's Code*/
            }

        public override void AddRecipes()
            {
            Recipe recipe = CreateRecipe();
            recipe.AddRecipeGroup("NicoMessy:GoldBars", 20);
            recipe.AddRecipeGroup("NicoMessy:IronBars", 35);
            recipe.AddIngredient(ItemID.ManaCrystal, 5);
            recipe.AddIngredient<MessyEssence>(4);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
            }
        public abstract class ArrowBase : ModProjectile
            {
            public override string Texture => "NicoMessy/Miscellany/Projectiles/Arrows/";
            public override void SetDefaults()
                {

                Projectile.width = 32;
                Projectile.height = 32;
                Projectile.scale = 1.35f;
                Projectile.friendly = true;
                Projectile.hostile = false;
                Projectile.DamageType = DamageClass.Magic;
                Projectile.penetrate = 1;
                Projectile.timeLeft = 960;
                Projectile.ignoreWater = true;
                Projectile.tileCollide = false;
                Projectile.extraUpdates = 0;

                }

            private const int BufferSize = 15; // This is the amount of positions we'll store. 10 is one sixth of a second's worth, if you want more than that, just increase this value.
            private Vector2[] positionBuffer = new Vector2[BufferSize]; // Initialises a Vector2 array of size BufferSize (so 10).
            private int bufferTail = 0; // This keeps track of the 'tail' of the buffer. Don't worry, I'll explain below.
            private bool bufferFull; // This keeps track of whether or not the buffer has been filled yet.
            public abstract int ArrowDust { get; }
            public abstract float ArrowR { get; }
            public abstract float ArrowG { get; }
            public abstract float ArrowB { get; }
            public override void AI()
                {
                // Lighting
                Lighting.AddLight(Projectile.Center, ArrowR, ArrowG, ArrowB);

                // Dust Effect AI
                positionBuffer[bufferTail] = Projectile.position;
                bufferTail++;
                if (bufferTail >= BufferSize)
                    {
                    bufferFull = true;
                    bufferTail = 0;
                    }

                int dustAmount = bufferFull ? BufferSize : bufferTail;

                for (int i = 0; i < dustAmount; i++)
                    {
                    int dustId = Dust.NewDust(positionBuffer[i], 1, 1, ArrowDust, 0f, 0f, 0, default(Color), 0.65f);
                    Main.dust[dustId].alpha = Projectile.alpha;
                    Main.dust[dustId].velocity *= 0f;
                    Main.dust[dustId].noGravity = true;
                    Main.dust[dustId].fadeIn *= 2.1f;
                    Main.dust[dustId].scale = 1f;
                    }
                }

            }
        public class Arrowleft : ArrowBase
            {
            public override string Texture => base.Texture + "arrowleft";
            public override int ArrowDust => DustID.HallowedTorch;
            public override float ArrowR => 1f;
            public override float ArrowG => 0.14f;
            public override float ArrowB => 0.4f;
            }
        public class Arrowdown : ArrowBase
            {
            public override string Texture => base.Texture + "arrowdown";
            public override int ArrowDust => DustID.BlueTorch;
            public override float ArrowR => 0.1f;
            public override float ArrowG => 0.1f;
            public override float ArrowB => 0.8f;
            }
        public class Arrowup : ArrowBase
            {
            public override string Texture => base.Texture + "arrowup";
            public override int ArrowDust => DustID.GreenTorch;
            public override float ArrowR => 0.25f;
            public override float ArrowG => 1f;
            public override float ArrowB => 0.25f;
            }
        public class Arrowright : ArrowBase
            {
            public override string Texture => base.Texture + "arrowright";
            public override int ArrowDust => DustID.Torch;
            public override float ArrowR => 1f;
            public override float ArrowG => 0.44f;
            public override float ArrowB => 0.15f;
            }


        }
    }