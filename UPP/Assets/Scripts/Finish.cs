using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public GameObject Menu;

    //private int Roses;
    private int CurrentLvl;
    private GameObject ScoreObj;

    void Start()
    {
        CurrentLvl = SceneManager.GetActiveScene().buildIndex; 
        ScoreObj = GameObject.Find("Score");
    }
    //private void FixedUpdate()
    //{
    //    if(ScoreObj.GetComponent<Score>().TakenRoses == Roses)
    //    {
    //        Time.timeScale = 0;
    //        Menu.SetActive(true);
    //    }
    //}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && ScoreObj.GetComponent<Score>().TakenRoses == ScoreObj.GetComponent<Score>().Roses)
        {
            if(CurrentLvl>= PlayerPrefs.GetInt("levels"))
            {
                PlayerPrefs.SetInt("levels", CurrentLvl+1);
            }
            Time.timeScale = 0;
            Menu.SetActive(true);
        }
    }
}
