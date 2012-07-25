#include <stdio.h>
#include <math.h>

//#define N 500
//#define M 601
// log 16 =  1.204119982656
#include "multi.h"

int NextPrime(int n);
int divisor(int n);

void main(){
    unsigned Mersenne[500], S[500], T[500], quot[500], res[500];
    int a[500];
    int p, j, k, t, d, r;

    p = 5;

    while(p <525){
        
        Initialize(Mersenne);
        Mersenne[0] = 1;
        LongLeftShift(Mersenne, p);
        Initialize(a);
        a[0] = 1;
        Sub(Mersenne, a);       // Mersenne = 2 ÇÃ p èÊ - 1

        printf("p = %d  \n", p); 
        // Display(Mersenne);

        Initialize(S);
        S[0] = 4;

        for(j = 1; j<p-1; j++){

            Copy(S, a);
            LongMul(S, a);      //  S -> S^2

            Initialize(a);
            a[0] = 2;
            Sub(S, a);          //  S -> S^2 - 2


            LongDiv(S, Mersenne, quot, res);
            if(DivCheck(S, Mersenne, quot, res)==0) {
                    printf("DivCheck Failed\n");
                    return;
            }

 

            Copy(S,T);
            LongRightShift(T, p);

            t = p/16;
            r = p - 16*t;
            d = Degree(S);
            for(k = d; k>t; k--){
                S[k] = 0;
            }
            S[t] = (S[t]<<(32-r))>>(32-r);
            Add(S, T);
            k = Compare(S, Mersenne);
            if(k==1 || k==0){
                Sub(S, Mersenne);
            }


            k = Compare(res, S);
            if(k!=0) {
                printf("Something is wrong\n");
                return;
            }

 

        }
        if(ZeroCheck(S)==0) printf("mersenne,   p = %d\n", p);
    
        p = p+2;
        p = NextPrime(p);   
    }
}
// n à»è„ÇÃç≈è¨ÇÃëfêî (>=3) Çï‘Ç∑ÅB
int NextPrime(int n){
    if(n <3) n = 3;
    if(n%2 == 0 ) n++;

    while(n > divisor(n))  n = n+2;
    return n;
}
// n ÇÃç≈è¨ÇÃê≥ÇÃñÒêî (>1) Çï‘Ç∑ÅB
int divisor(int n){
    int s,i;
    if(n%2 == 0) return 2;
    s = (int) sqrt(n);
    i = 3;
    while(i <= s){
        if(n%i == 0) return i;
        i = i+2;
    }
    return n;
}

