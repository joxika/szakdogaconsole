using System;
using System.Collections.Generic;
//03.18. babu levels
namespace Szakdoga_console
{
    class Program
    {
        List<Mezo> Palya = new List<Mezo>();
        public readonly int URESMEZO = 0;
        public readonly int SWORDSMAN = 1;
        public readonly int ARCHER = 2;
        public readonly int ASSASIN = 3;
        public readonly int BASE = 4;

        public static readonly string KEK = "kek";
        public static readonly string PIROS = "piros";
        public static readonly string URES = "ures";

        public static readonly int NEMLEHETIDELEPNI = 1;
        public static readonly int LEHETIDELEPNI = 2;
        public static readonly int LEHETIDEUTNI = 3;
        public static readonly int LEHETIDELETREHOZNI = 4;

        public static readonly int SEMMIAKCIOVAL = 1;
        public static readonly int KIJELOLESUTAN = 2;
        public static readonly int LETREHOZASNAL = 3;

        public string Kinekakore = KEK;

        public int Kekmana = 2;
        public int Pirosmana = 0;

        public int Kijeloltsor = 0;
        public int Kijeloltoszlop = 0;
        public int Hovasor = 2;
        public int Hovaoszlop = 2;

        public bool Csinalhatevalamit = false;
        public bool Vegeajateknak = false;

        static void Main(string[] args)
        {
            var program = new Program();

            program.Kiindulopalyafeltoltes();
            while (program.Vegeajateknak == false)
            {
                program.Palyakirajzolas(SEMMIAKCIOVAL);
                program.Mitcsinalhatsz();
            }
            program.Jatekvege();
        }
        void Kiindulopalyafeltoltes()
        {
            for (int i = 0; i < 64; i++)
            {
                Palya.Add(new Mezo(URESMEZO, URES, NEMLEHETIDELEPNI, 0, 0, 0, 0, 0));
            }
            Babuhozzaad(0 * 8 + 0, BASE, KEK, NEMLEHETIDELEPNI, 0, 0, 0, 0, 0);
            Babuhozzaad(7 * 8 + 7, BASE, PIROS, NEMLEHETIDELEPNI, 0, 0, 0, 0, 0);


        }
        void Babuhozzaad(int hova, int mit, string tulajdonos, int ide, int energia, int range,int damage, int defense, int level)
        {
                Palya[hova].tipus = mit;
                Palya[hova].tulajdonos = tulajdonos;
                Palya[hova].ide = ide;
                Palya[hova].energia = energia;
                Palya[hova].range = range;
                Palya[hova].damage = damage;
                Palya[hova].defense = defense;
                Palya[hova].level = level;
        }
        void Palyakirajzolas(int mikor)
        {
            Console.Clear();
            if (Kinekakore == PIROS)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("{0} köre van", Kinekakore);
                Console.WriteLine("{0} mana áll rendelkezésre", Pirosmana);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("{0} köre van", Kinekakore);
                Console.WriteLine("{0} mana áll rendelkezésre", Kekmana);
            }
            Console.WriteLine();

