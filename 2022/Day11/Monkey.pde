class Monkey {
  ArrayList<BigInteger> Items;
  char Operation;
  BigInteger OperationValue;
  BigInteger TestValue;
  Monkey TrueMonkey, FalseMonkey;
  
  int InspectionCounter = 0;
  
  Monkey() {
    Items = new ArrayList<BigInteger>();
  }
  
  void Catch(BigInteger item) {
    Items.add(item);
  }
  
  void Turn(BigInteger calmFactor) {
    for(BigInteger item: Items) {
      item = Inspect(item, calmFactor);
      ThrowTo(item).Catch(item);
    }
    Items = new ArrayList<BigInteger>();
  }
  
  BigInteger Inspect(BigInteger val, BigInteger calmFactor) {
    InspectionCounter++;
    
    switch(Operation) {
      case '*':
        val = val.multiply(OperationValue);
        break;
      case '+':
        val = val.add(OperationValue);
        break;
      case '^':
        //println("Square op");
        //println("source",val);
        val = val.pow(2);
        //println("result",val);
        break;
      default: throw new RuntimeException("Unknown operation: "+Operation);
    }
    
    if(calmFactor.compareTo(BigInteger.TEN)<0)
      return val.divide(calmFactor);
    else
      return val.remainder(calmFactor);
  }
  
  Monkey ThrowTo(BigInteger val) {
    return Test(val)
      ? TrueMonkey
      : FalseMonkey;
  }
  
  boolean Test(BigInteger i) {
    return i.remainder(TestValue) == BigInteger.ZERO;
  }
}