using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextLvl : MonoBehaviour
{
    public GameObject[] LvlList;
    public GameObject PrevButton;
    public int ÑurrentList = 0;

    void Start()
    {
        
    }

    void Update()
    {
        if (LvlList.Length > ÑurrentList + 1)
        {
            GetComponent<Button>().interactable = true;
        }else{
            GetComponent<Button>().interactable = false;
        }
    }

    public void Next()
    {
        if (LvlList.Length > ÑurrentList + 1)
        {
            LvlList[ÑurrentList].SetActive(false);
            ÑurrentList++;
            LvlList[ÑurrentList].SetActive(true);
            PrevButton.GetComponent<PrevLvl>().ÑurrentList++;
        }
    }
}
