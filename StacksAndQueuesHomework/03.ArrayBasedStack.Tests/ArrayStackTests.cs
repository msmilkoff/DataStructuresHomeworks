using NUnit.Framework;
using System;

namespace ArrayBasedStack.Tests
{
    [TestFixture()]
    public class ArrayStackTests
    {
        [Test()]
        public void PushPop_PushAndOne_ShouldAddAndRemoveCorrectly()
        {
            var stack = new ArrayStack<int>();

            Assert.AreEqual(stack.Count, 0);
            stack.Push(5);
            Assert.AreEqual(stack.Count, 1);

            var item = stack.Pop();
            Assert.AreEqual(5, item);
            Assert.AreEqual(stack.Count, 0);
        }

        // TODO: Write more tests.
    }
}

