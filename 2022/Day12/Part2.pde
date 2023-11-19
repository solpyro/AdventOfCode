ArrayList<ArrayList<int[]>> listOfPaths;
ArrayList<int[]> bestPath;

void part2() {
  findAllPaths();
  
  findBestPath();
  
  println("Best shortest path is: ",bestPath.size());
}

void findAllPaths() {
  listOfPaths = new ArrayList<ArrayList<int[]>>();
  for(int y=0; y<heightMap.length; y++) {
    int[] newStart = new int[]{0,y};
    if(equal(newStart,start))
      listOfPaths.add(shortestPath);
    else
      listOfPaths.add(findShortestPath(newStart));
  }
}

public void findBestPath() {
  bestPath = listOfPaths.get(0);
  for(ArrayList<int[]> path: listOfPaths)
    if(path.size()<bestPath.size())
      bestPath = path;
}