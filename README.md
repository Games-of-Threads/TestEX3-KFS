# TestEX3-KFS
> by Kristian Flejsborg Sørensen (cph-kf96)

this paper is the response to the assignment in the test cause stated [here](https://github.com/datsoftlyngby/soft2018spring-test-teaching-material/blob/master/exercises/Test%20Case%20Exercises.pdf) with the use of these [slides](https://github.com/datsoftlyngby/soft2018spring-test-teaching-material/blob/master/slides/Test%20Design%20Techniques.pdf)

## Equivalence classes
### 1. 
The table looks as follows.   
![](https://i.gyazo.com/93b5525a2555c77c6747da4e18555184.png)   

### 2. 
The table looks as follows.   
![](https://i.gyazo.com/eee5bf1f42e8fc0d01aab01bcdfc4a07.png)   

### 3. 
The table looks as follows.   
![](https://i.gyazo.com/9a70386a722ce6641f5b92bde78fcd74.png)   

## Boundary Analysis
### 1. 
The table looks as follows.   
![](https://i.gyazo.com/43faec8a6a5e08db7b88cee4bce226b3.png)   

### 2. 
The table looks as follows.   
![](https://i.gyazo.com/13d162a1a683898ffc4250db3af6f8a1.png)   

### 3. 
The table looks as follows.   
![](https://i.gyazo.com/d7bf18c6208e8fa8b7707f9cf35870d4.png)   

## Decision tables
### 1. 
Table looks like this.   
![](https://i.gyazo.com/8dc91dfbc4605b46f1ca799b23452fa9.png)   

### 2. 
Table looks like this.   
![](https://i.gyazo.com/4b0a68585817ede34a25b638d4029ef0.png)

## State transition
### 1. 
State Diagram looks as follows.   
![](https://i.gyazo.com/e3bd4d547074f7548f51db61f6f8e856.png)   

Bonus state table looks as follows.   
![](https://i.gyazo.com/7f374133d32e31073ce59958e678fc02.png)

### 2. 
table looks like this.   
![](https://i.gyazo.com/f60801f4c59567e490a4d0b137f8c29a.png)   

### 3. 
The test results with the following code gave these results.   
![](https://i.gyazo.com/1aa06df757d51bcc8328ed02cafcb4ac.png)   
test code looks as follows.   
![](https://i.gyazo.com/5180c4fdda2582722803869b56e445a7.png)   
![](https://i.gyazo.com/1972f9b69948409e7456828837da8c45.png)   

### 4. 
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
first test case reveals the first error.   
![](https://i.gyazo.com/dc0eb33f4459c66c6fc5841193ec81d6.png)   
the code that results in this exception looks like this.
```
if (index < 0 || nextFree <= index)
                throw new IndexOutOfRangeException("Error (remove): Invalid index"
               + index);
```
for some reason, the code implies that if you try to remove a object at the nextFree or above your selecting something that doesn't exist, which means some of my code might have been false positiv, as the size() function gets the right size value wise, but it returns nextFree which seems to be indicated here as "next free spot in the array". from this reveal it can be judged that some functions aren't working as they should, and the index value for alot of functions are in turmoil.   
although it's better to do a full review with the coder, timewise I choose to mirror the functionality of the add at index function, so instead of nextFree <= index, we remove the equal sign to keep parity in the code.   

this simple change have fixed all issues in the function.
 
### 5. 
I made both the table and the diagram, yet doing my development of test cases and implementation I exclusively used the table, though this isn't a indication of whats better as the program was rather enclosed meaning almost all functionality was connected to the same state "State 2".   
I think once the system gets larger the diagram is much better to get the details about any single state, while the table would grow exponentially, making it harder and harder unless you made smaller tables somehow.   

### 6. 
Make a conclusion where you specify the level of test coverage and argue for your chosen level:   
I believe I've visited 75% of the states I specified in my design, however S1 and S8 seems to slip me up as the creation of S1 can be argued isn't tested, yet the rest of the tests can't be done without it. Likewise I test for exceptions but the function S8 says exist doesn't actually exist so this direct function isn't tested but the code that throws the exception and those exceptions are mostly covered. I would also note the function "getLongerList()" was never stated and never tested although it was analysed and stated to be functioning as intended.   
There are alot of transitions, and I've only got a small % of them as it would take too long to actually manage all test cases, it can be argued that I could have been smarter in my coverage as stated in the power point slides, but I'm on a tight timeline here so I had to cut corners.   

## Personal Comment
this code really aggrevated me, and given the idea of tester feedback has to be neutral I think this is a good indication on how much one should prepare for discussing the code with the implementer, as it's unknown if it's intentional or accidentil that some things are as they are, and if it's the tester or the programmer that is at fault in the conflict of agreement, since code standards can be highly varied, this also shows how important code standards for a given company is as without a standard to follow I have no idea if this code is brilliant with minor flaws or terribly implemented.
