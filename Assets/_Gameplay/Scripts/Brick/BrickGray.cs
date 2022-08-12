using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickGray : MonoBehaviour
{
    public Transform myTransform;

    private void Update()
    {
        if (myTransform.position.y < -1f)
        {
            SimplePool.Despawn(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag(Constant.TAG_PLAYER))
        {
            SimplePool.Despawn(gameObject);
        }
    }
}
