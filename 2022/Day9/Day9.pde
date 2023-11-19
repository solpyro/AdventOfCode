//String file = "test.txt";
//String file = "test2.txt";
String file = "data.txt"; 

Motion[] motions;
Point start;
//Point[] rope = new Point[2]; //part1
Point[] rope = new Point[10]; //part2
PGraphics trace;
int startTime;

void setup() {
  parse();
  size(401,401);
  background(0);
  noStroke();
  
  int midpoint = ceil(width/2f);
  start = new Point(midpoint,midpoint);
  for(int i=0;i<rope.length;i++) {
    rope[i] = new Point(midpoint,midpoint);
    if(i>0) rope[i].head = rope[i-1];
  }
  trace = createGraphics(width, height);
  trace.beginDraw();
  trace.background(0);
  trace.endDraw();
  startTime = millis();
}
int step = 0;
void draw() {
  addTailToTrace();
  image(trace, 0, 0);
  
  moveRope(motions[step].Direction);
    
  drawLandmarks();
  
  motions[step].Steps--;
  if(motions[step].Steps == 0) step++;
  
  if(step == motions.length) {
    int time = millis()-startTime;
    println("Drawing the path took "+(time/1000f)+"s");
    addTailToTrace();
    noLoop();
    saveFrame(file+"_"+rope.length+".png");
    countTracePixels();
  }
}

void parse() {
  String[] steps = loadStrings(file);
  motions = new Motion[steps.length];
  for(int i=0; i<steps.length; i++)
    motions[i] = new Motion(steps[i]);
}