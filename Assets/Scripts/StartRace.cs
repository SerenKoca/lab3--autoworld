using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class RaceStarter : MonoBehaviour
{
    public Button startButton;
    public TextMeshProUGUI countdownText;
    public static bool raceStarted = false; // Static variable to be accessed by other scripts

    void Start()
    {
        startButton.onClick.AddListener(StartRace);
        countdownText.gameObject.SetActive(false);
    }

    void StartRace()
    {
        startButton.gameObject.SetActive(false);
        StartCoroutine(Countdown());
    }

    IEnumerator Countdown()
    {
        countdownText.gameObject.SetActive(true);
        for (int i = 3; i > 0; i--)
        {
            countdownText.text = i.ToString();
            yield return new WaitForSeconds(1);
        }
        countdownText.text = "Go!";
        raceStarted = true; // Set raceStarted to true when the countdown finishes
        yield return new WaitForSeconds(1);
        countdownText.gameObject.SetActive(false);
        // Add code here to actually start the race
    }
}