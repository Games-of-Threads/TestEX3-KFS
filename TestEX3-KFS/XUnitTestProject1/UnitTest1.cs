using System;
using Xunit;
using TestEX3_KFS;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        MyArrayListWithBugs array = new MyArrayListWithBugs();

        [Fact]
        public void Test1()
        {
            int size = 0;
            Assert.True(size == array.size());
        }

        [Fact]
        public void Test2()
        {
            Object temp = new Object();
            int size = 0;
            array.add(temp);
            size++;
            Assert.True(array.size() == size);
            temp = array.get(1);
            Assert.True(temp != null);
        }

        [Fact]
        public void Test3()
        {
            Object temp = new Object();
            int size = 0;
            array.add(0, temp);
            size++;
            Assert.True(array.size() == size);
            Object second = new Object();
            second = array.get(1);
            Assert.True(second != null);
        }

        [Fact]
        public void Test4()
        {
            Object temp = new Object();
            array.add(temp);
            array.add(temp);
            array.add(temp);
            temp = array.get(3);
            Assert.False(temp == null);
        }

        [Fact]
        public void Test5()
        {
            //impossible as there aren't any throw exception state
        }

        [Fact]
        public void Test6()
        {
            var ex = Assert.ThrowsAny<Exception>(() => array.get(4));
        }

        [Fact]
        public void Test7()
        {
            Object temp = new Object();
            array.add(temp);
            array.add(temp);
            array.add(temp);
            Assert.True(array.size() == 3);
            array.remove(3);
            Assert.True(array.size() == 2);
            array.remove(1);
            temp = array.get(1);
            Assert.True(temp != null);
        }
    }
}
