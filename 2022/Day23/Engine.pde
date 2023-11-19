char[] directions = {'N','S','W','E'};

void proposeMoves() {
  decisions.beginDraw();
  decisions.background(FIELD);
  
  for(int x = 0; x<width;x++)
    for(int y = 0; y<height;y++)
      if(get(x,y)==ELF && neighbours(x,y)>0)
        incrementDecisions(getNewPosition(x,y));
        
  decisions.endDraw();
}

void moveElves() {
  buffer.beginDraw();
  buffer.background(FIELD);
  
  for(int x = 0; x<width;x++)
    for(int y = 0; y<height;y++)
      if(get(x,y)==ELF) {
        if(neighbours(x,y)>0) {
          int[] position = getNewPosition(x,y);
          if(getDecision(position)==CHOICE)
            buffer.set(position[0],position[1],ELF);
          else
           buffer.set(x,y,ELF);
        } else 
          buffer.set(x,y,ELF);
      }
  buffer.endDraw();
  image(buffer,0,0);
  
  rotateDirections();
}

int neighbours(int x,int y) {
  int neighbours = 0;
  for(int _x = -1; _x<=1;_x++)
    for(int _y = -1; _y<=1;_y++)
      if ((_x !=0 && _y!=0)
      && (get(x+_x,y+_y)==ELF))
        neighbours++;
  return neighbours;
}

int[] getNewPosition(int x, int y) {
  for(char dir: directions) {  
    if(isEmpty(x,y,dir))
      return move(x,y,dir);
  }
  return new int[]{x,y};
}

boolean isEmpty(int x, int y,char dir) {
  switch(dir) {
    case 'N':
      return isEmpty(x-1,y-1) && isEmpty(x,y-1) && isEmpty(x,y-1);
    case 'S':
      return isEmpty(x-1,y+1) && isEmpty(x,y+1) && isEmpty(x,y+1);
    case 'W':
      return isEmpty(x-1,y-1) && isEmpty(x-1,y) && isEmpty(x-1,y+1);
    case 'E':
      return isEmpty(x+1,y-1) && isEmpty(x+1,y) && isEmpty(x+1,y+1);
    default:
      throw new RuntimeException("Direction '"+dir+"' is not defined");
  }
}

boolean isEmpty(int x, int y) {
  return get(x,y)!=ELF;
}

int[] move(int x, int y, char dir) {
   switch(dir) {
    case 'N':
      return new int[]{x,y-1};
    case 'S':
      return new int[]{x,y+1};
    case 'W':
      return new int[]{x-1,y};
    case 'E':
      return new int[]{x+1,y};
    default:
      throw new RuntimeException("Direction '"+dir+"' is not defined");
  }
}

void incrementDecisions(int[] coords) {
  //println(coords[0], coords[1], blue(getDecision(coords)));
  decisions.set(coords[0], coords[1], getDecision(coords)==FIELD?CHOICE:CROWD);
  //println(coords[0], coords[1], blue(getDecision(coords)));
}

color getDecision(int[] coords) {
  //println(blue(decisions.get(coords[0], coords[1])));
  return decisions.get(coords[0], coords[1]);
}

void rotateDirections() {
  directions = subset(append(directions, directions[0]),1);
}