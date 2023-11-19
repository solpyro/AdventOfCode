ArrayList<int[]> coordList, nextCoords, newCoords, shortestPath;
final int[][] NEIGHBOURS = {{-1,0},{0,-1},{1,0},{0,1}};

void part1() {
  coordList = initList(end);  
  nextCoords = initList(end);
  
  while(nextCoords.size()>0)
    populateCoordList();
  
  populateWeightMap();
  
  shortestPath = findShortestPath(start);
  
  println("Shortest path is: ",shortestPath.size());
}

ArrayList<int[]> initList(int[] coord) {
  ArrayList<int[]> list = new ArrayList<int[]>();
  list.add(new int[] {coord[0],coord[1],0});
  return list;
}

void populateCoordList() {
  newCoords = new ArrayList<int[]>();
  for(int[] coord: nextCoords)
    newCoords.addAll(validNeighbours(coord));
  coordList.addAll(newCoords);
  nextCoords = new ArrayList<int[]>();
  nextCoords.addAll(newCoords);
}

ArrayList<int[]> validNeighbours(int[] coord) {
  ArrayList<int[]> validNeighbours = new ArrayList<int[]>();
  for(int[] neighbour: NEIGHBOURS) {
    int[] newNeighbour = add(coord,neighbour);
    if(isOnMap(newNeighbour) && isNotHighCliff(newNeighbour, coord) && isNotInList(newNeighbour))
      validNeighbours.add(new int[]{newNeighbour[0],newNeighbour[1],coord[2]+1});
  }
  return validNeighbours;
}

boolean isOnMap(int[] candidate) {
  return !(min(candidate)<0 || candidate[0]>=heightMap[0].length || candidate[1]>=heightMap.length);
}

boolean isNotHighCliff(int[] current, int[] candidate) {
  return!(heightMap[candidate[1]][candidate[0]]-heightMap[current[1]][current[0]]>1);
}

boolean isNotInList(int[] coord) {
  return !contains(newCoords,coord) && !contains(coordList,coord);
}

boolean contains(ArrayList<int[]> haystack, int[] needle) {
  for(int[] candidate: haystack)
    if(equal(candidate,needle))
      return true;
  return false;
}
boolean equal(int[] a, int[] b) {
  return a[0]==b[0] &&a[1]==b[1];
}
int[] add(int[] a, int[] b) {
 return new int[]{a[0]+b[0],a[1]+b[1]};
}
  
void populateWeightMap() {
  weightMap = new int[heightMap.length][];
  for(int i=0;i<heightMap.length;i++)
    weightMap[i] = new int[heightMap[i].length];
  
  for(int[] coord: coordList) {
    weightMap[coord[1]][coord[0]] = coord[2];
    maxWeight = max(maxWeight,coord[2]);
  }
}
  
ArrayList<int[]> findShortestPath(int[] start) {
  ArrayList<int[]> path = initList(start);
  while(true) {
    int[] nextBestCoord = findNextBestCoord(path.get(path.size()-1));
    if(equal(nextBestCoord,end))
      break;
    path.add(nextBestCoord);
  }
  return path;
}
int[] findNextBestCoord(int[] currentCoord) {
  int[] nextBestCoord = new int[2];
  int nextBestWeight = weightMap[currentCoord[1]][currentCoord[0]];
  for(int[] neighbour: NEIGHBOURS) {
    int[] newNeighbour = add(currentCoord, neighbour);
    if(equal(newNeighbour,end))
      return newNeighbour;
    if(isOnMap(newNeighbour) && isNotHighCliff(currentCoord, newNeighbour) && weightMap[newNeighbour[1]][newNeighbour[0]]>0 && weightMap[newNeighbour[1]][newNeighbour[0]]<nextBestWeight) {
      nextBestCoord = newNeighbour;
      nextBestWeight = weightMap[newNeighbour[1]][newNeighbour[0]];
    }
  }
  return nextBestCoord;
}