using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Step : MonoBehaviour
{
    public ColorEnum color;
    public Transform myTransform;
    public MeshRenderer meshRenderer;

    public void SetColor(ColorEnum color)
    {
        this.color = color;
        meshRenderer.enabled = true;
        meshRenderer.material.SetColor(Constant.ID_COLOR, DataManager.Ins.colorDict[color]);
    }
}
