﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticleOverdrive.Misc
{
    static class Config
    {
        static BS_Utils.Utilities.Config config;

        static readonly string configName = "ParticleOverdrive";
        static readonly string sectionParticles = "Particles";

        internal static void Init()
        {
            config = new BS_Utils.Utilities.Config(configName);
        }

        static readonly string slashParticleMultiplier = "SlashParticleMultiplier";
        internal static float SlashParticleMultiplier
        {
            get
            {
                return config.GetFloat(sectionParticles, slashParticleMultiplier, 1.0f, true);
            }
            set
            {
                config.SetFloat(sectionParticles, slashParticleMultiplier, value);
            }
        }

        static readonly string slashParticleLifetimeMultiplier = "SlashParticleLifetimeMultiplier";
        internal static float SlashParticleLifetimeMultiplier
        {
            get
            {
                return config.GetFloat(sectionParticles, slashParticleLifetimeMultiplier, 1.0f, true);
            }
            set
            {
                config.SetFloat(sectionParticles, slashParticleLifetimeMultiplier, value);
            }
        }

        static readonly string explosionParticleMultiplier = "ExplosionParticleMultiplier";
        internal static float ExplosionParticleMultiplier
        {
            get
            {
                return config.GetFloat(sectionParticles, explosionParticleMultiplier, 1.0f, true);
            }
            set
            {
                config.SetFloat(sectionParticles, explosionParticleMultiplier, value);
            }
        }

        static readonly string explosionParticleLifetimeMultiplier = "ExplosionParticleLifetimeMultiplier";
        internal static float ExplosionParticleLifetimeMultiplier
        {
            get
            {
                return config.GetFloat(sectionParticles, explosionParticleLifetimeMultiplier, 1.0f, true);
            }
            set
            {
                config.SetFloat(sectionParticles, explosionParticleLifetimeMultiplier, value);
            }
        }

        static readonly string rainbowParticles = "RainbowParticles";
        internal static bool RainbowParticles
        {
            get
            {
                return config.GetBool(sectionParticles, rainbowParticles, false, true);
            }
            set
            {
                config.SetBool(sectionParticles, rainbowParticles, value);
            }
        }

        static readonly string dustParticles = "DustParticles";
        internal static bool DustParticles
        {
            get
            {
                return config.GetBool(sectionParticles, dustParticles, true, true);
            }
            set
            {
                config.SetBool(sectionParticles, dustParticles, value);
            }
        }

        static readonly string cameraGrain = "CameraGrain";
        internal static bool CameraGrain
        {
            get
            {
                return config.GetBool(sectionParticles, cameraGrain, true, true);
            }
            set
            {
                config.SetBool(sectionParticles, cameraGrain, value);
            }
        }
    }
}
