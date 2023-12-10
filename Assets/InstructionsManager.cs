using UnityEngine;
using TMPro;

public class InstructionManager : MonoBehaviour
{
    public TextMeshProUGUI instructionText1;
    public TextMeshProUGUI instructionText2;
    public float displayDuration = 5f; //duration in seconds

    void Start()
    {

        // Hide instructions after a certain duration
        Invoke("HideInstructions", displayDuration);
    }

    void HideInstructions()
    {
        instructionText1.gameObject.SetActive(false);
        instructionText2.gameObject.SetActive(false);
    }
}