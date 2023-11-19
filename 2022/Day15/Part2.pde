void part2() {
  int range = target * 2;
  for(int y=range;y>=0;y--) {
    //printProgress(range-y,range);
    ArrayList<int[]> sweeps = getCoverageInRow(y);
    if(countRestrictedSweepRange(sweeps,range)<range) {
      truncateToRange(sweeps, range);
      int x = 0;
      for(int[] sweep: sweeps) {
        if(x != sweep[0])
          break;
        x = sweep[1]+1;
      }
      println("x:",x,"y:",y,"freq:",(4000000l*x)+y);
      break;
    }
  }
  println("search complete");
}

int countRestrictedSweepRange(ArrayList<int[]> sweeps, int range) {
  int count = 0;
  for(int[] sweep: sweeps) {
    count += abs(min(sweep[1],range)-max(sweep[0],0))+1;
  }
  return count-1;
}
void truncateToRange(ArrayList<int[]> sweeps, int range) {
  for(int[] sweep: sweeps) {
    sweep[0] = max(sweep[0],0);
    sweep[1] = min(sweep[1],range);
  }
}