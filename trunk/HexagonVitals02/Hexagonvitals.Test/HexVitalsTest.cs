using ApprovalTests;
using ApprovalTests.Reporters;
using HexagonVitals01;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hexagonvitals.Test
{
    [UseReporter(typeof(DiffReporter))]
    [TestClass]
    public class HexVitalsTest
    {
        [TestMethod]
        public void TestMeasurementTypeZero()
        {
            var vitals = new HexVitals();
            vitals.DeriveSideLength(0, 6.0);
            Approvals.Approve(vitals.GetPropertiesAsString());
        }

        [TestMethod]
        public void TestMeasurementTypeOne()
        {
            var vitals = new HexVitals();
            vitals.DeriveSideLength(1, 6.0);
            Approvals.Approve(vitals.GetPropertiesAsString());
        }

        [TestMethod]
        public void TestMeasurementTypeTwo()
        {
            var vitals = new HexVitals();
            vitals.DeriveSideLength(2, 6.0);
            Approvals.Approve(vitals.GetPropertiesAsString());
        }

        [TestMethod]
        public void TestMeasurementTypeThree()
        {
            var vitals = new HexVitals();
            vitals.DeriveSideLength(3, 6.0);
            Approvals.Approve(vitals.GetPropertiesAsString());
        }

        [TestMethod]
        public void TestMeasurementTypeFour()
        {
            var vitals = new HexVitals();
            vitals.DeriveSideLength(4, 6.0);
            Approvals.Approve(vitals.GetPropertiesAsString());
        }

        [TestMethod]
        public void TestMeasurementTypeFive()
        {
            var vitals = new HexVitals();
            vitals.DeriveSideLength(5, 6.0);
            Approvals.Approve(vitals.GetPropertiesAsString());
        }

        [TestMethod]
        public void TestMeasurementTypeSix()
        {
            var vitals = new HexVitals();
            vitals.DeriveSideLength(6, 6.0);
            Approvals.Approve(vitals.GetPropertiesAsString());
        }

    }
}
