using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextLvl : MonoBehaviour
{
    public GameObject[] LvlList;
    public GameObject PrevButton;
    public int ŅurrentList = 0;

    void Start()
    {
        
    }

    void Update()
    {
        if (LvlList.Length > ŅurrentList + 1)
        {
            GetComponent<Button>().interactable = true;
        }else{
            GetComponent<Button>().interactable = false;
        }
    }

    public void Next()
    {
        if (LvlList.Length > ŅurrentList + 1)
        {
            LvlList[ŅurrentList].SetActive(false);
            ŅurrentList++;
            LvlList[ŅurrentList].SetActive(true);
            PrevButton.GetComponent<PrevLvl>().ŅurrentList++;
        }
    }
}
