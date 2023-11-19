import java.util.Arrays;
import java.util.Comparator;

static final Comparator<int[]> INTARRAY_COMPARATOR = new Comparator<int[]>() {
  @ Override final public int compare(final int[] a, final int[] b) {
    int compare;
    return
      (compare = Float.compare(a[0], b[0])) != 0
        ? compare 
        : Float.compare(a[1], b[1]);
  }
};