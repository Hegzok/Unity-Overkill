using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private PlayerStats playerStats;

    public GameObject GameCanvas;
    public GameObject MenuCanvas;

    public GameObject WeaponsPanel;
    public GameObject SkinsPanel;

    public TextMeshProUGUI GoldText;
    public TextMeshProUGUI LevelText;


    private void Update()
    {
        GoldText.text = "Gold: " + playerStats.Gold.ToString();
        LevelText.text = "Level: " + playerStats.Level.ToString();
    }

    public void PlayGame(bool play)
    {
        EventsManager.ChangeGameState(play);

        if (play)
        {
            GameCanvas.SetActive(true);
            MenuCanvas.SetActive(false);

            Flags.Instance.GamePlaying = true;
        }
        else
        {
            MenuCanvas.SetActive(true);
            GameCanvas.SetActive(false);

            SaveManager.Instance.SaveAllData();
            Flags.Instance.GamePlaying = false;
        }
    }

    public void HandleWeaponsPanel(bool switcher)
    {
        WeaponsPanel.SetActive(switcher);
    }

    public void HandleSkinsPanel(bool switcher)
    {
        SkinsPanel.SetActive(switcher);
    }

}
