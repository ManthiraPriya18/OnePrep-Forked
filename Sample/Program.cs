namespace Sample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Parent parent = new Parent();
            parent.Print();

            Child child = new Child();
            child.Print();

            Parent parent1 = new Child();
            parent1.Print();
            parent1.OnlyParent();
            
            //Child parent2 = new Parent();
        }

    }

    public class Parent
    {
        public virtual void Print()
        {
            Console.WriteLine("Parent");
        }

        public void OnlyParent()
        {
            Console.WriteLine("Only Parent");
        }
    }
    public class Child : Parent
    {
        public override void Print()
        {
            Console.WriteLine("Child");
        }
        public void OnlyChild()
        {
            Console.WriteLine("Only Parent");
        }

    }
}
