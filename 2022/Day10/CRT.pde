class CRT {
  private PGraphics frame;
  
  CRT() {
    frame = createGraphics(240,36);
    frame.beginDraw();
    frame.background(0);
    frame.stroke(0x99);
    frame.fill(0x99);
    frame.endDraw();
  }
  
  void draw(int cycle, int x) {
    int hPos = (cycle-1)%40;
    int vPos = (cycle-1)/40;
    
    if(x-1 == hPos || x == hPos || x+1 == hPos) {
      frame.beginDraw();
      frame.rect(hPos*6,vPos*6,6,6);
      frame.endDraw();
    }
    
    image(frame, 225, 90);
  }
}