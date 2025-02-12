using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 5f;
    private int currentWaypoint = 0;
    private Animator animator;

    private void Start()
    {
        currentWaypoint = 0;
        transform.position = waypoints[currentWaypoint].position;
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypoint].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, waypoints[currentWaypoint].position) < 0.1f)
        {
            if (currentWaypoint + 1 >= waypoints.Length)
            {
                currentWaypoint = 0;
            }
            else
            {
                currentWaypoint = currentWaypoint + 1;
            }

            animator.SetTrigger("flipAnimation");
        }
    }
}