using UnityEngine;
using System.Collections;

public class OyunSatınAl : MonoBehaviour {
    public void OnMouseUpAsButton()
    {
        GetComponent<AudioSource>().Play();
    }
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
