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
    public class PlayerAutoParry
    {
        static SlugcatStats.Name MySlugcat = new SlugcatStats.Name("Unknown");

        public static void OnEnable()
        {
            On.Player.Update += Player_AutoParry;
        }

        private static void Player_AutoParry(On.Player.orig_Update orig, Player self, bool eu)
        {
            orig(self, eu);
            if(self.SlugCatClass == MySlugcat && self.objectInStomach?.type == AbstractPhysicalObject.AbstractObjectType.Rock)
            {
                foreach (var grasp in self.grabbedBy)
                {
                    grasp.grabber.Stun(2);
                }
            }

        }

    }
}
