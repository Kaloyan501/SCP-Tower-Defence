using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed = 3f;

    private EnemyPath path;
    private int currentWaypoint = 1;

    public void Initialize(EnemyPath assignedPath)
    {
        path = assignedPath;

        if (path == null || path.WaypointCount == 0)
        {
            Destroy(gameObject);
            return;
        }

        // Start at the first waypoint.
        transform.position = path.GetWaypoint(0).position;
    }

    private void Update()
    {
        if (path == null)
            return;

        if (currentWaypoint >= path.WaypointCount)
        {
            Destroy(gameObject);
            return;
        }

        Transform target = path.GetWaypoint(currentWaypoint);

        transform.position = Vector3.MoveTowards(
            transform.position,
            target.position,
            speed * Time.deltaTime
        );

        if (Vector3.Distance(transform.position, target.position) < 0.05f)
        {
            currentWaypoint++;
        }
    }
}
