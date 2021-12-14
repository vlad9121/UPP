using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject Star;
    public int health = 0;
    public int Dir;
    public float ImmortalTime;
    public float end_line;
    public Image[] hearts;
    public SpriteRenderer spriteRend;
    public GameObject reload_button;
    public bool dmg;
    public bool isThrow;
    private Material matBlink;
    private Material matDefault;

    void Start()
    {
        //health = hearts.Length;
        matBlink = Resources.Load("PlayerBlink", typeof(Material)) as Material;
        matDefault = spriteRend.material;
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

        if (Input.GetKey(KeyCode.F) && !isThrow)
        {
            Shoot();
        }

    }

    void Shoot()
    {
        isThrow = true;
        if (transform.eulerAngles.y == 0)
        {
            Dir = 1;
        }
        else
        {
            Dir = -1;
        }
        Instantiate(Star, transform.position + new Vector3(Dir, 1, 0), Quaternion.identity);
        //Star.GetComponent<Star>()/
    }

    void ResetMaterial()
    {
        dmg = false;
        spriteRend.color = new Color(1, 1, 1);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Trap")
        {
            Damage();
        }
    }

    public void Damage()
    {
        if (!dmg)
        {
            health--;
            spriteRend.color = new Color(1,0,0);
            dmg = true;
            Invoke("ResetMaterial", ImmortalTime);
        }
    }
}
