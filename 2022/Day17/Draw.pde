color fallingRock = color(212, 191, 142);
color stoppedRock = color(76, 76, 69);
color border = color(136, 140, 141);
color background = color(0);

void draw() {
  background(background);
  
  if(fastMode) {
    if (rock == null) {
      rock = createRock();
      part2();
    } else {
      do {
        fireJets();
      } while(dropRock());
      writeRockToBoard();
      rock = null;
      deleteBlockedRows();
    }
  } else {
    if (rock == null) {
      rock = createRock();
      part1();
    } else {
      fireJets();
      if (!dropRock()) {
        //  write to board
        writeRockToBoard();
        rock = null;
      }
    }
  }
  drawBoard();
  drawFallingRock();
}


void drawFallingRock() {
  if (rock==null)
    return;

  int boardTop = getBoardTop();

  for (int y = 0; y < rock.shape.length; y++)
    for (int x = 0; x < rock.shape[y].length; x++)
      if (rock.shape[y][x])
        drawPixel(rock.x+x+1, boardTop+rock.y+y, fallingRock);
}

void drawBoard() {
  drawWalls();
  drawFloor();
  drawStoppedRocks();
}

void drawWalls() {
  for (int y = 0; y<=21; y++) {
    drawPixel(0, y, border);
    drawPixel(8, y, border);
  }
}

void drawFloor() { 
  if (board.size()<21)
    for (int x = 1; x<=7; x++)
      drawPixel(x, 20, border);
}

void drawStoppedRocks() {
  int boardTop = getBoardTop();
  
  for (int y = 0; y < board.size(); y++)
    for (int x = 0; x < board.get(y).length; x++)
      if(board.get(y)[x])
        drawPixel(x+1,boardTop+y,stoppedRock);
}

void drawPixel(int x, int y, color c) {
  strokeWeight(1);
  stroke(background);
  fill(c);
  rect(x*20, y*20, 20, 20);
}