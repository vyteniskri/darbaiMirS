public class galimybesJudet {
    public static void main(String[] args) {
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

        for (int i = 1; i < mas.length; i++){
            for (int j = 1; j < mas[i].length; j++){
                if (mas[i][j] != 0){
                    System.out.print(mas[i][j]);
                    int n = mas[i][1];
                    mas[i][1] = mas[i][j];
                    mas[i][j] = n;

                }
            }
            System.out.println();
        }
    }
}
//if (j+1 < mas[i].length &&  mas[i][j] != 0 && mas[i][j+1] != 0){
//        int n = mas[i][j];
//        mas[i][j] = mas[i][j+1];
//        mas[i][j+1] = n;
//        System.out.print(mas[i][j] + "" + mas[i][j+1] + " ");
//        }
