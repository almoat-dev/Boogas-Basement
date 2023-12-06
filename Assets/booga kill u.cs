using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boogakillu : MonoBehaviour
{
    public GameObject pauseMenuUI;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Cursor.lockState = CursorLockMode.None;
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}

