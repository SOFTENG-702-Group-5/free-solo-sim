using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Prompt1 : MonoBehaviour
{
    [SerializeField] private Text promptText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {   
            promptText.text = "Press W to walk foward";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Destroy(gameObject);
        promptText.text = "";
    }
}
