using UnityEngine;
using System.Collections;

public class İstatistikler : MonoBehaviour {
    struct Bilgi
    {
        string isim;
        int değer;

        public Bilgi(string isim, int değer)
        {
            this.isim = isim;
            this.değer = değer;
        }

        public string İsim
        {
            get
            {
                return isim;
            }

            set
            {
                isim = value;
            }
        }

        public int Değer
        {
            get
            {
                return değer;
            }

            set
            {
                değer = value;
            }
        }
    }
    struct İstatistik
    {
        Bilgi[] tutulanBilgiler;
        public İstatistik(params Bilgi[] bilgiler)
        {
            tutulanBilgiler = new Bilgi[bilgiler.Length];
            for (int i = 0; i < tutulanBilgiler.Length; i++)
            {
                tutulanBilgiler[i] = bilgiler[i];
            }
        }
        public Bilgi this[string isim]
        {
            get
            {
                for (int i = 0; i < tutulanBilgiler.Length; i++)
                {
                    if (tutulanBilgiler[i].İsim==isim)
                    {
                        return tutulanBilgiler[i];
                    }
                }
                return new Bilgi("",-1);
            }
            set
            {
                for (int i = 0; i < tutulanBilgiler.Length; i++)
                {
                    if (tutulanBilgiler[i].İsim == isim)
                    {
                        tutulanBilgiler[i]=value;
                    }
                }
            }
        }
        public Bilgi this[int i]
        {
            get
            {
                return tutulanBilgiler[i];
            }
            set
            {
                tutulanBilgiler[i] = value;
            }
        }
    }
}
