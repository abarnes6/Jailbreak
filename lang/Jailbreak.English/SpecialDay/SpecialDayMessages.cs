using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Utils;
using Jailbreak.Formatting.Base;
using Jailbreak.Formatting.Core;
using Jailbreak.Formatting.Logistics;
using Jailbreak.Formatting.Objects;
using Jailbreak.Formatting.Views;
using Jailbreak.Public.Mod.SpecialDay;
using Jailbreak.Public.Mod.SpecialDay.Enums;

namespace Jailbreak.English.SpecialDay;

public class SpecialDayMessages : ISpecialDayMessages, ILanguage<Formatting.Languages.English>
{
    public static FormatObject PREFIX =
        new HiddenFormatObject($" {ChatColors.DarkRed}[{ChatColors.LightRed}SD{ChatColors.DarkRed}]")
        {
            //	Hide in panorama and center text
            Plain = false,
            Panorama = false,
            Chat = true
        };

    public IView SpecialDayEnabled() => new SimpleView()
    {
        { PREFIX, "Special Day has been enabled. Type !lr to start a last request." }
    };

    public IView SpecialDayDisabled() => new SimpleView()
    {
        { PREFIX, "Special Day has been disabled." }
    };

    public IView SpecialDayNotEnabled() => new SimpleView()
    {
        { PREFIX, "Special Day is not enabled." }
    };

    public IView InvalidSpecialDay(string query)
    {
        return new SimpleView()
        {
            PREFIX,
            "Invalid Special Day: ",
            query
        };
    }

    public IView InvalidPlayerChoice(CCSPlayerController player, string reason)
    {
        return new SimpleView()
        {
            PREFIX,
            "Invalid player choice: ",
            player,
            " Reason: ",
            reason
        };
    }

    public IView InformSpecialDay(AbstractSpecialDay lr)
    {
        return new SimpleView()
        {
            PREFIX,
            lr.prisoner, "is preparing a", lr.type.ToFriendlyString(),
            "Special Day against", lr.guard
        };
    }

    public IView AnnounceSpecialDay(AbstractSpecialDay lr)
    {
        return new SimpleView()
        {
            PREFIX,
            lr.prisoner, "is doing a", lr.type.ToFriendlyString(),
            "Special Day against", lr.guard
        };
    }

    public IView SpecialDayDecided(AbstractSpecialDay lr, SDResult result)
    {
        return new SimpleView()
        {
            PREFIX,
            result == SDResult.PrisonerWin ? lr.prisoner : lr.guard, "won the SD."
        };
    }
}