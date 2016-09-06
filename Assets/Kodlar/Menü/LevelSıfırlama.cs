using UnityEngine;
using System.Collections;

public class MenuSıfırlama : MonoBehaviour {
    public void Buton()
    {
        PlayerPrefs.DeleteAll();
        Application.LoadLevel("Anamenü");
    }
}
