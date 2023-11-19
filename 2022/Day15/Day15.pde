//String file = "test.txt"; int target = 10; boolean visualise = true; 
String file = "data.txt"; int target = 2000000; boolean visualise = false;

ArrayList<int[]> sensors, beacons;
int minX, minY, maxX, maxY;

void setup() {
  size(37,37);
  background(background);
  noLoop();
  
  parse();
}

void draw() {
  if(visualise) {
    drawFields();
    drawSensors();
    drawBeacons();
    drawPart1Targeting();   
    saveFrame("visualisation.png");
  }
  part1();
  part2();
}