using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    public Character myCharacter;

    private Step step;
    private Spawner spawner;
    private Character otherCharacter;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Constant.TAG_SPAWNER))
        {
            spawner = CacheSpawner.Get(other);
            if (myCharacter.color == spawner.color)
            {
                myCharacter.AddBrick();
                spawner.TurnOff();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag(Constant.TAG_STEP))
        {
            step = CacheStep.Get(collision.collider);
            if (myCharacter.color != step.color && myCharacter.GetBrickCount() > 0)
            {
                myCharacter.UseBrick();
                step.SetColor(myCharacter.color);
            }
        }

        if (collision.collider.CompareTag(Constant.TAG_PLAYER))
        {
            otherCharacter = CacheCharacter.Get(collision.collider);
            if (myCharacter.GetBrickCount() < otherCharacter.GetBrickCount())
            {
                myCharacter.Fall();
            }
        }

        if (collision.collider.CompareTag(Constant.TAG_GRAYBRICK))
        {
            myCharacter.AddBrick();
        }
    }
}
