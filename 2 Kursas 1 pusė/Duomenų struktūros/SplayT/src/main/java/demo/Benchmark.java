
package demo;
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
        SplaySet<Car> splayTree;

        BstSet<Car> bstSet;

        AvlSet<Car> avlSet;

        @Setup(Level.Iteration)
        public void generateElements(BenchmarkParams params) {
            cars = Benchmark.generateElements(Integer.parseInt(params.getParam("elementCount")));
        }

        @Setup(Level.Invocation)
        public void fillCarSet(BenchmarkParams params) {
            splayTree = new SplaySet<Car>();
            addElements(cars, splayTree);

            bstSet = new BstSet<>();
            addElements(cars, bstSet);

            avlSet = new AvlSet<>();
            addElements(cars, avlSet);
        }
    }

    @Param({"10000", "20000", "40000", "80000", "160000"})
    public int elementCount;

    Car[] cars;

    @Setup(Level.Iteration)
    public void generateElements() {
        cars = generateElements(elementCount);
    }
    static Car[] generateElements(int count) {
        return new CarsGenerator().generateShuffle(count, 1.0);
    }

    ///SplayTree tikrinimas
//    @org.openjdk.jmh.annotations.Benchmark
//    public SplaySet<Car> SplayTreePut() {
//        SplaySet<Car> splayTree = new SplaySet<Car>();
//        addElements(cars, splayTree);
//        return splayTree;
//    }

//    @org.openjdk.jmh.annotations.Benchmark
//    public void SplayTreeRemove(FullSet carSet) {
//        for (Car c : carSet.cars){
//            carSet.splayTree.remove(c);
//        }
//    }

    @org.openjdk.jmh.annotations.Benchmark
    public void SplayTreeGet(FullSet carSet) {
        for (Car c : carSet.cars){
            carSet.splayTree.get(c);
        }
    }

    ///BstTree tikrinimas
//    @org.openjdk.jmh.annotations.Benchmark
//    public BstSet<Car> BstSetAdd(){
//        BstSet<Car> bstSet = new BstSet<>();
//        addElements(cars, bstSet);
//        return bstSet;
//    }

//    @org.openjdk.jmh.annotations.Benchmark
//    public void BstSetRemove(FullSet carSet){
//       for (Car c : carSet.bstSet){
//           carSet.bstSet.remove(c);
//       }
//    }
//
    @org.openjdk.jmh.annotations.Benchmark
    public void BstSetGet(FullSet carSet) {
        for (Car c : carSet.cars){
            carSet.bstSet.get(c);
        }
    }

    ///AvlTree tikrinimas
//    @org.openjdk.jmh.annotations.Benchmark
//    public BstSet<Car> AvlSetAdd(){
//        AvlSet<Car> avlSet = new AvlSet<>();
//        addElements(cars, avlSet);
//        return avlSet;
//    }

//    @org.openjdk.jmh.annotations.Benchmark
//    public void AvlSetRemove(FullSet carSet){
//        for (Car c : carSet.avlSet){
//            carSet.avlSet.remove(c);
//        }
//    }
//
    @org.openjdk.jmh.annotations.Benchmark
    public void AvlSetGet(FullSet carSet) {
        for (Car c : carSet.cars){
            carSet.avlSet.get(c);
        }
    }

    public static void addElements(Car[] carArray, SplaySet<Car> carSet) {
        for (int i = 0; i < carArray.length; i++) {
            carSet.put(carArray[i]);
        }
    }

    public static void addElements(Car[] carArray, BstSet<Car> carSet) {
        for (int i = 0; i < carArray.length; i++) {
            carSet.add(carArray[i]);
        }
    }

    public static void addElements(Car[] carArray, AvlSet<Car> carSet) {
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
