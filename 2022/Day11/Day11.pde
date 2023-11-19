import java.math.BigInteger;

//String file = "test.txt";
String file = "data.txt"; 

//BigInteger calmFactor = new BigInteger("3"); int rounds = 20; //part 1
BigInteger calmFactor = BigInteger.ONE; int rounds = 10000; //part 2

Monkey[] troop;

void setup() {
  parse();
  println(calmFactor);
  for(int round = 1; round <= rounds; round++) {
    //int prog = floor(100*round/rounds);
    //for(int i=0;i<prog;i++) print("#");
    //for(int i=prog+1;i<=100;i++) print("_");
    //println();
    
    if(round == 1 || round == 20 || round == 1000)
      println("----- Round",round,"-----");
    for(Monkey monkey: troop)
      monkey.Turn(calmFactor);
      
    
    if(round == 1 || round == 20 || round == 1000) {
      int[] inspections = new int[troop.length];
      for(int i=0;i<troop.length;i++)
        inspections[i] = troop[i].InspectionCounter;
      println(inspections);
    }
  }
  
  calculateMonkeyBusiness();
}

void calculateMonkeyBusiness() {
  int[] inspections = new int[troop.length];
  for(int i=0;i<troop.length;i++)
    inspections[i] = troop[i].InspectionCounter;
  println("----- Final -----");
  println(inspections);
  inspections = subset(reverse(sort(inspections)),0,2);
  println("Level of Monkey business:",(long)inspections[0]*(long)inspections[1]);
}