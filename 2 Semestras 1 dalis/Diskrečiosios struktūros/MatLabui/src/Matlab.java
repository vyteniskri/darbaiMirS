public class Matlab {
    public static void main(String[] args){
        int[][] mas = new int[9][8];
        mas[1][1] = 5;
        mas[1][2] = 2;
        mas[1][3] = 6;

        mas[2][1] = 1;
        mas[2][2] = 3;

        mas[3][1] = 2;
        mas[3][2] = 4;
        mas[3][3] = 5;

        mas[4][1] = 3;
        mas[4][2] = 5;
        mas[4][3] = 7;

        mas[5][1] = 1;
        mas[5][2] = 3;
        mas[5][3] = 4;
        mas[5][4] = 6;
        mas[5][5] = 8;

        mas[6][1] = 1;
        mas[6][2] = 5;

        mas[7][1] = 4;

        mas[8][1] = 5;


        int Ind = 1;
        int v = 1;
        int[] pastIndexs = new int[8];
        int[][] atsMas = new int[8][8];
        int placeOfpastIndex = 0;
        int minusInd = 1; //pradine reiksm 2
        int n = 0;
        while (n < 7){
            Ind = v;
            boolean isIn = false;
            for (int l = 1; l < pastIndexs.length; l++){
                if (pastIndexs[l] == Ind){
                    isIn = true;
                    break;
                }
            }
            if (isIn == false){
                placeOfpastIndex++;
                pastIndexs[placeOfpastIndex] = Ind;
            }

            for (int j = 1; j < mas[Ind].length; j++){
                if (mas[Ind][j] != 0){
                    boolean is = false;
                    for (int z = 1; z < pastIndexs.length; z++){
                        if (pastIndexs[z] != 0 && pastIndexs[z] == mas[Ind][j]){
                            is = true; // Yra skaicius
                            break;
                        }
                    }
                    if (is == false){
                        int atsMasInd = 1;
                        for (int k = 1; k < atsMas[Ind].length; k++){
                            if (atsMas[Ind][k] != 0){
                                atsMasInd++;
                            }
                        }
                        atsMas[Ind][atsMasInd] = mas[Ind][j];
                        v = mas[Ind][j];
                        minusInd = 1;
                        n++;
                        break;
                    }
                }

            }
            if (v == Ind){
                v = pastIndexs[placeOfpastIndex - minusInd];
                minusInd++;
            }
        }

//        for (int i = 1; i < mas.length; i++){
//            for (int j = 1; j < mas[i].length; j++){
//                System.out.print(mas[i][j]);
//            }
//            System.out.println("");
//        }

        for (int i = 1; i < atsMas.length; i++){
            for (int j = 1; j < atsMas[i].length; j++){
                if (atsMas[i][j] != 0){
                    System.out.print( i + " " + atsMas[i][j] +  " ");
                }
            }
            System.out.println("");
        }

    }
}
