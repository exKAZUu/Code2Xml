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

// 原則的に大きさ N の配列を扱う。但し 10 進表示に直すときに
// 大きさ M の配列を扱う。
// 4*N = 16 進の桁数、4*M = 10 進の桁数、M≒1.2041 N
// 関数の定義箇所は　//関数名　で検索可能

//Add 足算  ------------------------------------------------
// 長倍精度整数 a[] に長倍精度整数 b[] を加え、
// 結果を a[] に格納する。
// a + b -> a

void Add(unsigned a[], unsigned b[]){
    int i,j, s;
    unsigned x;
    s = Degree(b);
    for(i = 0; i<=s; i++){
        x = a[i]+b[i];
        if(x <= 0xffff){ // 桁上がりしないとき
            a[i] = x;
        } else {         // 桁上がりするとき
            a[i] = x & 0xffff;
                         // a[i] = x の下位 2 バイト
            j = i+1;     // 桁上がり処理
            while(a[j] == 0xffff) a[j++] = 0;
            a[j]++;
        }
    }
}
//Sub 引き算 -----------------------------------------------
// 長倍精度整数 a[] から長倍精度整数 b[] を引き、
// 結果を a[] に格納する。 a[] >= b[] であること。
// a - b -> a  (a >= b)
void Sub(unsigned a[], unsigned b[]){
    int i,j, s;
    s = Degree(b);
    for(i = 0; i<=s; i++){
        if(a[i]>=b[i]){  // そのまま引けるとき
            a[i] = a[i] - b[i];
        } else {         // 上の桁から 1 を借りる時
            a[i] = (0x10000 + a[i]) - b[i];
            j = i+1;     // 上の桁から 1 を引く
            while(a[j] == 0) a[j++] = 0xffff;
            a[j]--;
        }
    }
}

//Mul かけ算 1 ---------------------------------------------
// 長倍精度整数 a[] と 2 バイト整数 d の積
// 結果を a[] に格納する
// a*d -> a (d <=0xffff)
void Mul(unsigned a[], unsigned d){
    int i, s;
    unsigned x, q;

    s = Degree(a);
    q = 0;               // 桁上がり用のための変数

    for(i = 0; i<=s+1; i++){
        x = a[i]*d + q;  // a[i] に d を掛けて、
                         // 桁上がりしてきた数値 q を加える
        a[i] = x & 0xffff;
        q = x>>16;
                         // a[i] = x の下位 2 バイト
                         //    q = x の上位 2 バイト
    }
}

