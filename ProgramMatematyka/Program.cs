using System;

namespace ProgramMatematyka
{
    class Program
    {
        #region Zmienne
        private static double a = 0.5;
        private static double b = 4;
        private static double fa;
        private static double fb;
        private static double x;
        private static double x0;
        private static double x1;
        private static double fx;
        private static double fx0;
        private static double fx1;
        private static double E = 0.01;
        private static int iteracja;
        private static int nr = 6;
        private static int nrMetody = 1;
        private static int limIter = 100;
        private static double wynik;

        #endregion

        static void Main(string[] args)
        {
            Interfejs();
            Test();
            Console.ReadKey();
        }

        #region Testy
        public static void Test()
        {
            double testA = 1;
            double testB = 7;
            double testx0 = 3;
            Console.WriteLine("TEST Wszystkich metod");
            TestFalsi(testA, testB);
            TestNewtona(testx0);
            TestPołowienia(testA, testB);
            TestSiecznych(testA, testB);
        }
        static void TestFalsi(double testa, double testb)
        {
            for (int i = 1; i <= 6; i++)
            {
                nr = i;
                a = testa;
                b = testb;
                Falsi();
                Console.WriteLine("TEST Falsi  " + i + "    Wynik = " + x0 + "    Interacja = " + iteracja);
            }
        }
        static void TestNewtona(double testx0)
        {
            for (int i = 1; i <= 6; i++)
            {
                nr = i;
                x0 = testx0;
                Newtona();
                Console.WriteLine("TEST Newtona  " + i + "    Wynik = " + x0 + "    Interacja = " + iteracja);
            }
        }
        static void TestPołowienia(double testa, double testb)
        {
            for (int i = 1; i <= 6; i++)
            {
                nr = i;
                a = testa;
                b = testb;
                Falsi();
                Console.WriteLine("TEST Połowienia " + i + "    Wynik = " + x0 + "    Interacja = " + iteracja);
            }
        }
        static void TestSiecznych(double testa, double testb)
        {
            for (int i = 1; i <= 6; i++)
            {
                nr = i;
                a = testa;
                b = testb;
                Falsi();
                Console.WriteLine("TEST Siecznych   " + i + "    Wynik = " + x0 + "    Interacja = " + iteracja);
            }
        }
        #endregion
        #region Interface
        static void Interfejs()
        {
            Console.WriteLine("Maciej Drązek               Album: 87029 Łódź 2018.10");
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("    Obliczanie pierwiastka funkcji - Różne Metody    ");
            Console.WriteLine("              Wybierz Metodę obliczania              ");
            Console.WriteLine("        1 - Falsi             2 -  Newtona           ");
            Console.WriteLine("        3 - Połowienia        4 -  Siecznych         ");
            Console.WriteLine("               Wybierz metode nr + ENTER             ");
            nrMetody = Convert.ToInt16(Console.ReadLine());// Ręcznie wybieranie metody 
            switch (nrMetody)
            {
                case 1:
                    Console.WriteLine("                     Metoda Falsi                    ");
                    Console.WriteLine("        Podaj zakres poszukiwan pierwiastka:         ");
                    Console.WriteLine("         Podaj a = ... ENTER b = ... ENTER           ");
                    a = Convert.ToDouble(Console.ReadLine());
                    b = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("         Podano  a = " + a + "  i  b = " + b + "     ");
                    Falsi();
                    break;
                case 2:
                    Console.WriteLine("                   Metoda NEWTONA                    ");
                    Console.WriteLine("        Podaj zakres poszukiwan pierwiastka:         ");
                    Console.WriteLine("                   x0 = ... ENTER                    ");
                    x0 = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("          Podano  x0 = " + x0 + "                    ");
                    Newtona();
                    break;
                case 3:
                    Console.WriteLine("                 Metoda Połowienia                   ");
                    Console.WriteLine("        Podaj zakres poszukiwan pierwiastka:         ");
                    Console.WriteLine("         Podaj a = ... ENTER b = ... ENTER           ");
                    a = Convert.ToDouble(Console.ReadLine());
                    b = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("         Podano  a = " + a + "  i  b = " + b + "     ");
                    Połowienia();
                    break;
                case 4:
                    Console.WriteLine("                 Metoda Siecznych                    ");
                    Console.WriteLine("        Podaj zakres poszukiwan pierwiastka:         ");
                    Console.WriteLine("         Podaj a = ... ENTER b = ... ENTER           ");
                    a = Convert.ToDouble(Console.ReadLine());
                    b = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("         Podano  a = " + a + "  i  b = " + b + "     ");
                    Siecznych();
                    break;
                default:
                    Console.WriteLine("                     Nie ma takiej                   ");
                    break;
            }
            wynik = x0;
            Console.WriteLine();
            Console.WriteLine("        Szukanym pierwiastkiem funkcji jest:         ");
            Console.WriteLine("              x0 = " + wynik);
            Console.WriteLine("       Znaleziono go w  " + iteracja + " iteracji.   ");
            Console.WriteLine();
            Console.WriteLine(" Dziękuję                                            ");
            Console.WriteLine("                                       Maciej Drążek ");
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine();
            Console.ReadKey();
        }
        #endregion
        #region Funkcje
        static double Fx(int nr, double x)
        {
            switch (nr)
            {
                case 1:
                    fx = (Math.Pow(x, 3) - 3);
                    break;
                case 2:
                    fx = (Math.Pow(x, 3) - 10);
                    break;
                case 3:
                    fx = (Math.Pow(x, 4) - 5);
                    break;
                case 4:
                    fx = (Math.Pow((x), 5) - 10);
                    break;
                case 5:
                    fx = (Math.Pow(x, 2) - 2);
                    break;
                case 6:
                    fx = (2*(Math.Pow(x, 2)) - 11);
                    break;
                default:
                    fx = (Math.Pow(x, 2) - 2);
                    break;
            }
            return fx;
        }
        static double FxPoch(int nr, double x)
        {
            switch (nr)
            {
                case 1:
                    fx = 3 * (Math.Pow(x, 2));
                    break;
                case 2:
                    fx = 3 * (Math.Pow(x, 2));
                    break;
                case 3:
                    fx = 4 * (Math.Pow(x, 3));
                    break;
                case 4:
                    fx = 5 * (Math.Pow(x, 4));
                    break;
                case 5:
                    fx = 2 * x;
                    break;
                case 6:
                    fx = 2 * 2 * x;
                    break;
                default:
                    fx = 2 * x;
                    break;
            }
            return fx;
        }
        #endregion
        #region Metody 
        static void Falsi()
        {
            fa = Fx(nr, a);
            fb = Fx(nr, b);
            x1 = a;
            x0 = b;

            if (fa * fb > 0)
            {
                Console.WriteLine("---------    Funkcja nie spełnia założeń   ----------");
            }
            else
            {
                bool end = false;
                for (int i = 0; Math.Abs(x1 - x0) > E && !end; i++)
                {
                    if (Math.Abs(x1 - x0) > E)
                    {
                        x1 = x0;
                        x0 = a - fa * ((b - a) / (fb - fa));
                        fx0 = Fx(nr, x0);
                    }
                    if (Math.Abs(fx0) < E)
                    {
                        end = true;
                    }
                    if (fa * fb < 0)
                    {
                        b = x0;
                        fb = fx0;
                    }
                    else
                    {
                        a = x0;
                        fa = fx0;
                    }
                    iteracja = i;
                }
            }
        }
        static void Newtona()
        {
            x1 = x0 - 1;
            fx0 = Fx(nr, x0);
            bool end = false;

            for (int i = 0; i < limIter && !end; i++)
            {
                fx1 = FxPoch(nr, x0);
                if ((Math.Abs(fx1) < E))
                {
                    Console.WriteLine("/////////////////////// END 1 Zły punkt startowy     "); //end Złe punkty startowe  
                    Console.WriteLine("                  Spróbuj jeszcze raz                ");
                    end = true;
                }
                x1 = x0;
                x0 = (x0 - fx0 / fx);
                fx0 = (Fx(nr, x0));
                iteracja = i;
                if (!(Math.Abs(x1 - x0) > E))
                {
                    //end obliczone w teori 
                    end = true;
                }
                if (!(Math.Abs(fx0) > E))
                {
                    //end obliczone w teori 
                    end = true;
                }
            }
            if (iteracja > limIter)
            {
                Console.WriteLine("            Przekroczono limit obiegów.              ");
                x0 = 0;
                iteracja = 0;
            }
        }
        static void Połowienia()
        {
            // interfejs 

            //ciało Progrmau 
            fa = Fx(nr, a);
            fb = Fx(nr, b);
            bool end = false;

            if (fa * fb > 0)
            {
                Console.WriteLine("/////////////////////// END 1 Zły punkt startowy     ");
                Console.WriteLine("                  Spróbuj jeszcze raz                ");
                end = true;
            }

            for (int i = 0; (Math.Abs(a - b) > E) && !end && i < limIter; i++)
            {
                x0 = (a + b) / 2;
                fx0 = Fx(nr, x0);

                if ((Math.Abs(fx0) < E))
                {
                    Console.WriteLine("/////////////////////// END 2 OBLICZONO              ");
                    end = true;
                }
                if (fa * fx0 < 0)
                {
                    b = x0;
                    //fb = Fx(nr, b);
                }
                else
                {
                    a = x0;
                    fa = Fx(nr, a);
                }
                iteracja = i;
            }

            if (iteracja > limIter)
            {
                Console.WriteLine("            Przekroczono limit obiegów.              ");
            }
        }
        static void Siecznych()
        {
            fa = Fx(nr, a);
            fb = Fx(nr, b);
            bool end = false;
            for (int i = 0; (Math.Abs(a - b) > E) && !end && i < limIter; i++)
            {
                if ((Math.Abs(fa - fb) < E))
                {
                    Console.WriteLine("/////////////////////// END 1 Zły punkt startowy     ");
                    Console.WriteLine("                  Spróbuj jeszcze raz                ");
                    end = true;
                }
                x0 = (a - fa * ((a - b) / fa - fb));
                fx0 = Fx(nr, x0);
                if ((Math.Abs(fx0) < E))
                {
                    Console.WriteLine("/////////////////////// END 2 OBLICZONO              ");
                    end = true;
                }
                else
                {
                    b = a;
                    fb = fa;
                    a = x0;
                    fa = fx0;
                }
                iteracja = i;
            }
            if (iteracja > limIter)
            {
                Console.WriteLine("            Przekroczono limit obiegów.              ");
            }
        }
        #endregion
    }
}
