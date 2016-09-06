using UnityEngine;
using System.Collections;

public class OyunSatınAl : MonoBehaviour {
    public void OnMouseUpAsButton()
    {
        GetComponent<AudioSource>().Play();
    }
}
