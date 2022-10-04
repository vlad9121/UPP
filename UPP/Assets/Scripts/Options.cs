using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : MonoBehaviour
{
    public GameObject Options_menu;
    public GameObject Close_button;

    private void Start()
    {
    }

    public void OptionsOn()
    {
        Options_menu.SetActive(!Options_menu.activeInHierarchy);
        Close_button.SetActive(!Close_button.activeInHierarchy);
    }
}
