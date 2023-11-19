//String file = "test.txt";
String file = "data.txt";

HashMap<String, Monkey> troop;

void setup() {
  parse();
  part1();
  part2();
}

void part1() {
  println("root will shout", troop.get("root").getNumber());
}

void part2() {  
  Monkey root = troop.get("root");
  Monkey humanSide;
  long target, human;

  if (troop.get(root.a).contains("humn")) {
    target = troop.get(root.b).getNumber();
    humanSide = troop.get(root.a);
  } else {
    target = troop.get(root.a).getNumber();
    humanSide = troop.get(root.b);
  }

  human = findHumanNumber(humanSide, target);

  println(root.a, "and", root.b, "should shout", target, "so humn needs to shout", human);
}

long findHumanNumber(Monkey monkey, long target) {
  Monkey humanSide;
  String name;
  boolean valueIsA;
  long value;
  
  if (troop.get(monkey.a).contains("humn") || monkey.a.equals("humn")) {
    value = troop.get(monkey.b).getNumber();
    humanSide = troop.get(monkey.a);
    name = monkey.a;
    valueIsA = false;
  } else {
    value = troop.get(monkey.a).getNumber();
    humanSide = troop.get(monkey.b);
    name = monkey.b;
    valueIsA = true;
  }
  println(name);
  if (name.equals("humn")) {
    return invertOp(monkey.op, valueIsA, value, target);
  } else {
    target = invertOp(monkey.op, valueIsA, value, target);
    return findHumanNumber(humanSide, target);
  }
}

long invertOp(char op, boolean argIsA, long arg, long result) {
  switch(op) {
  case '-':
    if (!argIsA)
      return result + arg;
  case '+':
    return result - arg;
  case '*':
    return result / arg;
  case '/':
    if (argIsA)
      return arg / result; //assuming both arg and result are not 0
    return result * arg;
  default:
    throw new RuntimeException("Unknown operator: "+op);
  }
}