using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ArkaplanKaydır : MonoBehaviour {
    public float speed = 0.5f;
	// Update is called once per frame
	void Update () {
        Vector2 offset = new Vector2(Time.time * speed, 0);
        GetComponent<Renderer>().material.mainTextureOffset = offset;
	}
}
