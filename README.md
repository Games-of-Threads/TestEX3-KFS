# TestEX3-KFS
> by Kristian Flejsborg Sørensen (cph-kf96)

this paper is the response to the assignment in the test cause stated [here](https://github.com/datsoftlyngby/soft2018spring-test-teaching-material/blob/master/exercises/Test%20Case%20Exercises.pdf) with the use of these [slides](https://github.com/datsoftlyngby/soft2018spring-test-teaching-material/blob/master/slides/Test%20Design%20Techniques.pdf)

## Equivalence classes
1. The table looks as follows.   
![](https://i.gyazo.com/93b5525a2555c77c6747da4e18555184.png)   

2. The table looks as follows.   
![](https://i.gyazo.com/eee5bf1f42e8fc0d01aab01bcdfc4a07.png)   

3. The table looks as follows.   
![](https://i.gyazo.com/9a70386a722ce6641f5b92bde78fcd74.png)   

## Boundary Analysis
1. The table looks as follows.   
![](https://i.gyazo.com/43faec8a6a5e08db7b88cee4bce226b3.png)   

2. The table looks as follows.   
![](https://i.gyazo.com/13d162a1a683898ffc4250db3af6f8a1.png)   

3. The table looks as follows.   
![](https://i.gyazo.com/d7bf18c6208e8fa8b7707f9cf35870d4.png)   

## Decision tables
1. Table looks like this.   
![](https://i.gyazo.com/8dc91dfbc4605b46f1ca799b23452fa9.png)   

2. Table looks like this.   
![](https://i.gyazo.com/4b0a68585817ede34a25b638d4029ef0.png)

## State transition
1. State Diagram looks as follows.   
![](https://i.gyazo.com/e3bd4d547074f7548f51db61f6f8e856.png)   

Bonus state table looks as follows.   
![](https://i.gyazo.com/7f374133d32e31073ce59958e678fc02.png)

2. Derive test cases from the state diagram.   
3. Implement automated unit tests using the test cases above.   
4. Detect, locate (and document) and fix as many errors as possible in the class.   
a. Define (more) relevant test cases applying black box and white box techniques   
b. Use xUnit to implement and run the same tests cases again after fixing   
c. Study the implementation (code)   
d. Use debugger to locate errors   
5. Consider whether a state table is more useful design technique. Comment on that.   
6. Make a conclusion where you specify the level of test coverage and argue for your chosen level:   
 Percentage of states visited   
 Percentage of transitions exercised   
Formalities   
Hand-in on Moodle: Document with text descriptions + link to code on Github   
Code Deliverables: Automated unit tests for MyArrayListWithBugs.java + revised version of class.   
Deadline: February 25th at noon   

Code
```
package myBugs;
/**
* Class with bugs.
*
*
*/
public class MyArrayListWithBugs {

 private Object[] list;
 int nextFree;

 // Creates a new empty list
 public MyArrayListWithBugs()
 {
 list = new Object[5];
 nextFree = 0;
 }

 // Inserts object at the end of list
 public void add(Object o)
 {
 // check capacity
 if (list.length <= nextFree)
 list = getLongerList();

 list[nextFree] = o;
 nextFree++;
 }

 // Returns the number of objects in the list
 public int size()
 {
 return nextFree;
 }

 // Returns a reference to the object at position index
 // Throws IndexOutOfBoundsException
 public Object get(int index)
 {
 if(index <= 0 || nextFree < index)
 throw new IndexOutOfBoundsException("Error (get): Invalid index" +
index);

 return list[index];
 }

 // Inserts object at position index
 // Throws IndexOutOfBoundsException
 public void add(int index, Object o)
 {
 if(index < 0 || nextFree < index)
 throw new IndexOutOfBoundsException("Error (add): Invalid index" +
index);

 // check capacity
 if (list.length <= nextFree)
PBA Software Development: Test
Tine Marbjerg 5
 list = getLongerList();

 // Shift elements upwards to make position index free
 // Start with last element and move backwards
 for (int i = nextFree-1; i > index; i--) {
 list[i] = list[i-1];
 }

 list[index] = o;
 }

 // Removes object at position index
 // Returns a reference to the removed object
 // Throws IndexOutOfBoundsException
 public Object remove(int index)
 {
 if (index < 0 || nextFree <= index)
 throw new IndexOutOfBoundsException("Error (remove): Invalid index"
+ index);


 // Shift elements down to fill indexed position
 // Start with first element
 for (int i = index; i < nextFree-1; i++) {
 list[i] = list[i+1];
 }
 nextFree--;

 return list[index];

 }

 //============== private helper methods ==========
 // create a list with double capacity and
 // copy all elements to this
 private Object[] getLongerList() {
 Object[] tempList = new Object[list.length*2];
 for (int i=0; i< list.length;i++) {
 tempList[i] = list[i];
 }
 return tempList;
 }


}
```
