using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrevLvl : MonoBehaviour
{
    public GameObject[] LvlList;
    public int �urrentList = 0;
    public GameObject NextButton;

    void Start()
    {

    }

    void Update()
    {
        if (�urrentList > 0)
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
            LvlList[�urrentList].SetActive(false);
            �urrentList--;
            LvlList[�urrentList].SetActive(true);
            NextButton.GetComponent<NextLvl>().�urrentList--;
        }
    }
}