//LongMul かけ算 2 -----------------------------------------
// 長倍精度整数 a[] と長倍精度整数 b[] の積
// 結果を a[] に格納する
// a*b -> a
void LongMul(unsigned a[], unsigned b[]){
    int i,j,k;
    int s,t;
	//
    unsigned x, q, c[500];

    s = Degree(a);
    t = Degree(b);
    Initialize(c);       // 初期化

    for(i = 0; i<=s; i++){
        for(j = 0; j<=t; j++){
            x = a[i]*b[j]; k = i+j;
                         // 以下、桁上がり処理
            while(x>0){
                q = c[k] + x;
                c[k] = q & 0xffff;
                x = q>>16;
                         // c[k] = q の下位 2 バイト
                         //    x = q の上位 2 バイト
                k++;     // より上位の桁に加える
            }
        }
    }
    Copy(c,a);
}
//Div 割り算 1 -------------------------------------------- 
// 長倍精度整数 a[] を 2 バイト整数 d で割る。
// 商を a[] に格納し、余り res (2 バイト整数) を返す。
// d は 0 でないこと。
// a/d -> a (d <= 0xffff), 余り res を返す。
unsigned Div(unsigned a[], unsigned d){
    int i,x,q;
    unsigned res;
    res = 0;             // 上位の桁を割ったときのおつり
    
    i = Degree(a);       // 最上位の桁から順番に d で割る
    while(i>=0){
        x = (res<<16) + a[i];
                         //   x = 上位の桁からのおつりに
                         //        i 番目の桁を加える
        q = x/d;         //   q = x を d で割ったときの商
        res = x - q*d;   // res = x を d で割ったときの余り
        a[i] = q;
        i--;             // 1 つ下の桁にうつる
    }
    return res;
}
//LongDiv 割り算 2 -----------------------------------------
// 長倍精度整数 a[] を長倍精度整数 b[] で割る
// a/b  の商を quot[], 余りを res[] に格納,   
// b は 0 でないこと。
void LongDiv(unsigned a[], unsigned b[], 
             unsigned quot[], unsigned res[]){
    int s, t, k, sh;
    int i;
    unsigned x, D, Q;
	//
    unsigned c[500], d[500];
    
    // 初期化
    Copy(a, res);
    Initialize(quot);
    if(Compare(res, b) == -1) return;

    // 以後 res/b を実行する。
    t = Degree(b);
    // if(t==0 && b[0]==0) {
    //    printf("0 で除算。 Ctrl + c で終了\n");
    // }                    
    // b が 0 の場合には以下の while ループが無限ループ

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
                                     // 最上位の数の比較
        if(res[s] >= b[t]){          // res[s] >= b[t] の場合
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
                Copy(c,d);            // c = d;
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
        } else {                      // res[s] < b[t] の場合
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

//DivCheck  割り算の検算 ------------------------------------
//  LongDiv(a,b,quot, res) を実行後に
//  DivCheck(a, b, quote, res) を実行する。
//  正しければ 1 を返し、間違っていれば 0 を返す。
int DivCheck(unsigned a[], unsigned b[], unsigned quot[], unsigned res[]){
    //
	unsigned c[500];
    Copy(b,c);
    LongMul(c, quot);
    Add(c, res);
    if(Compare(a, c) ==0) return 1;
    return 0;
}

//Compare 大小比較 -----------------------------------------
// 長倍精度整数 a[] と長倍精度 b[] の比較。
// a > b ならば 1, a < b ならば -1, a = b ならば 0 を返す
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
//シフト (桁ずらし) ------------------------------
//LeftShift
// a を左へ sh 桁シフト、(0<=sh <=16)
void LeftShift(unsigned a[], int sh){
    int i, x;
    if(sh == 0) return;

    i = Degree(a);
    // 最上位の桁だけ別に処理
    x = a[i]<<sh;
    if(x > 0xffff) a[i+1] |= (x>>16);
    a[i] = x & 0xffff;
    i--;
    //
    while(i>=0){
        x = a[i]<<sh;
        a[i+1] |= (x>>16);
        a[i] = x & 0xffff;
        i--;
    }
}
//LongLeftShift
// a を左へ sh 桁シフト  (sh は 16 以上でもよい)
// はみ出しチェックをしていない。
void LongLeftShift(unsigned a[], int sh){
    int i, u;
	//
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
//RightShift
// a を右へ sh 桁シフト、(0<=sh <=16)、はみ出た部分は忘れる。
void RightShift(unsigned a[], int sh){
    int i, j, x;
    if(sh==0) return;

    i = Degree(a);
    // 最高位の桁を探す,
	//
    i = 500-1;
    while(i>0 && a[i]==0) i--;
    // 最下位の桁だけ別に処理
    a[0] = a[0]>>sh;
    j=1;
    //
    while(j<=i){
        x = (a[j]<<16)>>sh;
        a[j-1]|= (x & 0xffff);
        a[j] = x>>16;
        j++;
    }
}
//LongRightShift
// a を右へ sh 桁シフト、(sh は 16 より大きくてもよい), 
// はみでた部分は忘れる。
void LongRightShift(unsigned a[], int sh){
    int i, u;
	//
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
//Initialize
// 配列の初期化 --------------------------------------------
// 長倍精度整数 c[] を 0 にする。
// c -> 0
void Initialize(unsigned c[]){
    int i,t;
    t = Degree(c);
    for(i = 0; i<=t; i++) c[i] = 0;
}
//Copy
// 配列のコピー --------------------------------------------
// 長倍精度整数 a[] を長倍精度整数 b[] にコピー
// a -> b
void Copy(unsigned a[], unsigned b[]){
    int i,s;
    s = Degree(a);
    Initialize(b);
    for(i = 0; i<=s; i++) b[i] = a[i];
}
//ZeroCheck
// 零チェック ----------------------------------------------
// 長倍精度整数 a[] に対して
// a[] = 0 であれば 0 を返し、そうでなければ -1 を返す
int ZeroCheck(unsigned a[]){
    int i,j = 0;
	//
    for(i = 500-1; i>=0; i--){
        if(a[i] !=0 ){
            j = -1;
            break;
        }
    }
    return j;
}
//Degree
//  長倍精度整数 a[] の最上位の桁 --------------------------
//  a に対して a[s]!=0, a[s+1] = a[s+2] = ... = a[N-1] = 0 
// となる s を返す。但し、成分がすべて 0 の場合は 0 を返す。
int Degree(unsigned a[]){
	//
    int i = 500-1;
    while(i>0 && a[i]==0) i--;
    return i;
}
//ToDecimal
// 10 進数への変換 -----------------------------------------
void ToDecimal(unsigned a[], unsigned w[]){
    int i;
	//
    unsigned b[500];
    Copy(a, b);
	//
    for(i = 0; i<601; i++) w[i] = 0;
    i = 0;
    while( ZeroCheck(b)==-1 ) w[i++] = Div(b, 10000);

}
//ToHex
// 16 進数への変換 -----------------------------------------
void ToHex(unsigned w[], unsigned a[]){
    int i;
	//
    unsigned z[601];
	//
    for(i = 0; i<601; i++) z[i] = w[i];
    for(i = 0; i<500; i++) a[i] = 0;
    i = 0;
    while( ToHexZeroCheck(z) == -1) a[i++] = ToHexDiv(z);
}
//ToHexDiv
//  z は 10 進表示の長倍精度整数 
// z を (2の16乗) で割って、商を z, 余り res を返す
unsigned ToHexDiv(unsigned z[]){
    int i;
    unsigned x, q, res;

    res = 0;
    
    // z[] の最高位の桁を探す
	//
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
//ToHexZeroCheck
// z[0],..,z[M-1] がすべて 0 かどうかのチェック
// すべて 0 であれば 0 を返し、そうでなければ -1 を返す
int ToHexZeroCheck(unsigned z[]){
    int i, j = 0;
	//
    for(i = 601-1;i>=0;i--){
        if(z[i] != 0){
            j = -1;
            break;
        }
    }
    return j;
}
//Display
// 10 進表示 -----------------------------------------------
// 長倍精度整数 a[] を10 進数に変換して表示
void Display(unsigned a[]){
    int i;
	//
    unsigned w[601];       // 大きさ M の配列を使用
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
//DisplayHex
//  長倍精度整数 x[] を 16 進表示 --------------------------
void DisplayHex(unsigned a[]){
    int i;
    i = Degree(a);
    while(i>=0) printf("%4.4x ", a[i--]);
    printf("\n");
}
