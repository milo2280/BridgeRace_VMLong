using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Step : MonoBehaviour
{
    public ColorEnum color;
    public Material[] listMat;
    public Transform trans;
    public MeshRenderer mes;

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

            default:
                break;
        }
    }
}
