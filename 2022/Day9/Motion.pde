class Motion {
  char Direction;
  int Steps;
  
  Motion(String motion) {
    Direction = motion.charAt(0);
    Steps = int(motion.split(" ")[1]);
  }
}