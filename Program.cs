using System;
    class Program
    {
        static int[,,] w;
        static void Main(string[] args)
        {
            using (var prnt = new System.IO.StreamWriter(Console.OpenStandardOutput()))
            {
                w = new int[101, 101, 101];

                while (true)
                {
                    var a = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                    if (a[0] == -1 && a[1] == -1 && a[2] == -1)
                    {
                        break;
                    }
                    if (w[a[0] + 50, a[1] + 50, a[2] + 50] == 0)
                    {
                        GetW(a[0] + 50, a[1] + 50, a[2] + 50);
                    }
                    prnt.WriteLine(string.Format("w({0}, {1}, {2}) = {3}", a[0], a[1], a[2], w[a[0] + 50, a[1] + 50, a[2] + 50]));
                }
            }
        }
        static int GetW(int a, int b, int c)
        {
            if (w[a, b, c] != 0)
            {
                return w[a, b, c];
            }
            if (a <= 50 || b <= 50 || c <= 50)
            {
                w[a, b, c] = 1;
            }
            else if (a > 70 || b > 70 || c > 70)
            {
                w[a, b, c] = GetW(70, 70, 70);
            }
            else if (a < b && b < c)
            {
                w[a, b, c] = GetW(a, b, c - 1) + GetW(a, b - 1, c - 1) - GetW(a, b - 1, c);
            }
            else
            {
                w[a, b, c] = GetW(a - 1, b, c) + GetW(a - 1, b - 1, c) + GetW(a - 1, b, c - 1) - GetW(a - 1, b - 1, c - 1);
            }
            return w[a, b, c];
        }
    }