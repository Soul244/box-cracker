using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class LevelTıklama : MonoBehaviour {
    // Use this for initialization
    Text tx;
    int can;
    void Start () {
    }
    public GameObject obje;
	// Update is called once per frame
	void Update () {
	
	}
    public void Buton1()
    {
        SceneManager.LoadScene("1");
        caneksilt();
    }
    public void Buton2()
    {
        SceneManager.LoadScene("2");
    }
    public void Buton3()
    {
        SceneManager.LoadScene("3");
    }
    public void Buton4()
    {
        SceneManager.LoadScene("4");
    }
    public void Buton5()
    {
        SceneManager.LoadScene("5");
    }
    public void Buton6()
    {
        SceneManager.LoadScene("6");
    }
    public void Buton7()
    {
        SceneManager.LoadScene("7");
    }
    public void Buton8()
    {
        SceneManager.LoadScene("8");
    }
    public void Buton9()
    {
        SceneManager.LoadScene("9");
    }
    public void Buton10()
    {
        SceneManager.LoadScene("10");
    }
    void caneksilt()
    {
        obje = GameObject.Find("Can Sayısı");
        tx = obje.GetComponent<Text>();
        can = Convert.ToInt16(tx.text);
        tx.text = Convert.ToString(can - 1);
        PlayerPrefs.SetInt("Can Sayısı", can);
    }
}