            for (int sor = 0; sor < 8; sor++)
            {
                for (int oszlop = 0; oszlop < 8; oszlop++)
                {
                    Mezo jelenlegimezo = Palya[sor * 8 + oszlop];
                    Szinbeallitas(jelenlegimezo.tulajdonos);

                    Console.Write(" ");
                    if (mikor == 2)
                    {
                        Kijeloleshatter(sor, oszlop, KIJELOLESUTAN);
                    }
                    if (mikor == 3)
                    {
                        Kijeloleshatter(sor, oszlop, LEHETIDELETREHOZNI);
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
        void Kijeloleshatter(int sor, int oszlop, int mikor)
        {
            if (Kijeloltoszlop == oszlop && Kijeloltsor == sor && mikor == KIJELOLESUTAN)
            {
                Console.BackgroundColor = ConsoleColor.White;
            }
            else if (Palya[sor * 8 + oszlop].ide == LEHETIDELEPNI)
            {
                Console.BackgroundColor = ConsoleColor.DarkYellow;
            }
            else if (Palya[sor * 8 + oszlop].ide == LEHETIDEUTNI && mikor == KIJELOLESUTAN)
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Black;
            }
            if (mikor == LEHETIDELETREHOZNI)
            {
                if (Palya[sor * 8 + oszlop].ide == LEHETIDELETREHOZNI)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                }
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
                Palyakirajzolas(1);
                Babukijeloles();
                Hovalephetuthet();
                Palyakirajzolas(2);
                Babumitcsinaljon();

            }
            else if (bekert == "2") 
            {
                Hovahozhatjaletre();
                Palyakirajzolas(3);
                Babuletrehoz();
            }
            else if (bekert == "3")
            {
                Korvege();
                
            }
            Vegeeajateknak();

        }
        void Babuletrehoz()
        {
            int hovaraksor;
            int hovarakoszlop;


            Kiirasszinchange();

            Console.WriteLine();
            Console.WriteLine("Milyen tipusú bábut hozzon létre?");
            Console.WriteLine("1: Swordsman    2: Archer    3: Assasin");
            string milyentipus = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Milyen szintű bábut hozzon létre? ");
            Console.WriteLine("1: 1 mana    2: 3 mana    3: 9 mana");
            int milyenszint = Convert.ToInt32(Console.ReadLine());
            int szuksegesmana;
            if(milyenszint == 1) 
            {
                szuksegesmana = 1;
            }
            else if (milyenszint == 2) 
            {
                szuksegesmana = 3;
            }
            else
            {
                szuksegesmana = 9;
            }

            Console.WriteLine();
            Console.WriteLine("Hova rakja ki");
            Console.Write("     sor: ");
            hovaraksor = Convert.ToInt32(Console.ReadLine()) - 1;
            Console.Write("     oszlop: ");
            hovarakoszlop = Convert.ToInt32(Console.ReadLine()) - 1;

            int mostanimana = Kekmana;
            if (Kinekakore == PIROS)
            {
                mostanimana = Pirosmana;
            }

            if (Palya[hovaraksor * 8 + hovarakoszlop].tulajdonos == URES && Palya[hovaraksor * 8 + hovarakoszlop].ide == LEHETIDELETREHOZNI && mostanimana >= szuksegesmana)
            {
                if (milyenszint == 1 || milyenszint == 2 || milyenszint == 3)
                {
                    if (milyentipus == "1")
                    {
                        Babuhozzaad(hovaraksor * 8 + hovarakoszlop, SWORDSMAN, Kinekakore, NEMLEHETIDELEPNI, 0, 1, milyenszint+2, milyenszint+1, milyenszint);
                        mostanimana = mostanimana - szuksegesmana;
                        if (Kinekakore == PIROS)
                        {
                            Pirosmana = mostanimana;
                        }
                        else
                        {
                            Kekmana = mostanimana;
                        }
                    }
                    else if (milyentipus == "2")
                    {
                        Babuhozzaad(hovaraksor * 8 + hovarakoszlop, ARCHER, Kinekakore, NEMLEHETIDELEPNI, 0, 2, milyenszint+2, milyenszint, milyenszint);
                        mostanimana = mostanimana - szuksegesmana;
                        if (Kinekakore == PIROS)
                        {
                            Pirosmana = mostanimana;
                        }
                        else
                        {
                            Kekmana = mostanimana;
                        }
                    }
                    else if (milyentipus == "3")
                    {
                        Babuhozzaad(hovaraksor * 8 + hovarakoszlop, ASSASIN, Kinekakore, NEMLEHETIDELEPNI, 0, 1, milyenszint+2, milyenszint, milyenszint);
                        mostanimana = mostanimana - szuksegesmana;
                        if (Kinekakore == PIROS)
                        {
                            Pirosmana = mostanimana;
                        }
                        else
                        {
                            Kekmana = mostanimana;
                        }
                    }
                }
            }
        }
        void Hovahozhatjaletre() 
        {
            int holabazisomsor = 0;
            int holabazisomoszlop = 0;
            for (int sor = 0; sor < 8; sor++)
            {
                for (int oszlop = 0; oszlop < 8; oszlop++)
                {
                    if (Palya[sor * 8 + oszlop].tulajdonos == Kinekakore && Palya[sor * 8 + oszlop].tipus == BASE)
                    {
                        holabazisomsor = sor;
                        holabazisomoszlop = oszlop;
                    }
                }
            }
            for (int sor = 0; sor < 8; sor++)
            {
                for (int oszlop = 0; oszlop < 8; oszlop++)
                {
                    if (sor - holabazisomsor == 0 || sor - holabazisomsor == 1 || sor - holabazisomsor == -1)
                    {
                        if (oszlop - holabazisomoszlop == 0 || oszlop - holabazisomoszlop == 1 || oszlop - holabazisomoszlop == -1)
                        {
                            if (Palya[sor * 8 + oszlop].tulajdonos == URES)
                            {
                                Palya[sor * 8 + oszlop].ide = LEHETIDELETREHOZNI;
                            }
                            
                        }
                    }
                }
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

            if (Palya[kijeloltsor * 8 + kijeloltoszlop].tulajdonos == Kinekakore)
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
                            Csinalhatevalamit = true;
                        }
                        else if (Palya[Kijeloltsor * 8 + Kijeloltoszlop].energia != 0 &&
                            Palya[sor * 8 + oszlop].tulajdonos != Kinekakore &&
                            Palya[sor * 8 + oszlop].tulajdonos != URES &&
                            Palya[Kijeloltsor * 8 + Kijeloltoszlop].range >= tavolsagutesre &&
                            Palya[Kijeloltsor * 8 + Kijeloltoszlop].damage > Palya[sor * 8 + oszlop].defense)
                        {
                            Palya[sor * 8 + oszlop].ide = LEHETIDEUTNI;
                            Csinalhatevalamit = true;
                        }
                    }
                }
            }
        }
        int Tavolsagutesre(int sor, int oszlop)
        {
            int tavolsag = 20;
            for (int i = 1; i < 8; i++)
            {
                if (Math.Abs(Kijeloltoszlop - oszlop) >= i && Kijeloltsor == sor) 
                { 
                    tavolsag = i;
                }
                if (Math.Abs(Kijeloltsor - sor) >= i && Kijeloltoszlop == oszlop) 
                {
                    tavolsag = i;
                }
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
                if (Csinalhatevalamit == true)
                {

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
        }
        void Utesbekeres()
        {

            Kiirasszinchange();
            if (Palya[Kijeloltsor * 8 + Kijeloltoszlop].tulajdonos == Kinekakore)
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
            Csinalhatevalamit = false;
        }
        void Lepesbekeres()
        {
            if (Palya[Kijeloltsor * 8 + Kijeloltoszlop].tulajdonos != URES)
            {
                Kiirasszinchange();
                if (Palya[Kijeloltsor * 8 + Kijeloltoszlop].tulajdonos == Kinekakore)
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
                Palya[Hovasor * 8 + Hovaoszlop].damage = Palya[Kijeloltsor * 8 + Kijeloltoszlop].damage;
                Palya[Hovasor * 8 + Hovaoszlop].defense = Palya[Kijeloltsor * 8 + Kijeloltoszlop].defense;
                Palya[Hovasor * 8 + Hovaoszlop].level = Palya[Kijeloltsor * 8 + Kijeloltoszlop].level;


                Palya[Kijeloltsor * 8 + Kijeloltoszlop].tulajdonos = URES;
                Palya[Kijeloltsor * 8 + Kijeloltoszlop].tipus = URESMEZO;
                Palya[Kijeloltsor * 8 + Kijeloltoszlop].energia = 0;
                Palya[Kijeloltsor * 8 + Kijeloltoszlop].range = 0;
                Palya[Kijeloltsor * 8 + Kijeloltoszlop].damage = 0;
                Palya[Kijeloltsor * 8 + Kijeloltoszlop].defense = 0;
                Palya[Kijeloltsor * 8 + Kijeloltoszlop].level = 0;


            }
            for (int sor = 0; sor < 8; sor++)
            {
                for (int oszlop = 0; oszlop < 8; oszlop++)
                {
                    Palya[sor * 8 + oszlop].ide = NEMLEHETIDELEPNI;
                }
            }
            Csinalhatevalamit = false;
        }
        void Kiirasszinchange()
        {
            if (Kinekakore == PIROS)
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
            if (Kinekakore == PIROS)
            {
                Kinekakore = KEK;
                Kekmana = Kekmana + 2;
            }
            else
            {
                Kinekakore = PIROS;
                Pirosmana = Pirosmana + 2;
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
                            Palya[sor * 8 + oszlop].energia = 3;
                        }
                        
                    }
                    if (Palya[sor * 8 + oszlop].tulajdonos == URES)
                    {
                        Palya[sor * 8 + oszlop].ide = NEMLEHETIDELEPNI;
                    }
                }
            }
        }
        void Vegeeajateknak() 
        {
            int bazisokszama = 0;
            for (int sor = 0; sor < 8; sor++)
            {
                for (int oszlop = 0; oszlop < 8; oszlop++)
                {
                    if (Palya[sor * 8 + oszlop].tipus == BASE)
                    {
                        bazisokszama++;
                    }
                }
            }
            if (bazisokszama < 2)
            {
                Vegeajateknak = true;
            }
        }
        void Jatekvege() 
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("a {0} játékos nyert!", Kinekakore);
            Console.ReadKey();
        }
    }
}

