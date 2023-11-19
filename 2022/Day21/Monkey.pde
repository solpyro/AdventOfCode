class Monkey {
  boolean isNumber;
  long number;
  char op;
  String a, b;
  
  Monkey(long n) {
    isNumber = true;
    number = n;
  }
  
  Monkey(char _op, String _a, String _b) {
    isNumber = false;
    op = _op;
    a = _a;
    b = _b;
  }
  
  long getNumber() {
    if(isNumber)
      return number;
    return calculate(op, troop.get(a).getNumber(), troop.get(b).getNumber()); 
  }
  
  long calculate(char op, long a, long b) {
    switch(op) {
      case '+':
        return a+b;
      case '-':
        return a-b;
      case '*':
        return a*b;
      case '/':
        return a/b;
      default:
        throw new RuntimeException("Unknown operator: "+op);
    }
  }
  
  boolean contains(String name) {
    if(isNumber)
      return false;
      
    return (a.equals(name) || b.equals(name))
        || troop.get(a).contains(name)
        || troop.get(b).contains(name);
  }
}