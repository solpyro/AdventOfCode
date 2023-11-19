void part2() {
  flood = new boolean[cubes.length][][];
  for(int x = 0;x<flood.length;x++){
    flood[x] = new boolean[cubes.length][];
    for(int y = 0;y<flood[x].length;y++) {
      flood[x][y] = new boolean[cubes.length];
      for(int z = 0;z<flood[x][y].length;z++)
        flood[x][y][z] = true;
    }
  }
  
  ArrayList<int[]> queue = new ArrayList<int[]>();
  queue.add(new int[]{0,0,0});
  
  while(queue.size()>0) {
    ArrayList<int[]> nextQueue = new ArrayList<int[]>();
    for(int[] cell: queue) {
      if(!flood[cell[0]][cell[1]][cell[2]])
        continue;
      if(!cubes[cell[0]][cell[1]][cell[2]]) {
        flood[cell[0]][cell[1]][cell[2]] = false;
        nextQueue.addAll(getNeighbours(flood,cell));
      }
    }
    queue = nextQueue;
  }
  
  int totalOpenFaces = totalOpenFaces(flood);
  println("Lava blob has external surface area of",totalOpenFaces);
}

ArrayList<int[]> getNeighbours(boolean[][][] field, int[] cell) {
  int x = cell[0];  
  int y = cell[1];  
  int z = cell[2];  
  ArrayList<int[]> result = new ArrayList<int[]>();
  
  if(x>0 && field[x-1][y][z]) result.add(new int[]{x-1, y, z});
  if(y>0 && field[x][y-1][z]) result.add(new int[]{x, y-1, z});
  if(z>0 && field[x][y][z-1]) result.add(new int[]{x, y, z-1});
  if(x+1<field.length && field[x+1][y][z]) result.add(new int[]{x+1, y, z});
  if(y+1<field.length && field[x][y+1][z]) result.add(new int[]{x, y+1, z});
  if(z+1<field.length && field[x][y][z+1]) result.add(new int[]{x, y, z+1});
  
  return result;
}