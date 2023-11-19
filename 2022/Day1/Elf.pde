class Elf {
  IntList _inventory;
  
  Elf() {
    _inventory = new IntList();
  }
  
  void AddItem(int item) {
    _inventory.append(item);
  }
  
  int TotalCalories() {
    int calories = 0;
    for(float item: _inventory) calories += item;
    return calories;
  }
}