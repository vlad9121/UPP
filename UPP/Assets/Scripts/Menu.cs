using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Button[] Lvls;
    public GameObject LoadingScreen;
    public Text lists;
    public Text lvls;
    [SerializeField] private int UnLockLvl;

    void Start()
    {
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
        lvls.text = "Пройдено уровней " + PlayerPrefs.GetInt("levels", 1) + " / 8";
    }

    public void LoadLvl(int lvlIndex)
    {
        LoadingScreen.SetActive(true);
        SceneManager.LoadScene(lvlIndex);
    }
}
