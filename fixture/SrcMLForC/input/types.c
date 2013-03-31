struct test {
	int a;
	int *b;
	int *c[10];
	int **d[20];
} t1;

int main(int*[], int**[10], int *c[], int *const*d[10]);

int main(int *a[10]) {
	struct test t2;
	return 0;
}