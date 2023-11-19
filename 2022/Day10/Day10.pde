//String file = "test.txt";
String file = "data.txt"; 

String[] program;
CPU cpu;
Oscilloscope oscilloscope;
CRT crt;
int cycles = 1;

void setup() {
  program = loadStrings(file);
  cpu = new CPU(program);
  oscilloscope = new Oscilloscope();
  crt = new CRT();
  
  size(475,135);
}

void draw() {
  cpu.StartCycle();
  
  cpu.draw(cycles);
  oscilloscope.draw(cycles,cpu.x);
  crt.draw(cycles,cpu.x);
  
  part1();
  
  cpu.EndCycle();
  
  if(cpu.ProgramComplete())
  {
    println("Program completed at",cycles,"cycles");
    part1();
    noLoop();
  }
  cycles++;
}

int sumEvery20 = 0;
void part1() {
  if(cpu.ProgramComplete()) {
    println("Sum of signal strentgths: "+sumEvery20);
  } else if((cycles-20)%40 == 0 && cycles <= 220) {
    println("Cycle "+cycles+": X = "+cpu.x);
    sumEvery20 += cycles*cpu.x;
  }
}