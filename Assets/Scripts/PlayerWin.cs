using System;
using UnityEngine;

public class PlayerWin : MonoBehaviour
{
    public static Action OnPlayerWin;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            OnPlayerWin?.Invoke();
        }
    }
}
