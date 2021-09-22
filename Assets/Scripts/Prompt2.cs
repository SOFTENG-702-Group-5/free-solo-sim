using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Prompt2 : MonoBehaviour
{
    [SerializeField] private Text promptText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            promptText.text = "Press SPACE to climb";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Destroy(gameObject);
        promptText.text = "";
    }
}
