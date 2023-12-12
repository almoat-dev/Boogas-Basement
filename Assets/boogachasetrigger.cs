using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boogachasetrigger : MonoBehaviour
{
    public Behaviour AIChase;
    public Behaviour AIPatrol;

    //whenever the AggroHitbox collides with the player, enable the AIPathing script
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (AIChase.enabled == false)
            {
                AIChase.enabled = true;
                AIPatrol.enabled = false;
            }
        }
        else
        {
            AIChase.enabled = false;
            AIPatrol.enabled = true;
        }    

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

                AIChase.enabled = false;
                AIPatrol.enabled = true;

        }
    }

}
