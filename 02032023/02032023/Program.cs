using System.IO;

namespace _02032023
{
    public class K1
    {
        private string w1; 
        private string w2; 
        private double w3;

        public string W1 { get { return w1; } set { w1 = value; } }
        public string W2 { get { return w2; } set { w2 = value; } }
        public double W3 { get { return w3; } set { w3 = value; } }

        public K1() { }
        public K1(string w1, string w2, double w3) 
        {
            this.w1 = w1;
            this.w2 = w2;
            this.w3 = w3;
        }
        public K1(K1 k)
        {
            w1 = k.w1;
            w2 = k.w2;
            w3 = k.w3;
        }
        public void Copy(K1 k) 
        {
            w1 = k.w1;
            w2 = k.w2;
            w3 = k.w3;
        }
        public override string ToString()
        {
            return $"{w1} {w2} {w3}";
        }
    }    
    public class K2{
        private K1 ob1;

        public string W1
        {
            get { return ob1.W1; }
            set { ob1.W1 = value; }
        }
        public string W2
        {
            get { return ob1.W2; }
            set { ob1.W2 = value; }
        }
        public double W3
        {
            get { return ob1.W3; }
            set { ob1.W3 = value; }
        }

        public K2() 
        {
            ob1 = new K1();
        }
        public K2(string w1, string w2, double w3)
        {
            ob1 = new K1(w1,w2, w3);
        }
        public K2(K2 k) 
        {
            ob1 = new K1(k.ob1);
        }
        public void Copy(K2 k) 
        {
            ob1.Copy(k.ob1);
        }
        public static K2 operator -(K2 k, double d) => new K2(k.ob1.W1, k.ob1.W2, k.ob1.W3 - d);
        public static K2 operator +(K2 k, double d) => new K2(k.ob1.W1, k.ob1.W2, k.ob1.W3 + d);
        public static K2 operator +(K2 k, string s) => new K2(k.ob1.W1, k.ob1.W2 + s, k.ob1.W3);
        public static K2 operator +(string s, K2 k) => new K2(s+k.ob1.W1, k.ob1.W2, k.ob1.W3);

        public override string ToString()
        {
            return ob1.ToString();
        }
    }
        internal class Program
    {
        static void Main()
        {
            K2 ob1, ob2; ob1 = new K2();
            ob2 = new K2("kawa", "z mlekiem", 4.50);
            K2 ob3 = new K2(ob2);
            Console.WriteLine(ob1);
            Console.WriteLine(ob2);
            Console.WriteLine(ob2 - 1.25);            //modyfikacja składowej w3
            Console.WriteLine("***** 2 *****");           
            ob1.Copy(ob3);
            Console.WriteLine(ob1);        
            ob1.W2 +=" i cukrem";        
            ob1.W3 +=2;
            Console.WriteLine(ob1);
            Console.WriteLine("***** 3 *****");
            K2 [] tab;                                 //odczyt danych z pliku data.txt
            using (StreamReader file = new StreamReader("./data.txt")) 
            {
                string[] tmp;
                List<K2> list = new List<K2>();
                string line = file.ReadLine();
                while (line != null)
                {
                    tmp = line.Split(' ');
                    list.Add(new K2(tmp[0], tmp[1],double.Parse(tmp[2], System.Globalization.CultureInfo.InvariantCulture)));
                    line = file.ReadLine();
                }
                tab = list.ToArray();
            }
                for (int i = 0; i < tab.Length;++i )           
            {                
                tab[i] += 1;                         //modyfikowana składowa w3
                Console.WriteLine(tab[i]);           
            }            
            Console.WriteLine("***** 4 *****");            
            tab[1] = tab[1] + " with sugar";        //dotyczy składowej w2
            tab[3] = "hot " + tab[3];               //dotyczy składowej w1
            foreach (K2 k in tab)            
                Console.WriteLine(k);           
            Console.WriteLine("***** 5 *****");
        }
    }
}