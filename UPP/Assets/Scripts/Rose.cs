using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rose : MonoBehaviour
{
    public float ClearSpeed = 1f;
    public float RiseSpeed = 1f;
    //public float AnimSpeed = 0.07f;

    private GameObject ScoreTxt;
    private bool take;
    private Renderer RoseRend;
    private Color RoseColor;
    public AudioClip RosePickup;
    private AudioSource RoseAudio;

    void Start()
    {
        ScoreTxt = GameObject.Find("Score");
        RoseAudio = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
         ScoreTxt = GameObject.Find("Score");
        if (take)
        {
            RoseColor = GetComponent<Renderer>().material.color;
            if (RoseColor.a > 0)
            {
                RoseColor.a -= ClearSpeed * Time.deltaTime;
                GetComponent<Renderer>().material.color = RoseColor;
                transform.position = new Vector3(transform.position.x, transform.position.y + RiseSpeed * Time.deltaTime, 0);
            }
            if (RoseColor.a <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player" && !take)
        {
            take = true;
            if (!RoseAudio.isPlaying)
                RoseAudio.PlayOneShot(RosePickup);
            ScoreTxt.GetComponent<Score>().TakenRoses++;
        }
        //StartCoroutine("Anim");            

    }
    }
    //IEnumerator Anim()
    //{
    //    RoseColor = GetComponent<Renderer>().material.color;
    //    while(RoseColor.a > 0)
    //    {
    //        RoseColor.a -= ClearSpeed * Time.deltaTime;
    //        GetComponent<Renderer>().material.color = RoseColor;
    //        transform.position = new Vector3(0, transform.position.y + RiseSpeed * Time.deltaTime, 0);
    //        yield return new WaitForSeconds(AnimSpeed);
    //    }
    //    Destroy(this.gameObject);
    //}

