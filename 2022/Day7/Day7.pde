import java.util.Map;

//String file = "test.txt";
//String file = "kg959_5.txt";
//String file = "kg959_7.txt";
String file = "data.txt"; 

Folder root;
ArrayList<Tuple<String,Long>> directories;

void setup() {
  parse();
  part1();
  part2();
}

void parse() {
   String[] lines = loadStrings(file);
   Folder current = new Folder(null, null); //this will get destroyed but is required for the compiler
   for(String line: lines) {
      if(Parse.isCommand(line)) {
        if(Parse.isCdCommand(line)) {
          String action = Parse.cdAction(line);
          switch(action) {
            case"/": //initilise root
              root = new Folder(action, null);
              current = root;
              break;
            case "..": //step up the tree
              current = current.Parent;
              break;
            default: //find directory in current folder
              current = current.Child(action);
          }
        }
      } else {
        if(Parse.isDirectory(line)) {
          String directory = Parse.directoryName(line);
          if(!current.FolderExists(directory))
            current.Folders.add(new Folder(directory, current));
        } else {
          String fileName = Parse.fileName(line);
          if(!current.FileExists(fileName))
            current.Files.add(new File(Parse.fileName(line), Parse.fileSize(line)));
        }
      }
   }
   println(root.CountFolders()+" folders, "+root.CountFiles()+" files");
}

void part1() {
  directories = new ArrayList<Tuple<String,Long>>(); 
  
  directories.add(new Tuple<String,Long>(root.Name, root.Size()));
  println(root.Name, root.Size());
  AddFoldersToDictionary(root.Folders, directories, "-"); 
 
  long totalSizesLessThan100k = 0;
  for(Tuple<String,Long> dir: directories) {
    //println(e.getKey(), e.getValue());
    if(dir.Second<=100000) {
      totalSizesLessThan100k += dir.Second;
    }
    println(dir.Second, totalSizesLessThan100k);
  }
  
  println("Total folder sizes less than 100k: "+totalSizesLessThan100k);
}
void AddFoldersToDictionary(ArrayList<Folder> folders, ArrayList<Tuple<String,Long>> dict, String indent) {
  for(Folder folder: folders) {
    dict.add(new Tuple(folder.Name, folder.Size()));
    println(indent, folder.Name, folder.Size());
    AddFoldersToDictionary(folder.Folders, dict, indent+"-");
  }
}

void part2() {
  long freeSpace = 70000000l - root.Size();
  long deletionTarget = 30000000 - freeSpace;
  println("space to free: "+deletionTarget);
  
  long smallestFolderSize = root.Size();
  String smallestFolderName = root.Name;
  
  for(Tuple<String,Long> dir: directories)
    if(dir.Second > deletionTarget && dir.Second < smallestFolderSize) {
      smallestFolderSize = dir.Second;
      smallestFolderName = dir.First;
    }
  
  println("The smallest biggest folder is "+smallestFolderName+" ("+smallestFolderSize+")");
}