using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

using Random = UnityEngine.Random;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 10f;
    public float sprintSpeed = 20f;
    public float maxStamina = 100.0f;
    public float staminaConsumptionRate = 20.0f;
    public float staminaRecoveryRate = 80.0f;
    public bool needToRecover = false; 

    private float currentStamina = 100;

    public GameObject obj;
    public staminaBar staminaBar;

    // For audio playing purposes
    public float stepRate;
    public float stepCoolDown;
    public AudioClip footStepWalk;
    public AudioClip footStepRun;

    [SerializeField] private AudioSource laughter;

    void Start ()
    {
        float waitTime;

        //Plays sound effect randomly
        waitTime = Random.Range(20, 500);
        Invoke("playAudio", waitTime);
    }

    void playAudio()
    {
        laughter.Play();
    }

    // Update is called once per frame
    void Update()
    {
        staminaBar.SetStamina(Convert.ToInt32(currentStamina));
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        move.Normalize();

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftShift) && currentStamina > 1 && needToRecover == false)
        {
            stepRate = 0.3f;
            stepCoolDown -= Time.deltaTime;
            if ((Input.GetAxis("Horizontal") != 0f || Input.GetAxis("Vertical") != 0f) && stepCoolDown < 0f)
            {
                GetComponent<AudioSource>().pitch = 1f + Random.Range(-0.2f, 0.2f);
                GetComponent<AudioSource>().PlayOneShot(footStepRun, 0.9f);
                stepCoolDown = stepRate;
            }

            speed = sprintSpeed;
            currentStamina -= staminaConsumptionRate * Time.deltaTime * 2;
            if (currentStamina <= 1)
            {
                needToRecover = true;
            }
        }
        else
        {
            stepRate = 0.5f;
            stepCoolDown -= Time.deltaTime;
            if ((Input.GetAxis("Horizontal") != 0f || Input.GetAxis("Vertical") != 0f) && stepCoolDown < 0f)
            {
                GetComponent<AudioSource>().pitch = 1f + Random.Range(-0.2f, 0.2f);
                GetComponent<AudioSource>().PlayOneShot(footStepWalk, 0.9f);
                stepCoolDown = stepRate;
            }

            if (currentStamina >= 99)
            {
                needToRecover = false;
            }
            speed = 10f;
            currentStamina += (staminaRecoveryRate * Time.deltaTime) * 3;
            currentStamina = Mathf.Clamp(currentStamina, 0f, maxStamina);
        }

        Vector3 clampedPosition = transform.position;
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, 0,2); 
        transform.position = clampedPosition;
    }
}