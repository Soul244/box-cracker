using UnityEngine;
using System.Collections;

public class TestKodu : MonoBehaviour {

    public GameObject küp;
    public GameObject patlamaEfekti;
    ParticleSystem patlama;
    GameObject yokEdilecekPatlamaEfekti;
    void Start()
    {
        Instantiate(küp,küp.transform.position,Quaternion.identity);
    }
    void OnMouseUpAsButton()
    {
        Instantiate(patlamaEfekti, küp.transform.position, Quaternion.identity);
    }
}
