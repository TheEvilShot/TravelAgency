﻿namespace Domain.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class TransportTest
    {

        private Transport transport;
        private Tour tour;

        [SetUp]
        public void Setup()
        {
            this.transport = new Transport(1, "Airplane");
            this.tour = new Domain.Tour(1, "Планета Тур", DateTime.Now, 500, DateTime.Now, 23);
        }
        [Test]
        public void ToString_ValidData_Success()
        {

            //act
            var result = this.transport.ToString();
            //assert
            Assert.AreEqual("Airplane", result);
        }

        [Test]
        public void Ctor_WrongData_EmptyNameTransport_Fail() =>
            Assert.Throws<ArgumentOutOfRangeException>(() => _ = new Transport(1, ""));

        [Test]
        public void AddTourToTransport_ValidData_Success()
        {

            //act
            var result = this.transport.AddTour(tour);

            //assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public void AddTourToTransport_WrongParameter_Fail()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => _ = this.transport.AddTour(null));
            Assert.That(ex.ParamName, Is.EqualTo("tour"));
        }
    }
}
