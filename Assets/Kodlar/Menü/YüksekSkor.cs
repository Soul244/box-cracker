using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class YüksekSkor : MonoBehaviour {
    Text highscore;
    void Start()
    {
        highscore = GetComponent<Text>();
        highscore.text = "High Score: " + Convert.ToString(PlayerPrefs.GetInt("High Score"));
    }
}
