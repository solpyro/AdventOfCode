class Rock {
  boolean[][] shape;
  int x, y;
  
  Rock(char _shape) {
    x = 2;
    y = 0;
    switch(_shape) {
      case '-':
        shape = new boolean[][]{
          new boolean[]{ true, true, true, true}
        };
        break;
      case '+':
        shape = new boolean[][]{
          new boolean[]{false, true,false},
          new boolean[]{ true, true, true},
          new boolean[]{false, true,false}
        };
        break;
      case 'L':
        shape = new boolean[][]{
          new boolean[]{false,false, true},
          new boolean[]{false,false, true},
          new boolean[]{ true, true, true}
        };
        break;
      case '|':
        shape = new boolean[][]{
          new boolean[]{ true},
          new boolean[]{ true},
          new boolean[]{ true},
          new boolean[]{ true}
        };
        break;
      case '#':
        shape = new boolean[][]{
          new boolean[]{ true, true},
          new boolean[]{ true, true}
        };
        break;
    }
  }
} 