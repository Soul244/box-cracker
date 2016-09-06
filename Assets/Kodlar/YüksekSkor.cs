using UnityEngine;
using System.Collections;

public class YüksekSkor : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<TextMesh>().text = PlayerPrefs.GetInt("High Score").ToString();
        Debug.Log(PlayerPrefs.GetInt("High Score").ToString());
    }
}
