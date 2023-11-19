//String file = "test.txt";
String file = "data.txt"; 

int xMin=330, yMax=160, endlessVoid; 

void setup() {
  size(341,190);//x:670-330,y:0-160
  background(Void);
  
  drawRocks(parse());
}

void draw() {
  int[] pos = getNextRestingPlace();
  if(pos[1] >= endlessVoid) {
    println("Part 1:",countAllSand());
    saveFrame("part1.png");
    part2();
  } else
    set(pos[0],pos[1],Sand);
  if(pos[1] == 0) {
    noLoop();
    println("Part 2:",countAllSand());
    saveFrame("part2.png");
  }
}

ArrayList<int[][]> parse() {
  ArrayList<int[][]> rockPaths = new ArrayList<int[][]>(); 
  for(String line:loadStrings(file)) {
    String[] sSteps = splitTokens(line);
    int[][] steps = new int[(sSteps.length+1)/2][];
    int ptr = 0;
    for(String step:sSteps)
      if(!step.equals("->")) {
        steps[ptr] = int(split(step,","));
        endlessVoid = max(endlessVoid, steps[ptr][1]);
        ptr++;
      }
    rockPaths.add(steps);
  }
  return rockPaths;
}

void part2() {
  endlessVoid +=2;
  drawFloor();
}