using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]

public class TimeText : MonoBehaviour
{
    private Text label;

    private void Awake()
    {
        label = GetComponent<Text>();
    }

    private void Start()
    {
        label.text = "Time: " + "0 s";
    }

    private void Update()
    {
        label.text = "Time: " + TimeManager.instance.GetTime().ToString("F0") + " s";
    }
}