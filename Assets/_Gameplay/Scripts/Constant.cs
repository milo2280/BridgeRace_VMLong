using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ColorEnum { none, blue, green, red, yellow }

public class Constant
{
    // Character animation
    public const string ANIM_IDLE = "idle";
    public const string ANIM_RUN = "run";
    public const string ANIM_FALL = "fall";
    public const string ANIM_WIN = "win";
    public const string ANIM_LOSE = "lose";

    // Tag
    public const string TAG_SPAWNER = "Spawner";
    public const string TAG_STEP = "Step";
    public const string TAG_PLAYER = "Player";
    public const string TAG_SPAWNERHOLDER = "SpawnerHolder";
}
