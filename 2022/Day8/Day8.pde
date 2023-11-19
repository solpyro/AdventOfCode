//String file = "test.txt";
String file = "data.txt"; 

int[][] trees;
boolean[][] isVisible;
int[][] visibleTrees;
int maxTrees;

void setup() {
  parse();
  part1();
  part2();

  size(990, 990);
  noLoop();
}

void parse() {
  String[] lines = loadStrings(file);
  trees = new int[lines.length][];
  for (int i=0; i<lines.length; i++) {
    trees[i] = new int[lines[i].length()];
    for (int j=0; j<lines[i].length(); j++) {
      trees[i][j] = Character.getNumericValue(lines[i].charAt(j));
    }
  }
  println((trees.length*trees[0].length)+" trees in the forest");
}

int mode = 0;
color white = color(255);
color green = color(0, 255, 0);
void draw() {
  fill(color(255, 255, 255));
  int step = 990/trees.length;
  int halfStep = step/2;
  for (int y=0; y<trees.length; y++) {
    int yPos = y * step + halfStep;
    for (int x=0; x<trees[y].length; x++) {
      int diameter = step * (trees[y][x]+1) / 10;
      switch(mode) {
        case 0: 
          fill(255);
          break;
        case 1:
          fill(isVisible[y][x]
            ? green
            : white);
          break;
        case 2:
          fill(255*visibleTrees[y][x]/maxTrees);
      }
      ellipse(x * step + halfStep, yPos, diameter, diameter);
    }
  }
}
void keyPressed() {
  mode = (mode+1)%3;
  redraw();
}