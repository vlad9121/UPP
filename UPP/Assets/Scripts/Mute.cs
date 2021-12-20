using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mute : MonoBehaviour
{
    private Image button;

    private void Start()
    {
        button = GetComponent<Image>();
    }

    private void Update()
    {
        if (AudioListener.volume == 0)
        {
            button.color = new Color(1, 1, 1, 0.5f);
        }else{
            button.color = new Color(1, 1, 1, 1);
        }
    }

    public void Mute_Sound()
    {
        if (AudioListener.volume == 0)
        {
            AudioListener.volume = 1;
            button.color = new Color(1, 1, 1, 1);
        }
        else{
            AudioListener.volume = 0;
            button.color = new Color(1, 1, 1, 0.5f);
        }
    }
}
