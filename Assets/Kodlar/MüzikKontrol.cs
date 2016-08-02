using UnityEngine;

public class MüzikKontrol : MonoBehaviour {
    public AudioClip[] Müzikler;
    AudioSource sesKaynağı;
    float beklemeSüresi = 0;
    int müzikSırası = 0;
    bool sesKısık = false;
    public void MüzikAçKapa()
    {
        sesKaynağı.enabled = !sesKaynağı.enabled;
    }
    void MüzikOynat()
    {
        sesKaynağı.clip = Müzikler[müzikSırası];
        sesKaynağı.Play();
        beklemeSüresi = Müzikler[müzikSırası].length;
        müzikSırası++;
        if (müzikSırası==Müzikler.Length)
        {
            müzikSırası = 0;
        }
    }
    void Shuffle<T>(T[] array)
    {
        System.Random random = new System.Random();
        int n = array.Length;
        for (int i = 0; i < n; i++)
        {
            int r = i + (int)(random.NextDouble() * (n - i));
            T t = array[r];
            array[r] = array[i];
            array[i] = t;
        }
    }

    // Use this for initialization
    void Start () {
        sesKısık = false;
        Shuffle(Müzikler);
        sesKaynağı = GetComponent<AudioSource>();
        MüzikOynat();

    }
	
	// Update is called once per frame
	void Update () {
        if (!sesKısık)
        {
            if (UnityEditor.EditorApplication.currentScene == "Assets/Sahneler/1.unity")
            {
                sesKaynağı.volume = 0.15f;
                sesKısık = true;
            }
        }
        else
        {
            if (UnityEditor.EditorApplication.currentScene == "Assets/Sahneler/Ana Menü.unity")
            {
                sesKaynağı.volume = 0.7f;
                sesKısık = false;
            }
        }
        beklemeSüresi -= Time.deltaTime;
        if (beklemeSüresi<=0)
        {
            MüzikOynat();
        }
	}
}
