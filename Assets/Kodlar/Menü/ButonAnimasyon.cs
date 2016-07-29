using UnityEngine;
using System.Collections;

public class ButonAnimasyon : MonoBehaviour {
    Vector2 boyut,makBoyut;
    bool büyült;
	// Use this for initialization
	void Start () {
        büyült = true;
        boyut = transform.localScale;
        makBoyut = boyut + new Vector2(.05f, .05f);
	}
	
	// Update is called once per frame
	void Update () {
        if (büyült)
        {
            transform.localScale = Vector2.Lerp(transform.localScale, makBoyut, 13f*Time.deltaTime);
            if ((Vector2)transform.localScale==makBoyut)
            {
                büyült = false;
            }
        }
        else
        {
            transform.localScale = Vector2.Lerp(transform.localScale, boyut, 13f*Time.deltaTime);
            if ((Vector2)transform.localScale == boyut)
            {
                büyült = true;
            }
        }
	}
}
