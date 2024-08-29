using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;

namespace NicoMessy.Miscellany.Systems
	{
	/*

	The code in here was using the mod Len's Randoms as reference.

	*/
	public class AudioInit : ModSystem
		{
		public const string SoundFolder = "NicoMessy/Miscellany/Sounds/";

		// Gus' Balloon
		public static readonly SoundStyle BalloonHit = new(SoundFolder + "GusBalloon_hit");
		public static readonly SoundStyle BalloonMiss = new(SoundFolder + "GusBalloon_miss");
		}
	}