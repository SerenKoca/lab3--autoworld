using UnityEngine;
using UnityEngine.UI;

public class TeleportManager : MonoBehaviour
{
    public Transform sidelineTeleportArea;
    public Transform carTeleportArea;
    public Button sidelinesButton;
    public Button carToggleButton; // New button to toggle car status
    public GameObject player;
    public GameObject car;

    private bool isInCar = false;

    void Start()
    {
        sidelinesButton.onClick.AddListener(OnSidelinesButtonClick);
        carToggleButton.onClick.AddListener(ToggleCarStatus); // Add listener for the new button
    }

    void OnSidelinesButtonClick()
    {
        if (isInCar)
        {
            TeleportTo(carTeleportArea);
        }
        else
        {
            TeleportTo(sidelineTeleportArea);
        }
    }

    void TeleportTo(Transform teleportArea)
    {
        if (isInCar)
        {
            car.transform.position = teleportArea.position;
            car.transform.rotation = teleportArea.rotation;
        }
        else
        {
            player.transform.position = teleportArea.position;
            player.transform.rotation = teleportArea.rotation;
        }
    }

    void ToggleCarStatus()
    {
        isInCar = !isInCar;
    }
}