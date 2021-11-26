using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlatform : MonoBehaviour
{
    public GameObject BrokenOj;
    public GameObject ObjectNew1;
    public GameObject ObjectNew2;
    public GameObject ObjectNew3;
    public Sprite sprite1;
    public AudioClip clip;
    public AudioClip clip2;
    private bool broking;
    private float timer;
    private bool proigr;
    // Start is called before the first frame update
    void Start()
    {
        broking = false;
        timer = 0;
        proigr = true; 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (broking)
        {
            if (timer > 2.8 && proigr)
            {
                proigr = false;
                GetComponent<AudioSource>().PlayOneShot(clip2);
            }
            timer += Time.deltaTime;
            if (timer > 3)
            {
                //ObjectOld.SetActive(false);
                BrokenOj.SetActive(false);
                Instantiate(ObjectNew1, transform.position, Quaternion.identity);
                Instantiate(ObjectNew2, transform.position, Quaternion.identity);
                Instantiate(ObjectNew3, transform.position, Quaternion.identity);
                //ObjectNew1.SetActive(true);
                //ObjectNew2.SetActive(true);
                //ObjectNew3.SetActive(true);
                Destroy(this.gameObject);
                //broking = false;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        print("Просчёт коллайдера произошёл, но не определился");
        if (col.collider.tag == "Player")
        {
            print("Просчёт коллайдера произошёл");
            broking = true;
            GetComponent<SpriteRenderer>().sprite = null;
            BrokenOj.SetActive(true);
            //spriteRender.sprite = sprite1;
            //sprite.transform.localScale = new Vector3(0.58f, 0.58f, 1f);
            GetComponent<AudioSource> ().PlayOneShot (clip);
        }

    }
}
