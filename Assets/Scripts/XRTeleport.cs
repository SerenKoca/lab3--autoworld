using UnityEngine;

public class CustomTeleport : MonoBehaviour
{
    public Transform sidelineLocation; // Locatie voor zijlijn
    public Transform carLocation;     // Locatie voor auto
    public GameObject xrRig;          // De XR Rig

    public void TeleportToSideline()
    {
        xrRig.transform.position = sidelineLocation.position;
        xrRig.transform.rotation = sidelineLocation.rotation;
        Debug.Log("Teleported to Sideline");
    }

    public void TeleportToCar()
    {
        xrRig.transform.position = carLocation.position;
        xrRig.transform.rotation = carLocation.rotation;
        Debug.Log("Teleported to Car");
    }
}
