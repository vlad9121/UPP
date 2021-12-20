using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    public float force;
    public int Dir = 0;
    private Rigidbody2D rg;
     public AudioClip spawn;
    private Transform Player;

    void Start()
    {
        GetComponent<AudioSource>().PlayOneShot(spawn);
        Dir = GameObject.Find("Player").GetComponent<Player>().Dir;
        Player = GameObject.Find("Player").GetComponent<Transform>();
        rg = GetComponent<Rigidbody2D>();
        rg.velocity = new Vector2(Dir * transform.localScale.x, 1) * force;
    }

    void Update()
    {
        //rg.velocity = new Vector2(transform.localScale.x, 1) * force;
        if (transform.position.y < -10)
        {
            GameObject.Find("Player").GetComponent<Player>().isThrow = false;
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject.Find("Player").GetComponent<Player>().isThrow = false;
        Destroy(this.gameObject);
    }
}
