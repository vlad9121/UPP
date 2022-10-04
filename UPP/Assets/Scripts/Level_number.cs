using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class Level_number : MonoBehaviour
{
    public Text lvl;
    private Scene scene;
    private int lvl_number;
    void Start()
    {
        scene = SceneManager.GetActiveScene();
        int.TryParse(string.Join("", scene.name.Where(c => char.IsDigit(c))), out lvl_number);
        lvl.text += " " + lvl_number;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
