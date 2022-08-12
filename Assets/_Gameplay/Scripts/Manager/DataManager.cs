using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    public Dictionary<ColorEnum, Color> colorDict = new Dictionary<ColorEnum, Color>();
    public Vector3 finishPoint = new Vector3(0f, 13f, 70f);

    private void Start()
    {
        InitDict();
    }

    private void InitDict()
    {
        colorDict.Add(ColorEnum.blue, Color.blue);
        colorDict.Add(ColorEnum.red, Color.red);
        colorDict.Add(ColorEnum.green, Color.green);
        colorDict.Add(ColorEnum.yellow, Color.yellow);
    }
}
