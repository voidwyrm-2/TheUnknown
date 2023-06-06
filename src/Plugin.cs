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
using NuclearPasta.TheUnknown.Player_Hooks;
//using static UnityEngine.Input;

namespace NuclearPasta.TheUnknown
{
    [BepInPlugin(MOD_ID, "The Unknown", "0.1.0")]
    public class TheUnknownMod : BaseUnityPlugin
    {
        private const string MOD_ID = "dv.theunknown";

        static SlugcatStats.Name MySlugcat = new SlugcatStats.Name("Unknown");

        
        // Add hooks
        public void OnEnable()
        {
            PlayerFlight.OnEnable();
            PlayerExplode.OnEnable();
            PlayerAutoParry.OnEnable();
            GotAwayAgain.OnEnable();
            //On.RainWorld.OnModsInit += Extras.WrapInit(LoadResources);

            // Put your custom hooks here!
            //On.Player.AerobicIncrease += Player_Ribulet;
            On.Player.Update += Player_Update;
            
        }

        

        private void Player_Update(On.Player.orig_Update orig, Player self, bool eu)
        {
            orig(self, eu);
            if(self.IsJollyPlayer)
            {
            
            }
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