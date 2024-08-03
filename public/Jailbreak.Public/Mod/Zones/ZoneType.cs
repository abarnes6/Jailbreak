using System.Drawing;

namespace Jailbreak.Public.Mod.Zones;

public enum ZoneType {
  /// <summary>
  ///   This zone captures the armory or places that CTs should otherwise not camp
  /// </summary>
  ARMORY,

  /// <summary>
  ///   This zone captures the cell areas
  /// </summary>
  CELL,

  /// <summary>
  ///   This zone is a single point, and represents the cell button
  /// </summary>
  CELL_BUTTON,

  /// <summary>
  ///   This zone captures a secret area that Ts may try to access
  /// </summary>
  SECRET,

  /// <summary>
  ///   This zone grants health
  /// </summary>
  HEALTH,

  /// <summary>
  ///   This zone is a game such as climb, spleef, etc.
  /// </summary>
  GAME,

  /// <summary>
  ///   This zone supports many games, but is not a game-specific zone
  ///   e.g. playground, soccer field, etc.
  /// </summary>
  PLAYFIELD,

  /// <summary>
  ///   This zone is a single point, and represents a good spawn location
  /// </summary>
  SPAWN,

  /// <summary>
  ///   Similar to SPAWN, but this spawn location was automatically
  /// generated
  /// </summary>
  SPAWN_AUTO,

  /// <summary>
  ///   This zone represents an area on the map that only Ts can access
  /// </summary>
  ZONE_LIMIT_T,

  /// <summary>
  ///   This zone represents an area on the map that only CTs can access
  /// </summary>
  ZONE_LIMIT_CT,

  /// <summary>
  ///   This zone is a single point, and represents
  ///   the center of the map (both vertically and horizontally)
  /// </summary>
  CENTER
}

public static class ZoneTypeExtensions {
  public static Color GetColor(this ZoneType type) {
    return type switch {
      ZoneType.ARMORY        => Color.Blue,
      ZoneType.CELL          => Color.Red,
      ZoneType.SECRET        => Color.Green,
      ZoneType.HEALTH        => Color.Yellow,
      ZoneType.GAME          => Color.Purple,
      ZoneType.PLAYFIELD     => Color.Orange,
      ZoneType.SPAWN         => Color.White,
      ZoneType.ZONE_LIMIT_T  => Color.OrangeRed,
      ZoneType.ZONE_LIMIT_CT => Color.LightBlue,
      ZoneType.SPAWN_AUTO    => Color.Gray,
      _                      => Color.Black
    };
  }

  public static bool IsSinglePoint(this ZoneType type) {
    return type switch {
      ZoneType.CELL_BUTTON => true,
      ZoneType.SPAWN       => true,
      ZoneType.CENTER      => true,
      ZoneType.SPAWN_AUTO  => true,
      _                    => false
    };
  }
}