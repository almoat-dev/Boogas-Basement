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
    public float staminaRecoveryRate = 5.0f;

    private float currentStamina;

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        move.Normalize();

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftShift) && currentStamina > 1)
        {
            speed = sprintSpeed;
            currentStamina -= staminaConsumptionRate * Time.deltaTime;
        }
        else
        {
            speed = 5f;
            currentStamina += staminaRecoveryRate * Time.deltaTime;
            currentStamina = Mathf.Clamp(currentStamina, 0f, maxStamina);
        }

            Vector3 clampedPosition = transform.position;
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, 0,2); 
        transform.position = clampedPosition;
    }
}
