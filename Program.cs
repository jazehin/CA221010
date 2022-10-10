namespace CA221010
{
    public class Allat
    {
        public string Nev { get; set; }
        public float Suly { get; private set; } = 0f;
        
        public virtual string HangotAd() => "valami - valami";

        public void Taplalkozik(float kgKaja) => Suly += kgKaja;

        public void Mondja() => Console.WriteLine($"{Nev} mondja: {HangotAd()}");


    }

    public class Tita : Allat // -> korai kötés
    {
        public int EletekSzama { get; set; } = 9;

        public new string HangotAd() => "mijau - mijau";
    }

    public class Kuta : Allat // késői kötés
    {
        public bool Huseges { get; set; } = true;
        
        public override string HangotAd() => "vau - vau";
    }



    internal class Program
    {
        static void Main(string[] args)
        {
            #region jegyzet
            // encapsulation
            // - logikailag összetartozó dolgok (fields, methods) egy egységbe vannak zárva
            // - a helyes állapotért ez az egység felel

            // inheritance
            // - elsősorban az osztályok "továbbfejleszthetőségének" a lehetősége
            // - a gyermekosztály MINDENT örököl a szülő osztálytől
            // - el tudja "fedni" az eredeti metódust, ha azonos a fejléce
            // - de a régi 'örökölt' nem "tűnik el" (korai kötés: ott a régi, castolással elérhető)

            //polymorphism
            // - az ősosztály példányai képesek használni a gyermekosztály metódusait is, megfelelő körülmények között
            // - (késői kötés: át van írva, nem érhető el a régi)
            #endregion
            

            Allat allat = new Allat() { Nev = "Gertrúd" };
            Tita tita = new Tita() { Nev = "Lukrécia" };
            Kuta kuta = new Kuta() { Nev = "Bodri" };

            Console.WriteLine("A szülőosztály metódusával");
            allat.Mondja();
            tita.Mondja();
            kuta.Mondja();

            Console.WriteLine("\nMain metódusból");
            Console.WriteLine($"{allat.Nev} mondja: {allat.HangotAd()}");
            Console.WriteLine($"{tita.Nev} mondja: {tita.HangotAd()}");
            Console.WriteLine($"{kuta.Nev} mondja: {kuta.HangotAd()}");

            List<Allat> allatok = new();
            allatok.Add(allat);
            allatok.Add(tita);
            allatok.Add(kuta);

            Console.WriteLine("\nAllat lista részeként");
            foreach (Allat a in allatok)
            {
                Console.WriteLine($"{a.Nev} mondja: {a.HangotAd()}");
                if (a is Tita)
                    Console.WriteLine((a as Tita).HangotAd());
            }

            kuta.Taplalkozik(3.5f);
            Console.WriteLine($"\n{kuta.Nev} súlya: {kuta.Suly} kg");
        }
    }
}