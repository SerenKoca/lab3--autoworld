using UnityEngine;
using UnityEngine.InputSystem;

public class XRCameraSwitcher : MonoBehaviour
{
    public Camera[] cameras; // Array van alle camera's in de XR Rig
    public InputActionReference controllerClick; // Actie voor controller-click
    public KeyCode keyboardKey = KeyCode.Space; // Toets om camera te wisselen

    private int currentCameraIndex = 0; // Houdt de huidige actieve camera bij

    private void OnEnable()
    {
        // Abonneer op de controller-click actie
        controllerClick.action.performed += OnControllerClick;
    }

    private void OnDisable()
    {
        // Afmelden van de controller-click actie
        controllerClick.action.performed -= OnControllerClick;
    }

    private void Start()
    {
        // Schakel alleen de eerste camera in bij het starten
        ActivateCamera(0);
    }

    private void Update()
    {
        // Check toetsenbordinvoer
        if (Input.GetKeyDown(keyboardKey))
        {
            SwitchCamera();
        }
    }

    private void OnControllerClick(InputAction.CallbackContext context)
    {
        // Schakel camera bij controller-click
        SwitchCamera();
    }

    private void SwitchCamera()
    {
        // Schakel naar de volgende camera
        currentCameraIndex = (currentCameraIndex + 1) % cameras.Length;
        ActivateCamera(currentCameraIndex);
    }

    private void ActivateCamera(int index)
    {
        // Deactiveer alle camera's behalve de gewenste
        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].enabled = (i == index);
        }
    }
}
