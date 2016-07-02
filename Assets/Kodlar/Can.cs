using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Can : MonoBehaviour {
    public Text can;
    public Text süre;
    float zaman = 0f;
    float cansayisi = 0f;
    float süresayisi = 300f;
    int gecici = 0;
    int dk, sn = 0;
	// Use this for initialization
	void Start () {
        cansayisi = float.Parse(can.text);
        süre.text = süresayisi.ToString();             
    }	
	// Update is called once per frame
	void Update () {
        if (cansayisi != 5)
        {
            zaman += Time.deltaTime;
            gecici = Convert.ToInt32(süresayisi - int.Parse(zaman.ToString().Split('.')[0]));
            if (gecici>59)
            {
                dk = gecici / 60;
                sn = gecici % 60;
            }
            else
            {
                dk = 00;
                sn = gecici;
            }
            if (sn == 0)
            {
                süre.text = dk.ToString() + ":" + sn.ToString()+"0";
            }
            else
            {
                süre.text = dk.ToString() + ":" + sn.ToString();
            }   
            if (zaman >= süresayisi)
            {
                can.text = (cansayisi + 1).ToString();
                cansayisi++;
                zaman = 0;
            }
        }
        else
        {
            süre.text = "";
        }
    }
}
