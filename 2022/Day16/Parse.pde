void parse() {
  valves = new HashMap<String,Valve>();
  
  for(String line: loadStrings(file)) {
    String[] parts = split(line,"; ");
    
    String[] valveInfo = splitTokens(parts[0]);
    
    String[] tunnels = split(parts[1],", ");
    tunnels[0] = tunnels[0].substring(tunnels[0].length()-2);
    
    valves.put(valveInfo[1],new Valve(valveInfo[1], int(split(valveInfo[4],"=")[1]),tunnels));
  }
}