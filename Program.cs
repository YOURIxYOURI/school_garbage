
    public class punkt
    {
        private double x, y, z;

        public double X
        {
            get { return x; }
            set { x = value; }
        }
        public double Y
        {
            get { return y; }
            set { y = value; }
        }
        public double Z
        {
            get { return z; }
            set { z = value; }
        }

        public punkt() { x = 0; y = 0; z = 0; }
        public punkt(double X, double Y, double Z) { x = X; y = Y; z = Z; }
        public punkt(punkt p) { x = p.x; y = p.y; z = p.z; }
    }

    class prostokat
    {
        private double a, b;
        private punkt p;
        public double A
        {
            get { return a; }
            set { a = value; }
        }
        public double B
        {
            get { return b; }
            set { b = value; }
        }
        public double X
        {
            get { return p.X; }
            set { p.X = value; }
        }
        public double Y
        {
            get { return p.Y; }
            set { p.Y = value; }
        }
        public double Z
        {
            get { return p.Z; }
            set { p.Z = value; }
        }
        public prostokat() { a = 0; b = 0; p = new punkt(); }
        public prostokat(double A, double B, double X, double Y, double Z) { a = A; b = B; p = new punkt(X, Y, Z); }
        public prostokat(double A, double B, punkt P) { a = A; b = B; p = new punkt(P); }
        public prostokat(prostokat pr) { a = pr.a; b = pr.b; p = new punkt(pr.p); }
        public double pole() { return a * b; }
    }

    class graniastoslup
    {
        private prostokat pr;
        private double h;

        public double A
        {
            get { return pr.A; }
            set { pr.A = value; }
        }
        public double B
        {
            get { return pr.B; }
            set { pr.B = value; }
        }
        public double X
        {
            get { return pr.X; }
            set { pr.X = value; }
        }
        public double Y
        {
            get { return pr.Y; }
            set { pr.Y = value; }
        }
        public double Z
        {
            get { return pr.Z; }
            set { pr.Z = value; }
        }
        public double H
        {
            get { return h; }
            set { h = value; }
        }

        public graniastoslup() { h = 0; pr = new prostokat(); }
        public graniastoslup(double A, double B, double X, double Y, double Z, double H) { h = H; pr = new prostokat(A, B, X, Y, Z); }
        public graniastoslup(double A, double B, double H, punkt P) { h = H; pr = new prostokat(A, B, P); }
        public graniastoslup(double H, prostokat PR) { h = H; pr = new prostokat(PR); }
        public double pole() { return (pr.pole() * 2) + ((pr.A * h) * 2) + ((pr.B * h) * 2); }
        public double obw() { return pr.pole() * h; }

    }

class Program
{
    static void Main()
    {
        punkt p1 = new punkt();
        punkt p2 = new punkt(1, 2, 3);







        Console.WriteLine(p1.X + "\n" + p2.X);



        p1.X = 1; p1.Y = 10; p1.Z = 100;
        Console.WriteLine(p1.X + " " + p1.Y + " " + p1.Z);



        prostokat pr1 = new prostokat();
        prostokat pr2 = new prostokat(1, 2, 3, 10.5, 20.5);
        prostokat pr3 = new prostokat(5, 5, p2);



        pr1.X = 2; pr1.Y = 20; pr1.Z = 200; pr1.A = 10; pr1.B = 10;
        Console.WriteLine("pr1.X = " + pr1.X + "\t" + "pr1.Y = " + pr1.Y + "\t" + "pr1.Z = " + pr1.Z + "\t" + "pr1.A = " + pr1.A + "\t" + "pr1.B = " + pr1.B + "\t" + "pr1.pole() = " + pr1.pole());
        Console.WriteLine("pr3.X = " + pr3.X + "\t" + "pr3.Y = " + pr3.Y + "\t" + "pr3.Z = " + pr3.Z + "\t" + "pr3.A = " + pr3.A + "\t" + "pr3.B = " + pr3.B + "\t" + "pr3.pole() = " + pr3.pole());



        graniastoslup g1 = new graniastoslup();
        graniastoslup g2 = new graniastoslup(1, 2, 3, 10.5, 20.5, 30.5);
        graniastoslup g3 = new graniastoslup(300, 100, 200, p2);
        graniastoslup g4 = new graniastoslup(5, pr3);



        Console.WriteLine("g4.X = " + g4.X + "\t" + "g4.Y = " + g4.Y + "\t" + "g4.Z = " + g4.Z + "\t" + "g4.A = " + g4.A + "\t" + "g4.B = " + g4.B + "\t" + "g4.H = " + g4.H + "\t" + "g4.objetosc() = " + g4.obw());



        g1.A = 10; g1.B = 10; g1.H = 10;



        Console.WriteLine("g1.X = " + g1.X + "\t" + "g1.Y = " + g1.Y + "\t" + "g1.Z = " + g1.Z + "\t" + "g1.A = " + g1.A + "\t" + "g1.B = " + g1.B + "\t" + "g1.H = " + g1.H + "\t" + "g1.objetosc() = " + g1.obw());



        Console.Read();
    }
}
