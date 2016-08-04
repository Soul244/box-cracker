using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class AnaMenüyeDön : MonoBehaviour {
    public void Buton1()
    {
        GetComponent<AudioSource>().Play();
        SceneManager.LoadScene("Ana Menü");
    }
}
