package edu.ktu.ds.lab2.demo;

import edu.ktu.ds.lab2.utils.*;
import org.openjdk.jmh.annotations.*;
import org.openjdk.jmh.infra.BenchmarkParams;
import org.openjdk.jmh.runner.Runner;
import org.openjdk.jmh.runner.RunnerException;
import org.openjdk.jmh.runner.options.Options;
import org.openjdk.jmh.runner.options.OptionsBuilder;

import java.util.concurrent.TimeUnit;

@BenchmarkMode(Mode.AverageTime)
@State(Scope.Benchmark)
@OutputTimeUnit(TimeUnit.MICROSECONDS)
@Warmup(time = 1, timeUnit = TimeUnit.SECONDS)
@Measurement(time = 1, timeUnit = TimeUnit.SECONDS)
public class Benchmark {

    @State(Scope.Benchmark)
    public static class FullSet {

        Car[] cars;
        AvlSet<Car> avlSet;
        BstSet<Car> bstSet;

        @Setup(Level.Iteration)
        public void generateElements(BenchmarkParams params) {
            cars = Benchmark.generateElements(Integer.parseInt(params.getParam("elementCount")));
        }

        @Setup(Level.Invocation)
        public void fillCarSet(BenchmarkParams params) {
            addElements(cars, bstSet = new BstSet<>());
            addElements(cars, avlSet = new AvlSet<>());
        }
    }

    @Param({"4000", "8000", "16000", "32000", "64000"})
    public int elementCount;

    Car[] cars;

    @Setup(Level.Iteration)
    public void generateElements() {
        cars = generateElements(elementCount);
    }
    static Car[] generateElements(int count) {
        return new CarsGenerator().generateShuffle(count, 1.0);
    }

    @org.openjdk.jmh.annotations.Benchmark
    public void BstSetContainsAll(FullSet carSet) {
       carSet.bstSet.containsAll(carSet.bstSet);
    }

    @org.openjdk.jmh.annotations.Benchmark
    public void AvlSetContainsAll(FullSet carSet) {
        carSet.avlSet.containsAll(carSet.avlSet);
    }
    public static void addElements(Car[] carArray, SortedSet<Car> carSet) {
        for (int i = 0; i < carArray.length; i++) {
            carSet.add(carArray[i]);
        }
    }

    public static void main(String[] args) throws RunnerException {
        Options opt = new OptionsBuilder()
                .include(Benchmark.class.getSimpleName())
                .forks(1)
                .build();
        new Runner(opt).run();
    }
}
