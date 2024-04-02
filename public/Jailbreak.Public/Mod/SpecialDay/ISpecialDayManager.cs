using CounterStrikeSharp.API.Core;
using Jailbreak.Public.Behaviors;
using Jailbreak.Public.Mod.SpecialDay.Enums;

namespace Jailbreak.Public.Mod.SpecialDay;

public interface ISpecialDayManager : IPluginBehavior
{
    public bool IsSDEnabled { get; set; }
    public IList<AbstractSpecialDay> ActiveSDs { get; }

    bool InitiateSpecialDay(CCSPlayerController prisoner, CCSPlayerController guard, SDType lrType);
    bool EndSpecialDay(AbstractSpecialDay lr, SDResult result);

    public bool IsInSD(CCSPlayerController player)
    {
        return GetActiveSD(player) != null;
    }

    public AbstractSpecialDay? GetActiveSD(CCSPlayerController player)
    {
        return ActiveSDs.FirstOrDefault(lr => lr.guard.Slot == player.Slot || lr.prisoner.Slot == player.Slot);
    }
}