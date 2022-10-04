using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Button[] Lvls;
    public GameObject LoadingScreen;
    public GameObject LoadingScreen_spa;
    public Text lists;
    public Text lvls;
    [SerializeField] private int UnLockLvl;
    [SerializeField]
    private LocalizationManager localizationManager;

    void Start()
    {

        lvls.text += " " + PlayerPrefs.GetInt("levels", 1) + " / 8";
        PlayerPrefs.SetInt("levels", 7);
        UnLockLvl = PlayerPrefs.GetInt("levels", 1);

        for (int i = 0; i < UnLockLvl && Lvls[i]; i++)
        {
            Lvls[i].interactable = true;
        }
    }

    void Update()
    {
        if(GameObject.Find("Button (1)"))
        {
            lists.text = "1 / 2";
        }
        else
        {
            lists.text = "2 / 2";
        }
    }

    public void LoadLvl(int lvlIndex)
    {
        Debug.Log(localizationManager.CurrentLanguage);
        if (localizationManager.CurrentLanguage == "ru_RU")
        {
            LoadingScreen.SetActive(true);
        }
        else if (localizationManager.CurrentLanguage == "spa_SPA")
        {
            LoadingScreen_spa.SetActive(true);
        }
        SceneManager.LoadScene(lvlIndex);
    }
    
    public void UpdateLvls()
    {
        lvls.text += " " + PlayerPrefs.GetInt("levels", 1) + " / 8";
    }
}
