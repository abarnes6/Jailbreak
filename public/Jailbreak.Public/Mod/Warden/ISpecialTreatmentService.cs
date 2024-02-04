using CounterStrikeSharp.API.Core;

namespace Jailbreak.Public.Mod.Warden;

public interface ISpecialTreatmentService
{
     bool IsSpecialTreatment(CCSPlayerController? player);
     void SetSpecialTreatment(CCSPlayerController? player, bool value);
}