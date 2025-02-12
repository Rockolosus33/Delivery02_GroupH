using UnityEngine;
using UnityEngine.UI;

public class TextDistance : MonoBehaviour
{
    private Text label;

    private void Awake()
    {
        label = GetComponent<Text>();
    }

    private void Start()
    {
        label.text = "Distance: 0 m";
    }

    private void OnEnable()
    {
        DistanceManagement.OnDistanceChanged += UpdateDistanceText;
    }

    private void OnDisable()
    {
        DistanceManagement.OnDistanceChanged -= UpdateDistanceText;
    }

    private void UpdateDistanceText(float distance)
    {
        label.text = "Distance: " + distance.ToString("F2") + "m";
    }
}