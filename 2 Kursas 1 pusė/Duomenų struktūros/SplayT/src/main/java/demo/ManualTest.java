package demo;

public class ManualTest {
    public static void main(String[] args){

        TestSplayTree();
    }

    public static void TestSplayTree(){
        SplaySet<Car> set = new SplaySet<Car>();
        Car c1 = new Car("Renault", "Laguna", 2007, 50000, 1700);
        Car c2 = new Car("BMW", "E39", 2000, 10000, 3000);
        Car c3 = new Car("Tojota", "Elm", 2010, 200000, 10000);
        Car c4 = new Car("Subaru", "Auto", 2003, 50000, 2000);
        Car c5 = new Car("Volksvagen", "Pasat", 2007, 150000, 1500);
        Car c6 = new Car("Lexus", "Rib", 2005, 12000, 17000);

        Ks.oun("Patalpinti duomenys");
        set.put(c5);
        set.put(c6);
        set.put(c3);
        set.put(c2);
        set.put(c1);
        set.put(c4);

        for (Car c : set){
            Ks.oun(c);

        }
        Ks.oun("");
        Ks.oun(set.toVisualizedString(""));

        Ks.oun("Panaikintas automobilis Tojota");
        set.remove(c3);
        for (Car c : set){
            Ks.oun(c);

        }
        Ks.oun("");
        Ks.oun(set.toVisualizedString(""));

        Ks.oun("Bandoma įdėti jau egzistuojantį automobilį Renault");
        set.put(c1);
        for (Car c : set){
            Ks.oun(c);

        }
        Ks.oun("");
        Ks.oun(set.toVisualizedString(""));

        Ks.oun("Bandoma paimti automobilį BMW");
        Ks.oun(set.get(c2));
        Ks.oun("");
        Ks.oun(set.toVisualizedString(""));

        Ks.oun("Tikrinama ar egzistuoja automobilis Tojota");
        Ks.oun(set.contains(c3));
        Ks.oun("");
        Ks.oun(set.toVisualizedString(""));

        Ks.oun("Gražinamas splayTree elementų skaičius");
        Ks.oun(set.size());
        Ks.oun("");

        Ks.oun("Gražinamas medžio šaknies aukštis");
        Ks.oun(set.height());

    }
}
