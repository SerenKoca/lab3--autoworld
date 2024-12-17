using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource; // Audio source component
    public AudioClip startClip; // Audio clip for the start
    public AudioClip driveClip; // Audio clip for driving
    public AudioClip brakeClip; // Audio clip for braking
    public AudioClip idleClip; // Audio clip for idling

    private bool raceStarted = false;
    private bool raceFinished = false;

    void Start()
    {
        // Play the start sound at the beginning
        PlayStartSound();
    }

    void Update()
    {
        if (RaceStarter.raceStarted && !raceStarted)
        {
            raceStarted = true;
            PlayDriveSound();
        }
    }

    public void PlayStartSound()
    {
        audioSource.clip = startClip;
        audioSource.Play();
    }

    public void PlayDriveSound()
    {
        audioSource.clip = driveClip;
        audioSource.Play();
    }

    public void PlayBrakeSound()
    {
        audioSource.clip = brakeClip;
        audioSource.Play();
    }

    public void PlayIdleSound()
    {
        audioSource.clip = idleClip;
        audioSource.Play();
    }

    public void SetRaceFinished()
    {
        raceFinished = true;
    }

    public bool IsRaceFinished()
    {
        return raceFinished;
    }
}