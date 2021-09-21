using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Look1 : MonoBehaviour
{
    [SerializeField] private Transform targetObject;
    [SerializeField] private Transform player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.position = new Vector3(gameObject.transform.position.x, player.position.y, gameObject.transform.position.z);
            player.GetComponentInChildren<Animator>().SetFloat("Speed", 0);
            GameManager.IsInputEnabled = false;

            player.LookAt(targetObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Destroy(gameObject);
        player.LookAt(new Vector3(0, 0, 19));
    }
}
