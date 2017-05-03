using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPitch : MonoBehaviour
{

    public float minPitch = 1f;
    public float maxPitch = 1.5f;

    private AudioSource audio;

    // Use this for initialization
    void Awake()
    {
        audio = GetComponent<AudioSource>();
        audio.pitch = Random.Range(minPitch, maxPitch);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
