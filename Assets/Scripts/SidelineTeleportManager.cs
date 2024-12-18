using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class WaypointTeleport : MonoBehaviour
{
    public Transform player; // Reference to the player object
    public GameObject[] waypoints; // Array of waypoints
    public Button nextButton; // Reference to the Next button
    public Button previousButton; // Reference to the Previous button
    public FadeCanvas fadeCanvas; // Reference to the FadeCanvas script
    public Transform initialStartingPoint; // Reference to the initial starting point

    private int currentWaypointIndex = 0; // Index of the current waypoint

    void Start()
    {
        if (nextButton != null)
        {
            nextButton.onClick.AddListener(() => StartCoroutine(MoveToNextWaypoint()));
        }
        else
        {
            Debug.LogError("Next button not assigned.");
        }

        if (previousButton != null)
        {
            previousButton.onClick.AddListener(() => StartCoroutine(MoveToPreviousWaypoint()));
        }
        else
        {
            Debug.LogError("Previous button not assigned.");
        }

        // Move player to the initial starting point if assigned
        if (initialStartingPoint != null)
        {
            player.position = initialStartingPoint.position;
            player.rotation = initialStartingPoint.rotation;
        }
        else
        {
            // Move player to the initial waypoint if no initial starting point is assigned
            StartCoroutine(MoveToWaypoint(currentWaypointIndex));
        }
    }

    private IEnumerator MoveToNextWaypoint()
    {
        if (waypoints.Length == 0) yield break;

        currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        yield return StartCoroutine(MoveToWaypoint(currentWaypointIndex));
    }

    private IEnumerator MoveToPreviousWaypoint()
    {
        if (waypoints.Length == 0) yield break;

        currentWaypointIndex = (currentWaypointIndex - 1 + waypoints.Length) % waypoints.Length;
        yield return StartCoroutine(MoveToWaypoint(currentWaypointIndex));
    }

    private IEnumerator MoveToWaypoint(int index)
    {
        if (fadeCanvas != null)
        {
            fadeCanvas.StartFadeIn();
            yield return new WaitForSeconds(fadeCanvas.defaultDuration);
        }

        if (player != null && waypoints[index] != null)
        {
            player.position = waypoints[index].transform.position;
            player.rotation = waypoints[index].transform.rotation;
        }
        else
        {
            Debug.LogError("Player or waypoint not assigned.");
        }

        if (fadeCanvas != null)
        {
            fadeCanvas.StartFadeOut();
        }
    }
}