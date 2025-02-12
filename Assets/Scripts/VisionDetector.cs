using System;
using System.Collections.Generic;
using UnityEngine;

public class VisionDetector : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private GameObject playerObject;
    public LayerMask WhatIsPlayer;
    public LayerMask WhatIsVisible;
    private AudioSource audioSource;
    public float DetectionRange;
    public float VisionAngle;

    public static Action OnChangeFinalScene;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, DetectionRange);

        Vector3 direction1 = Quaternion.AngleAxis(VisionAngle / 2, Vector3.forward) * transform.up;
        Vector3 direction2 = Quaternion.AngleAxis(-VisionAngle / 2, Vector3.forward) * transform.up;

        Gizmos.color = Color.red;

        Gizmos.DrawRay(transform.position, direction1 * DetectionRange);
        Gizmos.DrawRay(transform.position, direction2 * DetectionRange);

        Gizmos.color = Color.white;
    }

    private void Update()
    {
        if (PlayerInRange())
        {
            if (PlayerInAngle(playerTransform))
            {
                if (PlayerIsVisible(playerTransform))
                {
                    if (!audioSource.isPlaying)
                    {
                        playerObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
                        StartCoroutine(PlayAudioAndNotify());
                    }
                }
            }
        }
    }

    private System.Collections.IEnumerator PlayAudioAndNotify()
    {
        audioSource.Play();
        yield return new WaitForSeconds(audioSource.clip.length);
        OnChangeFinalScene?.Invoke();
    }

    private bool PlayerInRange()
    {
        Collider2D playerCollider = Physics2D.OverlapCircle(transform.position, DetectionRange, WhatIsPlayer);
        return playerCollider != null;
    }

    private bool PlayerInAngle(Transform target)
    {
        Vector2 targetDir = target.position - transform.position;
        float angle = Vector2.Angle(targetDir, transform.up);
        return angle <= VisionAngle / 2;
    }

    private bool PlayerIsVisible(Transform target)
    {
        Vector3 dir = target.position - transform.position;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir.normalized, DetectionRange, WhatIsVisible);
        return hit.collider != null && hit.collider.transform == target;
    }
}
