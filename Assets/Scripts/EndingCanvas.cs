using TMPro;
using UnityEngine;

public class EndingCanvas : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI finalTimeText;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject losePanel;

    void Start()
    {

        if (TimeManager.instance.GetTime() > 60f)
        {
            finalTimeText.text = "Total time: " + 60 + " seconds";
        }
        else
        {
            finalTimeText.text = "Total time: " + TimeManager.instance.GetTime().ToString("F2") + " seconds";
        }

        winPanel.SetActive(false);
        losePanel.SetActive(true);
    }
}
