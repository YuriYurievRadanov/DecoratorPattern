using System;

namespace Decorator
{
    class Program
    {
        // Component
        abstract class Arms
        {
            public string Name;
            public abstract void Fire();
        }

        // ConcreteComponent
        class Artillery : Arms
        {
            protected double _barrel;
            protected double _range;

            public Artillery(double barrel, double range, string name)
            {
                _barrel = barrel;
                _range = range;
                Name = name;
            }

            public override void Fire()
            {
                Console.WriteLine("Artillery from class {0} fired at distance {2} from barrel {1} mm", Name, _barrel.ToString(), _range.ToString());
            }
        }

        // Decorator
        abstract class ArmsDecorator : Arms
        {
            protected Arms _arms;
            public ArmsDecorator(Arms arms)
            {
                _arms = arms;
            }
            public override void Fire()
            {
                if (_arms != null)
                    _arms.Fire();
            }
        }

        // ConcreteDecorator
        class ArtilleryDecorator : ArmsDecorator
        {
            public ArtilleryDecorator(Arms arms) : base(arms)
            {
            }

            public void Defense()
            {
                Console.WriteLine("\t{0} Defense Mode!", base._arms.Name);
            }
            public void Easy()
            {
                Console.WriteLine("\t{0} Fire mode!", _arms.Name);
            }
            public override void Fire()
            {
                base.Fire();
            }
        }

        static void Main(string[] args)
        {
            Artillery artillery = new Artillery(125, 40, "Storm A1");
            artillery.Fire();

            //Decorator object is instantiated
            ArtilleryDecorator artilleryDecorator = new ArtilleryDecorator(artillery);

            artilleryDecorator.Defense();
            artilleryDecorator.Fire();
            artilleryDecorator.Easy();
            artilleryDecorator.Fire();
        }
    }
}
