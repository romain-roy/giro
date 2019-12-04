using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class PriorityQueueTests
    {
        [Test]
        public void _01_testIsEmpty()
        {
            PriorityQueue<float> queue = new PriorityQueue<float>();
            Assert.IsTrue(queue.Count == 0);
            queue.Enqueue(5);
            Assert.IsFalse(queue.Count == 0);
        }
        
        [Test]
        public void _02_testSize()
        {
            PriorityQueue<float> queue = new PriorityQueue<float>();
            queue.Enqueue(5);
            queue.Enqueue(2);
            queue.Enqueue(.5f);
            Assert.IsTrue(queue.Count == 3);
        }
        
        [Test]
		public void _03_singleItemTest() {
			PriorityQueue<float> queue = new PriorityQueue<float>();
			queue.Enqueue(1);
			Assert.AreEqual(1, queue.Peek());
			Assert.AreEqual(1, queue.Count);
			Assert.IsFalse(queue.Count == 0);
		}

		[Test]
		public void _04_testElement() {
			PriorityQueue<float> queue = new PriorityQueue<float>();
			queue.Enqueue(5);
			queue.Enqueue(1);
			Assert.AreEqual(1, queue.Peek());
			queue.Dequeue();
			Assert.AreEqual(5, queue.Peek());
		}

		[Test]
		public void _05_threeItemsTest() {
			PriorityQueue<float> queue = new PriorityQueue<float>();
			queue.Enqueue(5);
			queue.Enqueue(6);
			queue.Enqueue(1);

			Assert.True(queue.Count != 0);
			Assert.AreEqual(3, queue.Count);
			Assert.AreEqual(1, queue.Peek());
		}

		[Test]
		public void _06_iteratorTest() {
			PriorityQueue<float> queue = new PriorityQueue<float>();
			queue.Enqueue(2);
			queue.Enqueue(5);
			queue.Enqueue(1);

			float[] expected = { 1, 2, 5 };

			for (int i = 0; i < expected.Length; i++)
			{
				Assert.AreEqual(expected[i], queue.Peek());
				queue.Dequeue();
			}
		}

		[Test]
		public void _07_removeTest() {
			PriorityQueue<float> queue = new PriorityQueue<float>();
			queue.Enqueue(8);
			queue.Enqueue(2);
			queue.Enqueue(5);

			queue.Dequeue();
			Assert.AreEqual(2, queue.Count);
			queue.Dequeue();
			Assert.AreEqual(1, queue.Count);
			queue.Dequeue();
			Assert.AreEqual(0, queue.Count);
		}

		[Test]
		public void _08_removeAddTest() {
			PriorityQueue<float> queue = new PriorityQueue<float>();
			
			queue.Enqueue(1);
			queue.Enqueue(2);
			queue.Enqueue(3);
			
			queue.Remove(2);
			
			queue.Enqueue(.5f);
			
			float[] expected = { .5f, 1, 3 };

			for (int i = 0; i < expected.Length; i++)
			{
				Assert.AreEqual(expected[i], queue.Peek());
				queue.Dequeue();
			}
		}

		[Test]
		public void _09_removeFirstItem()
		{
			PriorityQueue<float> queue = new PriorityQueue<float>();
			
			queue.Enqueue(1);
			queue.Enqueue(2);
			queue.Enqueue(3);
			
			queue.Remove(1);
			
			float[] expected = { 2, 3 };

			for (int i = 0; i < expected.Length; i++)
			{
				Assert.AreEqual(expected[i], queue.Peek());
				queue.Dequeue();
			}
		}
		
		[Test]
		public void _10_removeLastItem()
		{
			PriorityQueue<float> queue = new PriorityQueue<float>();
			
			queue.Enqueue(1);
			queue.Enqueue(2);
			queue.Enqueue(3);
			
			queue.Remove(3);
			
			float[] expected = { 1, 2 };

			for (int i = 0; i < expected.Length; i++)
			{
				Assert.AreEqual(expected[i], queue.Peek());
				queue.Dequeue();
			}
		}
    }
}
