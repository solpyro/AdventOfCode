static class Parse {
  static boolean isCommand(String line) {
    return line.indexOf("$ ") == 0;
  }
  static boolean isCdCommand(String line) {
    return line.indexOf("$ cd ") == 0;
  }
  static String cdAction(String line) {
    return line.substring(5);
  }
  
  static boolean isDirectory(String line) {
    return line.indexOf("dir ") == 0;
  }
  static String directoryName(String line) {
    return line.substring(4).trim();
  }
  
  static long fileSize(String line) {
    return Long.parseLong(line.substring(0, line.indexOf(" "))); //<>//
  }
  
  static String fileName(String line) {
    return line.substring(line.indexOf(" ")+1).trim();
  }
}