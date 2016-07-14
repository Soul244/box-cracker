using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BölümSeç : MonoBehaviour {
    Text tx;
    int can;
    bool oynat;
    public void OnMouseUpAsButton()
    {
        GetComponent<AudioSource>().Play();
        if (caneksilt())
        {
            SceneManager.LoadScene("1");
        }
    }
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    bool caneksilt()
    {
        tx = GameObject.Find("Can Sayısı").GetComponent<Text>();
        can = Convert.ToInt16(tx.text);
        if (can > 0)
        {
            oynat = true;
            tx.text = Convert.ToString(can - 1);
            PlayerPrefs.SetInt("Can Sayısı", can - 1);
        }
        else
        {
            oynat = false;
        }
        return oynat;
    }
}
