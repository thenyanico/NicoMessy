using Microsoft.Xna.Framework;
using NicoMessy.Miscellany.Items.Materials;
using System;
using System.Numerics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NicoMessy.Miscellany.Items.Weapons
    {
    public class GusBalloon : ModItem
        {
        public override void SetDefaults()
            {
            // Damage
            Item.damage = 21;
            Item.mana = 27;
            Item.DamageType = DamageClass.Magic;
            Item.useTime = 26;
            Item.useAnimation = 26;
            Item.knockBack = 0.8f;
            Item.crit = 13;

            // Projectile Call
            Item.shoot = ProjectileID.PurificationPowder; // For some reason, all the guns in the vanilla source have this.
            Item.shootSpeed = 9.5f;

            // Sprite Stuff
            Item.width = 30;
            Item.height = 38;
            Item.scale = 1f;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.holdStyle = ItemHoldStyleID.HoldUp;
            Item.rare = ItemRarityID.Green;

            // Others
            Item.value = Item.sellPrice(0, 4, 15, 82);
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "NicoMessy/Miscellany/Sounds/GusBalloon_atk.ogg");
        }
        //This actually allows the thing to shoot something that isn't Purification Powder
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            type = ModContent.ProjectileType<GusBalloonProj>();
            Vector2 muzzleOffset = Vector2.Normalize(velocity) * 25f;

            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
        }



        public override void AddRecipes()
            {
            Recipe recipe = CreateRecipe();
            recipe.AddRecipeGroup("NicoMessy:GoldBars", 25);
            recipe.AddRecipeGroup("IronBar", 30);
            recipe.AddIngredient(ItemID.ManaCrystal, 3);
            recipe.AddIngredient<MessyEssence>(4);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
            }
        }

    public abstract class GusBalloonProj : ModProjectile
        {
        public override string Texture => "NicoMessy/Miscellany/Projectiles/GusBalloonProj";
        public override void SetDefaults()
            {

            Projectile.width = 32;
            Projectile.height = 32;
            Projectile.scale = 1f;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.penetrate = 0;
            Projectile.timeLeft = 420;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            Projectile.extraUpdates = 0;

            }

        private const int BufferSize = 10; // This is the amount of positions we'll store. 10 is one sixth of a second's worth, if you want more than that, just increase this value.
        private Vector2[] positionBuffer = new Vector2[BufferSize]; // Initialises a Vector2 array of size BufferSize (so 10).
        private int bufferTail = 0; // This keeps track of the 'tail' of the buffer. Don't worry, I'll explain below.
        private bool bufferFull; // This keeps track of whether or not the buffer has been filled yet.
        public override void AI()
            {
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
                int dustId = Dust.NewDust(positionBuffer[i], 1, 1, DustID.Cloud, 0f, 0f, 0, default(Color), 0.55f);
                Main.dust[dustId].alpha = Projectile.alpha;
                Main.dust[dustId].velocity *= 0f;
                Main.dust[dustId].noGravity = true;
                Main.dust[dustId].fadeIn *= 1.8f;
                Main.dust[dustId].scale = 1f;
                }
            }
        }
    }