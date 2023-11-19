String file = "test.txt";
//String file = "data.txt";

String jetSequence, rockSequence;
Rock rock;
int jetPtr, rockPtr, deletedRows;
long rockCounter;
boolean fastMode = false;
ArrayList<boolean[]> board;

void setup() {
  jetSequence = loadStrings(file)[0];
  jetPtr = 0;
  rockSequence = "-+L|#";
  rockPtr = 0;
  
  deletedRows = 0;
  rockCounter = 0;
  board = new ArrayList<boolean[]>();
  
  size(180,420);//rock pixels are 20x20 
  frameRate(240);
}

void part1() {
  if(rockCounter%100 == 0)
    println("rock",rockCounter);
    
  if(rockCounter == 2023) {
    println("The rock tower is",board.size()-getHighestRock(),"units tall");
    
    fastMode = true; 
  }
}

void part2() {
  if(rockCounter%100 == 0)
    println("rock",rockCounter);
  
  if(rockCounter == 1000000000001l) {
    println("The rock tower is",(board.size()-getHighestRock())+deletedRows,"units tall");
    noLoop();
  }
}