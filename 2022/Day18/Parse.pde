void parse() {
  String[] lines = loadStrings(file);
  
  coords = new int[lines.length][];
  int maxDim = 0;
  
  for(int i=0;i<lines.length;i++) {
    coords[i] = int(lines[i].split(","));
    maxDim = max(maxDim,max(coords[i]));
  }
  maxDim++;
  
  cubes = new boolean[maxDim][][];
  for(int x = 0;x<cubes.length;x++){
    cubes[x] = new boolean[maxDim][];
    for(int y = 0;y<cubes[x].length;y++)
      cubes[x][y] = new boolean[maxDim];
  }  
  
  for(int i=0;i<coords.length;i++)
    cubes[coords[i][0]][coords[i][1]][coords[i][2]] = true;
}