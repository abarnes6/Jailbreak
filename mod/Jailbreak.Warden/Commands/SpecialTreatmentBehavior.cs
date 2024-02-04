using System.Reflection;
using CounterStrikeSharp.API.Core;
using Jailbreak.Public.Behaviors;
using Jailbreak.Public.Mod.Warden;

namespace Jailbreak.Warden.Commands;

public class SpecialTreatmentBehavior : IPluginBehavior, ISpecialTreatmentService
{
    private ISet<CCSPlayerController> _sts = new HashSet<CCSPlayerController>();

    public void Start(BasePlugin parent)
    {
        parent.RegisterEventHandler<EventPlayerDisconnect>(OnPlayerDisconnect); 
    }

    HookResult OnPlayerDisconnect(CCSPlayerController player, GameEventInfo info)
    {
        if(!player.IsValid)
            return HookResult.Continue;
        
        return HookResult.Continue;
    }

    public bool IsSpecialTreatment(CCSPlayerController? player)
    {
        throw new NotImplementedException();
    }

    public void SetSpecialTreatment(CCSPlayerController? player, bool value)
    {
        throw new NotImplementedException();
    }
}