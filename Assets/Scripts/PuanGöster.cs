using UnityEngine;
using System.Collections;

public class PuanGöster : MonoBehaviour {
    Ray ışın;
    RaycastHit darbe;
    bool puanGöster = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        ışın = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (KutuKontrol.tıklananKutu != new Vector3(-1, -1, -1) && Physics.Raycast(ışın, out darbe,Mathf.Infinity))
        {
            puanGöster = darbe.collider.tag == "Küp" ? true : false;
        }

    }
    void OnGUI()
    {
        if (puanGöster) //Artık puanı nasıl göstericeğimize karar verdiğimizde şekillendiririz.
        {
            GUI.Label(new Rect((Vector2)KutuKontrol.tıklananKutu, new Vector2(200, 60)), KutuKontrol.sonPuan.ToString());
        }
    }
}
