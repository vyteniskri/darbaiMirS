package edu.ktu.ds.lab2.demo;

import edu.ktu.ds.lab2.utils.*;
import edu.ktu.ds.lab2.utils.Set;

import java.util.*;
import java.util.function.Consumer;

/*
 * Aibės testavimas be Gui
 * Dirbant su Intellij ir norint konsoleje matyti gražų pasuktą medį,
 * reikia File -> Settings -> Editor -> File Encodings -> Global encoding pakeisti į UTF-8
 *
 */
public class ManualTest {

    static Car[] cars;
    static ParsableSortedSet<Car> cSeries = new ParsableBstSet<>(Car::new, Car.byPrice);

    public static void main(String[] args) throws CloneNotSupportedException {
        Locale.setDefault(Locale.US); // Suvienodiname skaičių formatus
        TestBst();
        //TestAvl();
        //executeTest();
    }

    public static void TestAvl(){
        ///AVL testavimas
        Car c1 = new Car("Renault", "Laguna", 2007, 50000, 1700);
        Car c2 = new Car.Builder()
                .make("Renault")
                .model("Megane")
                .year(2011)
                .mileage(20000)
                .price(3500)
                .build();
        Car c3 = new Car.Builder().buildRandom();
        Car c4 = new Car("Renault Laguna 2011 115900 700");
        Car c5 = new Car("Renault Megane 1946 365100 9500");
        Car c6 = new Car("Honda   Civic  2011  36400 80.3");
        Car c7 = new Car("Renault Laguna 2011 115900 7500");
        Car c8 = new Car("Renault Megane 1946 365100 950");
        Car c9 = new Car("Honda   Civic  2017  36400 850.3");
        Car c10 = new Car("Renault Laguna 2011 115900 700");
        Car c11 = new Car("Renault Megane 1946 365100 950");
        Car c12 = new Car("Renault Laguna 2011 115900 700");
        Car c13 = new Car("Renault Laguna 2011 115900 700");
        Car c14 = new Car("Renault Megane 1946 365100 9500");
        Car c15 = new Car("Honda   Civic  2011  36400 80.3");
        Car c16 = new Car("Renault Laguna 2011 115900 7500");
        Car c17 = new Car("Renault Megane 1946 365100 950");
        Car c18 = new Car("Honda   Civic  2017  36400 850.3");

        Car[] carsArray = {c9, c7, c8, c16, c17, c18, c11, c5,c1,c6,c2,c10,c3,c4,c15,c12,c13,c14};
        Ks.oun("Automobilių aibė AVL-medyje:");
        ParsableSortedSet<Car> carsSetAvl1 = new ParsableAvlSet<>(Car::new);
        ParsableSortedSet<Car> carsSetAvl2 = new ParsableAvlSet<>(Car::new);
        ParsableSortedSet<Car> carsSetAvl3 = new ParsableAvlSet<>(Car::new);
        ParsableSortedSet<Car> carsSetAvl4 = new ParsableAvlSet<>(Car::new);

        for (Car c : carsArray) {
            carsSetAvl1.add(c);
            carsSetAvl2.add(c);
            carsSetAvl3.add(c);
            carsSetAvl4.add(c);
        }

        Ks.ounn(carsSetAvl1.toVisualizedString(""));

        Ks.oun("LEFT");
        carsSetAvl1.remove(c1);
        Ks.ounn(carsSetAvl1.toVisualizedString(""));

        Ks.oun("DOUBLE LEFT");
        carsSetAvl2.remove(c15);
        carsSetAvl2.remove(c11);
        carsSetAvl2.remove(c10);
        carsSetAvl2.remove(c9);
        Ks.ounn(carsSetAvl2.toVisualizedString(""));

        Ks.oun("RIGHT");
        carsSetAvl3.remove(c11);
        carsSetAvl3.remove(c13);
        carsSetAvl3.remove(c15);
        carsSetAvl3.remove(c14);
        Ks.ounn(carsSetAvl3.toVisualizedString(""));

        Ks.oun("DOUBLE RIGHT");
        carsSetAvl4.remove(c6);
        Ks.ounn(carsSetAvl4.toVisualizedString(""));

        Ks.oun("");
    }

