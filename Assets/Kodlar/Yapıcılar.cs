﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class Yapıcılar : MonoBehaviour {

public void OnMouseUpAsButton()
    {
        GetComponent<AudioSource>().Play();
        SceneManager.LoadScene("Geliştirici");
    }
}
