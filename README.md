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

2. table looks like this.   
![](https://i.gyazo.com/f60801f4c59567e490a4d0b137f8c29a.png)   

3. The test results with the following code gave these results.   
![](https://i.gyazo.com/1aa06df757d51bcc8328ed02cafcb4ac.png)   
test code looks as follows.   
![](https://i.gyazo.com/5180c4fdda2582722803869b56e445a7.png)   
![](https://i.gyazo.com/1972f9b69948409e7456828837da8c45.png)   

4. Detect, locate (and document) and fix as many errors as possible in the class.   
The first failed test as shown below fails on the last Assert line.   
![](https://i.gyazo.com/19da23826626e690205dbe8643097114.png)   
which means the object returned from array.get(1) doesn't exist, either it's 0 based index or other factor have a play in this.   
the code shown below doesn't clerify this, but from the exception func it can be seen 0 and below is a invalid input, so it can be assumed it's not 0 index based, however the list is a Object array, so it's possible the Get function has a error in the return command.   
![](https://i.gyazo.com/71212cd097866fae01f52df93ccba8d6.png)   
after changing the line
```
return list[index];
```
to
```
return list[index - 1];
```
have solved the issue currently.   

the next test is much larger as shown below.   
![](https://i.gyazo.com/319ec1b43c337b8f72dd184d6471a0fb.png)   
it fails already on the add function call, looking at the code shown below.   
![](https://i.gyazo.com/24856de76b0b94da22bdc5736fcdcdc7.png)   
our intend is to insert a object on index position 2, and the error from the test shows this.   
![](https://i.gyazo.com/ca06eff51b73985a41fea3c99962068b.png)   
which following into the code we can see the following if statement is responsible for the error.   
```
if (index < 0 || nextFree < index)
                throw new IndexOutOfRangeException("Error (add): Invalid index" +
               index);
```
the issue seems to be that the var nextFree is 0 and since 0 < 2 the exception is thrown, question is if this is a correct error or a false positiv is yet to be known. and from futher analyses it can be concluded the code features by my personal opinion a very weird index system, using a array of objects but using a int to know how many actual index items there is.   
by changing the index addition from 2 to 0 to follow this index system, we stumple upon the next issue.   
```
            Assert.True(array.size() == size);
```
at this line in the test code we expect the size to be 1, since 1 element have been inserted, judging from the code and in reference to the earlier add function it can be seen the code doesn't call
```
nextFree++;
```
which seems to be the systems way of indexing it's objects.   
by adding this in the end of the function seems to do as it's suppose to, further chain testing is noted as required for later verification.   

the last test as shown here.   
![](https://i.gyazo.com/5be78f6b3418ffcd578afed9281e7944.png)   
is rather troublesome as for me to develop, since asserting throw exceptions weren't working, I had to change it to a less convoluted style so it's current form is this.   
![](https://i.gyazo.com/c7618ffaf3646d30bec2747edffc70f5.png)   
after this modification the test shows green and thats all current testing working correctly, however from additional looks over the confusing index system, makes it clear that many there can be many more test case issues in this code, likewise remove at index havn't been tested yet so that is the next step from here.   
![](https://i.gyazo.com/83cb16f1b8a275cf653980de2d1bf9b8.png)   
the test goes as follows, add 3, ensure size is 3, remove third element from list, ensure size is 2, remove first element, ensure size is 1, get the remaining element and assert it's not null.


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
