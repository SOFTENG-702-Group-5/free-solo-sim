using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mantle : MonoBehaviour
{
    [SerializeField] private Transform player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Animator anim = player.GetComponentInChildren<Animator>();

            anim.speed = 1;
            anim.SetTrigger("Mantle");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Destroy(gameObject);
    }
}
