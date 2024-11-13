package demo;

import java.io.PrintStream;

public class Ks {
    private static final PrintStream sout = System.out;
    private static final PrintStream serr = System.out;
    private static int errorNr;

    static public void oun(Object obj) {
        sout.println(obj);
    }

    static public void ern(Object obj) {
        serr.printf("***Klaida %d: %s\n", ++errorNr, obj);
    }
}
