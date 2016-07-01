using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BolumMantık : MonoBehaviour {
    public Button y1,y2,y3;
	// Use this for initialization
	void Start () {
        if (gameObject.name == "Level 1 Buton")
        {
            if (PlayerPrefs.GetInt(gameObject.name) == 0)
            {
                GetComponent<Button>().interactable = true;
                y1.interactable = false;
                y2.interactable = false;
                y3.interactable = false;
            }
            if (PlayerPrefs.GetInt(gameObject.name) == 1)
            {
                GetComponent<Button>().interactable = true;
                y1.interactable = false;
                y2.interactable = false;
                y3.interactable = false;
            }
            if (PlayerPrefs.GetInt(gameObject.name) == 2)
            {
                GetComponent<Button>().interactable = true;
                y1.interactable = true;
                y2.interactable = false;
                y3.interactable = false;
            }
            if (PlayerPrefs.GetInt(gameObject.name) == 3)
            {
                GetComponent<Button>().interactable = true;
                y1.interactable = true;
                y2.interactable = true;
                y3.interactable = false;
            }
            if (PlayerPrefs.GetInt(gameObject.name) == 4)
            {
                GetComponent<Button>().interactable = true;
                y1.interactable = true;
                y2.interactable = true;
                y3.interactable = true;
            }
        }
        else
        {
            if (PlayerPrefs.GetInt(gameObject.name) == 0)
            {
                GetComponent<Button>().interactable = false;
                y1.interactable = false;
                y2.interactable = false;
                y3.interactable = false;
            }
            if (PlayerPrefs.GetInt(gameObject.name) == 1)
            {
                GetComponent<Button>().interactable = true;
                y1.interactable = false;
                y2.interactable = false;
                y3.interactable = false;
            }
            if (PlayerPrefs.GetInt(gameObject.name) == 2)
            {
                GetComponent<Button>().interactable = true;
                y1.interactable = true;
                y2.interactable = false;
                y3.interactable = false;
            }
            if (PlayerPrefs.GetInt(gameObject.name) == 3)
            {
                GetComponent<Button>().interactable = true;
                y1.interactable = true;
                y2.interactable = true;
                y3.interactable = false;
            }
            if (PlayerPrefs.GetInt(gameObject.name) == 4)
            {
                GetComponent<Button>().interactable = true;
                y1.interactable = true;
                y2.interactable = true;
                y3.interactable = true;
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
    }
}
