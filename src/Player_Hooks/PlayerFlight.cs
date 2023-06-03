using MoreSlugcats;
using Noise;
using On;
using RWCustom;
using BepInEx.Logging;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using IL;
using UnityEngine;
//using static UnityEngine.Input;

namespace NuclearPasta.TheUnknown.Player_Hooks
{
    public class PlayerFlight
    {
        static SlugcatStats.Name MySlugcat = new SlugcatStats.Name("Unknown");

        public void OnEnable()
        {
            On.Player.checkInput += Player_FlyUp;
            On.Player.checkInput += Player_FlyUpLess;
            //On.Player.checkInput += Player_FlyUp;
            On.Player.checkInput += Player_FlyRight;
            On.Player.checkInput += Player_FlyLeft;
            On.Player.checkInput += Player_FlyDown;
            On.Player.checkInput += Player_FlyUpvelxy1;
            On.Player.checkInput += Player_FlyUpvelxy2;
            On.Player.checkInput += Player_FlyUpvelxy3;
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