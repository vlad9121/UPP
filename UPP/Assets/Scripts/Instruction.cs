using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instruction : MonoBehaviour
{
    public void Remove()
    {
        Destroy(this.gameObject);
    }
}
