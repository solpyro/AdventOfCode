void part1() {
  
  ArrayList<int[]> sweeps = getCoverageInRow(target);
  int count = countSweepRanges(sweeps);
  
  for(int[] beacon: beacons)
    if(beacon[1] == target)
      count--;

  println("Row",target,"contains",count,"excluded positions");
}

ArrayList<int[]> getCoverageInRow(int target) {
  ArrayList<int[]> sweeps = new ArrayList<int[]>();
  for(int[] sensor: sensors)
    projectIntoRow(target, sensor, sweeps);
  
  reduceSweepRanges(sweeps);
  return sweeps;
}

void projectIntoRow(int target, int[] sensor, ArrayList<int[]> sweeps) {
  if(inRange(target,sensor[1]-sensor[2],sensor[1]+sensor[2]))
    sweeps.add(getSweepAtTarget(sensor, target));
}

int[] getSweepAtTarget(int[] sensor, int target) {
  int dist = abs(sensor[1]-target);
  return new int[]{sensor[0]-(sensor[2]-dist), sensor[0]+(sensor[2]-dist)};
}

void reduceSweepRanges(ArrayList<int[]> sweeps) {
  for(int i=1;i<sweeps.size();i++) {
    for(int j = 0;j<i;j++) {
      if(overlap(sweeps.get(i), sweeps.get(j))) {
        sweeps.set(j,merge(sweeps.get(i), sweeps.get(j)));
        sweeps.remove(i);
        i=0;
        j=-1;
      }
    }
  }
}

int countSweepRanges(ArrayList<int[]> sweeps) {
  int count = 0;
  for(int[] sweep: sweeps) {
    count += abs(sweep[1]-sweep[0])+1;
  }
  return count;
}

int[] merge(int[] a, int[] b) {
  return new int[]{min(a[0],b[0]), max(a[1],b[1])};
}

boolean overlap(int[] a, int[] b) {
  return inRange(a[0],b) || inRange(a[1],b) || inRange(b[0], a);
}

boolean inRange(int candidate, int[] range) {
  return inRange(candidate, range[0], range[1]);
}

boolean inRange(int candidate, int min, int max) {
  return (candidate>=min) && (candidate<=max);
}