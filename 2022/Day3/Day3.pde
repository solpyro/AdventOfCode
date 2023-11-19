//String file = "test.txt";
String file = "data.txt"; 

Rucksack[] rucksacks;

void setup() {
  parse();
  part1();
  part2();
}

void parse() {
  String[] lines = loadStrings(file);
  rucksacks = new Rucksack[lines.length];
  for(int i=0;i<lines.length;i++)
    rucksacks[i] = new Rucksack(lines[i]);
  println("Rucksacks: "+rucksacks.length);
}

void part1() {
  int totalPriorities = 0;
  
  for(Rucksack rucksack:rucksacks)
    totalPriorities += GetPriority(rucksack.InBoth());
  
  println("Sum of priorities: "+totalPriorities);
}

void part2() {
  int totalBadgePriorities = 0;  
  
  for(int i=0;i<rucksacks.length;i+=3)
    totalBadgePriorities += GetPriority(FindBadgeForGroup(i));
  
  println("Sum of badge priorities: "+totalBadgePriorities); 
}

char FindBadgeForGroup(int i) {
  for(char item :rucksacks[i]._items) {
    if(rucksacks[i+1].Contains(item) && rucksacks[i+2].Contains(item))
      return item;
  }
  throw new IllegalArgumentException("No matching badge in group "+i);
}

int GetPriority(char item) {
  int value = int(item);
  value -= (value > 90)
    ? 96
    : 38;
  return value;
}