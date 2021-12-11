using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Trap : MonoBehaviour
{
    public AudioClip damagefire;
    private AudioSource trapAudio;

    // Start is called before the first frame update
    void Start()
    {
        trapAudio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (!trapAudio.isPlaying)
                trapAudio.PlayOneShot(damagefire);

        }
    }
}
