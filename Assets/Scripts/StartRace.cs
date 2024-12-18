using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class RaceStarter : MonoBehaviour
{
    public Button startButton;
    public TextMeshProUGUI countdownText;
    public Canvas raceStartCanvas; // Reference to the race start canvas
    public static bool raceStarted = false; // Static variable to be accessed by other scripts

    void Start()
    {
        startButton.onClick.AddListener(StartRace);
        countdownText.gameObject.SetActive(false); // Hide the countdown text initially
    }

    void StartRace()
    {
        startButton.gameObject.SetActive(false);
        countdownText.gameObject.SetActive(true); // Show the countdown text
        StartCoroutine(Countdown());
    }

    IEnumerator Countdown()
    {
        for (int i = 3; i > 0; i--)
        {
            countdownText.text = i.ToString();
            yield return new WaitForSeconds(1);
        }
        countdownText.text = "Go!";
        raceStarted = true; // Set raceStarted to true when the countdown finishes
        yield return new WaitForSeconds(1);
        raceStartCanvas.gameObject.SetActive(false); // Set the canvas to inactive
        startButton.gameObject.SetActive(false); // Ensure the button is inactive
        countdownText.gameObject.SetActive(false); // Ensure the text is inactive
        // Add code here to actually start the race
    }
}