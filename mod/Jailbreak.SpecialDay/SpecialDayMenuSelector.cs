using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Entities;
using CounterStrikeSharp.API.Modules.Menu;
using Jailbreak.Public.Mod.SpecialDay;
using Jailbreak.Public.Mod.SpecialDay.Enums;

namespace Jailbreak.SpecialDay;

public class SpecialDayMenuSelector
{
    private readonly CenterHtmlMenu _menu;
    private readonly Func<SDType, string> _command;

    public SpecialDayMenuSelector(ISpecialDayFactory factory) : this(factory, (lr) => "css_sd " + ((int)lr))
    {
    }

    public SpecialDayMenuSelector(ISpecialDayFactory factory, Func<SDType, string> command)
    {
        _command = command;
        _menu = new CenterHtmlMenu("css_lr [LR] [Player]");
        foreach (SDType lr in Enum.GetValues(typeof(SDType)))
        {
            if (!factory.IsValidType(lr))
                continue;
            _menu.AddMenuOption(lr.ToFriendlyString(), (p, o) => OnSelectLR(p, lr));
        }
    }

    public CenterHtmlMenu GetMenu()
    {
        return _menu;
    }

    private void OnSelectLR(CCSPlayerController player, SDType lr)
    {
        MenuManager.CloseActiveMenu(player);
        player.ExecuteClientCommandFromServer(this._command.Invoke(lr));
    }
}