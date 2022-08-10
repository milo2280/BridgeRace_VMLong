using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerHolder : MonoBehaviour
{
    public Spawner[] listSpawner;

    private int i, colorIndex, Rand, numOfSpawners, numOfColors;
    private List<int> classified;
    public List<Collider> colored;
    private List<Spawner> temp, blueSpawner, greenSpawner, redSpawner, yellowSpawner;
    private ColorEnum[] colorEnum;

    private void Start()
    {
        colorIndex = 0;
        colorEnum = (ColorEnum[])System.Enum.GetValues(typeof(ColorEnum));
        numOfColors = colorEnum.Length - 1;
        numOfSpawners = listSpawner.Length;
        classified = new List<int>();
        colored = new List<Collider>();
        blueSpawner = new List<Spawner>();
        greenSpawner = new List<Spawner>();
        redSpawner = new List<Spawner>();
        yellowSpawner = new List<Spawner>();

        RandomColor();
    }

    private void RandomColor()
    {
        for (i = 0; i < numOfSpawners; i++)
        {
            if (i % (int)(numOfSpawners / numOfColors) == 0) colorIndex++;

            Rand = Random.Range(0, numOfSpawners);
            while (classified.Contains(Rand))
            {
                Rand = Random.Range(0, numOfSpawners);
            }

            classified.Add(Rand);
            switch (colorIndex)
            {
                case 1:
                    blueSpawner.Add(listSpawner[Rand]);
                    break;

                case 2:
                    greenSpawner.Add(listSpawner[Rand]);
                    break;

                case 3:
                    redSpawner.Add(listSpawner[Rand]);
                    break;

                case 4:
                    yellowSpawner.Add(listSpawner[Rand]);
                    break;

                default:
                    break;
            }
        }
    }

    private void SetColor(ColorEnum color)
    {
        switch (color)
        {
            case ColorEnum.blue:
                temp = blueSpawner;
                break;

            case ColorEnum.green:
                temp = greenSpawner;
                break;

            case ColorEnum.red:
                temp = redSpawner;
                break;

            case ColorEnum.yellow:
                temp = yellowSpawner;
                break;
        }

        foreach(Spawner spawner in temp)
        {
            spawner.SetColor(color);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Constant.TAG_PLAYER) && !colored.Contains(other))
        {
            SetColor(other.GetComponent<Character>().myColor);
            colored.Add(other);
        }
    }
}
