using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextKaydır : MonoBehaviour {

    public Text tx;
    public float speed=1;
	// Update is called once per frame
	void Update () {
        if (tx.transform.position.y >= 146 || tx.transform.position.y <= -133)
        {
            speed *= -1;
        }
        tx.transform.position = new Vector3(tx.transform.position.x, tx.transform.position.y + Time.deltaTime * speed, tx.transform.position.z);
    }
}
