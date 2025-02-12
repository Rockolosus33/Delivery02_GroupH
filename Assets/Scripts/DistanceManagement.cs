using System;
using UnityEngine;

public class DistanceManagement : MonoBehaviour
{
    [SerializeField] private Transform player;

    private Vector3 lastPosition;
    private float totalDistance = 0f;

    public static Action<float> OnDistanceChanged;

    void Start()
    {
        lastPosition = player.position;
    }

    void Update()
    {
        float distance = Vector3.Distance(player.position, lastPosition);

        if (distance > 0.01f)
        {
            totalDistance += distance;
            lastPosition = player.position;
            OnDistanceChanged?.Invoke(totalDistance);
        }
    }
}