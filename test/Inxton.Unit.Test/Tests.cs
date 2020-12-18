using NUnit.Framework;
using Plc;
using Vortex.Adapters.Connector.Tc3.Adapter;
using Vortex.Connector;

namespace Inxton.Unit.Test
{
    /// <summary>
    /// To get more info about PLC Unit testing checkout.
    /// https://github.com/PTKu/tc.prober 
    /// https://github.com/tcunit/TcUnit
    /// </summary>
    public class Tests
    {
        private PlcTwinController Plc { get; set; }

        [SetUp]
        public void Setup()
        {
            //var adapter = Tc3ConnectorAdapter.Create(AmsId, Port);
            var adapter = new ConnectorAdapter(typeof(DummyConnectorFactory));
            Plc = new PlcTwinController(adapter);
        }

        [Test]
        public void ValueIsWrittenToThePlc()
        {
            // arrange
            var toWrite = "Hello test!";
            // act
            Plc.MAIN.Hello_World.Another.Synchron = toWrite;
            // assert
            Assert.AreEqual(Plc.MAIN.Hello_World.Another.Synchron, toWrite);
        }

        [Test]
        public void BoolIsInverterd()
        {
            // arrange
            Plc.MAIN.Hello_World.Bools.BoolOne.Synchron = true;
            // act
            Plc.MAIN.Hello_World.Bools.BoolOne.Synchron = !Plc.MAIN.Hello_World.Bools.BoolOne.Synchron;
            // assert
            Assert.AreEqual(Plc.MAIN.Hello_World.Bools.BoolOne.Synchron, false);
        }

    }
}