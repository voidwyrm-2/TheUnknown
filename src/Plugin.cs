using System;
using BepInEx;
using UnityEngine;
using SlugBase.Features;
using static SlugBase.Features.FeatureTypes;
using System.Runtime.CompilerServices;
using MoreSlugcats;
using Noise;
using On;
using RWCustom;
using BepInEx.Logging;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using IL;
//using static UnityEngine.Input;

namespace NuclearPasta.TheUnknown
{
    [BepInPlugin(MOD_ID, "The Unknown", "0.1.0")]
    class Plugin : BaseUnityPlugin
    {
        private const string MOD_ID = "dv.theunknown";

        static SlugcatStats.Name MySlugcat = new SlugcatStats.Name("Unknown");

        // Add hooks
        public void OnEnable()
        {
            //On.RainWorld.OnModsInit += Extras.WrapInit(LoadResources);

            // Put your custom hooks here!
            //On.Player.AerobicIncrease += Player_Ribulet;
        }

        /*
        private void Player_Ribulet(On.Player.orig_AerobicIncrease orig, Player self, float f)
        {
            orig(self, f);
            int i = 1000;
            if(self.SlugCatClass == MySlugcat && self.objectInStomach?.type == AbstractPhysicalObject.AbstractObjectType.BubbleGrass)
            {
                self.airInLungs = i;
            }
        }
        */

    }
}