void moveRope(char dir) {
  switch(dir) {
    case 'U':
      rope[0].y--;
      break;
    case 'D':
      rope[0].y++;
      break;
    case 'L':
      rope[0].x--;
      break;
    case 'R':
      rope[0].x++;
      break;
    default: throw new RuntimeException("Cannot move in direction "+dir);
  }
  for(Point point: rope)
    point.UpdatePosition();
}

void drawLandmarks() {
  fill(color(0,0,255));
  ellipse(start.x, start.y, 2, 2);
  for(Point point: rope)
    ellipse(point.x, point.y, 2, 2);
  
  fill(color(255,0,0));
  ellipse(rope[rope.length-1].x, rope[rope.length-1].y, 2, 2);
  
  fill(color(0,255,0));
  ellipse(rope[0].x, rope[0].y, 2, 2);
}

void addTailToTrace() {
  trace.beginDraw();
  trace.loadPixels();
  trace.pixels[rope[rope.length-1].y*trace.width + rope[rope.length-1].x] = color(255);
  trace.updatePixels();
  trace.endDraw();
}

void countTracePixels() {
  int counter = 0;
  trace.loadPixels();
  for(color px: trace.pixels) {
    if(px != color(0))
      counter++;
  }
  println(counter+" pixels were visited by the tail");
}