//String file = "test.txt";
String file = "data.txt"; 

String[] rounds;

void setup() {
  parse();
  part1();
  part2();
}

void parse() {
  rounds = loadStrings(file);
}

void part1() {
  int totalScore = 0;
  for(String round:rounds)
    totalScore += Part1.calculateRoundScore(round);
  println("Total score: "+totalScore);
}

void part2() {
  int totalScore = 0;
  for(String round:rounds)
    totalScore += Part2.calculateRoundScore(round);
  println("Total score: "+totalScore);
}