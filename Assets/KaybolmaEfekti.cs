using UnityEngine;
using System.Collections;

public class KaybolmaEfekti : MonoBehaviour {
    public float kaybolmaSüresi = 0.5f;
    Color renk;
	// Use this for initialization
	void Start () {
        renk = GetComponent<TextMesh>().color;
	}
	
	// Update is called once per frame
	void Update () {
        kaybolmaSüresi -= Time.deltaTime;
        if (kaybolmaSüresi<=0)
        {
            Destroy(gameObject);
        }
        renk.a -= 0.01f;
        transform.position = new Vector2(transform.position.x, transform.position.y + 0.05f);
        GetComponent<Renderer>().material.color = renk;
	}
}
