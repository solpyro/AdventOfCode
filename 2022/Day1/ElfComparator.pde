class ElfComparator implements Comparator<Elf> {
  int compare(Elf a, Elf b) {
    return a.TotalCalories()-b.TotalCalories();
  }
}