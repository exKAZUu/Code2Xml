int fibonacci(int n){
	if(n < 2){
		return n;
	}
	else{
		return fibonacci(n - 2) + fibonacci(n - 1);
	}
}