using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;

namespace program
{
    class Mieszkanie 
    {
        public int numer { get; set; }
        public double pow { get; set; }
        public double wys { get; set; }
        public int lp { get; set; }

        public Mieszkanie() { }
        public Mieszkanie(int Numer, double Pow, double Wys, int Lp) { numer = Numer; pow = Pow; wys = Wys; lp = Lp; }
        public Mieszkanie(Mieszkanie m) { numer = m.numer; pow = m.pow; wys = m.wys; lp = m.lp; }
        public void Copy(Mieszkanie m) { numer = m.numer; pow = m.pow;wys = m.wys;lp = m.lp; }
        public override string ToString()
        {
            return numer + " " + pow + " " + wys + " " + lp + "\n";
        }
    }
    class Pietro
    {
        public int numer { get; set; }
        public int n { get; set; }
        Mieszkanie[] mieszkania;

        public Mieszkanie this[uint i]
        {
            get { return mieszkania[i]; }
            set { mieszkania[i] = value; }
        }
        public Pietro() { }
        public Pietro(int Numer, int N, Mieszkanie[] m)
        {
            numer = Numer;
            n = N;
            mieszkania = new Mieszkanie[n];
            for (int i = 0; i < n; i++)
            {
                mieszkania[i] = new Mieszkanie(m[i]);
            }
        }
        public Pietro(Pietro p)
        {
            numer = p.numer;
            n = p.n;
            mieszkania = new Mieszkanie[n];
            for (int i = 0; i < n; i++)
            {
                mieszkania[i] = new Mieszkanie(p.mieszkania[i]);
            }
        }
        public void Copy(Pietro p)
        {
            numer = p.numer;
            n = p.n;
            mieszkania = new Mieszkanie[n];
            for (int i = 0; i < n; i++)
            {
                mieszkania[i].Copy(p.mieszkania[i]);
            }
        }

        public override string ToString() 
        {
            string tmp = numer + " \n";
            for (int i = 0; i < n; i++)
            {
                tmp += mieszkania[i].ToString();
            }
            return tmp;
        }
        public double wysokosc_pietra()
        {
            double tmp = mieszkania[0].wys;
            for (uint i = 1; i < n;i++)
            { if (mieszkania[i].wys > tmp) tmp = mieszkania[i].wys; }

            return tmp;
        }
    }
    class Klatka
    {
        public int numer { get; set; }
        public int n { get; set; }
        Pietro [] pietra;
        public Pietro this[uint i]
        {
            get { return pietra[i]; }
            set { pietra[i] = value; }
        }
        public Klatka() { }
        public Klatka(int Numer, int N, Pietro[] p)
        {
            numer = Numer;
            n = N;
            pietra = new Pietro[n];
            for (int i = 0; i < n; i++)
            {
                pietra[i] = new Pietro(p[i]);
            }

        }
        public Klatka(Klatka k)
        {
            numer = k.numer;
            n = k.n;
            pietra = new Pietro[n];
            for (int i = 0; i < n; i++)
            {
                pietra[i] = new Pietro(k.pietra[i]);
            }
        }
        public void Copy(Klatka k)
        {
            numer = k.numer;
            n = k.n;
            for (int i = 0; i < n; i++)
            {
                pietra[i].Copy(k.pietra[i]);
            }
        }
        public override string ToString()
        {
            string tmp = numer + " ";
            for (int i = 0; i < n; i++)
            {
                tmp += pietra[i].ToString();
            }
            return tmp;
        }
        public double wysokosc_klatki() 
        {
            double tmp = .0;
            for (uint i =0; i < n;i++) { tmp += pietra[i].wysokosc_pietra(); }
            return tmp;
        }
    }
    class Blok
    {
        public int numer { get; set; }
        public int n { get; set; }
        public string ulica { get; set; }
        Klatka[] klatki;
        public Klatka this[uint i]
        {
            get { return klatki[i]; }
            set { klatki[i] = value; }
        }

        public Blok() { }
        public Blok(int Numer, int N, string Ulica, Klatka[] k)
        {
            numer = Numer;
            n = N;
            ulica = Ulica;
            klatki = new Klatka[n];
            for (int i = 0; i < n; i++)
            {
                klatki[i] = new Klatka(k[i]);
            }
        }
        public Blok(Blok b)
        {
            numer = b.numer;
            n = b.n;
            ulica = b.ulica;
            klatki = new Klatka[n];
            for (int i = 0; i < n; i++)
            {
                klatki[i].Copy(b.klatki[i]);
            }
        }
        public void Copy(Blok b)
        {
            numer = b.numer;
            n = b.n;
            ulica = b.ulica;
            klatki = new Klatka[n];
            for (int i = 0; i < n; i++)
            {
                klatki[i].Copy(b.klatki[i]);
            }
        }
        public override string ToString()
        {
            string tmp = numer + " " + ulica + "";
            for (int i = 0; i < n; i++)
            {
                tmp += klatki[i].ToString();
            }
            return tmp;
        }
        public double wysokosc_bloku() 
        {
            double tmp = 0;
            for (uint i = 0; i < n; i++) { tmp += klatki[i].wysokosc_klatki(); }
            return tmp;
        }
        public Mieszkanie loft()
        {
            Mieszkanie tmp = new Mieszkanie(klatki[0][0][0]);
            for(uint i = 0; i < n;i++) 
            {
                for (uint j = 0; j < klatki[i].n; j++) 
                {
                    for (uint x = 0; x < klatki[i][j].n; x++) 
                    {
                        if (tmp.wys < klatki[i][j][x].wys)
                            tmp.Copy(klatki[i][j][x]);
                    }
                }
            }
            return tmp;
        }
    }
    class Program
    {
        
        static void Main(string[] args)
        {
            Mieszkanie[] m = new Mieszkanie[2];
            m[1] = new Mieszkanie(3, 75.5, 2.45, 4);
            m[0] = new Mieszkanie(4, 84.5, 3.45, 5);

            Mieszkanie[] m1 = new Mieszkanie[2];
            m1[1] = new Mieszkanie(1, 75.5, 2.45, 4);
            m1[0] = new Mieszkanie(2, 84.5, 2.85, 5);

            Pietro[] p = new Pietro[2];
            p[0] = new Pietro(1, 2, m1);
            p[1] = new Pietro(2, 2, m);

            Klatka[] k = new Klatka[1];
            k[0] = new Klatka(1, 2, p);

            Blok b = new Blok(1, 1, "prosta", k);

            Console.WriteLine(b.ToString());

            Console.WriteLine(b.wysokosc_bloku());

            Console.WriteLine(b.loft().ToString());



        }
    }
}
