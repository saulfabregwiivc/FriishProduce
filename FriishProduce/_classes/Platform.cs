﻿namespace FriishProduce
{
    public enum Platform
    {
        NES,
        SNES,
        N64,
        SMS,
        SMD,
        PCE,
        PCECD,
        NEO,
        MSX,
        C64,
        Flash,
        GB,
        GBC,
        GBA,
        GCN,
        S32X,
        SMCD,
        PSX,
        RPGM,
    }

    public static class Platforms
    {
        public static System.Collections.Generic.Dictionary<Platform, System.Drawing.Bitmap> Icons
        {
            get
            {
                System.Collections.Generic.Dictionary<Platform, System.Drawing.Icon> orig = new()
                {
                    {
                        Platform.NES,
                        Program.Lang.GetRegion() is Language.Region.Japan
                        ? FileDatas.Icons.FC : FileDatas.Icons.NES
                    },

                    {
                        Platform.SNES,
                        Program.Lang.GetRegion() is Language.Region.Americas or Language.Region.International
                        ? FileDatas.Icons.SNES : FileDatas.Icons.SFC
                    },

                    {
                        Platform.N64,
                        FileDatas.Icons.N64
                    },

                    {
                        Platform.SMS,
                        FileDatas.Icons.SMS
                    },

                    {
                        Platform.SMD,
                        FileDatas.Icons.SMD
                    },

                    {
                        Platform.PCE,
                        Program.Lang.GetRegion() is Language.Region.Japan
                        ? FileDatas.Icons.PCE : FileDatas.Icons.TG16
                    },

                    {
                        Platform.PCECD,
                        Program.Lang.GetRegion() is Language.Region.Japan
                        ? FileDatas.Icons.PCECD : FileDatas.Icons.TG16
                    },

                    {
                        Platform.NEO,
                        FileDatas.Icons.NEO
                    },

                    {
                        Platform.C64,
                        System.Drawing.Icon.FromHandle(Properties.Resources.flash.GetHicon())
                    },

                    {
                        Platform.MSX,
                        System.Drawing.Icon.FromHandle(Properties.Resources.c64.GetHicon())
                    },

                    {
                        Platform.Flash,
                        System.Drawing.Icon.FromHandle(Properties.Resources.msx.GetHicon())
                    },

                    {
                        Platform.PSX,
                        FileDatas.Icons.PSX
                    },

                    {
                        Platform.RPGM,
                        Properties.Resources.rpg2003
                    }
                };

                System.Collections.Generic.Dictionary<Platform, System.Drawing.Bitmap> resized = new();

                foreach (var item in orig)
                {
                    if (item.Key is Platform.RPGM)
                        resized.Add(item.Key, new System.Drawing.Icon(item.Value, 16, 16).ToBitmap());
                    else
                    {
                        System.Drawing.Bitmap b = new(16, 16);
                        using System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(b);
                        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                        g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
                        g.DrawImage(item.Value.ToBitmap(), 0, 0, 16, 16);
                        resized.Add(item.Key, b);
                    }
                };

                return resized;
            }
        }

        public static System.Collections.Generic.Dictionary<Platform?, string[]> Filters
        {
            get => new()
            {
                { Platform.NES, new string[] { ".nes" } },
                { Platform.SNES, new string[] { ".sfc", ".smc" } },
                { Platform.N64, new string[] { ".n64", ".v64", ".z64" } },
                { Platform.SMS, new string[] { ".sms" } },
                { Platform.S32X, new string[] { ".bin", ".gen", ".md" } },
                { Platform.SMD, new string[] { ".bin", ".gen", ".md" } },
                { Platform.PCE, new string[] { ".pce" } },
                { Platform.NEO, new string[] { ".zip" } },
                { Platform.MSX, new string[] { ".rom", ".mx1", ".mx2" } },
                { Platform.C64, new string[] { ".d64", /* ".t64" */ } },
                { Platform.GB, new string[] { ".gb" } },
                { Platform.GBC, new string[] { ".gbc" } },
                { Platform.GBA, new string[] { ".gba" } },
            };
        }
    }

    public enum Buttons
    {
        WiiRemote_Up,
        WiiRemote_Left,
        WiiRemote_Right,
        WiiRemote_Down,
        WiiRemote_A,
        WiiRemote_B,
        WiiRemote_1,
        WiiRemote_2,
        WiiRemote_Plus,
        WiiRemote_Minus,
        WiiRemote_Home,
        Nunchuck_Z,
        Nunchuck_C,
        Classic_Up,
        Classic_Left,
        Classic_Right,
        Classic_Down,
        Classic_A,
        Classic_B,
        Classic_X,
        Classic_Y,
        Classic_L,
        Classic_R,
        Classic_ZL,
        Classic_ZR,
        Classic_Plus,
        Classic_Minus,
        Classic_Home,
        Classic_Reserved,
        GC_Up,
        GC_Left,
        GC_Right,
        GC_Down,
        GC_A,
        GC_B,
        GC_X,
        GC_Y,
        GC_L,
        GC_R,
        GC_Z,
        GC_Start
    };
}
