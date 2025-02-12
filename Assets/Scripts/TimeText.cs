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
        label.text = "0";
    }

    private void Update()
    {
        label.text = TimeManager.instance.GetTime().ToString("F0");
    }
}