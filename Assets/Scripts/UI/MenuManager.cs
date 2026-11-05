using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject titleScreen;
    [SerializeField] private GameObject settings;

    public void OpenSettings()
    {
        titleScreen.SetActive(false);
        settings.SetActive(true);
    }

    public void BackToTitle()
    {
        settings.SetActive(false);
        mapSelector.SetActive(false);
        titleScreen.SetActive(true);
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

    [SerializeField] private GameObject mapSelector;

    public void OpenStart()
    {
        titleScreen.SetActive(false);
        mapSelector.SetActive(true);
    }
}
