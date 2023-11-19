long[] multiply(long[] array, int multiplier) {
  long[] result = new long[array.length];

  for (int i=0; i<array.length; i++)
    result[i] = array[i]*multiplier;

  return result;
}

long[] parseLong(String[] array) {
  long[] result = new long[array.length];

  for (int i=0; i<array.length; i++)
    result[i] = Long.parseLong(array[i]);

  return result;
}