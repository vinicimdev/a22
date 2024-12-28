using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Item : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject item;
    [SerializeField] private GameObject icon;
    [SerializeField] private AudioSource collectSound;

    [SerializeField] private bool isInTrigger = false;

    private void Start()
    {
        CollectItem(true, false);
        collectSound.Stop();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && isInTrigger)
        {
            StartCoroutine(PlayCollectSound());       
        }
    }
    IEnumerator PlayCollectSound()
    {
        Debug.Log("playing audio: " + collectSound.name);
        collectSound.Play();
        yield return new WaitForSeconds(0.2f);
        CollectItem(false, true);
    }

    private void CollectItem(bool _item, bool _icon)
    {
        item.SetActive(_item);
        icon.SetActive(_icon);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            isInTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isInTrigger = false;
        }
    }
}
