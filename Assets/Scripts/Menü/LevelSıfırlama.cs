using UnityEngine;
using System.Collections;

public class MenuSıfırlama : MonoBehaviour {

	// Use this for initialization
	void Start () {        
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void Buton()
    {
        PlayerPrefs.DeleteAll();
        Application.LoadLevel("Anamenü");
    }
}