    public static void TestBst(){
        BstSet<Car> nodes = new BstSet<Car>();

        Car c1 = new Car("Renault", "Laguna", 2007, 50000, 1700);
        Car c3 = new Car.Builder().buildRandom();
        Car c4 = new Car("Renault Laguna 2011 115900 700");
        Car c5 = new Car("Renault Megane 1946 365100 9500");
        Car c6 = new Car("Honda   Civic  2011  36400 80.3");
        Car c7 = new Car("Renault Laguna 2011 115900 7500");
        Car c8 = new Car("Renault Megane 1946 365100 950");
        Car c9 = new Car("Honda   Civic  2017  36400 850.3");

        nodes.add(c9);
        nodes.add(c7);
        nodes.add(c8);
        nodes.add(c5);
        nodes.add(c1);
        nodes.add(c6);

        Ks.oun("Auto Aibė:");

        for (Car a : nodes){
            Ks.oun("Aibė papildoma: " + a);
        }

        Ks.oun("");
        Ks.oun(nodes.toVisualizedString(""));

        //Remove
        Ks.oun("Remove");
        nodes.remove(c9);

        for (Car a : nodes){
            Ks.oun("Aibė papildoma: " + a);
        }

        Ks.oun("");
        Ks.oun(nodes.toVisualizedString(""));

        ///Remove iteratoriaus klaseje
        Ks.oun("Iteratoriaus Remove");
        Iterator<Car> iterat = nodes.iterator();

        int i = 0;
        while(iterat.hasNext()){
            Ks.oun("Aibė papildoma: " + iterat.next());
            if (i == 2){
                iterat.remove();
            }
            i++;
        }

        Ks.oun("");
        for (Car a : nodes){
            Ks.oun("Aibė papildoma: " + a);
        }

        Ks.oun("");

        ///AddAll
        Ks.oun("AddAll");
        Set<Car> set = new BstSet<>();
        set.add(c1);
        set.add(c3);
        set.add(c5);

        nodes.addAll(set);
        for (Car a : nodes){
            Ks.oun("Aibė papildoma: " + a);
        }
        Ks.oun(nodes.toVisualizedString(""));

        ///ContainsAll
        Ks.oun("ContainsAll");
        Ks.oun("Ar aibeje yra visi elementai ęsantys aibėje set: " + nodes.containsAll(set));

        nodes.remove(c1);
        Ks.oun("Ar aibeje yra visi elementai ęsantys aibėje set: " + nodes.containsAll(set));

        Ks.oun("");

        ///RetainAll
        Ks.oun("RetainAll");
        nodes.retainAll(set);

        for (Car a : nodes){
            Ks.oun("Aibė papildoma: " + a);
        }
        Ks.oun("");

        ///HeadSet
        Ks.oun("HeadSet");
        BstSet<Car> nodes2 = new BstSet<>();
        nodes2.add(c4);
        nodes2.add(c5);
        nodes2.add(c6);
        nodes2.add(c7);
        nodes2.add(c8);

        Set<Car> n1 = nodes2.headSet(c6);

        for (Car a : n1){
            Ks.oun("Aibė papildoma: " + a);
        }
        Ks.oun("");

        ///TailSet
        Ks.oun("TailSet");
        Set<Car> n2 = nodes2.tailSet(c5);

        for (Car a : n2){
            Ks.oun("Aibė papildoma: " + a);
        }
        Ks.oun("");

        ///SubSet
        Ks.oun("SubSet");
        Set<Car> n3 = nodes2.subSet(c5, c8);
        for (Car a : n3){
            Ks.oun("Aibė papildoma: " + a);
        }
        Ks.oun("");



    }

