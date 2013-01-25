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

// �����I�ɑ傫�� N �̔z��������B�A�� 10 �i�\���ɒ����Ƃ���
// �傫�� M �̔z��������B
// 4*N = 16 �i�̌����A4*M = 10 �i�̌����AM��1.2041 N
// �֐��̒�`�ӏ��́@//�֐����@�Ō����\

//Add ���Z  ------------------------------------------------
// ���{���x���� a[] �ɒ��{���x���� b[] �������A
// ���ʂ� a[] �Ɋi�[����B
// a + b -> a

void Add(unsigned a[], unsigned b[]){
    int i,j, s;
    unsigned x;
    s = Degree(b);
    for(i = 0; i<=s; i++){
        x = a[i]+b[i];
        if(x <= 0xffff){ // ���オ�肵�Ȃ��Ƃ�
            a[i] = x;
        } else {         // ���オ�肷��Ƃ�
            a[i] = x & 0xffff;
                         // a[i] = x �̉��� 2 �o�C�g
            j = i+1;     // ���オ�菈��
            while(a[j] == 0xffff) a[j++] = 0;
            a[j]++;
        }
    }
}
//Sub �����Z -----------------------------------------------
// ���{���x���� a[] ���璷�{���x���� b[] �������A
// ���ʂ� a[] �Ɋi�[����B a[] >= b[] �ł��邱�ƁB
// a - b -> a  (a >= b)
void Sub(unsigned a[], unsigned b[]){
    int i,j, s;
    s = Degree(b);
    for(i = 0; i<=s; i++){
        if(a[i]>=b[i]){  // ���̂܂܈�����Ƃ�
            a[i] = a[i] - b[i];
        } else {         // ��̌����� 1 ���؂�鎞
            a[i] = (0x10000 + a[i]) - b[i];
            j = i+1;     // ��̌����� 1 ������
            while(a[j] == 0) a[j++] = 0xffff;
            a[j]--;
        }
    }
}

//Mul �����Z 1 ---------------------------------------------
// ���{���x���� a[] �� 2 �o�C�g���� d �̐�
// ���ʂ� a[] �Ɋi�[����
// a*d -> a (d <=0xffff)
void Mul(unsigned a[], unsigned d){
    int i, s;
    unsigned x, q;

    s = Degree(a);
    q = 0;               // ���オ��p�̂��߂̕ϐ�

    for(i = 0; i<=s+1; i++){
        x = a[i]*d + q;  // a[i] �� d ���|���āA
                         // ���オ�肵�Ă������l q ��������
        a[i] = x & 0xffff;
        q = x>>16;
                         // a[i] = x �̉��� 2 �o�C�g
                         //    q = x �̏�� 2 �o�C�g
    }
}

