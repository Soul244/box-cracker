using UnityEngine;
using System.Collections;

public class BölümSeç : MonoBehaviour {
    public void OnMouseUpAsButton()
    {
        GetComponent<AudioSource>().Play();
        Application.LoadLevel("LevelMenü");
    }
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
