using System;
using System.Linq; //'include this namespace to use Enumerable.Select for arrays
using System.Collections.Generic; //'include this namespace to use list library for Q2-4


namespace CarSimulator
{
    public class Highway
    {
        static void Main(string[] args)
        {
            //Step 1: implement fleets of arrays/lists per vehicle type
            // and compute states

            // create fleet
            int fleetNumberPerType = 25;
            double dt = 1;

            //'define new array called myTeslas of class Tesla3 of size fleetNumberperType
            //'???if i use static for the subclasses will i avoid having to put Car. before them
            //'note lab manual code was missing the x=> part
            /*Car.Tesla3[] myTeslas = new Car.Tesla3[fleetNumberPerType].Select(x => new Car.Tesla3()).ToArray(); //TO DO: Projects each element of a sequence into a new form)
            Car.Prius[] myPriuses = new Prius[fleetNumberPerType].Select
            Car.Mazda3[] myMazdas = new Mazda3[fleetNumberPerType].Select
            Car.Herbie[] myHerbies = new Herbie[fleetNumberPerType].Select
            */

            
            Car.Tesla3[] myTeslas = Enumerable.Range(0, fleetNumberPerType - 1).Select(x => new Car.Tesla3()).ToArray(); //'why do i have to do fleetNumberPerType-1?
            Car.Prius[] myPriuses = Enumerable.Range(0, fleetNumberPerType - 1).Select(x => new Car.Prius()).ToArray();
            Car.Mazda3[] myMazdas = Enumerable.Range(0, fleetNumberPerType - 1).Select(x => new Car.Mazda3()).ToArray();
            Car.Herbie[] myHerbies = Enumerable.Range(0, fleetNumberPerType - 1).Select(x => new Car.Herbie()).ToArray();


            


            //'use this for loop to drive the cars from Q2-3
            for (double t = 0; t < 60; t += dt)
            {
                for (int i = 0; i < fleetNumberPerType - 1; i++)
                {
                    myTeslas[i].drive(dt);//'do i have to do it like this???
                    myPriuses[i].drive(dt);
                    myMazdas[i].drive(dt);
                    myHerbies[i].drive(dt);

                    //'how to start a new line???
                    Console.WriteLine("myTeslas car " + i + " state: position- " + myTeslas[i].myCarState.position + " velocity- " + myTeslas[i].myCarState.velocity + " acceleration- " + myTeslas[i].myCarState.accelation + " time- " + myTeslas[i].myCarState.time);
                    Console.WriteLine("myMazdas car " + i + " state: position- " + myMazdas[i].myCarState.position + " velocity- " + myMazdas[i].myCarState.velocity + " acceleration- " + myMazdas[i].myCarState.accelation + " time- " + myMazdas[i].myCarState.time);
                    Console.WriteLine("myPriuses car " + i + " state: position- " + myPriuses[i].myCarState.position + " velocity- " + myPriuses[i].myCarState.velocity + " acceleration- " + myPriuses[i].myCarState.accelation + " time- " + myPriuses[i].myCarState.time);
                    Console.WriteLine("myHerbies car " + i + " state: position- " + myHerbies[i].myCarState.position + " velocity- " + myHerbies[i].myCarState.velocity + " acceleration- " + myHerbies[i].myCarState.accelation + " time- " + myHerbies[i].myCarState.time);

                    //print states
                }

            }

            


            ////////////////////////////Step 2: implement all the fleet in one list and compute states/////////////////////////////////

            //'recall a list is a linked list, a bunch of objects linked together
            var myCars = new List<Car>(); //'create a new list of type var (generic variable type since adding 4 types of subclass. <Car> indicates those subclasses are from the Car class) called myCars

            //'use loop to fill the myCars list with fleetNumberPerType amount of car objects for each car
            for (int i = 0; i < fleetNumberPerType; i++)
            {
                myCars.Add(new Car.Tesla3());//' Add keyword adds objects to a linked list, use new bc using constructor to create a new Tesla3 object to add
                myCars.Add(new Car.Mazda3());
                myCars.Add(new Car.Prius());
                myCars.Add(new Car.Herbie());

            }
 


            // loop through the time and list to drive all the vehicles
            for (double t = 0; t < 60; t += dt)
            {
                //for (int i = 0; i < fleetNumberPerType; i++)
                //{
                    // TO DO: Drive myCars list and Display the cars states acceleration, speed, position, etc

                    //myCars[i].drive(dt);

                    foreach(var Car in myCars) //'foreach is easy way to access each entity in list
                    {
                        Car.drive(dt);
                        Console.WriteLine($" model: {Car.getModel()} position: {Car.myCarState.position} velocity: {Car.myCarState.velocity} acceleration: {Car.myCarState.accelation} time: {Car.myCarState.time}"); //'can just call the getModel method here to get the model
                    }

               // foreach (var Car in myCars)//'replace other forloop with this?
                   // {
                      //  Console.WriteLine($"position: {Car.myCarState.position} velocity: {Car.myCarState.velocity} acceleration: {Car.myCarState.accelation} model: {Car.getModel()} time: {Car.myCarState.time}" );

                   // }

                    //Console.WriteLine("myCars car " + i + " state: position- " + myTeslas[i].myCarState.position + " velocity- " + myTeslas[i].myCarState.velocity + " acceleration- " + myTeslas[i].myCarState.accelation + " time- " + myTeslas[i].myCarState.time);


                //}
            }

        }

    }
}
