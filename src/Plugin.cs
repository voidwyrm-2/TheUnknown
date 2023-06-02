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

namespace SlugTemplate
{
    [BepInPlugin(MOD_ID, "The Unknown", "0.1.0")]
    class Plugin : BaseUnityPlugin
    {
        private const string MOD_ID = "dv.theunknown";

        static SlugcatStats.Name MySlugcat = new SlugcatStats.Name("Unknown");

        // Add hooks
        public void OnEnable()
        {
            On.RainWorld.OnModsInit += Extras.WrapInit(LoadResources);

            // Put your custom hooks here!
            On.Player.checkInput += Player_checkInput1;
            On.Player.checkInput += Player_checkInput2;
        }

        private void Player_checkInput1(On.Player.orig_checkInput orig, Player self)
        {
            orig(self);
            if (self.SlugCatClass == MySlugcat && self.objectInStomach?.type == MoreSlugcatsEnums.AbstractObjectType.SingularityBomb)
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    self.mainBodyChunk.vel.y += 100f;
                }
                else
                {
                    return;
                }
            }
        }

        private void Player_checkInput2(On.Player.orig_checkInput orig, Player self)
        {
            orig(self);
            if (self.SlugCatClass == MySlugcat && self.objectInStomach?.type == MoreSlugcatsEnums.AbstractObjectType.SingularityBomb)
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    self.mainBodyChunk.vel.y += 25f;
                }
                else
                {
                    return;
                }
            }
        }

        /*
        private void Player_checkInput11(On.Player.orig_checkInput orig, Player self)
        {
            orig(self);
            if (self.SlugCatClass == MySlugcat && self.objectInStomach?.type == MoreSlugcatsEnums.AbstractObjectType.SingularityBomb)
            {
                if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.W))
                {
                    self.mainBodyChunk.vel.y += 10f;
                }
                else
                {
                    return;
                }
            }
        }
        */

        private void Player_checkInput12(On.Player.orig_checkInput orig, Player self)
        {
            orig(self);
            if (self.SlugCatClass == MySlugcat && self.objectInStomach?.type == MoreSlugcatsEnums.AbstractObjectType.SingularityBomb)
            {
                if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.D))
                {
                    self.mainBodyChunk.vel.x += 25f;
                }
                else
                {
                    return;
                }
            }
        }

        private void Player_checkInput13(On.Player.orig_checkInput orig, Player self)
        {
            orig(self);
            if (self.SlugCatClass == MySlugcat && self.objectInStomach?.type == MoreSlugcatsEnums.AbstractObjectType.SingularityBomb)
            {
                if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.A))
                {
                    self.mainBodyChunk.vel.x += -25f;
                }
                else
                {
                    return;
                }
            }
        }

        private void Player_checkInput14(On.Player.orig_checkInput orig, Player self)
        {
            orig(self);
            if (self.SlugCatClass == MySlugcat && self.objectInStomach?.type == MoreSlugcatsEnums.AbstractObjectType.SingularityBomb)
            {
                if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.S))
                {
                    self.mainBodyChunk.vel.y += -25f;
                }
                else
                {
                    return;
                }
            }
        }

        // Load any resources, such as sprites or sounds
        private void LoadResources(RainWorld rainWorld)
        {
        }


    }
}