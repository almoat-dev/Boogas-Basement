using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public GameManager gameManager;
    public CollectKeys collectKeys;

    [SerializeField] private AudioSource finishLineSoundEffect;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            if (collectKeys.getKeys() == 4)
            {
                gameManager.CompleteLevel();
                finishLineSoundEffect.Play();
             
            }
        }
    }
}