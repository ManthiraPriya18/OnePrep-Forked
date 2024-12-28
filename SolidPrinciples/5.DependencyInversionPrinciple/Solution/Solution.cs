using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples._5.DependencyInversionPrinciple.Solution
{
    /*
        Here the Higher level class Switch doesnt depends on lower level class (Fan , LightBulb).
        Instead both Higher level class and lower level class both depends on interface.
     */
    public class Switch
    {
        private readonly IDevice _device;

        public Switch(IDevice device)
        {
            _device = device;
        }

        public void TurnOn()
        {
            _device.TurnOn();
        }
        public void TurnOff()
        {
            _device.TurnOff();
        }
    }

    public class LightBulb : IDevice
    {

        public void TurnOff()
        {
            Console.WriteLine("Turning Off Light Bulb");
        }

        public void TurnOn()
        {
            Console.WriteLine("Turning On Light Bulb");
        }
    }

    public class Fan : IDevice
    {
        public void TurnOff()
        {
            Console.WriteLine("Turning Off Fan");
        }

        public void TurnOn()
        {
            Console.WriteLine("Turning On Fan");
        }
    }
}
