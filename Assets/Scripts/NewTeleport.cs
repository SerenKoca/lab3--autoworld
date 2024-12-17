using UnityEngine;
using UnityEngine.UI;
using TMPro; // For TextMeshPro
using System.Collections; // For IEnumerator

public class TeleportButton : MonoBehaviour
{
    public Transform player; // Reference to the player object
    public Transform teleportTarget; // Reference to the teleport target (waypoint)
    public FadeCanvas fadeCanvas; // Reference to the FadeCanvas script

    private Button button;

    void Start()
    {
        button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(() => StartCoroutine(TeleportWithFade()));
        }
        else
        {
            Debug.LogError("Button component not found on this GameObject.");
        }
    }

    private IEnumerator TeleportWithFade()
    {
        if (fadeCanvas != null)
        {
            fadeCanvas.StartFadeIn();
            yield return new WaitForSeconds(fadeCanvas.defaultDuration);
        }

        if (player != null && teleportTarget != null)
        {
            player.position = teleportTarget.position;
            player.rotation = teleportTarget.rotation;

            // Make the player a child of the car (teleportTarget's parent)
            player.SetParent(teleportTarget.parent);
        }
        else
        {
            Debug.LogError("Player or teleport target not assigned.");
        }

        if (fadeCanvas != null)
        {
            fadeCanvas.StartFadeOut();
        }
    }
}