    public static void executeTest() throws CloneNotSupportedException {
        Car c1 = new Car("Renault", "Laguna", 2007, 50000, 1700);
        Car c2 = new Car.Builder()
                .make("Renault")
                .model("Megane")
                .year(2011)
                .mileage(20000)
                .price(3500)
                .build();
        Car c3 = new Car.Builder().buildRandom();
        Car c4 = new Car("Renault Laguna 2011 115900 700");
        Car c5 = new Car("Renault Megane 1946 365100 9500");
        Car c6 = new Car("Honda   Civic  2011  36400 80.3");
        Car c7 = new Car("Renault Laguna 2011 115900 7500");
        Car c8 = new Car("Renault Megane 1946 365100 950");
        Car c9 = new Car("Honda   Civic  2017  36400 850.3");

        Car[] carsArray = {c9, c7, c8, c5, c1, c6};

        Ks.oun("Auto Aibė:");
        ParsableSortedSet<Car> carsSet = new ParsableBstSet<>(Car::new);

        for (Car c : carsArray) {
            carsSet.add(c);
            Ks.oun("Aibė papildoma: " + c + ". Jos dydis: " + carsSet.size());
        }
        Ks.oun("");
        Ks.oun(carsSet.toVisualizedString(""));

        ParsableSortedSet<Car> carsSetCopy = (ParsableSortedSet<Car>) carsSet.clone();

        carsSetCopy.add(c2);
        carsSetCopy.add(c3);
        carsSetCopy.add(c4);
        Ks.oun("Papildyta autoaibės kopija:");
        Ks.oun(carsSetCopy.toVisualizedString(""));

        c9.setMileage(10000);

        Ks.oun("Originalas:");
        Ks.ounn(carsSet.toVisualizedString(""));

        Ks.oun("Ar elementai egzistuoja aibėje?");
        for (Car c : carsArray) {
            Ks.oun(c + ": " + carsSet.contains(c));
        }
        Ks.oun(c2 + ": " + carsSet.contains(c2));
        Ks.oun(c3 + ": " + carsSet.contains(c3));
        Ks.oun(c4 + ": " + carsSet.contains(c4));
        Ks.oun("");

        Ks.oun("Ar elementai egzistuoja aibės kopijoje?");
        for (Car c : carsArray) {
            Ks.oun(c + ": " + carsSetCopy.contains(c));
        }
        Ks.oun(c2 + ": " + carsSetCopy.contains(c2));
        Ks.oun(c3 + ": " + carsSetCopy.contains(c3));
        Ks.oun(c4 + ": " + carsSetCopy.contains(c4));
        Ks.oun("");

        Ks.oun("Automobilių aibė su iteratoriumi:");
        Ks.oun("");
        for (Car c : carsSet) {
            Ks.oun(c);
        }
        Ks.oun("");
        Ks.oun("Automobilių aibė AVL-medyje:");
        ParsableSortedSet<Car> carsSetAvl = new ParsableAvlSet<>(Car::new);
        for (Car c : carsArray) {
            carsSetAvl.add(c);
        }
        Ks.ounn(carsSetAvl.toVisualizedString(""));

        Ks.oun("Automobilių aibė su iteratoriumi:");
        Ks.oun("");
        for (Car c : carsSetAvl) {
            Ks.oun(c);
        }

        Ks.oun("");
        Ks.oun("Automobilių aibė su atvirkštiniu iteratoriumi:");
        Ks.oun("");
        Iterator<Car> iter = carsSetAvl.descendingIterator();
        while (iter.hasNext()) {
            Ks.oun(iter.next());
        }

        Ks.oun("");
        Ks.oun("Automobilių aibės toString() metodas:");
        Ks.ounn(carsSetAvl);

        // Išvalome ir suformuojame aibes skaitydami iš failo
        carsSet.clear();
        carsSetAvl.clear();

        Ks.oun("");
        Ks.oun("Automobilių aibė DP-medyje:");
        carsSet.load("data\\ban.txt");
        Ks.ounn(carsSet.toVisualizedString(""));
        Ks.oun("Išsiaiškinkite, kodėl medis augo tik į vieną pusę.");

        Ks.oun("");
        Ks.oun("Automobilių aibė AVL-medyje:");
        carsSetAvl.load("data\\ban.txt");
        Ks.ounn(carsSetAvl.toVisualizedString(""));

        Set<String> carsSet4 = CarMarket.duplicateCarMakes(carsArray);
        Ks.oun("Pasikartojančios automobilių markės:\n" + carsSet4);

        Set<String> carsSet5 = CarMarket.uniqueCarModels(carsArray);
        Ks.oun("Unikalūs automobilių modeliai:\n" + carsSet5);
        Set<String> carsSet6 = CarMarket.uniqueCarModelsLambdaStyle(carsArray);
        Ks.oun("Unikalūs automobilių modeliai (lambda):\n" + carsSet6);
    }

    static ParsableSortedSet<Car> generateSet(int kiekis, int generN) {
        cars = new Car[generN];
        for (int i = 0; i < generN; i++) {
            cars[i] = new Car.Builder().buildRandom();
        }
        Collections.shuffle(Arrays.asList(cars));

        cSeries.clear();
        Arrays.stream(cars).limit(kiekis).forEach(cSeries::add);
        return cSeries;
    }
}
