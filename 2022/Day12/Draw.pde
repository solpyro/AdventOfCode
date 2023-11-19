void drawMap() {
  drawTerrain();
  drawTerminals();
}

void drawPath() {
  drawWeightedTerrain();
  drawCliffs();
  drawPath(shortestPath, color(0,0,255));
  drawTerminals();
}

void drawBestPath() {
  drawWeightedTerrain();
  drawCliffs();
  drawPossiblePaths(color(128,128,255));
  drawPath(bestPath, color(0,0,255));
  drawTerminals();
}

void drawTerrain() {
  noStroke();
  for(int y=0; y<heightMap.length; y++)
    for(int x=0; x<heightMap[y].length; x++) {
      fill(color(heightMap[y][x]*10));
      rect(5*x,5*y,5,5);
    }
}
void drawWeightedTerrain() {
  noStroke();
  for(int y=0; y<weightMap.length; y++)
    for(int x=0; x<weightMap[y].length; x++) {
      color n = 0xff0000 + 0xffff*(1-(weightMap[y][x]/maxWeight));
      fill(heatmapColor(weightMap[y][x],maxWeight));
      rect(5*x,5*y,5,5);
    }
}
color heatmapColor(int value, float maxValue) {
  return (value==0)
    ? 0
    : color(
        255,
        255*(1-(value/maxValue)),
        0
      );
}

void drawCliffs() {
  stroke(0);
  for(int i=0;i<heightMap.length;i++) {
    drawVerticalBarriers(i);
    if(i>0)
      drawHorizontalBarriers(i);
  }
}
void drawVerticalBarriers(int y){
  for(int x=1;x<heightMap[y].length;x++)
    if(abs(heightMap[y][x]-heightMap[y][x-1])>1)
      line(x*5,y*5,x*5,y*5+5);
}
void drawHorizontalBarriers(int y){
  for(int x=1;x<heightMap[y].length;x++)
    if(abs(heightMap[y][x]-heightMap[y-1][x])>1)
      line(x*5,y*5,x*5+5,y*5);
}

void drawPossiblePaths(color pathColor) {
  for(ArrayList<int[]> path: listOfPaths)
    drawPath(path, pathColor);
}
void drawPath(ArrayList<int[]> path, color pathColor) {
  stroke(pathColor);
  for(int i=0; i<path.size()-1; i++)
    drawLine(path.get(i),path.get(i+1));
  drawLine(path.get(path.size()-1),end);
}
void drawLine(int[] start, int[] end) {
  line(start[0]*5+3,start[1]*5+3,end[0]*5+3,end[1]*5+3);
}

void drawTerminals() {
  noStroke();
  fill(0,255,0);
  ellipse(start[0]*5+3,start[1]*5+3,3,3);
  fill(255,0,0);
  ellipse(end[0]*5+3,end[1]*5+3,3,3);
}