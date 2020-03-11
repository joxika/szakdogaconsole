using System;
using System.Collections.Generic;

namespace Szakdoga_console
{
    class Program
    {
        List<Mezo> Palya = new List<Mezo>();
        public readonly int URESMEZO = 0;
        public readonly int SWORDSMAN = 1;
        public readonly int ARCHER = 2;
        public readonly int ASSASIN = 3;

        public static readonly string KEK = "kek";
        public static readonly string PIROS = "piros";
        public static readonly string URES = "ures";

        public static readonly int NEMLEHETIDELEPNI = 1;
        public static readonly int LEHETIDELEPNI = 2;
        public static readonly int LEHETIDEUTNI = 3;

        public string kinekakore = KEK;

        public int Kijeloltsor = 0;
        public int Kijeloltoszlop = 0;

        public int Hovasor = 2;
        public int Hovaoszlop = 2;

        static void Main(string[] args)
        {
            var program = new Program();

            program.Urespalyafeltoltes();
            while (true)
            {
                program.Palyakirajzolas(false);
                program.Mitcsinalhatsz();
            }
        }
        void Urespalyafeltoltes()
        {
            for (int i = 0; i < 64; i++)
            {
                Palya.Add(new Mezo(URESMEZO, URES, NEMLEHETIDELEPNI, 0, 0));
            }
        }
        void Babuhozzaad(int hova, int mit, string tulajdonos, int ide, int energia, int range)
        {
                Palya[hova].tipus = mit;
                Palya[hova].tulajdonos = tulajdonos;
                Palya[hova].ide = ide;
                Palya[hova].energia = energia;
                Palya[hova].range = range;
        }
        void Palyakirajzolas(bool kijelolesutan)
        {
            Console.Clear();
            if (kinekakore == PIROS)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
            }
            Console.WriteLine("{0} köre van", kinekakore);
            Console.WriteLine();

