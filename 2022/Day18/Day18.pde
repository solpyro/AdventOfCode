//String file = "test.txt";
String file = "data.txt";

int[][] coords;
boolean[][][] cubes;
boolean[][][] flood;


float cameraRadius = (height/2) / tan(PI/4);
float sceneOffset;

void setup() {
  parse();
  part1();
  part2();
  
  sceneOffset = cubes.length/2l;
  
  size(500,500,P3D);
}

void draw() {
  background(0);
  drawCubes();
  lights();
  
  int ticks = millis();
  camera(
    cameraRadius*sin(ticks/500f)+sceneOffset, 20*sin(ticks/400f)+sceneOffset, cameraRadius*cos(ticks/500f)+sceneOffset, 
    sceneOffset, sceneOffset, sceneOffset, 
    0, 1, 0);
}

void drawCubes() {
  noStroke();
  for(int[] coord: coords) {
    fill(200+random(55),100+random(50),0);
    pushMatrix();
    translate(coord[0],coord[1],coord[2]);
    box(1);
    popMatrix();
  }
}