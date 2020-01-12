using System;
using System.Linq;
using Harmony;
using UnityEngine;
using ParticleOverdrive.Misc;
using BS_Utils.Utilities;
using System.Reflection.Emit;
using System.Reflection;

namespace ParticleOverdrive.Patches
{
    [HarmonyPatch(typeof(NoteCutParticlesEffect))]
    [HarmonyPatch("SpawnParticles")]
    class NoteCutParticlesEffectSpawnParticles
    {
        internal static void Prefix(ref NoteCutParticlesEffect __instance, ref Color32 color, ref int sparkleParticlesCount, ref int explosionParticlesCount, ref float lifetimeMultiplier)
        {
            ParticleSystem explosionPS = Plugin.GetExplosionPS(__instance);
            ParticleSystem[] sparklesPSAry = Plugin.GetSparklesPS(__instance);
            ParticleSystem.EmitParams[] sparklesEmitParamsAry = Plugin.GetSparklesEmitParams(__instance);
            PrintEmitParams(__instance, "sparklesEmitParamsAry[0]", ref sparklesEmitParamsAry[0]);
            sparkleParticlesCount = Mathf.FloorToInt(sparkleParticlesCount * Plugin.SlashParticleMultiplier);
            explosionParticlesCount = Mathf.FloorToInt(explosionParticlesCount * Plugin.ExplosionParticleMultiplier);
            lifetimeMultiplier *= Plugin.SlashParticleLifetimeMultiplier;
            if (Plugin.RainbowParticles)
                color = UnityEngine.Random.ColorHSV();
            ParticleSystem.MainModule slashMain = sparklesPSAry[0].main;
            slashMain.maxParticles = int.MaxValue;
            ParticleSystem.MainModule explosionMain = explosionPS.main;
            //explosionMain.gravityModifier = new ParticleSystem.MinMaxCurve(1f, 9f);
            foreach (var sparkles in sparklesPSAry)
            {
                var thing = sparkles.colorOverLifetime;
                thing.enabled = true;
                thing.color = new ParticleSystem.MinMaxGradient(GenerateGradient(color));
            }
            PrintEmitParams(__instance, "explosionEmitParams", ref Plugin.GetExplosionEmitParams(__instance));
            //Plugin.GetExplosionEmitParams(__instance).startSize3D = new Vector3(1f, .1f, 1f);
            //Plugin.GetExplosionEmitParams(__instance).angularVelocity = 180f;
            explosionMain.maxParticles = int.MaxValue;
            explosionMain.startLifetimeMultiplier = Plugin.ExplosionParticleLifetimeMultiplier;
        }

        private static Gradient GenerateGradient(Color32 startingColor)
        {
            return new Gradient()
            {
                mode = GradientMode.Blend,
                colorKeys = new GradientColorKey[4]
                    {
                        new GradientColorKey((Color)startingColor, 0.0f),
                        new GradientColorKey(UnityEngine.Random.ColorHSV(), 0.2f),
                        new GradientColorKey(UnityEngine.Random.ColorHSV(), 0.6f),
                        new GradientColorKey(UnityEngine.Random.ColorHSV(), 1f)
                    }
            };
        }


        private static void PrintEmitParams(NoteCutParticlesEffect __instance, string name, ref ParticleSystem.EmitParams e)
        {

            ParticleSystem explosionPS = Plugin.GetExplosionPS(__instance);
            Plugin.log.Info($"{explosionPS.colorOverLifetime.enabled}, {explosionPS.colorOverLifetime.color.color}");
            Plugin.log.Info($"{name}'s EmitParams:");
            Plugin.log.Info($"  {nameof(e.angularVelocity)}: {e.angularVelocity}");
            Plugin.log.Info($"  {nameof(e.angularVelocity3D)}: {e.angularVelocity3D}");
            Plugin.log.Info($"  {nameof(e.applyShapeToPosition)}: {e.applyShapeToPosition}");
            Plugin.log.Info($"  {nameof(e.axisOfRotation)}: {e.axisOfRotation}");
            Plugin.log.Info($"  {nameof(e.position)}: {e.position}");
            Plugin.log.Info($"  {nameof(e.rotation)}: {e.rotation}");
            Plugin.log.Info($"  {nameof(e.rotation3D)}: {e.rotation3D}");
            Plugin.log.Info($"  {nameof(e.startColor)}: {e.startColor}");
            Plugin.log.Info($"  {nameof(e.startLifetime)}: {e.startLifetime}");
            Plugin.log.Info($"  {nameof(e.startSize)}: {e.startSize}");
            Plugin.log.Info($"  {nameof(e.startSize3D)}: {e.startSize3D}");
            Plugin.log.Info($"  {nameof(e.velocity)}: {e.velocity}");
        }
    }
}
