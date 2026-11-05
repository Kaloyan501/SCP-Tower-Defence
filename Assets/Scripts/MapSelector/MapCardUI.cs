using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class MapCardUI : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private Image mapImage;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text descriptionText;

    public void Setup(
        string mapName,
        Sprite image,
        string description,
        UnityAction onClick)
    {
        nameText.text = mapName;
        mapImage.sprite = image;
        mapImage.enabled = image != null;
        descriptionText.text = description;

        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(onClick);
    }
}