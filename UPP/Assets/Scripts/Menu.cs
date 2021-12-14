using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Button[] Lvls;
    public GameObject LoadingScreen;
    private int UnLockLvl;

    void Start()
    {
        UnLockLvl = PlayerPrefs.GetInt("levels", 1);

        for (int i = 0; i < UnLockLvl && Lvls[i]; i++)
        {
            Lvls[i].interactable = true;
        }
    }

    void Update()
    {
        
    }

    public void LoadLvl(int lvlIndex)
    {
        LoadingScreen.SetActive(true);
        SceneManager.LoadScene(lvlIndex);
    }
}
