using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public GameObject Menu;

    //private int Roses;
    private GameObject ScoreObj;

    void Start()
    {
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
            Time.timeScale = 0;
            Menu.SetActive(true);
        }
    }
}
