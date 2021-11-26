using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int health = 0;
    public float end_line;
    public Image[] hearts;
    public GameObject reload_button;

    void Start()
    {
        //health = hearts.Length;
    }

    void FixedUpdate()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].color = new Color(1, 0, 0);
            }else {
                hearts[i].color = new Color(0.2f, 0.2f, 0.2f);
            }
        }

        if (health <= 0)
        {
            Time.timeScale = 0;
            reload_button.SetActive(true);
        }

        if (transform.position.y < end_line)
        {
            health = 0;
        }
    }
}
