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
        label.text = "0";
    }

    private void OnEnable()
    {
        DistanceManagement.OnDistanceChanged += UpdateDistanceText;
    }

    //private void OnDisable()
    //{
    //DistanceManagement.OnDistanceChanged += UpdateDistanceText;
    //}

    private void UpdateDistanceText(float distance)
    {
        label.text = distance.ToString("F2");
    }
}
