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
    public class PlayerExplode
    {
        static SlugcatStats.Name MySlugcat = new SlugcatStats.Name("Unknown");

        public static void OnEnable()
        {
            On.Player.checkInput += Player_BootlegAscension;
            On.Player.Die += Player_SelfDestruct;
        }

        private static void Player_SelfDestruct(On.Player.orig_Die orig, Player self)
        {

            orig(self);

            bool wasDead = self.dead;

            if (self.SlugCatClass == MySlugcat && self.objectInStomach?.type == AbstractPhysicalObject.AbstractObjectType.ScavengerBomb)
            {
                if (Input.GetKey(KeyCode.LeftControl))
                {
                    if (!wasDead)
                    {
                        if (!self.dead)
                        {
                            self.Die();
                        }
                    }
                }
            }

            if (self.SlugCatClass == MySlugcat && self.objectInStomach?.type == AbstractPhysicalObject.AbstractObjectType.ScavengerBomb)
            {
                if (wasDead)
                {
                    if (self.dead)
                    {
                        // Adapted from ScavengerBomb.Explode
                        var room = self.room;
                        var pos = self.mainBodyChunk.pos;
                        var color = self.ShortCutColor();
                        room.AddObject(new Explosion(room, self, pos, 7, 250f, 6.2f, 100f, 42f, 0.75f, self, 0.7f, 160f, 1f));
                        room.AddObject(new Explosion.ExplosionLight(pos, 280f, 1f, 7, color));
                        room.AddObject(new Explosion.ExplosionLight(pos, 230f, 1f, 3, new Color(1f, 1f, 1f)));
                        room.AddObject(new ExplosionSpikes(room, pos, 14, 30f, 9f, 7f, 170f, color));
                        room.AddObject(new ShockWave(pos, 660f, 0.45f, 7, false));

                        room.ScreenMovement(pos, default, 1.3f);
                        room.PlaySound(SoundID.Bomb_Explode, pos);
                        room.InGameNoise(new Noise.InGameNoise(pos, 9000f, self, 1f));
                        self.objectInStomach.realizedObject.RemoveFromRoom();
                    }
                }
            }
        }

        private static void Player_BootlegAscension(On.Player.orig_checkInput orig, Player self)
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

    }
}