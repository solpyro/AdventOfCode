import java.util.Arrays;

class Rucksack {
  char[] _items;
  char[] _front;
  char[] _back;
  
  public Rucksack(String contents) {
    _items = contents.toCharArray();
    _front = contents.substring(0, contents.length()/2).toCharArray();
    _back = contents.substring(contents.length()/2).toCharArray();
    Arrays.sort(_front);
    Arrays.sort(_back);
  }
  
  public char InBoth() {
    for(char item:_front) {
      if(Contains(_back,item))
        return item;
    }
    throw new IllegalArgumentException("No matching item in both arrays");
  }
  
  public boolean Contains(char needle) {
    return Contains(_front, needle) || Contains(_back, needle);
  }
  
  private boolean Contains(char[] haystack, char needle) {
    for(char item: haystack)
      if(item == needle)
        return true;
    return false;
  }
}