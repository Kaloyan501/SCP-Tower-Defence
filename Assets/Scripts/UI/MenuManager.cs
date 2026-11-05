using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject titleScreenPanel;
    [SerializeField] private GameObject settingsPanel;

    public void OpenSettings()
    {
        titleScreenPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void BackToTitle()
    {
        settingsPanel.SetActive(false);
        titleScreenPanel.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }

    [SerializeField] private Toggle fullscreenToggle;

    private void Start()
    {
        fullscreenToggle.isOn = Screen.fullScreen;
        fullscreenToggle.onValueChanged.AddListener(SetFullscreen);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
