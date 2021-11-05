using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private Text ScoreTxt;
    public int Roses = 0;
    void Start()
    {
        ScoreTxt = GetComponent<Text>();
    }

    void FixedUpdate()
    {
        ScoreTxt.text = Roses.ToString();
    }
}
