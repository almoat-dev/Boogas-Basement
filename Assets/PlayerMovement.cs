using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 5f;
    public float sprintSpeed = 20f;
    public float maxStamina = 100.0f;
    public float staminaConsumptionRate = 6.0f;
    public float staminaRecoveryRate = 80.0f;
    public bool needToRecover = false; 

    private float currentStamina = 100;


    public staminaBar staminaBar; 

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
            
            speed = sprintSpeed;
            currentStamina -= staminaConsumptionRate * Time.deltaTime;
            if (currentStamina <= 1)
            {
                needToRecover = true;
            }
        }
        else
        {
            
            if (currentStamina >= 99)
            {
                needToRecover = false;
            }
            speed = 5f;
            currentStamina += (staminaRecoveryRate * Time.deltaTime) * 3;
            currentStamina = Mathf.Clamp(currentStamina, 0f, maxStamina);
        }

            Vector3 clampedPosition = transform.position;
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, 0,2); 
        transform.position = clampedPosition;
    }
}