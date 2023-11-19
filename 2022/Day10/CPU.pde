class CPU {
  String[] prog;
  int x = 1;
  
  private int ptr = 0;  
  private String instr; 
  private int val;
  private boolean loaded;
  
  CPU(String[] _prog) {
    prog = _prog;
  }
  
  void StartCycle() {
    if(instr==null) {
      loaded = true;
      loadedInstruction = prog[ptr];
      String[] instruction = loadedInstruction.split(" ");
      instr = instruction[0];
      if(instruction.length>1) {
        val = int(instruction[1]);
      } 
    } else {
      loaded = false;
    }
  }
  void EndCycle() {
    if(instr.equals("noop")) { //is noop
        completeInstruction();
    } else if(!loaded) {
      //println(x, val, x+val);
      x += val;
      completeInstruction();
    }
  }
  private void completeInstruction() {
    loaded = false;
    instr = null;
    ptr++;
  }
  
  boolean ProgramComplete() {
    return ptr >= program.length;
  }
  
  private String loadedInstruction;
  void draw(int cycles) {
    background(0x33);
    textSize(20);
    fill(0xFF);
    
    text("Cycles: "+cycles, 5, 25);
    text("Pointer: "+ptr, 5, 50); //add progress bar?
    text("Instruction: "+instr, 5, 75);
    text("Value: "+val, 5, 100);
    text("Register: "+x, 5, 125);
  }
}