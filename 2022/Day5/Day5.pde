//String file = "test.txt";
String file = "data.txt"; 

StringList[] stacks;
String[] instructions;

void setup() {
  parse();
  //part1();
  part2();
}

void parse() {
  String[] lines = loadStrings(file);
  int split = 0;
  
  while(lines[split].length()>0)
    split++;
  
  stacks = Parse.Containers(subset(lines,0,split));
  instructions = subset(lines,split+1);
  
  println("Stacks: "+stacks.length);
  println("Instructions: "+instructions.length);
}

void part1() {
  for(String instruction:instructions) {
    ApplyStep9000(Parse.Instruction(instruction));
  }
  println("Top crates: "+ReadTopCrates());
}

void ApplyStep9000(int[] instruction) {//count source target
  for(int i=0;i<instruction[0];i++)
    MoveCrate(instruction[1],instruction[2]);
}
void MoveCrate(int source, int target) {
  String temp = stacks[source].remove(stacks[source].size()-1);
  stacks[target].append(temp);
}

void part2() {
  for(String instruction:instructions) {
    ApplyStep9001(Parse.Instruction(instruction));
  }
  println("Top crates: "+ReadTopCrates());
}

void ApplyStep9001(int[] instruction) {//count source target
  StringList temp = new StringList();
  for(int i=0;i<instruction[0];i++)
    temp.append(stacks[instruction[1]].remove(stacks[instruction[1]].size()-1));
  for(int i=0;i<instruction[0];i++)
    stacks[instruction[2]].append(temp.remove(temp.size()-1));
}

String ReadTopCrates() {
  String topCrates = "";
  for(StringList stack: stacks)
    topCrates += stack.get(stack.size()-1);
  return topCrates;
}