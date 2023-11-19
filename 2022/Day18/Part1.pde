void part1() {
  int totalOpenFaces = totalOpenFaces(cubes);
  println("Lava blob has surface area of",totalOpenFaces);
}

int totalOpenFaces(boolean[][][] field) {
  int totalOpenFaces = 0;
  
  for(int x = 0;x<field.length; x++)
    for(int y = 0;y<field[x].length; y++)
      for(int z = 0;z<field[x][y].length; z++)
        if(field[x][y][z])
          totalOpenFaces += openFaces(field,x,y,z);
  
  return totalOpenFaces;
}

int openFaces(boolean[][][] field, int x, int y, int z) {
  int openFaces = 0;
  
  if(x==0 || !field[x-1][y][z]) openFaces++;
  if(y==0 || !field[x][y-1][z]) openFaces++;
  if(z==0 || !field[x][y][z-1]) openFaces++;
  if(x+1==field.length || !field[x+1][y][z]) openFaces++;
  if(y+1==field.length || !field[x][y+1][z]) openFaces++;
  if(z+1==field.length || !field[x][y][z+1]) openFaces++;
  
  return openFaces;
}