using CounterStrikeSharp.API.Core;
using Jailbreak.Formatting.Base;
using Jailbreak.Public.Mod.SpecialDay;
using Jailbreak.Public.Mod.SpecialDay.Enums;

namespace Jailbreak.Formatting.Views;

public interface ISpecialDayMessages
{
    public IView SpecialDayEnabled();
    public IView SpecialDayDisabled();
    public IView SpecialDayNotEnabled();
    public IView InvalidSpecialDay(string query);
    public IView InvalidPlayerChoice(CCSPlayerController player, string reason);
    public IView InformSpecialDay(AbstractSpecialDay lr);
    public IView AnnounceSpecialDay(AbstractSpecialDay lr);
    public IView SpecialDayDecided(AbstractSpecialDay lr, SDResult result);
}