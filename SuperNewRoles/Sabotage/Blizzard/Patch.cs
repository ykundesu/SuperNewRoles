﻿using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperNewRoles.Sabotage.Blizzard
{
    public static class SlowSpeed
    {
        public static ProgressTracker Instance;
        [HarmonyPatch(typeof(ProgressTracker),nameof(ProgressTracker.FixedUpdate))]
        class TaskBarPatch
        {
            public static void Postfix(ProgressTracker __instance)
            {
                Instance = __instance;
                if (PlayerControl.GameOptions.TaskBarMode != TaskBarMode.Invisible)
                {
                    if (SabotageManager.thisSabotage == SabotageManager.CustomSabotage.CognitiveDeficit)
                    {
                        __instance.gameObject.SetActive(main.IsLocalEnd);
                    }
                }
            }
        }
        //ここにスピード関連を書こう
    }
}