using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Teleporting : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform teleportTarget;
    [SerializeField] private Transform player;
    [SerializeField] private Image blackFade;

    void Start()
    {
        blackFade.canvasRenderer.SetAlpha(0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(fadeIn());
        }

        fadeOut();
    }

    IEnumerator fadeIn()
    {
        yield return new WaitForSeconds(1);
        //teleport logic
        CharacterController cc = player.GetComponent<CharacterController>();
        cc.enabled = false;
        player.transform.position = teleportTarget.transform.position;
        cc.enabled = true;

        blackFade.CrossFadeAlpha(0, 1, true);
    }

    void fadeOut()
    {
        blackFade.CrossFadeAlpha(2, 1, true);
    }
}
