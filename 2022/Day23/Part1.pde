void part1() {
  round++;
  if(round==10) {
    noLoop();
    saveFrame(file+"_part1.png");
    int[] limits = getLimits();
    
    long count = emptyTilesInRect(limits);
    int elves = countElves(limits);
    
    stroke(0,255,0);
    noFill();
    rect(limits[0]-1, limits[1]-1,limits[2]-limits[0]+2,limits[3]-limits[1]+2);
    
    println("There are",count,"empty spaces and",elves,"elves");
  }
}

int[] getLimits() {
  int[] limits = {Integer.MAX_VALUE,Integer.MAX_VALUE,0,0};
  
  for(int x = 0;x<width;x++)
    for(int y = 0;y<width;y++)
      if(get(x,y)==ELF) {
        limits[0] = min(limits[0], x);
        limits[1] = min(limits[1], y);
        limits[2] = max(limits[2], x);
        limits[3] = max(limits[3], y);
      }
  
  return limits;
}

long emptyTilesInRect(int[] limits) {
  long count = 0;
  
  for(int x = limits[0];x<=limits[2];x++)
    for(int y = limits[1];y<=limits[3];y++)
      if(get(x,y)==FIELD)
        count++;
  
  return count;
}

int countElves(int[] limits) {
  int count = 0;
  
  for(int x = limits[0];x<=limits[2];x++)
    for(int y = limits[1];y<=limits[3];y++)
      if(get(x,y)==ELF)
        count++;
  
  return count;
}