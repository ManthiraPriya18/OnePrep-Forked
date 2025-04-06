using ProblemSingleInheritance = ObjectOrientedProgramming._3.Inheritance.SingleInheritance.Problem;
using SolutionSingleInheritance = ObjectOrientedProgramming._3.Inheritance.SingleInheritance.Solution;
using ProblemMultiLevelInheritance = ObjectOrientedProgramming._3.Inheritance.MultilevelInheritance.Problem;
using SolutionMultiLevelInheritance = ObjectOrientedProgramming._3.Inheritance.MultilevelInheritance.Solution;
using ProblemHierarchicalInheritance = ObjectOrientedProgramming._3.Inheritance.HierarchicalInheritance.Problem;
using SolutionHierarchicalInheritance = ObjectOrientedProgramming._3.Inheritance.HierarchicalInheritance.Solution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectOrientedProgramming.Helpers.Common;
using ObjectOrientedProgramming._3.Inheritance.MultilevelInheritance.Solution;

namespace ObjectOrientedProgramming._3.Inheritance
{
    public class ExecuteInheritance
    {
        public void Run()
        {
            ExecuteSingleInheritance();
            ExecuteMultiLevelInheritance();
            ExecuteHierarchicalInheritance();
        }

        #region Single Inheritance
        public void ExecuteSingleInheritance()
        {
            Seperators.PrintProblemExecStartsSeperator();
            ExecuteSingleInheritanceProblem();
            Seperators.PrintProblemExecEndsSeperator();

            Seperators.PrintSolutionExecStartsSeperator();
            ExecuteSingleInheritanceSolution();
            Seperators.PrintSolutionExecEndsSeperator();

            Seperators.PrintSeperator();
            ExecuteSingleInheritanceAdditional();
            Seperators.PrintSeperator();
        }

        public void ExecuteSingleInheritanceProblem()
        {
            ProblemSingleInheritance.Dog dog = new ProblemSingleInheritance.Dog();
            dog.Bark(); // "Barking"

            //GetTotalPopulation will create an obj of Animal
            Console.WriteLine(dog.GetTotalPopulation()); //10000
        }

        public void ExecuteSingleInheritanceSolution()
        {
            SolutionSingleInheritance.Dog dog = new SolutionSingleInheritance.Dog(60);
            dog.Bark(); // "Barking"
            Console.WriteLine(dog.TotalAnimalPopulation);
        }

        public void ExecuteSingleInheritanceAdditional()
        {
            SolutionSingleInheritance.Dog dog = new SolutionSingleInheritance.Dog(60);
            SolutionSingleInheritance.Animal animal = new SolutionSingleInheritance.Dog(60);

            //AverageLifeSpan available in both class and not overrdided in Dog class
            Console.WriteLine(dog.AverageLifeSpan()); // Avergae Life Span of Dog is 12 years
            Console.WriteLine(animal.AverageLifeSpan()); // Avergae Life Span of Animal is 30 years

            // FavFood available in both class and it is overrided in Dog class
            Console.WriteLine(dog.FavFood()); //Dog FavFood is Biscuits
            Console.WriteLine(animal.FavFood()); // Dog FavFood is Biscuits

            //Since FavFood is overrided in Dog class, we cant invoke the FavFood in Animal class
            //For which we need to expose one function in Dog class which will call the base implementation
            Console.WriteLine(dog.BaseFavFood()); // Animal FavFood is Meat

            //AverageWeight available in both, Not overrided in Dog class, but AverageWeight Function in Dog class use 'new' keyword
            //Which will hide the implementation of the base class, hence we can call the base method by casting
            Console.WriteLine(dog.AverageWeight()); // Average Weight of Dog is 12Kg
            Console.WriteLine(animal.AverageWeight());// Average Weight of Animal is 40kg

            Console.WriteLine(((SolutionSingleInheritance.Animal)dog).AverageWeight()); // Average Weight of Animal is 40kg
            Console.WriteLine(((SolutionSingleInheritance.Dog)animal).AverageWeight()); // Average Weight of Dog is 12Kg

            //SpecificMethodInDog only available in Dog, Hence only Dog dog = new Dog() can access,
            //Animal animal = new Dog(), cant access Bcz animal will have Animal class reference & SpecificMethodInDog not available in Animal
            Console.WriteLine(dog.SpecificMethodInDog()); //This Method only available in Dog
            //Console.WriteLine(animal.SpecificMethodInDog()); // Uncomment this will throw error
        }

        #endregion

        #region Multilevel Inheritance
        public void ExecuteMultiLevelInheritance()
        {
            Seperators.PrintProblemExecStartsSeperator();
            ExecuteMultiLevelInheritanceProblem();
            Seperators.PrintProblemExecEndsSeperator();

            Seperators.PrintSolutionExecStartsSeperator();
            ExecuteMultiLevelInheritanceSolution();
            Seperators.PrintSolutionExecEndsSeperator();

            Seperators.PrintSeperator();
            ExecuteMultiLevelInheritanceAdditional();
            Seperators.PrintSeperator();
        }

