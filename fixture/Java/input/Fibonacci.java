public static class Fibonacci {
  public static int fibonacci(int n) {
    if (n < 2) {
      return n;
    }
    else {
      return fibonacci(n - 1) + fibonacci(n - 2);
    }
  }
}

