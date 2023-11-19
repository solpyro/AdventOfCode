color background = color(0);
color sensor = color(0,255,0);
color field = color(0,128,0);
color beacon = color(255,0,0);

void drawFields() {
  for(int[] sensor: sensors)
    drawField(sensor);
}

void drawSensors() {
  drawDots(sensors, sensor);
}

void drawBeacons() {
  drawDots(beacons, beacon);
}

void drawPart1Targeting() {
  stroke(255,255,255,50);
  line(0,target-minY-1,width,target-minY-1);
  line(0,target-minY+1,width,target-minY+1);
}

void drawDots(ArrayList<int[]> dots, color col) { 
  for(int[] dot: dots)
    set(mapToCanvas(dot), col);
}

void drawField(int[] sensor) {
  stroke(field);
  strokeWeight(1);
  
  for(int i=0;i<=sensor[2];i++) {
    int stepLength = sensor[2]-i;
    line(mapToCanvas(sensor[0]-stepLength,sensor[1]-i),mapToCanvas(sensor[0]+stepLength,sensor[1]-i));
    line(mapToCanvas(sensor[0]-stepLength,sensor[1]+i),mapToCanvas(sensor[0]+stepLength,sensor[1]+i));   
  }
}

void line(int[] start, int[] end) {
  line(start[0], start[1], end[0], end[1]);
}

void set(int[] coord, color col) {
  set(coord[0], coord[1], col);
}

int[] mapToCanvas(int[] coord) {
  return mapToCanvas(coord[0], coord[1]);
}
int[] mapToCanvas(int x, int y) {
  return new int[]{
    x-minX,
    y-minY
  };
}