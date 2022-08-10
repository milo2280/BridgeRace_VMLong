using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public ColorEnum color;
    public Material[] listMat;

    public MeshRenderer mes;
    public BoxCollider box;

    public void SetColor(ColorEnum color)
    {
        this.color = color;
        mes.enabled = true;

        switch (color)
        {
            case ColorEnum.blue:
                mes.material = listMat[0];
                break;

            case ColorEnum.green:
                mes.material = listMat[1];
                break;

            case ColorEnum.red:
                mes.material = listMat[2];
                break;

            case ColorEnum.yellow:
                mes.material = listMat[3];
                break;
        }
    }

    public void TurnOn()
    {
        mes.enabled = true;
        box.enabled = true;
    }

    public void TurnOff()
    {
        mes.enabled = false;
        box.enabled = false;
        Invoke("TurnOn", 5.0f);
    }
}