//LongMul �����Z 2 -----------------------------------------
// ���{���x���� a[] �ƒ��{���x���� b[] �̐�
// ���ʂ� a[] �Ɋi�[����
// a*b -> a
void LongMul(unsigned a[], unsigned b[]){
    int i,j,k;
    int s,t;
	//
    unsigned x, q, c[500];

    s = Degree(a);
    t = Degree(b);
    Initialize(c);       // ������

    for(i = 0; i<=s; i++){
        for(j = 0; j<=t; j++){
            x = a[i]*b[j]; k = i+j;
                         // �ȉ��A���オ�菈��
            while(x>0){
                q = c[k] + x;
                c[k] = q & 0xffff;
                x = q>>16;
                         // c[k] = q �̉��� 2 �o�C�g
                         //    x = q �̏�� 2 �o�C�g
                k++;     // ����ʂ̌��ɉ�����
            }
        }
    }
    Copy(c,a);
}
//Div ����Z 1 -------------------------------------------- 
// ���{���x���� a[] �� 2 �o�C�g���� d �Ŋ���B
// ���� a[] �Ɋi�[���A�]�� res (2 �o�C�g����) ��Ԃ��B
// d �� 0 �łȂ����ƁB
// a/d -> a (d <= 0xffff), �]�� res ��Ԃ��B
unsigned Div(unsigned a[], unsigned d){
    int i,x,q;
    unsigned res;
    res = 0;             // ��ʂ̌����������Ƃ��̂���
    
    i = Degree(a);       // �ŏ�ʂ̌����珇�Ԃ� d �Ŋ���
    while(i>=0){
        x = (res<<16) + a[i];
                         //   x = ��ʂ̌�����̂����
                         //        i �Ԗڂ̌���������
        q = x/d;         //   q = x �� d �Ŋ������Ƃ��̏�
        res = x - q*d;   // res = x �� d �Ŋ������Ƃ��̗]��
        a[i] = q;
        i--;             // 1 ���̌��ɂ���
    }
    return res;
}
//LongDiv ����Z 2 -----------------------------------------
// ���{���x���� a[] �𒷔{���x���� b[] �Ŋ���
// a/b  �̏��� quot[], �]��� res[] �Ɋi�[,   
// b �� 0 �łȂ����ƁB
void LongDiv(unsigned a[], unsigned b[], 
             unsigned quot[], unsigned res[]){
    int s, t, k, sh;
    int i;
    unsigned x, D, Q;
	//
    unsigned c[500], d[500];
    
    // ������
    Copy(a, res);
    Initialize(quot);
    if(Compare(res, b) == -1) return;

    // �Ȍ� res/b �����s����B
    t = Degree(b);
    // if(t==0 && b[0]==0) {
    //    printf("0 �ŏ��Z�B Ctrl + c �ŏI��\n");
    // }                    
    // b �� 0 �̏ꍇ�ɂ͈ȉ��� while ���[�v���������[�v

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
                                     // �ŏ�ʂ̐��̔�r
        if(res[s] >= b[t]){          // res[s] >= b[t] �̏ꍇ
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
        } else {                      // res[s] < b[t] �̏ꍇ
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

//DivCheck  ����Z�̌��Z ------------------------------------
//  LongDiv(a,b,quot, res) �����s���
//  DivCheck(a, b, quote, res) �����s����B
//  ��������� 1 ��Ԃ��A�Ԉ���Ă���� 0 ��Ԃ��B
int DivCheck(unsigned a[], unsigned b[], unsigned quot[], unsigned res[]){
    //
	unsigned c[500];
    Copy(b,c);
    LongMul(c, quot);
    Add(c, res);
    if(Compare(a, c) ==0) return 1;
    return 0;
}

//Compare �召��r -----------------------------------------
// ���{���x���� a[] �ƒ��{���x b[] �̔�r�B
// a > b �Ȃ�� 1, a < b �Ȃ�� -1, a = b �Ȃ�� 0 ��Ԃ�
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
//�V�t�g (�����炵) ------------------------------
//LeftShift
// a ������ sh ���V�t�g�A(0<=sh <=16)
void LeftShift(unsigned a[], int sh){
    int i, x;
    if(sh == 0) return;

    i = Degree(a);
    // �ŏ�ʂ̌������ʂɏ���
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
// a ������ sh ���V�t�g  (sh �� 16 �ȏ�ł��悢)
// �͂ݏo���`�F�b�N�����Ă��Ȃ��B
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
// a ���E�� sh ���V�t�g�A(0<=sh <=16)�A�͂ݏo�������͖Y���B
void RightShift(unsigned a[], int sh){
    int i, j, x;
    if(sh==0) return;

    i = Degree(a);
    // �ō��ʂ̌���T��,
	//
    i = 500-1;
    while(i>0 && a[i]==0) i--;
    // �ŉ��ʂ̌������ʂɏ���
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
// a ���E�� sh ���V�t�g�A(sh �� 16 ���傫���Ă��悢), 
// �݂͂ł������͖Y���B
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
// �z��̏����� --------------------------------------------
// ���{���x���� c[] �� 0 �ɂ���B
// c -> 0
void Initialize(unsigned c[]){
    int i,t;
    t = Degree(c);
    for(i = 0; i<=t; i++) c[i] = 0;
}
//Copy
// �z��̃R�s�[ --------------------------------------------
// ���{���x���� a[] �𒷔{���x���� b[] �ɃR�s�[
// a -> b
void Copy(unsigned a[], unsigned b[]){
    int i,s;
    s = Degree(a);
    Initialize(b);
    for(i = 0; i<=s; i++) b[i] = a[i];
}
//ZeroCheck
// ��`�F�b�N ----------------------------------------------
// ���{���x���� a[] �ɑ΂���
// a[] = 0 �ł���� 0 ��Ԃ��A�����łȂ���� -1 ��Ԃ�
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
//  ���{���x���� a[] �̍ŏ�ʂ̌� --------------------------
//  a �ɑ΂��� a[s]!=0, a[s+1] = a[s+2] = ... = a[N-1] = 0 
// �ƂȂ� s ��Ԃ��B�A���A���������ׂ� 0 �̏ꍇ�� 0 ��Ԃ��B
int Degree(unsigned a[]){
	//
    int i = 500-1;
    while(i>0 && a[i]==0) i--;
    return i;
}
//ToDecimal
// 10 �i���ւ̕ϊ� -----------------------------------------
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
// 16 �i���ւ̕ϊ� -----------------------------------------
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
//  z �� 10 �i�\���̒��{���x���� 
// z �� (2��16��) �Ŋ����āA���� z, �]�� res ��Ԃ�
unsigned ToHexDiv(unsigned z[]){
    int i;
    unsigned x, q, res;

    res = 0;
    
    // z[] �̍ō��ʂ̌���T��
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
// z[0],..,z[M-1] �����ׂ� 0 ���ǂ����̃`�F�b�N
// ���ׂ� 0 �ł���� 0 ��Ԃ��A�����łȂ���� -1 ��Ԃ�
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
// 10 �i�\�� -----------------------------------------------
// ���{���x���� a[] ��10 �i���ɕϊ����ĕ\��
void Display(unsigned a[]){
    int i;
	//
    unsigned w[601];       // �傫�� M �̔z����g�p
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
//  ���{���x���� x[] �� 16 �i�\�� --------------------------
void DisplayHex(unsigned a[]){
    int i;
    i = Degree(a);
    while(i>=0) printf("%4.4x ", a[i--]);
    printf("\n");
}
