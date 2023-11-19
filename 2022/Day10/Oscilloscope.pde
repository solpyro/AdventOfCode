class Oscilloscope {
  private PGraphics signalOutput;
  
  Oscilloscope() {
    signalOutput = createGraphics(240,70);
    signalOutput.beginDraw();
    signalOutput.background(0);
    
    signalOutput.stroke(0x66);
    for(int x = 20;x<240;x+=40)
      signalOutput.line(x,0,x,99);
    
    signalOutput.stroke(0x33);
    for(int x = 40;x<240;x+=40)
      signalOutput.line(x,0,x,99);
      
    signalOutput.stroke(color(0,255,0));
    signalOutput.fill(color(0,255,0));
    signalOutput.endDraw();
  }
  
  void draw(int cycles, int x) {
    signalOutput.beginDraw();
    signalOutput.point(cycles-1, 40-x);
    signalOutput.endDraw();
    
    image(signalOutput, 225, 10);
  }
}