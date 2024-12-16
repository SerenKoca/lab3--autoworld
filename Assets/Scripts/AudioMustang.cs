using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MustangAudioManager : MonoBehaviour
{
    public AudioClip idlingClip; // Idling noise clip
    public AudioClip drivingClip; // Driving noise clip
    private AudioSource audioSource; // Audio source component
    private MustangMovement mustangMovement; // Reference to the car's movement script

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        mustangMovement = GetComponentInParent<MustangMovement>();
        audioSource.clip = idlingClip;
        audioSource.loop = true; // Ensure the idling clip loops
        audioSource.Play();
    }

    void Update()
    {
        if (RaceStarter.raceStarted && audioSource.clip != drivingClip) // Check if the race has started
        {
            audioSource.clip = drivingClip;
            audioSource.loop = true; // Ensure the driving clip loops
            audioSource.Play();
        }

        if (mustangMovement != null && mustangMovement.raceFinished) // Check if the race is finished
        {
            audioSource.Stop();
        }
    }
}