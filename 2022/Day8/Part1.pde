void part1() {
  isVisible = new boolean[trees.length][];
  for(int i=0;i<trees.length;i++) {
    isVisible[i] = new boolean[trees.length];
    for(int j=0;j<trees[i].length;j++) {
      if(i==0 || j==0 || i==trees.length-1 || j==trees[i].length-1) {
        isVisible[i][j] = true;
      } else {
        isVisible[i][j] = isHighestOnAnySide(i,j);
      }      
    }
  }
  
  int trues = 0;
  for(boolean[] row: isVisible)
    for(boolean visible: row)
      trues += visible?1:0;
  println(trues+" trees are visible");
}
boolean isHighestOnAnySide(int i, int j) {
  return trees[i][j] > maxInRow(i,0,j)
      || trees[i][j] > maxInRow(i,j+1,trees.length)
      || trees[i][j] > maxInCol(j,0,i)
      || trees[i][j] > maxInCol(j,i+1,trees.length);
}
int maxInRow(int row, int start, int end) {
  int result = 0;
  for(int i=start;i<end;i++)
    if(trees[row][i]>result)
      result = trees[row][i];
  return result; 
}
int maxInCol(int col, int start, int end) {
  int result = 0;
  for(int i=start;i<end;i++)
    if(trees[i][col]>result)
      result = trees[i][col];
  return result; 
}