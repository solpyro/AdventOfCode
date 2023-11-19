static class Part2 {
  static int calculateRoundScore(String round) {
    return shapeScore(round)+gameScore(round.charAt(round.length()-1));
  }
  
  static int shapeScore(String game) {
    switch(game) {
      case "C Z":
      case "A Y":
      case "B X":
        return 1; //rock
      case "A Z":
      case "B Y":
      case "C X":
        return 2; //paper
      case "A X":
      case "B Z":
      case "C Y":
        return 3; //scissors
      default: throw new RuntimeException("Bad game: "+game);
    }
  }
  
  static int gameScore(char shape) {
    switch(shape){
      case 'X': return 0;
      case 'Y': return 3;
      case 'Z': return 6;
      default: throw new RuntimeException("Bad shape: "+shape);
    }
  }
}