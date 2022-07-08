using System;

namespace ierarhie
{
    class Program
    {
        static void Main(string[] args)
        {

            Persoana p1 = new Persoana("Kerry", "Wareing", 44, "CEO");
            Persoana p2 = new Persoana("Barnabas", "Hairsine", 53, "Deputy Director");
            Persoana p3 = new Persoana("Judie", "Osmon", 29, "IT Division");
            Persoana p4 = new Persoana("Radcliffe", "Chastanet", 24, "Marketing Head");
            Persoana p5 = new Persoana("Mandie", "Trusty", 22, "Security Head");
            Persoana p6 = new Persoana("Schuyler", "Ibarra", 25, "App Development Head");
            Persoana p7 = new Persoana("Kiley", "Curless", 38, "Logistics Head");
            Persoana p8 = new Persoana("Cameron", "Eidler", 44, "Public Relations Head");

            Ierarhie ierarhie = new Ierarhie(p1);

            ierarhie.addSubordinate("CEO", p2);
            ierarhie.addSubordinate("Deputy Director", p3);
            ierarhie.addSubordinate("Deputy Director", p4);

            ierarhie.addSubordinate("IT Division", p5);
            ierarhie.addSubordinate("IT Division", p6);

            ierarhie.addSubordinate("Marketing Head", p7);
            ierarhie.addSubordinate("Marketing Head", p8);

            ierarhie.afisare();


        }
    }
}
