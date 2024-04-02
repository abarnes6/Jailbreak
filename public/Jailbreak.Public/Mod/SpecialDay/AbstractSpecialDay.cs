using CounterStrikeSharp.API.Core;
using Jailbreak.Public.Mod.SpecialDay.Enums;

namespace Jailbreak.Public.Mod.SpecialDay;

public abstract class AbstractSpecialDay(
    BasePlugin plugin,
    ISpecialDayManager manager,
    CCSPlayerController prisoner,
    CCSPlayerController guard)
{
    public CCSPlayerController prisoner { get; protected set; } = prisoner;
    public CCSPlayerController guard { get; protected set; } = guard;
    public abstract SDType type { get; }

    public SDState state { get; protected set; }
    protected BasePlugin plugin = plugin;
    protected ISpecialDayManager manager = manager;

    public void PrintToParticipants(string message)
    {
        prisoner.PrintToChat(message);
        guard.PrintToChat(message);
    }

    public abstract void Setup();
    public abstract void Execute();
    public abstract void OnEnd(SDResult result);
}