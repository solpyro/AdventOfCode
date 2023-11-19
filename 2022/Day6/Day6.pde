//String file = "test.txt";
String file = "data.txt"; 

StringList[] stacks;
String[] instructions;

void setup() {
  String[] data = loadStrings(file);
  for(String stream:data) {
    part1(stream);
    part2(stream);
  }
}

void part1(String stream) {
  UniqueTokenSearch(stream,4);
}

void part2(String stream) {
  UniqueTokenSearch(stream,14);
}
  
void UniqueTokenSearch(String stream, int tokenLength) {
  for(int i=0; i<stream.length()-tokenLength;i++) {
    if(AreUniqueChars(stream.substring(i,i+tokenLength))){
      println("marker "+stream.substring(i,i+tokenLength)+" found at "+(i+tokenLength));
      break;
    }
  }
}

boolean AreUniqueChars(String token) {
  for(int i=0;i<token.length()-1;i++) {
    for(int j=i+1;j<token.length();j++) {
      if(token.charAt(i) == token.charAt(j))
        return false;
    }
  }
  return true;
}