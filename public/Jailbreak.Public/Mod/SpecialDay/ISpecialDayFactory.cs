using CounterStrikeSharp.API.Core;
using Jailbreak.Public.Behaviors;
using Jailbreak.Public.Mod.SpecialDay.Enums;

namespace Jailbreak.Public.Mod.SpecialDay;

public interface ISpecialDayFactory : IPluginBehavior
{
    AbstractSpecialDay CreateSpecialDay(CCSPlayerController prisoner, CCSPlayerController guard, SDType type);
    bool IsValidType(SDType type);
}