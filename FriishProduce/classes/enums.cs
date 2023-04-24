﻿using System.Collections.Generic;

namespace FriishProduce
{
    public enum Platforms
    {
        nes = 0,
        snes = 1,
        n64 = 2,
        sms = 3,
        smd = 4,
        pce = 5,
        neogeo = 6,
        c64 = 7,
        msx = 8,
        flash = 9,
    }

    public enum InjectionMethod
    {
        VC = 0,
        FCEGX = 1,
        Snes9xGX = 2,
        VBAGX = 3,
        GenPlusGX = 4,
        LibRetro = 5
    }

    /// <summary>
    /// The language used by the UI. Currently supported are added automatically
    /// </summary>
    public class Languages
    {
        readonly Dictionary<string, string> list;
        public Languages()
        {
            list = new Dictionary<string, string>
            {
                { "[System]", "sys" },
                { "English", "en" },
                { "français", "fr" }
            };
        }

        public Dictionary<string, string> Get() => list;
    }
}
