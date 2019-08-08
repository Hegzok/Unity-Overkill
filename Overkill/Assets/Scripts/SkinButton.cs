using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkinButton : MonoBehaviour
{
    [SerializeField] private Skin skin;

    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI skinName;

    // Use this for initialization
    void Start()
    {
        skinName.text = skin.Name;
        icon.sprite = skin.Icon;
    }

    public void UpdateSkin()
    {
        EventsManager.UpdateSkin(skin);
    }
}
