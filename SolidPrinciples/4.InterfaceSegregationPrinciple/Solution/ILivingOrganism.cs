using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples._4.InterfaceSegregationPrinciple.Solution
{
    public interface IFlyingOrganism
    {
        void Fly();
    }
    public interface IWalkingOrganism
    {
        void Walk();
    }
    public interface ISwimmingOrganism
    {
        void Swim();
    }

    public interface IBird : IFlyingOrganism, IWalkingOrganism
    {

    }
    public interface IFish : ISwimmingOrganism
    {

    }

}
