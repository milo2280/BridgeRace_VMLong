using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickHolder : MonoBehaviour
{
    public Transform spineTransform;
    public GameObject brickPrefab;

    private Transform trans;

    private GameObject tempBrick;
    private Vector3 tempPos;
    private List<GameObject> listBricks;

    private void Start()
    {
        trans = GetComponent<Transform>();
        tempPos = new Vector3(0f, 0f, -0.3f);
        listBricks = new List<GameObject>();
    }

    private void Update()
    {
        trans.position = spineTransform.position;
        trans.rotation = spineTransform.rotation;
    }

    public void AddBrick()
    {
        tempBrick = Instantiate(brickPrefab, trans);
        tempBrick.transform.localPosition = tempPos;
        tempPos.y += 0.2f;
        listBricks.Add(tempBrick);
    }

    public void UseBrick()
    {
        GameObject.Destroy(listBricks[listBricks.Count - 1]);
        listBricks.RemoveAt(listBricks.Count - 1);
        tempPos.y -= 0.2f;
    }
}
