//String file = "test.txt";
String file = "data.txt"; 

int[][] heightMap, weightMap;
int[] start, end;
int frame = 0, maxWeight;

void setup() {
  size(865,205);//(173,41)x5
  noLoop();
  
  parse();
  part1();
  part2();
}


void draw() {
  switch(frame) {
    case 0:
      drawMap();
      saveFrame("map.png");
      break;
    case 1:
      drawPath();
      saveFrame("path.png");
      break;
    case 2:
      drawBestPath();
      saveFrame("bestPath.png");
  }
}

void keyPressed() {
  frame = (frame+1)%3;
  redraw();
}