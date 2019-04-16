using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using AntMapGenerator.Utilities;

namespace AntMapGenerator.Tests
{
    public class PriorityListTests
    {
        PriorityList<TestItem> list;



        private struct TestItem : IPrioritizable
        {
            public int Priority { get; }

            public TestItem(int priority) : this()
            {
                Priority = priority;
            }
        }

        [SetUp]
        public void SetUp()
        {
            list = new PriorityList<TestItem>();
        }

        // A Test behaves as an ordinary method
        [Test]
        public void ListPrioritySortsOnAdd()
        {
            list.Add(new TestItem(5));
            Assert.That(list[0].Priority, Is.EqualTo(5));
            list.Add(new TestItem(1));
            Assert.That(list[0].Priority, Is.EqualTo(1));
            Assert.That(list[1].Priority, Is.EqualTo(5));
            list.Add(new TestItem(3));
            Assert.That(list[0].Priority, Is.EqualTo(1));
            Assert.That(list[1].Priority, Is.EqualTo(3));
            Assert.That(list[2].Priority, Is.EqualTo(5));
            list.Add(new TestItem(-1));
            Assert.That(list[0].Priority, Is.EqualTo(-1));
            Assert.That(list[1].Priority, Is.EqualTo(1));
            Assert.That(list[2].Priority, Is.EqualTo(3));
            Assert.That(list[3].Priority, Is.EqualTo(5));
        }

        [Test]
        public void ListPrioritySortsOnRemove()
        {
            list.Add(new TestItem(5));
            list.Add(new TestItem(1));
            list.Add(new TestItem(3));
            list.Add(new TestItem(-1));

            list.RemoveAt(1);
            Assert.That(list[0].Priority, Is.EqualTo(-1));
            Assert.That(list[1].Priority, Is.EqualTo(3));
            Assert.That(list[2].Priority, Is.EqualTo(5));
        }


    }
}
