using System;
using System.Collections.Generic;
using System.Text;

namespace Hooke_Jeeves
{
    class Point
    {
        private List<float> valueVector;

        public Point(float[] currentValues)
        {
            valueVector = new List<float>(currentValues);
        }
        
        public void addValue(float value)
        {
            valueVector.Add(value);
        }

        public float getValueByIndex(int index)
        {
            return valueVector[index];
        }

        public int size()
        {
            return valueVector.Count;
        }

        public Point getNewPointDelta(float delta, int index)
        {
            float[] buffer = valueVector.ToArray();
            buffer[index] += delta;
            return new Point(buffer);
        }

        public static Point operator +(Point point1, Point point2)
        {
            List<float> buffer = new List<float>(point1.valueVector);
            for(int i = 0; i < point2.size(); i++)
            {
                buffer[i] += point2.getValueByIndex(i);
            }
            return new Point(buffer.ToArray());
        }

        public static Point operator *(Point point1, float stepValue)
        {
            List<float> buffer = new List<float>(point1.valueVector);
            for (int i = 0; i < point1.size(); i++)
            {
                buffer[i] *= stepValue;
            }
            return new Point(buffer.ToArray());
        }

        public static Point operator -(Point point1, Point point2)
        {
            List<float> buffer = new List<float>(point1.valueVector);
            for (int i = 0; i < point1.size(); i++)
            {
                buffer[i] -= point2.getValueByIndex(i);
            }
            return new Point(buffer.ToArray());
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("X = (");
            foreach(float value in valueVector)
            {
                sb.Append(value);
                sb.Append(" ");
            }
            sb.Append(")");
            return sb.ToString();
        }
    }
}
