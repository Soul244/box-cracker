using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AraMenüFonksiyonları : MonoBehaviour {
    public static bool oyunDurdu = false;
    public static bool oyunBitti = false;
    public static bool geriSayım = false;
    void Awake()
    {
        oyunDurdu = oyunBitti = false;
    }
    public void AraMenüGöster()
    {
        
        if (!oyunBitti)
        {
            Canvas AraMenü = GetComponent<Canvas>();
            if (AraMenü.enabled)
            {
                oyunDurdu = false;
                AraMenü.enabled = false;
            }
            else {
                GameObject.Find("highscore").GetComponent<Text>().text = "High Score: " + PlayerPrefs.GetInt("High Score").ToString();
                GameObject.Find("score").GetComponent<Text>().text = "Score: " + GameObject.Find("Skor").GetComponent<TextMesh>().text;
                AraMenü.enabled = true;
                oyunDurdu = true;
            }
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            AraMenüGöster();
        }
    }
	public void AnaMenüyeDön()
    {
        oyunDurdu = false;
        SceneManager.LoadScene("Ana Menü");
    }
    public void TekrarOyna()
    {
        int can = PlayerPrefs.GetInt("Can Sayısı");       
        if (can!=0)
        {
            PlayerPrefs.SetInt("Can Sayısı", can - 1);
            SceneManager.LoadScene("1");
            oyunDurdu = true;
        }
        oyunDurdu = false;
    }
    public void Cikis()
    {
        Application.Quit();
    }
}
