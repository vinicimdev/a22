using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LockedDoor : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject key;
    [SerializeField] private TextMeshProUGUI lockedMessage;
    [SerializeField] private Animator anim;
    [SerializeField] private AudioSource openDoorSound;

    private bool isOpen = false;
    private bool isInTrigger = false;

    // Start is called before the first frame update
    void Start()
    {
        lockedMessage.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.E) && isInTrigger && !isOpen && key.activeInHierarchy)
        {
            StartCoroutine(OpenDoor());
        }
        if(Input.GetKeyUp(KeyCode.E) && isInTrigger && !isOpen && !key.activeInHierarchy)
        {
            lockedMessage.gameObject.SetActive(true);
        }
    }

    IEnumerator OpenDoor()
    {
        anim.SetBool("Aberta", true);
        openDoorSound.Play();
        key.SetActive(false);
        isOpen = true;
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("Aberta", false);       
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
            lockedMessage.gameObject.SetActive(false);
        }
    }
}
