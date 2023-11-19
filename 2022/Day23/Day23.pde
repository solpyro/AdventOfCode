String file = "test.txt";
//String file = "data.txt";

PGraphics buffer, decisions;
final color FIELD = color(0,0,0);
final color ELF = color(255,0,0);
final color CHOICE = color(0,0,128);
final color CROWD = color(0,0,255);
int round = 0;

void setup() {
  size(799,799);//real map is 150*200 units
  buffer = createGraphics(width,height);
  decisions = createGraphics(width,height);
    
  parse();
}

void draw() {
  proposeMoves();
  moveElves();
  //image(buffer,0,0);
  //image(decisions,0,0);
  part1();
}

void parse() {
  String[] rows = loadStrings(file);
  
  int elves = 0;
  int left = (width-rows[0].length())/2;
  int top = (height-rows.length)/2; 
  
  buffer.beginDraw();
  buffer.background(FIELD);
  for(int y = 0;y<rows.length;y++)
    for(int x = 0;x<rows[y].length();x++)
      if(rows[y].charAt(x)=='#') {
        buffer.set(left+x,top+y,ELF);
        elves++;
      }
  buffer.endDraw();
  image(buffer,0,0);
  
  println("There are",elves,"elves");
}