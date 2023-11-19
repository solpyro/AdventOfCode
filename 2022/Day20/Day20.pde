//String file = "test.txt";
String file = "data.txt";

int decryptionKey = 811589153;
long[] values;
int[] orders;


void setup() {
  part1();
  part2();
}

void parse() {
  values = parseLong(loadStrings(file));
  orders = new int[values.length];
  for(int i=0;i<values.length;i++)
    orders[i] = i;
}

void part1() {
  parse();
  mix();
  getCoordinates();
}

void part2() {
  parse();
  values = multiply(values,decryptionKey);
  for(int i=0;i<10;i++)
    mix();
  getCoordinates();
}

void getCoordinates() {
  int zero = findIndex(0, values);
  int onek = (1000+zero)%values.length;
  int twok = (2000+zero)%values.length;
  int threek = (3000+zero)%values.length;
  
  println("The sum of coordinates (",values[onek],values[twok],values[threek],") is",values[onek]+values[twok]+values[threek]);
}