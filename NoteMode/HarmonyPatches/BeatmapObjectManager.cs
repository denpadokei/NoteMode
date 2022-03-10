﻿using HarmonyLib;
using NoteMode.Configuration;
using System.Reflection;

namespace NoteMode.HarmonyPatches
{
    [HarmonyPatch(typeof(BasicBeatmapObjectManager), "ProcessNoteData")]
    public class BasicBeatmapObjectManagerProcessNoteData
    {
        static bool Prefix(ref NoteData noteData)
        {
            if ((noteData.colorType == ColorType.ColorA) && PluginConfig.Instance.noRed)
            {
                return false;
            }
            else if ((noteData.colorType == ColorType.ColorB) && PluginConfig.Instance.noBlue)
            {
                return false;
            }

            if (PluginConfig.Instance.noNotesBomb)
            {
                return false;
            }
            return true;
        }
    }

    [HarmonyPatch(typeof(BasicBeatmapObjectManager), "ProcessObstacleData")]
    public class BasicBeatmapOjbectManagerProcessObstacleData
    {
        static bool Prefix(ref ObstacleData obstacleData, ref BeatmapObjectSpawnMovementData.ObstacleSpawnData obstacleSpawnData)
        {
            if (PluginConfig.Instance.noNotesBomb)
            {
                return false;
            }
            return true;
        }
    }

    [HarmonyPatch(typeof(BasicBeatmapObjectManager), "ProcessSliderData")]
    public class BasicBeatmapOjbectManagerProcessSliderData
    {
        static bool Prefix(ref SliderData sliderData)
        {
            if ((sliderData.colorType == ColorType.ColorA) && PluginConfig.Instance.noRed)
            {
                return false;
            }
            else if ((sliderData.colorType == ColorType.ColorB) && PluginConfig.Instance.noBlue)
            {
                return false;
            }

            if (PluginConfig.Instance.noNotesBomb)
            {
                return false;
            }
            return true;
        }
    }
}