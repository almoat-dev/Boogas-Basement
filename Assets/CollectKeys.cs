using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectKeys : MonoBehaviour
{
    int keys = 0;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Key"))
        {
            Destroy(other.gameObject);
            keys++;
            Debug.Log("Keys: " + keys);
        }
    }
}
