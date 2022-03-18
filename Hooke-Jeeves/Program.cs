using System;

namespace Hooke_Jeeves
{
    class Program
    {
        static double function(Point currentPoint)
        {
            float x1 = currentPoint.getValueByIndex(0);
            float x2 = currentPoint.getValueByIndex(1);
            return 100 * Math.Pow((x2 - Math.Pow(x1, 2)), 2) + Math.Pow((1 - x1), 2);
        }

        static bool betterAccuracy(Point currentPoint, float accuracy)
        {
            return function(currentPoint) < accuracy;
        }

        static bool neighboringPointIsBetter(Point currentPoint, float delta, int index)
        {
            return function(currentPoint.getNewPointDelta(delta, index)) < function(currentPoint);
        }

        static void printResultOfPoint(Point currentPoint, string pointInformation)
        {
            Console.WriteLine(pointInformation + currentPoint);
            Console.WriteLine("|Значение в этой точке: " + function(currentPoint));
        }

        static void Main(string[] args)
        {
            //Задаем начальные значения
            float[] startingValues = { -1.2f, 1 };
            float[] deltaValues = { 0.0004f, 0.0004f };
            float stepValue = 2.8f;
            float accuracy = 0.7f;


            Point startPoint = new Point(startingValues);
            ControlParametrs controlParametrs = new ControlParametrs(deltaValues, stepValue, accuracy);

            while (!betterAccuracy(startPoint, controlParametrs.Accuracy))
            {
                Point currentPoint = startPoint;
                printResultOfPoint(currentPoint, "Текущая точка: ");

                for (int i = 0; i < startPoint.size(); i++)
                {
                    if (neighboringPointIsBetter(currentPoint, controlParametrs.getDeltaByIndex(i), i))
                    {
                        currentPoint = currentPoint.getNewPointDelta(controlParametrs.getDeltaByIndex(i), i);
                        continue;
                    }

                    if (neighboringPointIsBetter(currentPoint, -controlParametrs.getDeltaByIndex(i), i))
                    {
                        currentPoint = currentPoint.getNewPointDelta(-controlParametrs.getDeltaByIndex(i), i);
                        continue;
                    }
                }

                printResultOfPoint(currentPoint, "Точка после смещений: ");

                Point nextPoint = startPoint + (currentPoint - startPoint) * controlParametrs.getStepValue();
                printResultOfPoint(nextPoint, "Точки по направлению: ");
                Console.WriteLine();

                if (function(nextPoint) < function(currentPoint))
                {
                    startPoint = nextPoint;
                }
                else
                {
                    if(startPoint == currentPoint)
                    {
                        Console.WriteLine("Смещение не произведено.");
                        break;
                    }
                    startPoint = currentPoint;
                }
            }

            printResultOfPoint(startPoint, "В результате работы алгоритма получена точка: ");
            
        }
    }
}
