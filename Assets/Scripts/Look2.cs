using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look2 : MonoBehaviour
{
    [SerializeField] private Transform npc5;
    [SerializeField] private Transform player;
    [SerializeField] private AudioSource audioSource;
    private Camera cam;
    private bool triggered = false;

    private void Start()
    {
        cam = player.GetComponentInChildren<Camera>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            triggered = true;
            GameManager.IsCameraEnabled = false;
            GameManager.IsInputEnabled = false;

            player.position = new Vector3(gameObject.transform.position.x, player.position.y, gameObject.transform.position.z);
            player.GetComponentInChildren<Animator>().SetFloat("Speed", 0);
            player.GetComponentInChildren<Animator>().speed = 0;

            npc5.GetComponent<Animator>().SetBool("Talk", true);

            cam.transform.localRotation = Quaternion.Euler(10f, 50f, 0f);

            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
    }

    void Update()
    {
        if (triggered && !audioSource.isPlaying)
        {
            Destroy(gameObject);

            GameManager.IsCameraEnabled = true;
            GameManager.IsInputEnabled = true;

            npc5.GetComponent<Animator>().SetBool("Talk", false);
            cam.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }
}
