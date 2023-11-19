void parse() {
  String[] lines = loadStrings(file);

  parseMap(subset(lines, 0, lines.length-2));
  parsePath(lines[lines.length-1]);
  
  findStart();
  
  println("Map is", map[0].length, "by", map.length, "units");
  println("Path has", pathDistances.length, "legs and", pathDirections.length, "turns");
  println("Start is at (",x,y,")");
}

void parsePath(String pathString) {
  pathDistances = toIntArray(matchAll(pathString, "\\d+"));
  pathDirections = toCharArray(matchAll(pathString, "[LR]"));
}

void parseMap(String[] mapStrings) {
  int maxWidth = 0;

  for (String row : mapStrings)
    maxWidth = max(maxWidth, row.length());

  map = new char[mapStrings.length][];
  for (int i=0; i<mapStrings.length; i++)
    map[i] = expand(mapStrings[i].toCharArray(), maxWidth);
}

void findStart() {
  y = 0;
  for(int i=0;i<map[0].length;i++)
    if(map[0][i] == '.') {
      x = i;
      return;
    }
}


int[] toIntArray(String[][] matches) {
  int[] result = new int[matches.length];
  for (int i=0; i<matches.length; i++)
    result[i] = int(matches[i][0]);
  return result;
}

char[] toCharArray(String[][] matches) {
  char[] result = new char[matches.length];
  for (int i=0; i<matches.length; i++)
    result[i] = matches[i][0].charAt(0);
  return result;
}