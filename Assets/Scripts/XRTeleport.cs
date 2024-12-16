using UnityEngine;
using UnityEngine.UI; // Zorg ervoor dat de UI namespace beschikbaar is

public class TeleportToCar : MonoBehaviour
{
    public Transform carTransform; // De Transform van de auto
    public Transform[] sidelinePoints; // Een array van Transforms op de zijlijn
    public GameObject xrOrigin; // De XR Rig of XR Origin

    public Button nextButton; // De button voor het volgende sideline punt
    public Button previousButton; // De button voor het vorige sideline punt

    private int currentSidelineIndex = 0; // Huidige index van het sideline punt

    void Start()
    {
        // Koppel de buttons aan de juiste functies wanneer de scene begint
        nextButton.onClick.AddListener(GoToNextSidelinePoint);
        previousButton.onClick.AddListener(GoToPreviousSidelinePoint);
    }

    // Functie om de speler naar de auto te teleporteren en de XR Origin te koppelen
    public void TeleportToCarPosition()
    {
        // Zet de XR Origin als child van de auto
        xrOrigin.transform.SetParent(carTransform);

        // Teleporteer de XR Origin naar de positie van de auto
        xrOrigin.transform.localPosition = Vector3.zero;
        xrOrigin.transform.localRotation = Quaternion.identity;
    }

    // Functie om de speler naar de zijlijn te teleporteren en los te maken van de auto
    public void TeleportToSideline()
    {
        // Ontkoppel de XR Origin van de auto
        xrOrigin.transform.SetParent(null);

        // Teleporteer de XR Origin naar het huidige zijlijnpunt
        if (sidelinePoints.Length > 0)
        {
            xrOrigin.transform.position = sidelinePoints[currentSidelineIndex].position;
            xrOrigin.transform.rotation = sidelinePoints[currentSidelineIndex].rotation;
        }
    }

    // Functie om naar het volgende punt op de zijlijn te gaan
    public void GoToNextSidelinePoint()
    {
        // Verhoog de index en zorg ervoor dat deze niet groter is dan het aantal sideline punten
        currentSidelineIndex = Mathf.Min(currentSidelineIndex + 1, sidelinePoints.Length - 1);
        TeleportToCurrentSidelinePoint();
    }

    // Functie om naar het vorige punt op de zijlijn te gaan
    public void GoToPreviousSidelinePoint()
    {
        // Verlaag de index en zorg ervoor dat deze niet kleiner is dan 0
        currentSidelineIndex = Mathf.Max(currentSidelineIndex - 1, 0);
        TeleportToCurrentSidelinePoint();
    }

    // Functie om naar het huidige sideline punt te teleporteren
    private void TeleportToCurrentSidelinePoint()
    {
        // Teleporteer de XR Origin naar de huidige sideline positie en rotatie
        if (sidelinePoints.Length > 0)
        {
            xrOrigin.transform.position = sidelinePoints[currentSidelineIndex].position;
            xrOrigin.transform.rotation = sidelinePoints[currentSidelineIndex].rotation;
        }
    }
}
