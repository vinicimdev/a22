using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Animator anim;
    [SerializeField] private AudioSource openDoorSound;

    private bool isOpen = false;
    private bool isInTrigger = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E) && isInTrigger && !isOpen)
        {
            StartCoroutine(OpenDoor());
        }
    }

    IEnumerator OpenDoor()
    {
        anim.SetBool("Abriu", true);
        openDoorSound.Play();
        isOpen = true;
        yield return new WaitForSeconds(0.1f);
        anim.SetBool("Abriu", false);
    }

    private void CheckPlayerIsInDoorRange()
    {
        isInTrigger = !isInTrigger;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CheckPlayerIsInDoorRange();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CheckPlayerIsInDoorRange();
        }
    }
}
