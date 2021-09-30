using System;
namespace CarSimulator
{
    public class State
    {
        public double position;
        public double velocity;
        public double accelation;
        public double time;

        //implement methods like set, constructors (if applicable)

        //'default constructor that initializes everything in the state to zero
        //'??do i need to add public for the constructors
        public State()
        {
            position = 0;
            velocity = 0;
            accelation = 0;
            time = 0;
        }


        //'overloaded constructor that allows you to initialize member variables
        public State(double inputposition,double inputvelocity,double inputaccelation,double inputtime)
        {
            position = inputposition;
            velocity = inputvelocity;
            accelation = inputaccelation;
            time = inputtime;
        }




        //'set method we can use to set all the variables at once
        public void setstate(double pos,double vel,double acc,double newtime){
            position = pos;
            velocity = vel;
            accelation = acc;
            time = newtime;
            
         }
        

    }
}
