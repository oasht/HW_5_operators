using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;
namespace HW_5
{
   
    class Euro
    {
        private int euros;

        public int Euros
        {
            get { return euros; }
            set { euros = value;}
        }

        private int cents;

        public int Cents
        {
            get { return cents; }
            set { if (value >= 0 && value <= 99) cents = value;}
        }

        public Euro()
        {
            euros = 0;
            cents = 0;
        }
        public override string ToString()
        {

            return $"value = {euros} euros {cents} cents";
        }
       
    }
    class Money
    {
        private int rubles;

        public int Rubles
        {
            get { return rubles; }
            set { rubles = value; }
        }

        private int kopecks;

        public int Kopecks
        {
            get { return kopecks; }
            set { if (value >= 0 || value <= 99) kopecks = value; }
        }

        public Money()
        {
            rubles = 0;
            kopecks = 0;
        }
       
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
        public override bool Equals(object obj)
        {
            return this.ToString() == obj.ToString();
        }
 public static int Converter(Money m)
        {
            int n;
            n = m.rubles * 100 + m.kopecks;
            return n;
        }
        public static explicit operator double(Money m)
        {
            double n;
            n = (double)Converter(m) / 100;
            return n;
        }
        public static implicit operator Money(int number)
        {
            return new Money { Rubles = number, Kopecks=0 };
        }
        public override string ToString()
        {

            return $"{rubles} rubles {kopecks} kopecks";
        }
        public static explicit operator Money(Euro e)
        {
            int n;
            int r;
            int k;
            n = ((e.Euros*100)+e.Cents)*80;
            r = n / 100;
            k = n % 100;
            return new Money { Rubles = r, Kopecks = k };
        }

    public static Money operator ++(Money m) { m.rubles += 1; return m; }
        public static Money operator --(Money m) { m.rubles -= 1; return m; }
        public static Money operator -(Money m)
        {
            m.rubles *= -1;
            return m;
        }
        public static Money operator +(Money m1, Money m2)
        {
            int n;
            int r;
            int k;
            n = Converter(m1) + Converter(m2);
            r = n / 100;
            k= n % 100;
            return new Money { rubles = r, kopecks = k };
        }
        public static Money operator - (Money m1, Money m2)
        {
            int n;
            int r;
            int k;
            n = Converter(m1) - Converter(m2);
            r = n / 100;
            k = n % 100;
            return new Money { rubles = r, kopecks = k };
        }

        public static Money operator *(Money m1, Money m2)
        {
            int n;
            int r;
            int k;
            n = Converter(m1) * Converter(m2);
            r = n / 100;
            k = n % 100;
            return new Money { rubles = r, kopecks = k };
        }
        public static Money operator /(Money m1, Money m2)
        {
            int n;
            int r;
            int k;
            n = Converter(m1) / Converter(m2);
            r = n / 100;
            k = n % 100;
            return new Money { rubles = r, kopecks = k };
        }

        public static bool operator > (Money m1, Money m2)
        {
            return Converter(m1) > Converter(m2);
            
        }

        public static bool operator <(Money m1, Money m2)
        {
            return Converter(m1) < Converter(m2);

        }
        public static bool operator ==(Money m1, Money m2)
        {
            return Converter(m1) == Converter(m2);

        }

        public static bool operator !=(Money m1, Money m2)
        {
            return Converter(m1) != Converter(m2);

        }

       
    }
    class Program
    {
        static void Main(string[] args)
        {

            string q="1";
            int digit;
            do
            {

                Clear();
                WriteLine("Please choose action: 1 - logical operations, 2 - money convertation\n");
                try
                {
                    digit = Convert.ToInt32(ReadLine());
                }
                catch (Exception)
                {
                    WriteLine("Error, input just number!!!");
                    WriteLine("Press Enter");
                    ReadLine();
                    continue;
                }

                switch (digit)
                {

                    case 1:
                        {

                            Clear();
                            Money m1 = new Money();
                            Money m2 = new Money();
                            Money[] ar = { m1, m2 }; 
                            try
                            {
                                for (int i = 0; i < 2; i++)
                                {
                                    Clear();
                                    Write($"Enter rubles for the {i+1} object\n\n");
                                    ar[i].Rubles = int.Parse(ReadLine());
                                    WriteLine();
                                    Write($"Enter kopecks for the {i+1} object\n\n");
                                    ar[i].Kopecks = int.Parse(ReadLine());
                                }
                                
                            }
                            catch (Exception)
                            {
                                WriteLine("Error");
                                WriteLine("Press Enter");
                                ReadLine();
                                continue;
                            }

                            Clear();
                            WriteLine($"First object value = {m1.ToString()}\n\n");
                            WriteLine($"Second object value = {m2.ToString()}\n\n");
                            Money s = m1 + m2;
                            WriteLine($"The summ of two objects = {s.ToString()} ");
                            WriteLine("******************************************\n");
                            Money d = m1 - m2;
                            WriteLine($"The difference of two objects = {d.ToString()}");
                            WriteLine("******************************************\n");
                            Money mult = m1 * m2;
                            WriteLine($"The multiplication of two objects = {mult.ToString()}");
                            WriteLine("******************************************\n");
                            Money divid = m1 / m2;
                            WriteLine($"The result of division of two objects = {divid.ToString()}");
                            WriteLine("******************************************\n");
                            WriteLine($"Is the first object bigger than the second? - {m1>m2}");
                            WriteLine("******************************************\n");
                            double change = (double)m1;
                            WriteLine($"First object converted to double - {change}");
                            WriteLine("******************************************\n");
                            WriteLine("Enter any number\n");
                            int number = int.Parse(ReadLine());
                            
                            Money m3 = number;
                            WriteLine($"\nNumber converted to rubles - {m3.ToString()}");
                            WriteLine("******************************************\n");
                            Money minus = new Money();
                            minus=-m1;
                            WriteLine($"The negative value of the first object = {minus.ToString()}");
                        }
                        break;
                    case 2:
                        {
                            Clear();
                            Euro e = new Euro();
                            Write($"Enter euros\n\n");
                            e.Euros = int.Parse(ReadLine());
                            WriteLine();
                            Write($"Enter cents\n\n");
                            e.Cents = int.Parse(ReadLine());
                            Money m4 = (Money)e;
                            WriteLine($"\nEuro converted to rubles - {m4.ToString()}");
                        }
                        break;
                }
                
                WriteLine("\nPress 1 to continue\n");
                q = ReadLine();
                Clear();
            } while (q == "1");


        }
    }
}