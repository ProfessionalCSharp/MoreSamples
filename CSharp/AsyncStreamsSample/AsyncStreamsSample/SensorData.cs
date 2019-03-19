using System;
using System.Collections.Generic;
using System.Text;

namespace AsyncStreamsSample
{
    public struct SensorData
    {
        public SensorData(int value1, int value2) => (Value1, Value2) = (value1, value2);

        public int Value1 { get; }
        public int Value2 { get; }
    }
}