        public void ExecuteMultiLevelInheritanceProblem()
        {
            // Though this works, It will lead to lot of duplicate code, If the classes are related & not used inheritance
            ProblemMultiLevelInheritance.Employee employee = new ProblemMultiLevelInheritance.Employee();
            employee.AttendMeeting(); //General meeting...

            ProblemMultiLevelInheritance.BackendEngineer backendEngineer = new ProblemMultiLevelInheritance.BackendEngineer();
            employee.AttendMeeting(); // General meeting...
        }
        public void ExecuteMultiLevelInheritanceSolution()
        {
            SolutionMultiLevelInheritance.BackendEngineer backendEngineer = new SolutionMultiLevelInheritance.BackendEngineer();

            Employee employeeRef = backendEngineer;
            Engineer engineerRef = backendEngineer;

            // Since AttendMeeting declared as new, Each of the Classes can get its own implementation & via cast we can call the respective class
            employeeRef.AttendMeeting(); //Employee: Attend general meetings
            engineerRef.AttendMeeting(); //Engineer: Attend sprint meetings
        }
        public void ExecuteMultiLevelInheritanceAdditional()
        {
            SolutionMultiLevelInheritance.BackendEngineer backendEngineer = new SolutionMultiLevelInheritance.BackendEngineer();

            Employee employeeRef = backendEngineer;
            Engineer engineerRef = backendEngineer;

            // Since AttendMeeting declared as new, Each of the Classes can get its own implementation & via cast we can call the respective class
            employeeRef.AttendMeeting(); //Employee: Attend general meetings
            engineerRef.AttendMeeting(); //Engineer: Attend sprint meetings
            backendEngineer.AttendMeeting(); //BackendEngineer: Backend architecture sync
            ((SolutionMultiLevelInheritance.Engineer)backendEngineer).AttendMeeting(); //Engineer: Attend sprint meetings
            ((SolutionMultiLevelInheritance.BackendEngineer)engineerRef).AttendMeeting(); ////BackendEngineer: Backend architecture sync

            // Since DailyStandup is override & sealed in Enginner, It cannot be override in BackendEngineer, and when we actually try for Employee, 
            // Still we will receive the implementation in Enginner
            employeeRef.DailyStandup(); //Engineer: Attends with scrum team
            engineerRef.DailyStandup(); //Engineer: Attends with scrum team
            backendEngineer.DailyStandup(); //Engineer: Attends with scrum team

            //Role was defined as Virtual in Employee, and overrided in Engineer, and as new in BackendEngineer
            //Hence only in BackendEngineer class it will have its own implementation & it hides the Role implementation of base class, So from 
            // BackendEngineer we can call the base role
            Console.WriteLine(employeeRef.Role()); //Engineer
            Console.WriteLine(engineerRef.Role()); //Engineer
            Console.WriteLine(((Employee)engineerRef).Role()); //Engineer
            Console.WriteLine(backendEngineer.Role()); //Backend Engineer
            Console.WriteLine(((Employee)backendEngineer).Role()); //Engineer

        }
        #endregion

        #region Hierarchical Inheritance
        public void ExecuteHierarchicalInheritance()
        {
            Seperators.PrintProblemExecStartsSeperator();
            ExecuteHierarchicalInheritanceProblem();
            Seperators.PrintProblemExecEndsSeperator();

            Seperators.PrintSolutionExecStartsSeperator();
            ExecuteHierarchicalInheritanceSolution();
            Seperators.PrintSolutionExecEndsSeperator();

        }

        public void ExecuteHierarchicalInheritanceProblem()
        {
            string Title = "Enlightment";
            string Author = "Krishna";
            ProblemHierarchicalInheritance.VideoContent videoContent = new ProblemHierarchicalInheritance.VideoContent(Title,Author);
            ProblemHierarchicalInheritance.ArticleContent articleContent = new ProblemHierarchicalInheritance.ArticleContent(Title,Author);
            ProblemHierarchicalInheritance.PodcastContent podcastContent = new ProblemHierarchicalInheritance.PodcastContent(Title,Author);

            videoContent.Publish();       // Specific    
            videoContent.PlayVideo();     // Specific

            articleContent.Publish();     // Specific
            articleContent.ReadArticle(); // Specific

            podcastContent.Publish();     // Specific
            podcastContent.StreamAudio(); // Specific
        }
        public void ExecuteHierarchicalInheritanceSolution()
        {
            string Title = "Enlightment";
            string Author = "Krishna";
            SolutionHierarchicalInheritance.VideoContent videoContent = new SolutionHierarchicalInheritance.VideoContent(Author,Title);
            videoContent.Publish();         // Inherited
            videoContent.PlayVideo();       // Specific

            SolutionHierarchicalInheritance.ArticleContent articleContent = new SolutionHierarchicalInheritance.ArticleContent(Author, Title);
            articleContent.Publish();       // Inherited
            articleContent.ReadArticle();   // Specific

            SolutionHierarchicalInheritance.PodcastContent podcastContent = new SolutionHierarchicalInheritance.PodcastContent(Author, Title);
            podcastContent.Publish();       // Inherited
            podcastContent.StreamAudio();   // Specific

        }
        
        #endregion
    }
}
