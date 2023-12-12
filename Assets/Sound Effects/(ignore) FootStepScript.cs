using UnityEngine;
using System.Collections;

public class FootStepScript : MonoBehaviour
{
    public float stepRate;
    public float stepCoolDown;
    public AudioClip footStepWalk;
    public AudioClip footStepRun;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift)) {
            stepRate = 0.3f;
            stepCoolDown -= Time.deltaTime;
            if ((Input.GetAxis("Horizontal") != 0f || Input.GetAxis("Vertical") != 0f) && stepCoolDown < 0f)
            {
                GetComponent<AudioSource>().pitch = 1f + Random.Range(-0.2f, 0.2f);
                GetComponent<AudioSource>().PlayOneShot(footStepRun, 0.9f);
                stepCoolDown = stepRate;
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
        }  
    }
}