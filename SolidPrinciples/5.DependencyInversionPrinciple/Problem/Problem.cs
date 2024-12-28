using SolidPrinciples._5.DependencyInversionPrinciple.Solution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples._5.DependencyInversionPrinciple.Problem
{
    /*
        Here the class Switch (Higer level class), Is depends on lower level class (LightBulb, Fan)
        The Object creation of lower level modules is tightly copuled with the higer level module,
        In future if any change in lower level module, Then there is going to be change in higer level module as well.
     */


    public class Switch
    {
        private LightBulb _bulb = new LightBulb(); // Direct dependency
        private Fan _fan = new Fan(); // Direct dependency

        public void TurnOnAndOffBulb()
        {
            _bulb.TurnOn();
            _bulb.TurnOff();
        }
        public void TurnOnAndOffFan()
        {
            _fan.TurnOn();
            _fan.TurnOff();
        }
    }

    public class LightBulb
    {
        public void TurnOn()
        {
            Console.WriteLine("Turning On Light Bulb");
        }
        public void TurnOff()
        {
            Console.WriteLine("Turning Off Light Bulb");
        }
    }
    public class Fan
    {
        public void TurnOn()
        {
            Console.WriteLine("Turning On Fan");
        }
        public void TurnOff()
        {
            Console.WriteLine("Turning Off Fan");
        }
    }


}
