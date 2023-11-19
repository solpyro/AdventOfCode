void parse() {
  String[] lines = loadStrings(file);
  
  troop = new HashMap<String, Monkey>();
  
  for(String line: lines) {
    String[] monkey = split(line, ": ");
    try {
      troop.put(monkey[0],new Monkey(Long.parseLong(monkey[1])));
    } catch (NumberFormatException e) {
      String[] operation = splitTokens(monkey[1]);
      troop.put(monkey[0],new Monkey(operation[1].charAt(0),operation[0],operation[2]));
    }
  }
  
  println("There are",troop.size(),"monkeys");
}