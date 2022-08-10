using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cache : MonoBehaviour
{
    private static Dictionary<Collider, Spawner> spawners = new Dictionary<Collider, Spawner>();
    private static Dictionary<Collider, Step> steps = new Dictionary<Collider, Step>();
    private static Dictionary<Collider, SpawnerHolder> spawnerHolders = new Dictionary<Collider, SpawnerHolder>();

    public static Spawner GetSpawner(Collider collider)
    {
        if (!spawners.ContainsKey(collider))
        {
            spawners.Add(collider, collider.GetComponent<Spawner>());
        }

        return spawners[collider];
    }

    public static Step GetStep(Collider collider)
    {
        if (!steps.ContainsKey(collider))
        {
            steps.Add(collider, collider.GetComponent<Step>());
        }

        return steps[collider];
    }

    public static SpawnerHolder GetSpawnerHolder(Collider collider)
    {
        if (!spawnerHolders.ContainsKey(collider))
        {
            spawnerHolders.Add(collider, collider.GetComponent<SpawnerHolder>());
        }

        return spawnerHolders[collider];
    }
}
