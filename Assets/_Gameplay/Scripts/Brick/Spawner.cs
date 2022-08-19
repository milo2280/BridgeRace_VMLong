using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public ColorEnum color;
    public MeshRenderer meshRenderer;
    public BoxCollider myCollider;
    public Transform myTransform;

    public void SetColor(ColorEnum color)
    {
        this.color = color;
        meshRenderer.enabled = true;
        meshRenderer.material.SetColor(Constant.ID_COLOR, DataManager.Ins.colorDict[color]);
    }

    public void TurnOn()
    {
        meshRenderer.enabled = true;
        myCollider.enabled = true;
    }

    public void TurnOff()
    {
        meshRenderer.enabled = false;
        myCollider.enabled = false;
        Invoke(nameof(TurnOn), 5.0f);
    }
}
