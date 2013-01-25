void Add(unsigned a[], unsigned b[]);
void Sub(unsigned a[], unsigned b[]);
void Mul(unsigned a[], unsigned d);
void LongMul(unsigned a[], unsigned b[]);

unsigned Div(unsigned a[], unsigned d);
void LongDiv(unsigned a[], unsigned b[], unsigned quot[], unsigned res[]);
int DivCheck(unsigned a[], unsigned b[], unsigned quot[], unsigned res[]);

int Compare(unsigned a[], unsigned b[]);
void LeftShift(unsigned a[], int sh);
void LongLeftShift(unsigned a[], int sh);
void RightShift(unsigned a[], int sh);
void LongRightShift(unsigned a[], int sh);
void Initialize(unsigned c[]);

void Copy(unsigned a[], unsigned b[]);
int ZeroCheck(unsigned a[]);
int Degree(unsigned a[]);

void ToDecimal(unsigned [], unsigned w[]);
void ToHex(unsigned w[], unsigned a[]);
unsigned ToHexDiv(unsigned z[]);
int ToHexZeroCheck(unsigned z[]);

void Display(unsigned a[]);
void DisplayHex(unsigned a[]);











void Add(unsigned a[], unsigned b[]){
    int i,j, s;
    unsigned x;
    s = Degree(b);
    for(i = 0; i<=s; i++){
        x = a[i]+b[i];
        if(x <= 0xffff){ 
            a[i] = x;
        } else {         
            a[i] = x & 0xffff;
                         
            j = i+1;     
            while(a[j] == 0xffff) a[j++] = 0;
            a[j]++;
        }
    }
}




void Sub(unsigned a[], unsigned b[]){
    int i,j, s;
    s = Degree(b);
    for(i = 0; i<=s; i++){
        if(a[i]>=b[i]){  
            a[i] = a[i] - b[i];
        } else {         
            a[i] = (0x10000 + a[i]) - b[i];
            j = i+1;     
            while(a[j] == 0) a[j++] = 0xffff;
            a[j]--;
        }
    }
}





void Mul(unsigned a[], unsigned d){
    int i, s;
    unsigned x, q;

    s = Degree(a);
    q = 0;               

    for(i = 0; i<=s+1; i++){
        x = a[i]*d + q;  
                         
        a[i] = x & 0xffff;
        q = x>>16;
                         
                         
    }
}





void LongMul(unsigned a[], unsigned b[]){
    int i,j,k;
    int s,t;
	
    unsigned x, q, c[500];

    s = Degree(a);
    t = Degree(b);
    Initialize(c);       

    for(i = 0; i<=s; i++){
        for(j = 0; j<=t; j++){
            x = a[i]*b[j]; k = i+j;
                         
            while(x>0){
                q = c[k] + x;
                c[k] = q & 0xffff;
                x = q>>16;
                         
                         
                k++;     
            }
        }
    }
    Copy(c,a);
}





unsigned Div(unsigned a[], unsigned d){
    int i,x,q;
    unsigned res;
    res = 0;             
    
    i = Degree(a);       
    while(i>=0){
        x = (res<<16) + a[i];
                         
                         
        q = x/d;         
        res = x - q*d;   
        a[i] = q;
        i--;             
    }
    return res;
}




void LongDiv(unsigned a[], unsigned b[], 
             unsigned quot[], unsigned res[]){
    int s, t, k, sh;
    int i;
    unsigned x, D, Q;
	
    unsigned c[500], d[500];
    
    
    Copy(a, res);
    Initialize(quot);
    if(Compare(res, b) == -1) return;

    
    t = Degree(b);
    
    
    
    

    sh=0;
    x = b[t];
    while( (x &(0x8000)) == 0){
        x = x<<1;
        sh++;
    }

    LeftShift(res, sh);
    LeftShift(b, sh);
    while(1){
        s = Degree(res);
                                     
        if(res[s] >= b[t]){          
            Initialize(c); 
            for(i = 0; i<=t;i++) c[s-t+i] = b[i];
            k = Compare(res, c);
            if(k == 1 || k == 0){
                quot[s-t] = 1;
                Sub(res, c);
            } else {
                Initialize(c);
                Initialize(d);
                for(i=0; i<=t;i++) c[s-t-1+i]=b[i];
                Copy(c,d);            
                D = 0xffff;
                Mul(c,D);
                while(1){
                    k = Compare(res, c);
                    if(k == 1 || k ==  0) break;
                    Sub(c,d);
                    D--;
                }
                quot[s-t-1] = D;
                Sub(res, c);
            }
        } else {                      
            x = (res[s]<<16) + res[s-1];
            Q = x / b[t];
            Initialize(c);
            Initialize(d);
            for(i=0;i<=t;i++) c[s-t-1+i] = b[i];
            Copy(c,d);
            Mul(c, Q);
            while(1){
                k = Compare(res, c);
                if(k == 1 || k == 0) break;
                Sub(c,d);
                Q--;
            }
            quot[s-t-1] = Q;
            Sub(res, c);
        }
        k = Compare(res, b);
        if(k == -1) break;
    }
    RightShift(res, sh);
    RightShift(b, sh);
}





