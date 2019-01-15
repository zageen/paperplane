using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneLoader : MonoBehaviour {

    //Menu Manager
    public GameObject creditPanel;
    public GameObject levelselectPanel;
    public GameObject optionsPanel;
    public GameObject titlePanel;

    private LoadedPanel loadedPanel;

    public void LoadLevel()
    {
        SceneManager.LoadScene("Scenetest1");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void LoadLevelSelect()
    {
        titlePanel.SetActive(false);
        levelselectPanel.SetActive(true);

        loadedPanel = LoadedPanel.LevelSelect;
    }
  

    public void LoadOptions()
    {
        titlePanel.SetActive(false);
        optionsPanel.SetActive(true);

        loadedPanel = LoadedPanel.Options;
    }

    public void LoadCredits()
    {
        creditPanel.SetActive(true);
        titlePanel.SetActive(false);


        loadedPanel = LoadedPanel.Credits;
    }

    public void LoadtitleScreen()
    {
        switch (loadedPanel)
        {
            case (LoadedPanel.Credits):
                creditPanel.SetActive(false);
                break;
            case (LoadedPanel.LevelSelect):
                levelselectPanel.SetActive(false);
                break;
            case (LoadedPanel.Options):
                optionsPanel.SetActive(false);
                break;
            case (LoadedPanel.Title):
                break;


        }
        loadedPanel = LoadedPanel.Title;
        titlePanel.SetActive(true);
    }

    public enum LoadedPanel
    {
        LevelSelect,
        Credits,
        Options,
        Title
    }

    public void ChangeVolume()
    {

    }
}
