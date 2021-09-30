using System;

namespace CarSimulator
{
    class Program
    {

        
        static void Main(string[] args)
        {
            

            // read in car mass
            Console.WriteLine("Enter the mass of the car (kg): ");
            double mass;
            mass = Convert.ToDouble(Console.ReadLine());

            // read in engine force
            Console.WriteLine("Enter the net force of the engine (N): ");
            double engine_force;
            engine_force = Convert.ToDouble(Console.ReadLine());

            // read in drag area
            Console.WriteLine("Enter the car's drag area (m^2): ");
            double drag_area;
            drag_area = Convert.ToDouble(Console.ReadLine());

            // read in time step
            Console.WriteLine("Enter the simulation time step (s): ");
            double dt;
            dt = Convert.ToDouble(Console.ReadLine());

            // read in total number of simulation steps
            Console.WriteLine("Enter the number of time steps (int): ");
            int N;
            N = Convert.ToInt32(Console.ReadLine());

            // initialize the car's state
            double x0 = 0;  // initial position
            double v = 0;  // initial velocity
            double t = 0;  // initial time
            double fd, x1, a; // drag force and secondary position and acceleration


            
             //'declare and initialize dedicated initial velocity variable
            double v0 = 0;

            //'declare and initialize total force variable
            double totalforce = 0;



            // run the simulation
            for (int i = 0; i < N; ++i)
            {
                // TODO: COMPUTE UPDATED STATE HERE


                //'first compute drag force

                fd = 0.5 * 1.225 * drag_area * v0;

                //'compute total force on car

                totalforce = engine_force - fd;

                //'compute acceleration

                a = Physics1D.compute_acceleration(totalforce, mass);

                //'compute velocity

                v = Physics1D.compute_velocity(v0, a, dt);

                //'compute new position

                x1 = Physics1D.compute_position(x0, v, dt);

                
                //'update dedicated initial position and initial velocity variables
                x0 = x1;
                v0 = v;



                t += dt;  // increment time

                // print the time and current state
                Console.WriteLine("t:{0}, a:{1}, v:{2}, x1:{3}, fd:{4} ", t, a, v, x1, fd);
            }

        
            
        }

        
    }
}
