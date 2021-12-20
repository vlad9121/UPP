using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Restart : MonoBehaviour
{
    public Text txt;

    public void Load_Menu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void Restart_Scene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void Next_Level()
    {
        if(SceneManager.GetActiveScene().buildIndex < SceneManager.sceneCountInBuildSettings &&
            SceneManager.GetActiveScene().buildIndex < PlayerPrefs.GetInt("levels", 1))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
            Time.timeScale = 1;
        }
    }

    public void Ñontinue()
    {
        if (GameObject.Find("Player").GetComponent<Player>().health > 0)
        {
            this.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
