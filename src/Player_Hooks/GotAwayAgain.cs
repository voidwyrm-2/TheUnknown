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
    public class GotAwayAgain
    {
        static SlugcatStats.Name MySlugcat = new SlugcatStats.Name("Unknown");

        public static void OnEnable()
        {
            //On.Player.Die += Player_ThrownSpear;
        }
        /*
        private static void Player_ThrownSpear(On.Player.orig_Die orig, Player self)
        {
            orig(self);
            if(self.SlugCatClass == MySlugcat && self.dead)
            {
                var room = self.room;
                var pos = self.mainBodyChunk.pos;
                var color = self.ShortCutColor();
                room.AddObject(new Explosion(room, self, pos, 7, 10f, 50f, 100f, 10f, 0.75f, self, 0.7f, 160f, 1f));
                room.AddObject(new Explosion.ExplosionLight(pos, 280f, 1f, 7, color));
                room.AddObject(new Explosion.ExplosionLight(pos, 230f, 1f, 3, new Color(1f, 1f, 1f)));
                room.AddObject(new ExplosionSpikes(room, pos, 14, 30f, 9f, 7f, 170f, color));
                room.AddObject(new ShockWave(pos, 660f, 0.45f, 7, false));

                room.ScreenMovement(pos, default, 1.3f);
                room.PlaySound(SoundID.Bomb_Explode, pos);
                room.InGameNoise(new Noise.InGameNoise(pos, 9000f, self, 1f));
                self.Destroy();
            }
        }
        */

    }
}
