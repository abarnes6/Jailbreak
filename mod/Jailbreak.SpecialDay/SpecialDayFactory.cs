using CounterStrikeSharp.API.Core;
using Jailbreak.SpecialDay.SpecialDays;
using Jailbreak.Public.Mod.SpecialDay;
using Jailbreak.Public.Mod.SpecialDay.Enums;

namespace Jailbreak.SpecialDay;

public class SpecialDayFactory(ISpecialDayManager manager) : ISpecialDayFactory
{
    private BasePlugin _plugin;

    public void Start(BasePlugin parent)
    {
        _plugin = parent;
    }

    public AbstractSpecialDay CreateSpecialDay(CCSPlayerController prisoner, CCSPlayerController guard, LRType type)
    {
        return type switch
        {
            //LRType.KnifeFight => new KnifeFight(_plugin, manager, prisoner, guard),
            //LRType.GunToss => new GunToss(_plugin, manager, prisoner, guard),
            //LRType.NoScope => new NoScope(_plugin, manager, prisoner, guard),
            //LRType.RockPaperScissors => new RockPaperScissors(_plugin, manager, prisoner, guard),
            //LRType.Coinflip => new Coinflip(_plugin, manager, prisoner, guard),
            _ => throw new ArgumentException("Invalid last request type: " + type, nameof(type))
        };
    }

    public bool IsValidType(LRType type)
    {
        return type switch
        {
            LRType.KnifeFight => true,
            LRType.GunToss => true,
            LRType.NoScope => true,
            LRType.RockPaperScissors => true,
            LRType.Coinflip => true,
            _ => false
        };
    }
}