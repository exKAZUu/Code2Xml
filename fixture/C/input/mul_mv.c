#include <stdio.h>


int main(void)
{
    int i, j;
    double x[3] = {-33.0, 9.0, 6.0};
    double a[3][3] = {{2.0, 4.0, 6.0}, 
                      {3.0, 8.0, 7.0}, 
                      {5.0, 7.0, 12345678901234567890.0}};
    double y[3];


    /*  print matrix and vector  */
    printf("x = \n");
    for (i=0; i<3; i++) {
        printf("%6.2f\n", x[i]);
    }

    printf("A = \n");
    for (i=0; i<3; i++) {
        for (j=0; j<3; j++) {
            printf(" %6.5f", a[i][j]);
        }
        printf("\n");
    }


    /*  multiplication  */
    for(i=0; i<3; i++){
        y[i] = 0.0;
        for(j=0; j<3; j++){
            y[i] += a[i][j]*x[j];
        }
    }


    /*  print answer  */            
    printf("A*x = \n");
    for(i=0; i<3; i++){
        printf("%6.2f\n", y[i]);
    }


    return 0;
}
