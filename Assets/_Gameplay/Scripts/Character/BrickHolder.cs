using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickHolder : MonoBehaviour
{
    public Transform myTransform;
    public Transform spineTransform;
    public GameObject brickPrefab;
    public GameObject grayBrickPrefab;
    public int brickCount { get; private set; }

    private GameObject tempBrick;
    private Vector3 nextBrickPos;
    private List<GameObject> listBricks;

    private void Start()
    {
        nextBrickPos = new Vector3(0f, 0f, -0.3f);
        listBricks = new List<GameObject>();
    }

    private void Update()
    {
        myTransform.position = spineTransform.position;
        myTransform.rotation = spineTransform.rotation;
    }

    public void AddBrick()
    {
        tempBrick = SimplePool.Spawn(brickPrefab, nextBrickPos, myTransform);
        nextBrickPos.y += 0.2f;
        listBricks.Add(tempBrick);
        brickCount++;
    }

    public void UseBrick()
    {
        SimplePool.Despawn(listBricks[brickCount - 1]);
        listBricks.RemoveAt(brickCount - 1);
        nextBrickPos.y -= 0.2f;
        brickCount--;
    }

    public void DropBrick()
    {
        foreach (GameObject brick in listBricks)
        {
            nextBrickPos.y -= 0.2f;
            SimplePool.Despawn(brick);
            tempBrick = SimplePool.Spawn(grayBrickPrefab, myTransform.position + nextBrickPos, Quaternion.identity);
        }
        nextBrickPos = new Vector3(0f, 0f, -0.3f);
        listBricks.Clear();
        brickCount = 0;
    }

    public void ClearBrick()
    {
        foreach (GameObject brick in listBricks)
        {
            nextBrickPos.y -= 0.2f;
            SimplePool.Despawn(brick);
        }
        nextBrickPos = new Vector3(0f, 0f, -0.3f);
        listBricks.Clear();
        brickCount = 0;
    }
}
