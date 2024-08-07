﻿using CounterStrikeSharp.API.Modules.Utils;
using Jailbreak.Formatting.Base;
using Jailbreak.Formatting.Logistics;
using Jailbreak.Formatting.Views;
using Jailbreak.Formatting.Core;
using Jailbreak.Formatting.Objects;

namespace Jailbreak.English.LastGuard;

public class LastGuardNotifications : ILastGuardNotifications, ILanguage<Formatting.Languages.English>
{
    public static FormatObject PREFIX =
        new HiddenFormatObject($" {ChatColors.DarkRed}[{ChatColors.LightRed}Last Guard{ChatColors.DarkRed}]")
        {
            //	Hide in panorama and center text
            Plain = false,
            Panorama = false,
            Chat = true
        };

    public IView LG_STARTED(int ctHealth, int tHealth)
    {
        return new SimpleView()
        {
            PREFIX,
            $"{ChatColors.Red}Last Guard has been activated! Last guard has", ctHealth,
            $"{ChatColors.Red}health and Ts have", tHealth, $"{ChatColors.Red}health."
        };
    }
}