            for (int sor = 0; sor < 8; sor++)
            {
                for (int oszlop = 0; oszlop < 8; oszlop++)
                {
                    Mezo jelenlegimezo = Palya[sor * 8 + oszlop];
                    Szinbeallitas(jelenlegimezo.tulajdonos);

                    Console.Write(" ");
                    if (kijelolesutan == true)
                    {
                        Kijeloleshatter(sor, oszlop);
                    }

                    Console.Write(jelenlegimezo.tipus);
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.WriteLine();
            }
        }
        void Szinbeallitas(string tulajdonos)
        {
            if (tulajdonos == URES)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
            }
            if (tulajdonos == PIROS)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            if (tulajdonos == KEK)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
            }
        }
        void Kijeloleshatter(int sor, int oszlop)
        {
            if (Kijeloltoszlop == oszlop && Kijeloltsor == sor)
            {
                Console.BackgroundColor = ConsoleColor.White;
            }
            else if (Palya[sor * 8 + oszlop].ide == LEHETIDELEPNI)
            {
                Console.BackgroundColor = ConsoleColor.DarkYellow;
            }
            else if (Palya[sor * 8 + oszlop].ide == LEHETIDEUTNI)
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Black;
            }

        }
        void Mitcsinalhatsz()
        {
            Kiirasszinchange();
            Console.WriteLine();
            Console.WriteLine("bábukijelölés: 1");
            Console.WriteLine("bábu létrehozás: 2");
            Console.WriteLine("kör vége: 3");

            string bekert = Console.ReadLine();
            if (bekert == "1")
            {
                Palyakirajzolas(false);
                Babukijeloles();
                Hovalephetuthet();
                Palyakirajzolas(true);
                Babumitcsinaljon();

            }
            else if (bekert == "2") 
            {
                Babuletrehoz();
            }
            else if (bekert == "3")
            {
                Korvege();
                
            }

        }
        void Babuletrehoz() 
        {
            int hovaraksor;
            int hovarakoszlop;
            Kiirasszinchange();
            Console.WriteLine();
            Console.WriteLine("Milyen tipusú bábut?");
            Console.WriteLine("1: Swordsman    2: Archer    3: Assasin");

            string bekert = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Hova rakja ki");
            Console.Write("     sor: ");
            hovaraksor = Convert.ToInt32(Console.ReadLine()) - 1;
            Console.Write("     oszlop: ");
            hovarakoszlop = Convert.ToInt32(Console.ReadLine()) - 1;

            if (bekert == "1" && Palya[hovaraksor * 8 + hovarakoszlop].tulajdonos == URES)
            {
                Babuhozzaad(hovaraksor * 8 + hovarakoszlop, SWORDSMAN, kinekakore, NEMLEHETIDELEPNI, 0, 1);
            }
            else if (bekert == "2" && Palya[hovaraksor * 8 + hovarakoszlop].tulajdonos == URES)
            {
                Babuhozzaad(hovaraksor * 8 + hovarakoszlop, ARCHER, kinekakore, NEMLEHETIDELEPNI, 0, 2);
            }
            else if (bekert == "3" && Palya[hovaraksor * 8 + hovarakoszlop].tulajdonos == URES)
            {
                Babuhozzaad(hovaraksor * 8 + hovarakoszlop, ASSASIN, kinekakore, NEMLEHETIDELEPNI, 0, 1);
            }
        }
        void Babukijeloles()
        {
            int kijeloltsor;
            int kijeloltoszlop;
            Kiirasszinchange();
            Console.WriteLine();
            Console.WriteLine("Bábukijelölés");
            Console.Write("     sor: ");
            kijeloltsor = Convert.ToInt32(Console.ReadLine()) - 1;
            Console.Write("     oszlop: ");
            kijeloltoszlop = Convert.ToInt32(Console.ReadLine()) - 1;

            {
                Kijeloltsor = kijeloltsor;
                Kijeloltoszlop = kijeloltoszlop;
            }
        }
        void Hovalephetuthet()
        {
            for (int sor = 0; sor < 8; sor++)
            {
                for (int oszlop = 0; oszlop < 8; oszlop++)
                {
                    if (Palya[Kijeloltsor * 8 + Kijeloltoszlop].tulajdonos != URES)
                    {
                        int tavolsagutesre = Tavolsagutesre(sor, oszlop);
                        int tavolsaglepesre = Tavolsaglepesre(sor, oszlop);

                        if (Palya[Kijeloltsor * 8 + Kijeloltoszlop].energia >= tavolsaglepesre && Palya[sor * 8 + oszlop].tulajdonos == URES)
                        {

                            Palya[sor * 8 + oszlop].ide = LEHETIDELEPNI;
                        }
                        else if (Palya[Kijeloltsor * 8 + Kijeloltoszlop].energia != 0 &&
                            Palya[sor * 8 + oszlop].tulajdonos != kinekakore &&
                            Palya[sor * 8 + oszlop].tulajdonos != URES &&
                            Palya[Kijeloltsor * 8 + Kijeloltoszlop].range >= tavolsagutesre)
                        {
                            Palya[sor * 8 + oszlop].ide = LEHETIDEUTNI;
                        }
                    }
                }
            }
        }
        int Tavolsagutesre(int sor, int oszlop)
        {
            int tavolsag = 0;
            for (int i = 1; i < 8; i++)
            {
                if (Math.Abs(Kijeloltoszlop - oszlop) >= i && Kijeloltsor == sor) { tavolsag = i; }
                if (Math.Abs(Kijeloltsor - sor) >= i && Kijeloltoszlop == oszlop) { tavolsag = i; }
            }
            return tavolsag;
        }
        int Tavolsaglepesre(int sor, int oszlop)
        {
            int tavolsag = 0;
            for (int i = 1; i < 8; i++)
            {
                if (Kijeloltoszlop > oszlop)
                {
                    tavolsag++;
                    oszlop++;
                }
                if (Kijeloltoszlop < oszlop)
                {
                    tavolsag++;
                    oszlop--;
                }
                if (Kijeloltsor > sor)
                {
                    tavolsag++;
                    sor++;
                }
                if (Kijeloltsor < sor)
                {
                    tavolsag++;
                    sor--;
                }
            }
            return tavolsag;
        }
        void Babumitcsinaljon()
        {
            if (Palya[Kijeloltsor * 8 + Kijeloltoszlop].tulajdonos != URES)
            {
                Kiirasszinchange();

                Console.WriteLine();
                Console.WriteLine("1: ütés");
                Console.WriteLine("2: lépés");

                string mitcsinaljon = Console.ReadLine();
                if (mitcsinaljon == "1")
                {
                    Utesbekeres();
                }
                else if (mitcsinaljon == "2")
                {
                    Lepesbekeres();
                }
            }
        }
        void Utesbekeres()
        {

            Kiirasszinchange();
            if (Palya[Kijeloltsor * 8 + Kijeloltoszlop].tulajdonos == kinekakore)
            {
                Console.WriteLine();

                Console.WriteLine("Hova üssön");
                Console.Write("     sor: ");
                Hovasor = Convert.ToInt32(Console.ReadLine()) - 1;
                Console.Write("     oszlop: ");
                Hovaoszlop = Convert.ToInt32(Console.ReadLine()) - 1;
            }
            Utes();


        }
        void Utes()
        {
            if (Palya[Hovasor * 8 + Hovaoszlop].ide == LEHETIDEUTNI)
            {
                Palya[Kijeloltsor * 8 + Kijeloltoszlop].energia = Palya[Kijeloltsor * 8 + Kijeloltoszlop].energia - 1;

                Palya[Hovasor * 8 + Hovaoszlop].tulajdonos = URES;
                Palya[Hovasor * 8 + Hovaoszlop].tipus = URESMEZO;
                Palya[Hovasor * 8 + Hovaoszlop].energia = 0;



            }
            for (int sor = 0; sor < 8; sor++)
            {
                for (int oszlop = 0; oszlop < 8; oszlop++)
                {
                    Palya[sor * 8 + oszlop].ide = NEMLEHETIDELEPNI;
                }
            }
        }
        void Lepesbekeres()
        {
            if (Palya[Kijeloltsor * 8 + Kijeloltoszlop].tulajdonos != URES)
            {
                Kiirasszinchange();
                if (Palya[Kijeloltsor * 8 + Kijeloltoszlop].tulajdonos == kinekakore)
                {
                    Console.WriteLine();
                    Console.WriteLine("Lépés");
                    Console.Write("     sor: ");
                    Hovasor = Convert.ToInt32(Console.ReadLine()) - 1;
                    Console.Write("     oszlop: ");
                    Hovaoszlop = Convert.ToInt32(Console.ReadLine()) - 1;
                }
                Lepes();
            }
        }
        void Lepes()
        {
            if (Palya[Hovasor * 8 + Hovaoszlop].ide == LEHETIDELEPNI)
            {
                int tavolsag = Tavolsaglepesre(Hovasor, Hovaoszlop);

                Palya[Hovasor * 8 + Hovaoszlop].tulajdonos = Palya[Kijeloltsor * 8 + Kijeloltoszlop].tulajdonos;
                Palya[Hovasor * 8 + Hovaoszlop].tipus = Palya[Kijeloltsor * 8 + Kijeloltoszlop].tipus;
                Palya[Hovasor * 8 + Hovaoszlop].energia = Palya[Kijeloltsor * 8 + Kijeloltoszlop].energia - tavolsag;
                Palya[Hovasor * 8 + Hovaoszlop].range = Palya[Kijeloltsor * 8 + Kijeloltoszlop].range;


                Palya[Kijeloltsor * 8 + Kijeloltoszlop].tulajdonos = URES;
                Palya[Kijeloltsor * 8 + Kijeloltoszlop].tipus = URESMEZO;
                Palya[Kijeloltsor * 8 + Kijeloltoszlop].energia = 0;
                Palya[Kijeloltsor * 8 + Kijeloltoszlop].range = 0;


            }
            for (int sor = 0; sor < 8; sor++)
            {
                for (int oszlop = 0; oszlop < 8; oszlop++)
                {
                    Palya[sor * 8 + oszlop].ide = NEMLEHETIDELEPNI;
                }
            }
        }
        void Kiirasszinchange()
        {
            if (kinekakore == PIROS)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
            }
        }
        void Korvege()
        {
            if (kinekakore == PIROS)
            {
                kinekakore = KEK;
            }
            else
            {
                kinekakore = PIROS;
            }
            for (int sor = 0; sor < 8; sor++)
            {
                for (int oszlop = 0; oszlop < 8; oszlop++)
                {
                    if (Palya[sor * 8 + oszlop].tulajdonos != URES)
                    {
                        if (Palya[sor * 8 + oszlop].tipus == SWORDSMAN || Palya[sor * 8 + oszlop].tipus == ARCHER)
                        {
                            Palya[sor * 8 + oszlop].energia = 2;
                        }
                        else if (Palya[sor * 8 + oszlop].tipus == ASSASIN)
                        {
                            Palya[sor * 8 + oszlop].energia = 2;
                        }
                    }
                }
            }

        }
    }
}

