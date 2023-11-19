void parse() {
  String[] input = loadStrings(file);
  
  troop = new Monkey[(input.length+1)/7];
  
  for(int i=0; i<troop.length; i++)
    troop[i] = new Monkey();
    
  for(int i=0; i<troop.length; i++) {
    parseMonkey(troop[i],subset(input, 7*i,6));
  }
  
  if(calmFactor == BigInteger.ONE) {
    for(Monkey monkey: troop) 
      calmFactor = calmFactor.multiply(monkey.TestValue);
  }
}

void parseMonkey(Monkey monkey, String[] lines) {
  setItems(monkey,lines[1]);
  setOperation(monkey,lines[2]);
  setTest(monkey,lines[3]);
  setTrueMonkey(monkey,lines[4]);
  setFalseMonkey(monkey,lines[5]);
}

void setItems(Monkey monkey, String itemsLine) {
  String[] items = splitTokens(split(itemsLine,": ")[1],", ");
  for(String item: items)
    monkey.Items.add(new BigInteger(item));
}

void setOperation(Monkey monkey, String operationLine) {
  if(operationLine.indexOf("old * old") > -1) {
    monkey.Operation = '^';
  } else {
    if(operationLine.indexOf('*') > -1) {
      monkey.Operation = '*';
    }
    if(operationLine.indexOf('+') > -1) {
      monkey.Operation = '+';
    }
    monkey.OperationValue = getBigIntFromEndOfString(operationLine);
  }
}

void setTest(Monkey monkey, String testLine) {
  monkey.TestValue = getBigIntFromEndOfString(testLine);
}

void setTrueMonkey(Monkey monkey, String trueMonkeyLine) {
  int target = getIntFromEndOfString(trueMonkeyLine);
  monkey.TrueMonkey = troop[target];
}

void setFalseMonkey(Monkey monkey, String falseMonkeyLine) {
  int target = getIntFromEndOfString(falseMonkeyLine);
  monkey.FalseMonkey = troop[target];
}

BigInteger getBigIntFromEndOfString(String line) {
  String[] tokens = splitTokens(line);
  return new BigInteger(tokens[tokens.length-1]);
}

int getIntFromEndOfString(String line) {
  String[] tokens = splitTokens(line);
  return int(tokens[tokens.length-1]);
}