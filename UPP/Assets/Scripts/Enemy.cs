using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform LeftPoint, RightPoint;
    public float speed;
    public int Dir = 1;
    private GameObject Player;
    private bool Target;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        Player = GameObject.Find("Player");
    }

    void Update()
    {
        CheckTerritory();
        if (!Target)
        {
            Patrol();
        }else{
            Attack();
        }
    }

    void Patrol()
    {
        //anim.SetBool("Attack", false);
        if (transform.position.x > RightPoint.position.x - 0.7f)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            Dir = -1;
        }
        if (transform.position.x < LeftPoint.position.x + 0.7f)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            Dir = 1;
        }
        transform.position += new Vector3(Dir * speed * Time.deltaTime, 0, 0);
    }

    void CheckTerritory()
    {
        if (Player.transform.position.x > LeftPoint.position.x &&
            Player.transform.position.x < RightPoint.position.x &&
            Player.transform.position.y < LeftPoint.position.y + 2 &&
            Player.transform.position.y > LeftPoint.position.y)
        {
            if (transform.position.x < Player.transform.position.x && Dir == 1)
            {
                Target = true;
            }
            else if(transform.position.x > Player.transform.position.x && Dir == -1)
            {
                Target = true;
            }
            
        }else{
            Target = false;
            anim.SetBool("Attack", false);
        }
    }

    void Attack()
    {
        if (transform.position.x < Player.transform.position.x)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            Dir = 1;
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            Dir = -1;
        }
        if (Vector2.Distance(transform.position, Player.transform.position) < 1.2f)//dmg
        {
            anim.SetBool("Attack", true);
            Invoke("Damage", 1f);
        }
        else
        {
            anim.SetBool("Attack", false);
            transform.position += new Vector3(Dir * speed * Time.deltaTime, 0, 0);
        }
    }
    void Damage()
    {
        Player.GetComponent<Player>().Damage();
    }
    IEnumerator Bite()
    {
        yield return new WaitForSeconds(6f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Star")
        {
            Destroy(this.gameObject);
        }
    }
}
