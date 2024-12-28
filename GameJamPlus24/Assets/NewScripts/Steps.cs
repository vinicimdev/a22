using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steps : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private AudioSource stepsSound;

    private Vector3 lastPos;

    // Start is called before the first frame update
    void Start()
    {
        lastPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if(transform.position != lastPos && !stepsSound.isPlaying)
        {
            stepsSound.Play();
        }
        else if(transform.position == lastPos && stepsSound.isPlaying)
        {
            stepsSound.Stop();
        }

        lastPos = transform.position;
    }
}
