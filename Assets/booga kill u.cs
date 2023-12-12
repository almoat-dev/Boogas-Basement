using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boogakillu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    [SerializeField] private AudioSource jumpScareSoundEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            jumpScareSoundEffect.Play();
            Cursor.lockState = CursorLockMode.None;
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}

