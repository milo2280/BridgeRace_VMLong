using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerHolder : MonoBehaviour
{
    public Spawner[] listSpawner;
    public Transform[] listGate;

    private int i, colorIndex, Rand, spawnerCount, colorCount;
    private ColorEnum[] colorEnum;
    private List<int> classified = new List<int>();
    private List<Collider> colored = new List<Collider>();
    private List<Spawner> blueSpawner = new List<Spawner>();
    private List<Spawner> greenSpawner = new List<Spawner>();
    private List<Spawner> redSpawner = new List<Spawner>();
    private List<Spawner> yellowSpawner = new List<Spawner>();
    private Dictionary<ColorEnum, List<Spawner>> spawnerDict = new Dictionary<ColorEnum, List<Spawner>>();

    private void Start()
    {
        InitDict();
        colorCount = spawnerDict.Count;
        spawnerCount = listSpawner.Length;
        colorEnum = (ColorEnum[])System.Enum.GetValues(typeof(ColorEnum));

        RandomColor();
    }

    private void InitDict()
    {
        spawnerDict.Add(ColorEnum.blue, blueSpawner);
        spawnerDict.Add(ColorEnum.green, greenSpawner);
        spawnerDict.Add(ColorEnum.red, redSpawner);
        spawnerDict.Add(ColorEnum.yellow, yellowSpawner);
    }

    private void RandomColor()
    {
        for (i = 0; i < spawnerCount; i++)
        {
            if (i % (int)(spawnerCount / colorCount) == 0) colorIndex++;
            if (colorIndex > colorCount) break;

            Rand = Random.Range(0, spawnerCount);
            while (classified.Contains(Rand))
            {
                Rand = Random.Range(0, spawnerCount);
            }

            classified.Add(Rand);
            spawnerDict[colorEnum[colorIndex]].Add(listSpawner[Rand]);
        }
    }

    private void SetColor(ColorEnum color)
    {
        foreach(Spawner spawner in spawnerDict[color])
        {
            spawner.SetColor(color);
        }
    }

    public List<Spawner> GetListSpawner(ColorEnum color)
    {
        return spawnerDict[color];
    }

    public Transform[] GetListGate()
    {
        return listGate;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Constant.TAG_PLAYER) && !colored.Contains(other))
        {
            SetColor(CacheCharacter.Get(other).color);
            colored.Add(other);
        }
    }
}
