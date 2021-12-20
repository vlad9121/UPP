using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    private GameObject Pause_Menu;

    private void Start()
    {
        Pause_Menu = GameObject.Find("Player").GetComponent<Player>().reload_button;
    }

    public void PauseOn()
    {
        Time.timeScale = 0;
        Pause_Menu.SetActive(true);
    }
}
