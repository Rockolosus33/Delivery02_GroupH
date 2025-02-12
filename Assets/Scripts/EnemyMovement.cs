using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private int intialWayPoint;

    public float StayTime;
    public Transform[] waypoints;
    public float speed = 5f;
    private int currentWaypoint = 0;
    private int initalAngle = 0;

    [SerializeField] private EnemyDirection enemyDirection;
    private EnemyState curretState;
    private float _timer;

    enum EnemyDirection
    {
        Vertical,
        Horizontal
    }

    enum EnemyState
    {
        Idle,
        Patrol
    }

    private void Start()
    {
        _timer = 0.0f;

        currentWaypoint = intialWayPoint;
        curretState = EnemyState.Idle;
        transform.position = waypoints[currentWaypoint].position;
        initalAngle = 0;

        if (enemyDirection == EnemyDirection.Horizontal)
        {
            animator.SetTrigger("EnemyFrontAnimation");

            if (intialWayPoint == 0)
            {
                initalAngle = 270;
            }
            else
            {
                initalAngle = -90;
            }

            this.transform.rotation = Quaternion.Euler(0, 0, initalAngle);
        }
    }

    void Update()
    {
        if (curretState == EnemyState.Patrol)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypoint].position, speed * Time.deltaTime);

            if (Vector2.Distance(transform.position, waypoints[currentWaypoint].position) < 0.1f)
            {
                if (currentWaypoint + 1 >= waypoints.Length)
                {
                    if (enemyDirection == EnemyDirection.Vertical)
                    {
                        animator.SetTrigger("EnemyBackAnimation");
                        this.transform.rotation = Quaternion.Euler(0, 0, initalAngle);
                    }
                    else
                    {
                        this.transform.rotation = Quaternion.Euler(0, 0, initalAngle);
                    }

                    currentWaypoint = 0;
                }
                else
                {
                    if (enemyDirection == EnemyDirection.Vertical)
                    {
                        animator.SetTrigger("EnemyFrontAnimation");
                    }

                    currentWaypoint = currentWaypoint + 1;
                    this.transform.rotation = Quaternion.Euler(0, 0, initalAngle + 180);
                }

                curretState = EnemyState.Idle;
            }
        }
        else if (curretState == EnemyState.Idle)
        {
            if (IsTimeUp())
            {
                curretState = EnemyState.Patrol;
                _timer = 0f;
            }
        }
    }

    private bool IsTimeUp()
    {
        _timer += Time.deltaTime;
        return (_timer > StayTime);
    }
}