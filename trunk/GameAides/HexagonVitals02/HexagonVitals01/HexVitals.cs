// HexVitals was written by William Getz on 5/26/11
// The purpose of this program is to derive the seven vital pieces of information
// needed in order to work with hexagons in a Role Playing Game setting.
//
// This Class handles the math of the form.
// By supplying one of the seven values of a hex, this math will place the value in terms
// of the side length, which I found to be the common factor amongst all the hex calculations.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace HexagonVitals01
{
    public class Example
    {
        private int x1;
        private int x2;

        public int Number1
        {
            get 
                // public int Number1()
            { return x1; } // is sidelength
            set
                // public void Number1(int value)
            {
                // x1 = value
                // x2 = value - 2
                CalculateValues(value);
            }
        }

        public int Number2 //Area
        {
            get { return x2; }
            set
            {
                //x2 = value;
                //x1 = value + 2;
                CalculateValues(value + 2);
            }
        }

        private void CalculateValues(int x1Value)
        {
            x1 = x1Value; //is sidelength
            x2 = x1Value - 2;
        }
    }

    public class HexVitals
    {

        public double _sideLength; // The common factor in all the hex calculations

        enum Hexagon
        {
            ApothemLength, Area, CenterToVertex, PerimeterLength, SideLength,
            SideToSideLength, VertexToVertexLength
        }

        // When you press Calculate, a new HexVitals object is created where - 
        // The property is instead keyed to the drop down menu. Instead, set the property to the value
        // typed in initially, and have the property derive the side length in the get/set.
        public double ApothemLength
        {
            get
            {
                return (Math.Sqrt(3) / 2) * _sideLength;
            }
            set
            {
                _sideLength = ((2 * value) / 3) * Math.Sqrt(3);
            }
        }
        public double Area
        {
            get
            {
                return ((3 * Math.Sqrt(3)) / 2) * Math.Pow(_sideLength, 2);
            }
            set
            {
                _sideLength = ((Math.Sqrt(2) * Math.Sqrt(value)) * (Math.Sqrt(Math.Sqrt(3))) / 3);
            }
        }
        public double CenterToVertex
        {
            get
            {
                return _sideLength;
            }
            set
            {
                _sideLength = value;
            }
        }
        public double PerimeterLength
        {
            get
            {
                return 6 * _sideLength;
            }
            set
            {
                _sideLength = value / 6;
            }
        }
        public double SideLength
        {
            get
            {
                return _sideLength;
            }
            set
            {
                _sideLength = value;
            }
        }
        public double SideToSideLength
        {
            get
            {
                return 2 * ((Math.Sqrt(3) / 2) * _sideLength);
            }
            set
            {
                _sideLength = (value / 3) * Math.Sqrt(3);
            }
        }
        public double VertexToVertexLength
        {
            get
            {
                return 2 * _sideLength;
            }
            set
            {
                _sideLength = value / 2;
            }
        }

        public void DeriveSideLength(int measurementType, double startingMeasurement)
        {
            //Use measurementType to 

            switch (measurementType)
            {
                case 0:
                    ApothemLength = startingMeasurement;
                    break;
                case 1:
                    Area = startingMeasurement;
                    break;
                case 2:
                    CenterToVertex = startingMeasurement;
                    break;
                case 3:
                    PerimeterLength = startingMeasurement;
                    break;
                case 4:
                    SideLength = startingMeasurement;
                    break;
                case 5:
                    SideToSideLength = startingMeasurement;
                    break;
                case 6:
                    VertexToVertexLength = startingMeasurement;
                    break;
                default:
                    _sideLength = 0;
                    break;
            }
        }
    }
}
