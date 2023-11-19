import java.util.Comparator;

//String file = "test.txt";
String file = "data.txt"; 

ElfComparator ec = new ElfComparator();

ArrayList<Elf> elves;

void setup() {
  parseData();
  part1();
  part2();
}

void parseData() {
  String[] strings = loadStrings(file);
  elves = new ArrayList<Elf>();
  Elf elf = new Elf();
  for (String s : strings) {
    if (s.length() == 0) {
      elves.add(elf);
      elf = new Elf();
    } else {
      elf.AddItem(int(s));
    }
  }
  elves.add(elf);
  elves.sort(ec);
  println("Elves count: "+elves.size());
}

void part1() {
  println("Elves count: "+elves.size());
  Elf elfWithMostCalories = elves.get(elves.size()-1);
  println("Most calories: "+elfWithMostCalories.TotalCalories());
}

void part2() {
  int calories = 0;
  for(int i=1;i<4;i++)
    calories += elves.get(elves.size()-i).TotalCalories();
  println("Top three total calories: "+calories);
}

void draw() {
}