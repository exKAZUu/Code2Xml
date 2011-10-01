int fibonacci2(int n){
	if(n < 0){
		printf("aaaa");
	}
	else if(n == 1 || n == 2){
		return 1;
	}
	else{
		return fibonacci2(n - 1) + fibonacci2(n - 2);
	}
}