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
            On.Player.checkInput += Player_FlyUp;
            On.Player.checkInput += Player_FlyUpLess;
            //On.Player.checkInput += Player_FlyUp;
            On.Player.checkInput += Player_FlyRight;
            On.Player.checkInput += Player_FlyLeft;
            On.Player.checkInput += Player_FlyDown;
            On.Player.checkInput += Player_FlyUpvelxy1;
            On.Player.checkInput += Player_FlyUpvelxy2;
            On.Player.checkInput += Player_FlyUpvelxy3;
            On.Player.checkInput += Player_BootlegAscension;
            On.Player.Die += Player_SelfDestruct;
            //On.Player.checkInput += Player_Ribulet;
        }

        /*
        private void Player_Ribulet(On.Player.orig_checkInput orig, Player self)
        {
            orig(self);
        }
        */



        private void Player_SelfDestruct(On.Player.orig_Die orig, Player self)
        {
            orig(self);
            if (self.SlugCatClass == MySlugcat && self.objectInStomach?.type == AbstractPhysicalObject.AbstractObjectType.ScavengerBomb)
            {
                if (Input.GetKey(KeyCode.LeftControl))
                {
                    if (!self.dead)
                    {
                        var room = self.room;
                        var pos = self.mainBodyChunk.pos;
                        var color = self.ShortCutColor();
                        room.AddObject(new Explosion(room, self, pos, 7, 250f, 6.2f, 20f, 1000f, 0.75f, self, 0.7f, 160f, 1f));
                        room.AddObject(new Explosion.ExplosionLight(pos, 280f, 1f, 7, color));
                        room.AddObject(new Explosion.ExplosionLight(pos, 230f, 1f, 3, new Color(1f, 1f, 1f)));
                        room.AddObject(new ExplosionSpikes(room, pos, 14, 30f, 9f, 7f, 170f, color));
                        room.AddObject(new ShockWave(pos, 330f, 0.045f, 5, false));

                        room.ScreenMovement(pos, default, 1.3f);
                        room.PlaySound(SoundID.Bomb_Explode, pos);
                        room.InGameNoise(new Noise.InGameNoise(pos, 9000f, self, 1f));
                        self.room.abstractRoom.creatures[0].realizedCreature.Die();
                    }
                }
            }
        }

            private void Player_BootlegAscension(On.Player.orig_checkInput orig, Player self)
            {
                orig(self);
                if (self.SlugCatClass == MySlugcat && self.objectInStomach?.type == AbstractPhysicalObject.AbstractObjectType.ScavengerBomb)
                {
                    if (Input.GetKey(KeyCode.LeftShift))
                    {
                        var room = self.room;
                        var pos = self.mainBodyChunk.pos;
                        var color = self.ShortCutColor();
                        room.AddObject(new Explosion(room, self, pos, 7, 250f, 6.2f, 10f, 1000f, 0.25f, self, 0.7f, 160f, 1f));
                        room.AddObject(new Explosion.ExplosionLight(pos, 280f, 1f, 7, color));
                        room.AddObject(new Explosion.ExplosionLight(pos, 230f, 1f, 3, new Color(1f, 1f, 1f)));
                        room.AddObject(new ExplosionSpikes(room, pos, 14, 30f, 9f, 7f, 170f, color));
                        room.AddObject(new ShockWave(pos, 330f, 0.045f, 5, false));

                        room.ScreenMovement(pos, default, 1.3f);
                        room.PlaySound(SoundID.Bomb_Explode, pos);
                        room.InGameNoise(new Noise.InGameNoise(pos, 9000f, self, 1f));
                    }
                }
            }

            private void Player_FlyUp(On.Player.orig_checkInput orig, Player self)
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



            private void Player_FlyUpLess(On.Player.orig_checkInput orig, Player self)
            {
                orig(self);
                if (self.SlugCatClass == MySlugcat && self.objectInStomach?.type == MoreSlugcatsEnums.AbstractObjectType.SingularityBomb)
                {
                    if (Input.GetKey(KeyCode.LeftControl))
                    {
                        self.mainBodyChunk.vel.y += 10f;
                    }
                    else
                    {
                        return;
                    }
                }
            }

            /*
            private void Player_FlyUp(On.Player.orig_checkInput orig, Player self)
            {
                orig(self);
                if (self.SlugCatClass == MySlugcat && self.objectInStomach?.type == MoreSlugcatsEnums.AbstractObjectType.SingularityBomb)
                {
                    if (Input.GetKey(KeyCode.LeftAlt) && Input.GetKey(KeyCode.W))
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

            private void Player_FlyRight(On.Player.orig_checkInput orig, Player self)
            {
                orig(self);
                if (self.SlugCatClass == MySlugcat && self.objectInStomach?.type == MoreSlugcatsEnums.AbstractObjectType.SingularityBomb)
                {
                    if (Input.GetKey(KeyCode.LeftAlt) && Input.GetKey(KeyCode.D))
                    {
                        self.mainBodyChunk.vel.x += 10f;
                    }
                    else
                    {
                        return;
                    }
                }
            }

            private void Player_FlyLeft(On.Player.orig_checkInput orig, Player self)
            {
                orig(self);
                if (self.SlugCatClass == MySlugcat && self.objectInStomach?.type == MoreSlugcatsEnums.AbstractObjectType.SingularityBomb)
                {
                    if (Input.GetKey(KeyCode.LeftAlt) && Input.GetKey(KeyCode.A))
                    {
                        self.mainBodyChunk.vel.x += -10f;
                    }
                    else
                    {
                        return;
                    }
                }
            }

            private void Player_FlyDown(On.Player.orig_checkInput orig, Player self)
            {
                orig(self);
                if (self.SlugCatClass == MySlugcat && self.objectInStomach?.type == MoreSlugcatsEnums.AbstractObjectType.SingularityBomb)
                {
                    if (Input.GetKey(KeyCode.LeftAlt) && Input.GetKey(KeyCode.S))
                    {
                        self.mainBodyChunk.vel.y += -10f;
                    }
                    else
                    {
                        return;
                    }
                }
            }

            private void Player_FlyUpvelxy1(On.Player.orig_checkInput orig, Player self)
            {
                orig(self);
                if (self.SlugCatClass == MySlugcat && self.objectInStomach?.type == MoreSlugcatsEnums.AbstractObjectType.SingularityBomb)
                {
                    if (Input.GetKey(KeyCode.LeftAlt) && Input.GetKey(KeyCode.S))
                    {
                        self.mainBodyChunk.vel.y += 2f;
                    }
                    else
                    {
                        return;
                    }
                }
            }
        private void Player_FlyUpvelxy2(On.Player.orig_checkInput orig, Player self)
        {
            orig(self);
            if (self.SlugCatClass == MySlugcat && self.objectInStomach?.type == MoreSlugcatsEnums.AbstractObjectType.SingularityBomb)
            {
                if (Input.GetKey(KeyCode.LeftAlt) && Input.GetKey(KeyCode.A))
                {
                    self.mainBodyChunk.vel.y += 2f;
                }
                else
                {
                    return;
                }
            }
        }
        private void Player_FlyUpvelxy3(On.Player.orig_checkInput orig, Player self)
        {
            orig(self);
            if (self.SlugCatClass == MySlugcat && self.objectInStomach?.type == MoreSlugcatsEnums.AbstractObjectType.SingularityBomb)
            {
                if (Input.GetKey(KeyCode.LeftAlt) && Input.GetKey(KeyCode.D))
                {
                    self.mainBodyChunk.vel.y += 2f;
                }
                else
                {
                    return;
                }
            }
        }


    }
}