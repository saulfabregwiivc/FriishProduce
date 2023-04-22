# FriishProduce
**FriishProduce** is a channel injector for (v)Wii, which allows for ROM replacement and customization in Virtual Console WADs.
This application is designed to streamline the process to as few third-party programs as possible.

***The project and readme are currently under work-in-progress and will be updated over the course of time.***

## Minimum specifications
* OS: **Windows 7 or newer**
* .NET Frameworks:
  * **.NET 2.0** (needed for libWiiSharp)
  * **.NET 4.7.2** (needed for ccf-tools)
* Required by HowardC Tools:
  * **ActiveX Control Pad** [[Download](http://download.microsoft.com/download/activexcontrolpad/install/4.0.0.950/win98mexp/en-us/setuppad.exe) and run in Windows XP (SP3) compatibility mode]
  * **comdlg32.ocx**, **comctl32.ocx** and **mscomctl.ocx** [Download and register these files using Regsvr32]

## Wiki
Please see the [Wiki](https://github.com/CatmanFan/FriishProduce/wiki/Setup) for instructions on setup and usage.

## Credits
I would like to thank the following people, without whom this project would not have been possible:

* **Leathl** for the libWiiSharp library, and **[WiiDatabase](https://github.com/WiiDatabase)**/**[Larsenv](https://github.com/larsenv)** for the [fork used here](https://github.com/WiiDatabase/libWiiSharp/).
* **[libertyernie](https://github.com/libertyernie)** for forking [ccf-tools](https://github.com/libertyernie/ccf-tools) (original: **paulguy**) and [BrawlLib](https://github.com/libertyernie/brawllib-wit) (original: **soopercool101**).
* **[SuperrSonic](https://github.com/SuperrSonic)** for reverse-engineering much of Wii software and official emulator code, and in particular, his [fork of RetroArch Wii](https://github.com/SuperrSonic/RA-SS).
* **HowardC** for his tools (particularly, VCbrlyt).
* **alpha-0** for WWCXTool.
* **[Alcaro](https://github.com/Alcaro)** for [Floating IPS](https://github.com/Alcaro/Flips) (Flips).
* **Jurai** for developing the ROMC compressor (additionally with **Haruhiko Okumura**'s LZSS code)
* **[SaulFabre](https://github.com/saulfabregwiivc)** for archiving several tools and aiding in research.

This application is distributed and licensed under the **GNU General Public License v3.0** ([view in full](https://github.com/CatmanFan/FriishProduce/blob/main/LICENSE)).