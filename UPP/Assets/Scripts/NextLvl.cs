using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextLvl : MonoBehaviour
{
    public GameObject[] LvlList;
    public GameObject PrevButton;
    public int �urrentList = 0;

    void Start()
    {
        
    }

    void Update()
    {
        if (LvlList.Length > �urrentList + 1)
        {
            GetComponent<Button>().interactable = true;
        }else{
            GetComponent<Button>().interactable = false;
        }
    }

    public void Next()
    {
        if (LvlList.Length > �urrentList + 1)
        {
            LvlList[�urrentList].SetActive(false);
            �urrentList++;
            LvlList[�urrentList].SetActive(true);
            PrevButton.GetComponent<PrevLvl>().�urrentList++;
        }
    }
}
