using CounterStrikeSharp.API.Modules.Utils;
using Jailbreak.Formatting.Base;
using Jailbreak.Formatting.Views;

namespace Jailbreak.English.SpecialDay;

public class HNSInstanceMessages() : TeamDayMessages("Hide and Seek") {
  public IView SpecialDayStart
    => new SimpleView {
      {
        ISpecialDayMessages.PREFIX, Name,
        "has begun! Prisoners must hide and CTs must seek!"
      },
      SimpleView.NEWLINE,
      { ISpecialDayMessages.PREFIX, "CTs have 250 HP!" }
    };

  public IView StayInArmory
    => new SimpleView {
      ISpecialDayMessages.PREFIX, "Today is", Name, ", stay in the armory!"
    };

  public IView ReadyOrNot
    => new SimpleView {
      ISpecialDayMessages.PREFIX, "Ready or not, here they come!",
    };
}