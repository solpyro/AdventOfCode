void part2() {
  maxTrees = 0;
  visibleTrees = new int[trees.length][];
  for(int i=0;i<visibleTrees.length;i++) {
    visibleTrees[i] = new int[trees[i].length];
    for(int j=0;j<visibleTrees[i].length;j++) {
      visibleTrees[i][j] = countVisibleTrees(i,j);
      if(visibleTrees[i][j]>maxTrees)
        maxTrees = visibleTrees[i][j];
    }
  }
  println("Most visible trees are: "+maxTrees);
}
int countVisibleTrees(int i, int j) {
  return countUp(i,j)
       * countLeft(i,j)
       * countRight(i,j)
       * countDown(i,j);
}
int countUp(int i, int j) {
  if(i==0) return 0;
  
  int counter = 0;
  int n = i-1;
  while(n>=0 && trees[n][j]<trees[i][j]) {
    counter++;
    n--;
  }
  if(n>=0 && trees[n][j]>=trees[i][j]) counter++;
  
  return counter;
}
int countLeft(int i, int j) {
  if(j==0) return 0;
  
  int counter = 0;
  int n = j-1;
  while(n>=0 && trees[i][n]<trees[i][j]) {
    counter++;
    n--;
  }
  if(n>=0 && trees[i][n]>=trees[i][j]) counter++;
  
  return counter;
}
int countRight(int i, int j) {
  if(j == trees.length-1) return 0;
    
  int counter = 0;
  int n = j+1;
  while(n<trees.length && trees[i][n]<trees[i][j]) {
    counter++;
    n++;
  }
  if(n<trees.length && trees[i][n]>=trees[i][j]) counter++;
  
  return counter;
}
int countDown(int i, int j) {
  if(i == trees.length-1) return 0;
  
  int counter = 0;
  int n = i+1;
  while(n<trees.length && trees[n][j]<trees[i][j]) {
    counter++;
    n++;
  }
  if(n<trees.length && trees[n][j]>=trees[i][j]) counter++;
  
  return counter;
}