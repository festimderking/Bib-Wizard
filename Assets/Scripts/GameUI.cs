using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public static int score;

    
    public TMP_Text text1;
    public TMP_Text text2;

    // public Image bar;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text1.text = "Score: " + score;
          //  text2.text = "Mana: " + GameObject.FindWithTag("Player").GetComponent<Wizard>().mana;
       // bar.rectTransform.localScale = new Vector3(1, 1, 1);

    }
}
