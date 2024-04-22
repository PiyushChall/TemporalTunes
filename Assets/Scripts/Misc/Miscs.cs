using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Misc
{
    public static class Paths
    {
        public const string SettingsPath = "SavedData/settings.json";
        public const string SavePath = "SavedData/save/";
        public static readonly string DataPath = "SaveData/";
    }
    public static class Constants
    {
        public const string StartScene = "TestScene";
        public const string AudioRoot = "Audio/";
        public const float BG_SoundTransitionInterval = 2;
        public static readonly Dictionary<KeyCode, Note> notesKeys = new(){
            { KeyCode.DownArrow, Note.D },
            { KeyCode.UpArrow, Note.U },
            { KeyCode.RightArrow, Note.R },
            { KeyCode.LeftArrow, Note.L },
        };

        public static readonly Dictionary<char, float> notesPitch = new(){
            { 'd', 1.2f },
            { 'u', 1.6f },
            { 'r', 1.4f },
            { 'l', 1f },
        };
    }

    //Delegates
    public delegate bool Condition();
}