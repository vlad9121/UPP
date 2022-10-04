using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnSwitchLang : MonoBehaviour
{
    [SerializeField]
    private LocalizationManager localizationManager;

    public void OnButtonClick()
    {
        localizationManager.CurrentLanguage = name;
       GameObject.Find("Menu").GetComponent<Menu>().UpdateLvls();
    }
        
}
