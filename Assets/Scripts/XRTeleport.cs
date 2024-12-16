using UnityEngine;

public class TeleportManager : MonoBehaviour
{
    public Transform carTransform; // Transform van de auto
    public Transform[] sidelinePoints; // Lijst van teleportatiepunten bij de zijlijn
    public GameObject xrOrigin; // De XR Rig of XR Origin

    private int currentSidelineIndex = 0; // Huidig teleportatiepunt bij de zijlijn

    // Functie om de speler naar de auto te teleporteren en de XR Origin te koppelen
    public void TeleportToCarPosition()
    {
        xrOrigin.transform.SetParent(carTransform);
        xrOrigin.transform.localPosition = Vector3.zero;
        xrOrigin.transform.localRotation = Quaternion.identity;
    }

    // Functie om de speler naar het huidige zijlijnpunt te teleporteren
    public void TeleportToCurrentSideline()
    {
        xrOrigin.transform.SetParent(null); // Ontkoppel van de auto
        xrOrigin.transform.position = sidelinePoints[currentSidelineIndex].position;
        xrOrigin.transform.rotation = sidelinePoints[currentSidelineIndex].rotation;
    }

    // Functie die wordt aangeroepen wanneer de speler een trigger binnenkomt
    private void OnTriggerEnter(Collider other)
    {
        // Controleer of de speler de trigger binnenkomt
        if (other.CompareTag("Player"))  // Zorg ervoor dat je tag op de speler correct is
        {
            // Verhoog de index voor het volgende teleportatiepunt
            currentSidelineIndex = (currentSidelineIndex + 1) % sidelinePoints.Length;

            // Teleporteer de speler naar het nieuwe punt
            TeleportToCurrentSideline();
        }
    }
}
