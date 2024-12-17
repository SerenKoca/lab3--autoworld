using UnityEngine;
using UnityEngine.UI;

public class RaceResetter : MonoBehaviour
{
    public Button resetButton; // Reference to the reset button
    public Button startButton; // Reference to the start button
    public GameObject[] cars; // Array of car GameObjects (assign all car objects in the inspector)

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
        resetButton.gameObject.SetActive(false); // Hide the reset button initially
        resetButton.onClick.AddListener(ResetRace);

        // Show the start button initially
        startButton.gameObject.SetActive(true);
    }

    void Update()
    {
        // Show the reset button when the race is finished
        if (RaceStarter.raceStarted && AllCarsFinished())
        {
            resetButton.gameObject.SetActive(true); // Show the reset button
            startButton.gameObject.SetActive(false); // Hide the start button
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

    void ResetRace()
    {
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

        // Show the start button and hide the reset button
        startButton.gameObject.SetActive(true);
        resetButton.gameObject.SetActive(false);
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
