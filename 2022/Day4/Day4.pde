//String file = "test.txt";
String file = "data.txt"; 

String[][] pairs;

void setup() {
  parse();
  part1();
  part2();
}

void parse() {
  String[] lines = loadStrings(file);
  pairs = new String[lines.length][];
  for(int i=0;i< lines.length; i++) {
    pairs[i] = lines[i].split(",");
  }
  println("Pairs: "+pairs.length);
}

void part1() {
  int containedPairs = 0;
  
  for(String[] pair: pairs) {
    if(IsFullyContained(pair))
      containedPairs++;
  }
  
  println("Contained pairs: "+containedPairs);
}

void part2() {
  int overlappingPairs = 0;
  
  for(String[] pair:pairs) {
    if(Overlap(pair))
      overlappingPairs++;
  }
  
  println("Overlapping pairs: "+overlappingPairs);
}

boolean IsFullyContained(String[] pair) {
  int[] a = ParseRange(pair[0]);
  int[] b = ParseRange(pair[1]);
  
  if(a[0]==b[0]) return true;
  
  if(a[0]<b[0]){
    return a[1]>=b[1]; 
  } else {
    return b[1]>=a[1];
  }
}

boolean Overlap(String[] pair) {
  int[] a = ParseRange(pair[0]);
  int[] b = ParseRange(pair[1]);
  
  if(b[0]<=a[1] && b[1]>=a[1]) return true;
  if(a[0]<=b[1] && a[1]>=b[1]) return true;
  retrun false;
}

int[] ParseRange(String range) {
  int[] iRange = new int[2];
  String[] sRange = range.split("-");
  iRange[0] = int(sRange[0]);
  iRange[1] = int(sRange[1]);
  return iRange;
}