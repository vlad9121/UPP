using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private Text ScoreTxt;
    public int Roses;
    private GameObject[] RosesObj;
    public int TakenRoses = 0;
    void Start()
    {
        ScoreTxt = GetComponent<Text>();
        RosesObj = GameObject.FindGameObjectsWithTag("Rose");
        Roses = RosesObj.Length;
    }

    void FixedUpdate()
    {
        ScoreTxt.text = TakenRoses.ToString() + '/' + Roses;
    }
}
