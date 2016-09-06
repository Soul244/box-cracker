using UnityEngine;
using System.Collections;

public class MesajÖzeliği : MonoBehaviour {
    public float görünmeSüresi;
	// Update is called once per frame
	void Update () {
        görünmeSüresi -= Time.deltaTime;
        if (görünmeSüresi<=0)
        {
            Destroy(this.gameObject);
        }
	}
}
