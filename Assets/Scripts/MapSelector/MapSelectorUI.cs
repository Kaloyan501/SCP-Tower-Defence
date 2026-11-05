using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class MapEntry
{
    public string mapName;
    public Texture2D image;

    [TextArea(2, 5)]
    public string description;
}

public class MapSelectorUI : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private RectTransform content;
    [SerializeField] private MapCardUI cardPrefab;
    [SerializeField] private TMP_Text selectedMapText;

    [Header("Maps")]
    [SerializeField]
    private List<MapEntry> maps =
        new List<MapEntry>();

    public UnityEvent<int> onMapSelected;

    public int SelectedMapIndex { get; private set; } = -1;

    private void Start()
    {
        BuildList();
    }

    public void BuildList()
    {
        // Remove existing cards
        foreach (Transform child in content)
        {
            Destroy(child.gameObject);
        }

        // Generate a card for every map
        for (int i = 0; i < maps.Count; i++)
        {
            int index = i;
            MapEntry map = maps[i];

            MapCardUI card = Instantiate(cardPrefab, content);

            card.Setup(
                map.mapName,
                map.image,
                map.description,
                () => SelectMap(index)
            );
        }
    }

    private void SelectMap(int index)
    {
        if (index < 0 || index >= maps.Count)
            return;

        SelectedMapIndex = index;

        if (selectedMapText != null)
            selectedMapText.text = maps[index].mapName;

        onMapSelected?.Invoke(index);

        Debug.Log("Selected map: " + maps[index].mapName);
    }
}
