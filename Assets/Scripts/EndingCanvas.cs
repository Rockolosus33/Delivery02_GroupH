using TMPro;
using UnityEngine;

public class EndingCanvas : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI finalTimeText;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject losePanel;

    private void OnEnable()
    {
        ActiveFinalPanel(GameManager.playerHasWon);
        finalTimeText.text = "High Score: " + TimeManager.instance.GetTime().ToString("F2") + " seconds";
    }

    private void ActiveFinalPanel(bool hasWon)
    {
        if (hasWon)
        {
            winPanel.SetActive(true);
            losePanel.SetActive(false);
        }
        else
        {
            winPanel.SetActive(false);
            losePanel.SetActive(true);
        }
    }
}