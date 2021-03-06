using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrevLvl : MonoBehaviour
{
    public GameObject[] LvlList;
    public int ŅurrentList = 0;
    public GameObject NextButton;

    void Start()
    {

    }

    void Update()
    {
        if (ŅurrentList > 0)
        {
            GetComponent<Button>().interactable = true;
        }
        else
        {
            GetComponent<Button>().interactable = false;
        }
    }

    public void Prev()
    {
        if (LvlList.Length - 1 >= 0)
        {
            LvlList[ŅurrentList].SetActive(false);
            ŅurrentList--;
            LvlList[ŅurrentList].SetActive(true);
            NextButton.GetComponent<NextLvl>().ŅurrentList--;
        }
    }
}