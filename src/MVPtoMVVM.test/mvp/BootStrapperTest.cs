using System;
using MVPtoMVVM.mvp;
using MVPtoMVVM.repositories;
using NUnit.Framework;
using StructureMap;

namespace MVPtoMVVM.test.mvp
{
    [TestFixture]
    public class BootStrapperTest
    {
        
        [SetUp]
        public void Setup()
        {
            new Bootstrap().Execute();
        }

        [Test]
        public void it_should_register_the_repository()
        {
            Console.Out.WriteLine(ObjectFactory.WhatDoIHave());
            Assert.That(ObjectFactory.GetInstance<ITodoItemRepository>(), Is.TypeOf<TodoItemRepository>());
        }
    }
}