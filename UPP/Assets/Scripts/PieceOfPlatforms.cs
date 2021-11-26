using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceOfPlatforms: MonoBehaviour
{
    public float end_line;
    private Color PlatformClr;
    public float SpeedOfVanish;
    void Start()
    {
        
    }
    void Update()
    {
        PlatformClr = GetComponent<SpriteRenderer>().color;
        if (PlatformClr.a > 0)
        {
            PlatformClr.a -= SpeedOfVanish * Time.deltaTime;
            GetComponent<SpriteRenderer>().color = PlatformClr;
        }
        if(transform.position.y < end_line || PlatformClr.a <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
