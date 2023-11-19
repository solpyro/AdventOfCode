class Point {
  int x;
  int y;
  Point head;
  
  Point(int _x, int _y) {
    x = _x;
    y = _y;
  }
  
  void UpdatePosition() {
    if(head==null) return;
    
    int xDiff = x-head.x;
    int yDiff = y-head.y;
    if(abs(xDiff)>1) {
      x -= abs(xDiff)/xDiff;
      if(abs(yDiff)>0)
        y -= abs(yDiff)/yDiff;
      return;
    } else if(abs(yDiff)>1) {
      y -= abs(yDiff)/yDiff;
      if(abs(xDiff)>0)
        x -= abs(xDiff)/xDiff;
    }
  }
}