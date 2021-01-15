using System;
using System.Collections.Generic;

namespace prob3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Fiind dat (Zn,*) grupul resturilor modulo n, n = ");
            int n = int.Parse(Console.ReadLine());
           
            var aux = new List<int>();
            Console.Write("Introduceti un numar pentru a afla ordinul lui: ");
            int x = int.Parse(Console.ReadLine());


            if (x>=n)
            {
                Console.WriteLine("Numarul trebuie sa fie mai mic ca n");
                return;
            }
            int b = x,k=1;
            bool ok = true;
            if (b==1)
            {
                Console.WriteLine("Ordinul lui {0} este {1}", x, k);
            }
            else
            {
                do
                {
                    b = (b * x) % n;
                    Console.WriteLine("{0}: restul = {1}",k+1,b);
                    if (aux.IndexOf(b)!=-1)
                    {
                        ok = false;
                        break;
                    }
                    aux.Add(b);
                    k++;
                } while (b!=1);

                if (ok)
                    Console.WriteLine("Ordinul lui {0} este {1}",x,k);
                else
                    Console.WriteLine("Ordinul lui {0} este infinit", x);
            }
        }
        
    }
}
