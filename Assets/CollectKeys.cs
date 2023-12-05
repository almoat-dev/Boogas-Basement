using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectKeys : MonoBehaviour
{
    public Image[] keyImages;
    int keys = 0;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Key"))
        {
            Destroy(other.gameObject);
            if (keys < keyImages.Length)
            {
                keyImages[keys].gameObject.SetActive(true);
                keys++;
            }
            Debug.Log("Keys: " + keys);
        }
    }
}
