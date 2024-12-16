using UnityEngine;

public class TeleportToCar : MonoBehaviour
{
    public Transform carTransform; // De Transform van de auto
    public Transform sidelineTransform; // De Transform van de zijlijn
    public GameObject xrOrigin; // De XR Rig of XR Origin

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

        // Teleporteer de XR Origin naar de positie van de zijlijn
        xrOrigin.transform.position = sidelineTransform.position;
        xrOrigin.transform.rotation = sidelineTransform.rotation;
    }
}
