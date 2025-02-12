using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private int intialWayPoint;

    public Transform[] waypoints;
    public float speed = 5f;
    private int currentWaypoint = 0;

    [SerializeField] private EnemyDirection enemyDirection;

    enum EnemyDirection
    {
        Vertical,
        Horizontal
    }

    private void Start()
    {
        currentWaypoint = intialWayPoint;
        transform.position = waypoints[currentWaypoint].position;

        if (enemyDirection == EnemyDirection.Horizontal)
        {
            animator.SetTrigger("EnemyFrontAnimation");
        }
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypoint].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, waypoints[currentWaypoint].position) < 0.1f)
        {
            if (currentWaypoint + 1 >= waypoints.Length)
            {
                if (enemyDirection == EnemyDirection.Vertical)
                {
                    animator.SetTrigger("EnemyBackAnimation");
                }

                currentWaypoint = 0;
                this.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                if (enemyDirection == EnemyDirection.Vertical)
                {
                    animator.SetTrigger("EnemyFrontAnimation");
                }

                currentWaypoint = currentWaypoint + 1;
                this.transform.rotation = Quaternion.Euler(0, 0, 180);
            }
        }
    }
}