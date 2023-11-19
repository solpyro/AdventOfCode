void parse() {
  String[] lines = loadStrings(file);
  heightMap = new int[lines.length][];
  for(int y=0;y<lines.length;y++) {
    char[] chars = lines[y].toCharArray();
    heightMap[y] = new int[chars.length];
    for(int x=0;x<chars.length;x++) {
      heightMap[y][x] = charToHeight(chars[x]);
      //check & note S & E
      if(chars[x] == 'S') start = new int[]{x,y};
      if(chars[x] == 'E') end = new int[]{x,y};
    }
  }
}

int charToHeight(char a) {
  if(a=='S') a = 'a';
  if(a=='E') a = 'z';
  return (a-97);
}