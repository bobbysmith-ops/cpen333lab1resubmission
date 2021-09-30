using System;
namespace CarSimulator
{
    public class Car
    {
        //'for Q2 part 2 switch the private fields to protected 
        protected double mass;
        protected string model;
        protected double dragArea;
        protected double engineForce;


        private bool accelerating;//'not super important

        //'the creation of a state object in the car class basically corresponds to the arrow connecting the car class to state class in the class diagram from lab manual
        public State myCarState = new State();  //'instance/object/instantiation of the State class (this just creates a state object within the car class using default constructor,ie. every car will have a state)
                                                //' DON'T EVEN HAVE TO INSTANTIATE PHYSICS1D HERE TO USE ITS METHODS BC THOSE METHODS ARE STATIC


        /// implement constructor and methods

        //' no arg constructor for Car class, could i have just left these brackets empty and it would have put default values for the data fields?
        public Car()
        {
            mass = 0;
            model = null;
            dragArea = 0;
            engineForce = 0;
        }
        


        //'Constructor for Car class
        public Car(string amodel, double amass, double aengineForce, double adragArea)
        {
            model = amodel;
            mass = amass;
            dragArea = adragArea;
            engineForce = aengineForce;
        }
    

        
        //'a car object may invoke getModel to return its model eg myTesla.getModel in DragRace.cs
        public string getModel()
        {
            return model;
        }


        public double getMass()
        {
            return mass;
        }



        //'this is kind of unnecesary, dont need to use.  If you call it with 1 then accelerating=1 aka foot on gas, call with 0 then accelerating=0 aka foot not on gas
        public void accelerate(bool on)
        {
            accelerating = on;
        }




        //'use my physics 1D formulas to calculate how my state data fields are changing with each time interval dt, and update the state data fields
        //'this works bc Physics1D methods are public and so are State data fields
        //'for Q2 part 2 you add the virtual to override the drive function
        public virtual void drive(double dt)
        {

            //'first compute drag force, only need fd for drive function so can just declare it w/in the function

            double fd = 0.5 * 1.225 * dragArea * myCarState.velocity;

            //'compute total force on car, again i only need totalforce for the drive function so can just declare it in here

            double totalforce = engineForce - fd;

            //'compute acceleration

            myCarState.accelation = Physics1D.compute_acceleration(totalforce, mass);

            //'compute velocity (this is where the myCarState.velocity field is updated from the previous velocity to the current velocity)

            myCarState.velocity = Physics1D.compute_velocity(myCarState.velocity, myCarState.accelation, dt);

            //'compute new position

            myCarState.position = Physics1D.compute_position(myCarState.position, myCarState.velocity, dt);

            //' update time data field

            myCarState.time = myCarState.time + dt;


        }



        //'???????? did i do this right, can i use getter to return an object??
        public State getstate()
        {
            return myCarState;
        }


        ///////////////implement inheritence

        public class Prius : Car //'defines that Prius class is derived from base class Car (Car is base class, Prius is derived class)
        {

            //'no arg aka default constructor for prius derived-class/subclass. Calls the parent/base noarg constructor
            public Prius() : base()
            {
                model = "Prius";
                mass = 1000;
                engineForce = 750;
                dragArea = 0.43;
            }

            //'constructor for prius derived-class/subclass
            //'???? not totally sure about naming for variables here, what do they have to match if anything?
            public Prius(string model, double mass, double engineForce, double dragArea) : base(model, mass, engineForce, dragArea)
            {

            }
        }



        public class Mazda3 : Car
        {
            public Mazda3() : base()
            {
                model = "Mazda3";
                mass = 1300;
                engineForce = 800;
                dragArea = 0.45;
            }
            public Mazda3(string model, double mass, double engineForce, double dragArea) : base(model, mass, engineForce, dragArea)
            {

            }
        }


        public class Tesla3 : Car
        {
            public Tesla3() : base()
            {
                model = "Tesla3";
                mass = 1500;
                engineForce = 1000;
                dragArea = 0.51;
            }
            public Tesla3(string model, double mass, double engineForce, double dragArea) : base(model, mass, engineForce, dragArea)
            {

            }
        }


        //'this car type has to override the drive function
        public class Herbie : Car
        {
            public Herbie() : base()
            {
                model = "Herbie";
                mass = 1000;
                engineForce = 1500;
                dragArea = 0.40;
            }
            public Herbie(string model, double mass, double engineForce, double dragArea) : base(model, mass, engineForce, dragArea)
            {

            }

            public override void drive(double dt) //'Q2 part 2, implement the function i want to override with the override keyword
            {

                //' set fd to 0 bc herbie can ignore air drag
                double fd = 0;
                double totalforce = engineForce - fd;
                myCarState.accelation = Physics1D.compute_acceleration(totalforce, mass);
                myCarState.velocity = Physics1D.compute_velocity(myCarState.velocity, myCarState.accelation, dt);
                myCarState.position = Physics1D.compute_position(myCarState.position, myCarState.velocity, dt);
                myCarState.time = myCarState.time + dt;
            }


        }




    }
}
    


    




     



    

