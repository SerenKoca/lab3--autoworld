using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class RaceResetter : MonoBehaviour
{
    public Button resetButton; // Reference to the reset button on the canvas
    public GameObject[] cars; // Array of car GameObjects (assign all car objects in the inspector)
    public Transform player; // Reference to the player object
    public Transform playerStartPoint; // Reference to the player's starting point
    public List<GameObject> screensToDeactivate; // List of screens to deactivate
    public List<GameObject> screensToActivate; // List of screens to activate
    public Canvas resetCanvas; // Reference to the reset canvas
    public FadeCanvas fadeCanvas; // Reference to the FadeCanvas script

    // Store the initial positions of the cars
    private Vector3[] initialPositions;

    void Start()
    {
        // Store initial positions of the cars
        initialPositions = new Vector3[cars.Length];
        for (int i = 0; i < cars.Length; i++)
        {
            initialPositions[i] = cars[i].transform.position;
        }

        // Add listener to the reset button
        resetButton.onClick.AddListener(() => StartCoroutine(PerformReset()));

        // Hide the reset button and canvas initially
        resetButton.gameObject.SetActive(false);
        resetCanvas.gameObject.SetActive(false);
    }

    void Update()
    {
        // Show the reset canvas when the race is finished
        if (RaceStarter.raceStarted && AllCarsFinished())
        {
            resetCanvas.gameObject.SetActive(true); // Show the reset canvas
            resetButton.gameObject.SetActive(true); // Show the reset button
        }
    }

    bool AllCarsFinished()
    {
        // Check if all cars are finished (simplified check)
        foreach (var car in cars)
        {
            // Check for each specific car movement script
            if (car.GetComponent<Model40Movement>() != null && !car.GetComponent<Model40Movement>().raceFinished)
            {
                return false;
            }

            if (car.GetComponent<MustangMovement>() != null && !car.GetComponent<MustangMovement>().raceFinished)
            {
                return false;
            }

            if (car.GetComponent<ModelTMovement>() != null && !car.GetComponent<ModelTMovement>().raceFinished)
            {
                return false;
            }
        }
        return true; // All cars are finished
    }

    IEnumerator PerformReset()
    {
        // Debug logs to check player start point
        Debug.Log("Player Start Point Position: " + playerStartPoint.position);
        Debug.Log("Player Start Point Rotation: " + playerStartPoint.rotation);

        // Start fade-in effect
        if (fadeCanvas != null)
        {
            fadeCanvas.StartFadeIn();
            yield return new WaitForSeconds(fadeCanvas.defaultDuration);
        }

        // Detach the player from any parent
        player.SetParent(null);

        // Teleport the player back to the starting point
        if (player != null && playerStartPoint != null)
        {
            player.position = playerStartPoint.position;
            player.rotation = playerStartPoint.rotation;
        }
        else
        {
            Debug.LogError("Player or player start point not assigned.");
        }

        // Start fade-out effect
        if (fadeCanvas != null)
        {
            fadeCanvas.StartFadeOut();
        }

        // Debug logs to check player position after teleport
        Debug.Log("Player Position after Teleport: " + player.position);
        Debug.Log("Player Rotation after Teleport: " + player.rotation);

        // Reset the race state
        RaceStarter.raceStarted = false;

        // Reset cars' positions and states
        for (int i = 0; i < cars.Length; i++)
        {
            if (cars[i] != null)
            {
                cars[i].transform.position = initialPositions[i]; // Reset car's position
                ResetCarState(cars[i]); // Reset car's speed and state
            }
        }

        // Deactivate specified UI screens
        foreach (GameObject screen in screensToDeactivate)
        {
            if (screen != null && screen.activeSelf)
            {
                screen.SetActive(false);
            }
        }

        // Activate specified UI screens
        foreach (GameObject screen in screensToActivate)
        {
            if (screen != null && !screen.activeSelf)
            {
                screen.SetActive(true);
            }
        }
    }

    void ResetCarState(GameObject car)
    {
        // Reset each car based on its movement script
        if (car.GetComponent<Model40Movement>() != null)
        {
            var model40 = car.GetComponent<Model40Movement>();
            model40.currentSpeed = 0;
            model40.raceFinished = false;
            ResetCarAudio(model40.audioSource, model40.idleClip);
        }
        else if (car.GetComponent<MustangMovement>() != null)
        {
            var mustang = car.GetComponent<MustangMovement>();
            mustang.currentSpeed = 0;
            mustang.raceFinished = false;
            ResetCarAudio(mustang.audioSource, mustang.idleClip);
        }
        else if (car.GetComponent<ModelTMovement>() != null)
        {
            var modelT = car.GetComponent<ModelTMovement>();
            modelT.currentSpeed = 0;
            modelT.raceFinished = false;
            ResetCarAudio(modelT.audioSource, modelT.idleClip);
        }
    }

    void ResetCarAudio(AudioSource audioSource, AudioClip idleClip)
    {
        if (audioSource != null && audioSource.clip != idleClip)
        {
            audioSource.clip = idleClip;
            audioSource.Play();
        }
    }
}
