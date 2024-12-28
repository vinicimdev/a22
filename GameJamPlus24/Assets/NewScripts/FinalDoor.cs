using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FinalDoor : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject key1;
    [SerializeField] private GameObject key2;
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
        if (Input.GetKeyUp(KeyCode.E) && isInTrigger && !isOpen && key1.activeInHierarchy && key2.activeInHierarchy)
        {
            StartCoroutine(OpenDoor());
        }
        if (Input.GetKeyUp(KeyCode.E) && isInTrigger && !isOpen && !key1.activeInHierarchy && !key2.activeInHierarchy)
        {
            lockedMessage.gameObject.SetActive(true);
        }
    }

    IEnumerator OpenDoor()
    {
        anim.SetBool("Abriu", true);
        openDoorSound.Play();
        key1.SetActive(false);
        key2.SetActive(false);
        isOpen = true;
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("Abriu", false);
        SceneManager.LoadScene("Menu");
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
