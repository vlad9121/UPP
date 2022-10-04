using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class npc : MonoBehaviour
{
    public GameObject Menu;
    public GameObject Task;
    public GameObject Score;
    private bool givetask;

    //private int Roses;
    private int CurrentLvl;
    private GameObject ScoreObj;

    void Start()
    {
        CurrentLvl = SceneManager.GetActiveScene().buildIndex; 
        givetask = false;
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
        if (givetask == true) {
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
        if (collision.tag == "Player" && givetask == false) {
            givetask = true;
            Task.SetActive(true);
            Score.SetActive(true);
            ScoreObj = GameObject.Find("Score");
            Destroy(Task, 2f);
        }
    }
}
