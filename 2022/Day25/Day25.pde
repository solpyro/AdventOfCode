String exampleDecimal = "decimal.txt";
String exampleSnafu = "snafu.txt";

String file = "test.txt";
//String file = "data.txt";

int[] fuelReqs;

void setup() {
  demo();
  parse();
  //part1();
}

void demo() {
  for(int n: int(loadStrings(exampleDecimal)))
    println(n,"=>",toSnafu(n));
  
  println("-----");
  
  for(String s: loadStrings(exampleSnafu))
    println(s,"=>",toInt(s));
  
  println("-----");
}

void parse() {
  fuelReqs = toInts(loadStrings(file));
  prettyPrint(fuelReqs);
}

void part1() {
  int total = 0;
  
  for(int req: fuelReqs) {
    total += req;
  }
  
  println("Total fuel requirement is",total,"base 10, or",toSnafu(total),"SNAFU");
}