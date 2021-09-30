using System;


namespace CarSimulator
{
    public class Class1
    {


        
        //'testing our set method with a main function
        static void Main(string[] args)
        {

            State s1 = new State(); //'declare a State object/instance called s1 using the default constructor (also need to include 'new' before the constructor in c#, the syntax for this is pretty different from c++
            s1.setstate(1, 4, 5, 7); //' call the set method to set all the attributes in one line (that's why we using one here even tho all the state data fields are public)
            Console.WriteLine("state is " + s1.position + " " + s1.velocity + " " + s1.accelation + " "  + s1.time);




        }


        


    }
}
