using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Look1 : MonoBehaviour
{
    [SerializeField] private Transform npc1;
    [SerializeField] private Transform player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameManager.IsCameraEnabled = false;
            GameManager.IsInputEnabled = false;

            player.position = new Vector3(gameObject.transform.position.x, player.position.y, gameObject.transform.position.z);
            player.GetComponentInChildren<Animator>().SetFloat("Speed", 0);

            npc1.GetComponent<Animator>().SetBool("Talk", true);

            Camera cam = player.GetComponentInChildren<Camera>();
            cam.transform.localRotation = Quaternion.Euler(10f, -30f, 0f);

            // player.LookAt(npc1);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Destroy(gameObject);
        npc1.GetComponent<Animator>().SetBool("Talk", false);
        player.LookAt(new Vector3(0, 0, 19));
    }
}
