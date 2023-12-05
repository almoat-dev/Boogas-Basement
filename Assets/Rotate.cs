using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] float speedY;
    void Update()
    {
        Vector3 rotation = new Vector3(0, 360 * speedY * Time.deltaTime, 0);
        transform.Rotate(rotation);
    }
}
