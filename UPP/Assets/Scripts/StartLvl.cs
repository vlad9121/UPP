using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartLvl : MonoBehaviour
{
    public Button[] Lvls;
    private int UnLockLvl;

    void Start()
    {
        UnLockLvl = PlayerPrefs.GetInt("levels", 1);

        for(int i = 0; i < UnLockLvl; i++)
        {
            Lvls[i].interactable = true;
        }
    }

    void Update()
    {
        
    }
}
