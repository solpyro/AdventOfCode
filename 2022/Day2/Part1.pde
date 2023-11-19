static class Part1 {
  static int calculateRoundScore(String round) {
    return shapeScore(round.charAt(round.length()-1))+gameScore(round);
  }
  
  static int shapeScore(char shape) throws RuntimeException  {
    switch(shape){
      case 'X': return 1;
      case 'Y': return 2;
      case 'Z': return 3;
      default: throw new RuntimeException("Bad shape: "+shape);
    }
  }
  static int gameScore(String game) throws RuntimeException  {
    switch(game) {
      case "A X":
      case "B Y":
      case "C Z":
        return 3; //draw
      case "A Y":
      case "B Z":
      case "C X":
        return 6; //win
      case "A Z":
      case "B X":
      case "C Y":
        return 0; //lose
      default: throw new RuntimeException("Bad game: "+game);
    }
  }
}