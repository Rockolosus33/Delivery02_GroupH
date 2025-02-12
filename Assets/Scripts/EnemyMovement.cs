using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public Transform[] waypoints; // Array de waypoints
    public float speed = 5f; // Velocidad de movimiento
    private int currentWaypoint = 0;

    private void Start()
    {
        transform.position = waypoints[currentWaypoint].position;
    }
    void Update()
    {
        if (waypoints.Length == 0) return;

        // Mover el objeto hacia el waypoint actual
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypoint].position, speed * Time.deltaTime);

        // Verificar si llegó al waypoint
        if (Vector2.Distance(transform.position, waypoints[currentWaypoint].position) < 0.1f)
        {
            // Pasar al siguiente waypoint
            currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
        }
    }
}
