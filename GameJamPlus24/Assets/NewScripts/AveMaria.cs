using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AveMaria : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private AudioSource aveMariaSound;
    [SerializeField] private GameObject toyBox;

    public bool isPlaying = false;

    // Update is called once per frame
    void Update()
    {
        if(!toyBox.activeInHierarchy && !isPlaying)
        {
            isPlaying = true;
            aveMariaSound.Play();
        }
    }
}
