using System;
using System.Collections.Generic;
using System.Text;

namespace Hooke_Jeeves
{
    class ControlParametrs
    {
        private List<float> controlVector;
        private float stepValue;
        private float accuracy;

        public float Accuracy
        {
            get => accuracy;
            set => accuracy = value;
        }

        public ControlParametrs(float[] currentValues, float stepValue, float accuracy)
        {
            controlVector = new List<float>(currentValues);
            this.stepValue = stepValue;
            this.accuracy = accuracy;
        }

        public float getDeltaByIndex(int index)
        {
            return controlVector[index];
        }

        public float getStepValue()
        {
            return stepValue;
        }
    }
}
