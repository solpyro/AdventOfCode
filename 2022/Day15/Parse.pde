import java.util.Comparator;

void parse() {
  String[] lines = loadStrings(file);
  sensors = new ArrayList<int[]>();
  beacons = new ArrayList<int[]>();
 
  for(String line: lines)
    parse(line);
  
  reduceBeaconsToUnique();
  getBounds();
    
  println(sensors.size(),"sensors,",beacons.size(),"unique known beacons");
  println("Dimentions: (",minX,minY,"),(",maxX,maxY,")");
  println("Map Size: ",maxX-minX+1,"x",maxY-minY+1);
}

void parse(String line) {
  String[][] matches = matchAll(line, "x=(-?\\d+), y=(-?\\d+)");
  sensors.add(new int[]{
    int(matches[0][1]),
    int(matches[0][2]),
    manhattanDistance(int(matches[0]),int(matches[1]))
  });
  beacons.add(new int[]{
    int(matches[1][1]),
    int(matches[1][2])
  });
}

int manhattanDistance(int[] a, int[] b) {
  return abs(a[1]-b[1]) + abs(a[2]-b[2]);
}

void reduceBeaconsToUnique() {
  beacons.sort(INTARRAY_COMPARATOR);
  for(int i=1;i<beacons.size();i++) {
    if(INTARRAY_COMPARATOR.compare(beacons.get(i),beacons.get(i-1))==0) {
      beacons.remove(i);
      i--;
    }
  }
}

void getBounds() {
  minX = Integer.MAX_VALUE;
  minY = Integer.MAX_VALUE;
  maxX = 0;
  maxY = 0;
  
  for(int[] sensor: sensors)
    updateBounds(sensor);
}

void updateBounds(int[] coord) {
  minX = min(minX,coord[0]-coord[2]);
  minY = min(minY,coord[1]-coord[2]);
  maxX = max(maxX,coord[0]+coord[2]);
  maxY = max(maxY,coord[1]+coord[2]);
}