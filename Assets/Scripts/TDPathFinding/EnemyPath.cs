using UnityEngine;

public class EnemyPath : MonoBehaviour
{
    private Transform[] waypoints;

    public int WaypointCount => waypoints.Length;

    private void Awake()
    {
        RefreshWaypoints();
    }

    private void RefreshWaypoints()
    {
        int count = transform.childCount;
        waypoints = new Transform[count];

        for (int i = 0; i < count; i++)
        {
            waypoints[i] = transform.GetChild(i);
        }
    }

    public Transform GetWaypoint(int index)
    {
        if (index < 0 || index >= waypoints.Length)
            return null;

        return waypoints[index];
    }
}
