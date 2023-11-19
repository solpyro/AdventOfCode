Packet FromJSON(String json) {
  return FromJSON(parseJSONArray(json));
}
Packet FromJSON(JSONArray array) {
    return new List(array);
}
Packet FromJSON(int number) {
    return new Number(number);
}

abstract class Packet {
  int compare(Packet p2) {
    Packet p1 = this;
    
    if((p1 instanceof Number) && (p2 instanceof Number)) {
      return (((Number)p1).value-((Number)p2).value==0)
        ? 0
        : (((Number)p1).value-((Number)p2).value)/abs(((Number)p1).value-((Number)p2).value);
    }
    
    List l1 = (p1 instanceof Number)
      ? new List(p1)
      : (List)p1;
    List l2 = (p2 instanceof Number)
      ? new List(p2)
      : (List)p2;
      
    for(int i=0;;i++) {
      int length1 = l1.values.length;
      int length2 = l2.values.length;
      
      if(length1 == length2 && length1==i) {
        return 0;
      }
      
      if(i<length1 && i<length2) {
        int result = l1.values[i].compare(l2.values[i]);
        if(result != 0)
          return result;
        continue;
      }
      
      return (length1-length2==0)
        ? 0
        : length1-length2/abs(length1-length2);
    }
  }
}
class Number extends Packet {
  int value;
  
  Number(int number){
    value = number;
  }
  
  String toString() {
    return str(value);
  }
}
class List extends Packet {
  Packet[] values;
  
  List(JSONArray array){
    values = new Packet[array.size()];
    for(int i=0;i<values.length;i++) {
      try {
        values[i] = FromJSON(array.getJSONArray(i));
      } catch(RuntimeException e) { //should be ClassCastException
        values[i] = FromJSON(array.getInt(i));
      } 
    }
  }
  List(Packet packet) {
    values = new Packet[]{packet};
  }
  
  String toString() {
    String[] strings = new String[values.length];
    for(int i=0;i<values.length;i++)
      strings[i] = values[i].toString();
    return "["+join(strings,",")+"]";
  }
}