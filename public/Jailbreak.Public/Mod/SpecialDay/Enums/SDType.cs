using CounterStrikeSharp.API.Core;
using Microsoft.Extensions.Logging.Abstractions;

namespace Jailbreak.Public.Mod.SpecialDay.Enums;

public enum SDType
{
    GunToss,
    RockPaperScissors,
    KnifeFight,
    NoScope,
    Coinflip,
    ShotForShot,
    MagForMag,
    Race
}

public static class SDTypeExtensions
{
    public static string ToFriendlyString(this SDType type)
    {
        return type switch
        {
            SDType.GunToss => "Gun Toss",
            SDType.RockPaperScissors => "Rock Paper Scissors",
            SDType.KnifeFight => "Knife Fight",
            SDType.NoScope => "No Scope",
            SDType.Coinflip => "Coinflip",
            SDType.ShotForShot => "Shot For Shot",
            SDType.MagForMag => "Mag For Mag",
            SDType.Race => "Race",
            _ => "Unknown"
        };
    }

    public static SDType FromIndex(int index)
    {
        return (SDType)index;
    }

    public static SDType? FromString(string type)
    {
        if (Enum.TryParse<SDType>(type, true, out var result))
            return result;
        type = type.ToLower().Replace(" ", "");
        switch (type)
        {
            case "rps":
                return SDType.RockPaperScissors;
            case "s4s":
            case "sfs":
                return SDType.ShotForShot;
            case "m4m":
            case "mfm":
                return SDType.MagForMag;
        }

        if (type.Contains("knife"))
            return SDType.KnifeFight;
        if (type.Contains("scope"))
            return SDType.NoScope;
        if (type.Contains("gun"))
            return SDType.GunToss;
        if (type.Contains("coin") || type.Contains("fifty"))
            return SDType.Coinflip;
        return null;
    }
}