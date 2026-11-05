
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class MapCardUI : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private RawImage mapImage;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text descriptionText;

    public void Setup(
        string mapName,
        Texture2D image,
        string description,
        UnityAction onClick)
    {
        nameText.text = mapName;

        mapImage.texture = image;
        mapImage.enabled = image != null;

        descriptionText.text = description;

        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(onClick);
    }
}
