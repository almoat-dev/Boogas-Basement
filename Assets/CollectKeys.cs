using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectKeys : MonoBehaviour
{
    public Image[] keyImages;
    private int keys = 0;
    public int getKeys()
    {
        return keys;
    }

    [SerializeField] private AudioSource collectionSoundEffect;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Key"))
        {
            collectionSoundEffect.Play();
            Destroy(other.gameObject);
            if (keys < keyImages.Length)
            {
                keyImages[keys].gameObject.SetActive(true);
                keys++;
            }
            Debug.Log("Keys: " + keys);
        }
        else if(other.gameObject.CompareTag("Door"))
        {
            if (keys == 4)
            {
                Debug.Log("booga diff");
            }
            else
            {
                Debug.Log("no keys?");
            }
        }
    }
}
