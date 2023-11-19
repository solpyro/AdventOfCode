color Void = color(0);
color Rock = color(127,131,134);
color Sand = color(194,178,108);

void drawRocks(ArrayList<int[][]> rockPaths) {
  stroke(Rock);
  strokeWeight(1);
  for(int[][] path: rockPaths)
    for(int i=0;i<path.length-1;i++) {
      //println(path[i][0]-xMin,path[i][1],path[i+1][0],path[i+1][1]);
      line(path[i][0]-xMin,path[i][1],path[i+1][0]-xMin,path[i+1][1]);
    }
}
void drawFloor() {
  stroke(Rock);
  strokeWeight(1);
  line(0,endlessVoid,width,endlessVoid);
}

int[] getNextRestingPlace() {
  int[] pos = new int[]{500-xMin, 0};
  while(true) {
    if(pos[1]==endlessVoid || canMoveDown(pos))
      pos = moveDown(pos);
    else
      return pos;
  }
}

boolean canMoveDown(int[] pos) {
  return (pos[1]<height-1)
      && ((get(pos[0],pos[1]+1)==Void)
        || (pos[0]>0 && get(pos[0]-1,pos[1]+1)==Void)
        || (pos[0]+1<width && get(pos[0]+1,pos[1]+1)==Void));
}

int[] moveDown(int[] pos) {
  pos[1] = pos[1]+1;
  if(get(pos[0],pos[1])==Void)
    return pos;
  if(get(pos[0]-1,pos[1])==Void)
    pos[0] = pos[0]-1;
  else if(get(pos[0]+1,pos[1])==Void)
    pos[0] = pos[0]+1;
  return pos;
}

int countAllSand() {
  int sandCount = 0;
  loadPixels();
  for(color pixel: pixels) 
    if(pixel==Sand)
      sandCount++;
  return sandCount;
}