int DivCheck(unsigned a[], unsigned b[], unsigned quot[], unsigned res[]){
    
	unsigned c[500];
    Copy(b,c);
    LongMul(c, quot);
    Add(c, res);
    if(Compare(a, c) ==0) return 1;
    return 0;
}




int Compare(unsigned a[], unsigned b[]){
    int s,t;

    s = Degree(a);
    t = Degree(b);
    if(s<t) return -1;
    if(s>t) return 1;
    while(s>0 && a[s]==b[s]) s--;
    if(a[s]<b[s]) return -1;
    if(a[s]>b[s]) return 1;
    return 0;
}



void LeftShift(unsigned a[], int sh){
    int i, x;
    if(sh == 0) return;

    i = Degree(a);
    
    x = a[i]<<sh;
    if(x > 0xffff) a[i+1] |= (x>>16);
    a[i] = x & 0xffff;
    i--;
    
    while(i>=0){
        x = a[i]<<sh;
        a[i+1] |= (x>>16);
        a[i] = x & 0xffff;
        i--;
    }
}



void LongLeftShift(unsigned a[], int sh){
    int i, u;
	
    unsigned temp[500];
    if(sh < 16){
        LeftShift(a, sh);
    } else {
        u = sh/16;
        sh = sh - u*16;
        
        i = Degree(a);
        Initialize(temp);
        while(i>=0){
            temp[i+u] = a[i];
            i--;
        }
        Copy(temp, a);
        LeftShift(a, sh);
    }
}


void RightShift(unsigned a[], int sh){
    int i, j, x;
    if(sh==0) return;

    i = Degree(a);
    
	
    i = 500-1;
    while(i>0 && a[i]==0) i--;
    
    a[0] = a[0]>>sh;
    j=1;
    
    while(j<=i){
        x = (a[j]<<16)>>sh;
        a[j-1]|= (x & 0xffff);
        a[j] = x>>16;
        j++;
    }
}



void LongRightShift(unsigned a[], int sh){
    int i, u;
	
    unsigned temp[500];
    if(sh < 16){
        RightShift(a, sh);
    } else {
        u = sh/16;
        sh = sh - u*16;

        i = Degree(a);
        Initialize(temp);
        while(i>=u){
            temp[i-u] = a[i];
            i--;
        }
        Copy(temp, a);
        RightShift(a, sh);
    }
}




void Initialize(unsigned c[]){
    int i,t;
    t = Degree(c);
    for(i = 0; i<=t; i++) c[i] = 0;
}




void Copy(unsigned a[], unsigned b[]){
    int i,s;
    s = Degree(a);
    Initialize(b);
    for(i = 0; i<=s; i++) b[i] = a[i];
}




int ZeroCheck(unsigned a[]){
    int i,j = 0;
	
    for(i = 500-1; i>=0; i--){
        if(a[i] !=0 ){
            j = -1;
            break;
        }
    }
    return j;
}




int Degree(unsigned a[]){
	
    int i = 500-1;
    while(i>0 && a[i]==0) i--;
    return i;
}


void ToDecimal(unsigned a[], unsigned w[]){
    int i;
	
    unsigned b[500];
    Copy(a, b);
	
    for(i = 0; i<601; i++) w[i] = 0;
    i = 0;
    while( ZeroCheck(b)==-1 ) w[i++] = Div(b, 10000);

}


void ToHex(unsigned w[], unsigned a[]){
    int i;
	
    unsigned z[601];
	
    for(i = 0; i<601; i++) z[i] = w[i];
    for(i = 0; i<500; i++) a[i] = 0;
    i = 0;
    while( ToHexZeroCheck(z) == -1) a[i++] = ToHexDiv(z);
}



unsigned ToHexDiv(unsigned z[]){
    int i;
    unsigned x, q, res;

    res = 0;
    
    
	
    i = 601-1;
    while(i>0 && z[i]==0)i--;

    while(i>=0){
        x = res*10000 + z[i];
        q = (x>>16);
        res = x - (q<<16);
        z[i] = q;
        i--;
    }
    return res;
}



int ToHexZeroCheck(unsigned z[]){
    int i, j = 0;
	
    for(i = 601-1;i>=0;i--){
        if(z[i] != 0){
            j = -1;
            break;
        }
    }
    return j;
}



void Display(unsigned a[]){
    int i;
	
    unsigned w[601];       
    ToDecimal(a, w);

    i = Degree(w);
    printf("%4.1u ", w[i]);
    i--;
    while(i>=0){
        printf("%4.4u ", w[i]);
        i--;
    }
    printf("\n");
}


void DisplayHex(unsigned a[]){
    int i;
    i = Degree(a);
    while(i>=0) printf("%4.4x ", a[i--]);
    printf("\n");
}
