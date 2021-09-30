using System;
namespace CarSimulator
{
    public class DragRace
    {
        static void Main(string[] args)
        {
            //'args are model,mass,engine force,drag area
            Car myTesla = new Car("Tesla", 1500, 1000, 0.51); //'recall you use the "new" keyword in c# for constructing a new object, when inside of a main method?
            Car myPrius = new Car("Prius", 1000, 750, 0.43);


            //'seeing below, myTesla is a car object, myCarState is a state object that every car object has, setstate is a method that every state object can call
            myTesla.myCarState.setstate(0, 0, 0, 0); //'using set function to initialize the states of both cars to 0, args are position,velocity,acceleration,time
            myPrius.myCarState.setstate(0, 0, 0, 0);
            

            // drive for 60 seconds with delta time of 1s
            double dt = 1;




            //'call drive method (implemented in car class) to compute new values for the mycarstate object that each car has
            //'print the contents of the state object for each car
            //'compare the positions of the cars, (positions as in the data field in their state objects) and print the name of the one with a higher position value
            for (double t = 0; t < 60; t += dt)
            {

                myTesla.drive(dt);
                myPrius.drive(dt);

                Console.WriteLine("Tesla state: position- " + myTesla.myCarState.position + " velocity- " + myTesla.myCarState.velocity + " acceleration- " + myTesla.myCarState.accelation + " time- " + myTesla.myCarState.time);
                Console.WriteLine("Prius state: position- " + myPrius.myCarState.position + " velocity- " + myPrius.myCarState.velocity + " acceleration- " + myPrius.myCarState.accelation + " time- " + myPrius.myCarState.time);

                if (myTesla.myCarState.position > myPrius.myCarState.position)
                {
                    Console.WriteLine("Tesla in lead");
                }

                else if (myTesla.myCarState.position < myPrius.myCarState.position)
                {
                    Console.WriteLine("Prius in lead");
                }

                if (myTesla.myCarState.position >= 402.3 && myPrius.myCarState.position >= 402.3)
                {
                    if (myTesla.myCarState.position > myPrius.myCarState.position)
                    {
                        Console.WriteLine("Tesla wins");
                    }

                    else if (myTesla.myCarState.position < myPrius.myCarState.position)
                    {
                        Console.WriteLine("Prius wins");
                    }

                    break;
                }


                // print the time and current state
                // print who is in lead




            }
        }
    }
}
