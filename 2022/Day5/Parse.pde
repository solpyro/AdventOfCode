public static class Parse {
  public static StringList[] Containers(String[] containers) {
    int stackCount = GetStackCount(containers[containers.length-1]);
    StringList[] stacks = new StringList[stackCount];
    
    for(int i=0; i<stackCount;i++) {
      stacks[i] = new StringList();
      for(int j=containers.length-2; j>=0; j--) {
        int index = i*4+1;
        if(index>containers[j].length()) break;
        if(containers[j].substring(index,index+1).equals(" ")) break;
        stacks[i].append(containers[j].substring(index,index+1));
      }
    }
    return stacks;
  }
  
  private static int GetStackCount(String stackNumbers) {
    stackNumbers = trim(stackNumbers);
    return int(stackNumbers.substring(stackNumbers.length()-1));
  }
  
  public static int[] Instruction(String instruction) {
    String[] instructions = instruction.split(" ");
    int[] output = new int[3];
    output[0] = int(instructions[1]);
    output[1] = int(instructions[3])-1;
    output[2] = int(instructions[5])-1;
    return output;
  }
}