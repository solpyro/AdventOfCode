String toSnafu(int input) {
  //convert to SNAFU
  return "undefined";
  //throw new RuntimeException("Not implemented");
}

int toInt(String input) {
  int result = 0;
  for(int i=0;i<input.length();i++) {
    switch(input.charAt(input.length()-1-i)) {
      case '2':
        result += 2*pow(5,i);
        break;
      case '1':
        result += pow(5,i);
        break;
      case '0':
        break;
      case '-':
        result -= pow(5,i);
        break;
      case '=':
        result -= 2*pow(5,i);
        break;
      default:
        throw new RuntimeException("Unknown SNAFU numeral '"+input.charAt(input.length()-1-i)+"'");
    }
  }
  return result;
}

int[] toInts(String[] input) {
  int[] output = new int[input.length];
  
  for(int i=0;i<input.length;i++)
    output[i] = toInt(input[i]);
  
  return output;
}