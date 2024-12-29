using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples._3.LiskovSubsitutionPrinciple.Problem
{
    /*
        Here we are having a Base class - DataExporter, and derived class CSVExporter, ExcelExporter, ExcelExporter.
        In the dervived class we are using the base class method ValidateData to check if data corrupted and then export.
        The problem is the derived class will give its own implementation for exporting the data & in few scenarios it will throw error.
        Check in ExecuteLSP.RunProblem how are we executing.
        Since we established the inheritance, If the derived class is replaced with base class, then it should act as a subsitute and the
        behaviour should not change.
        Ideally the base class should be able to subsitute the devired class and vice versa, If it not happening, Then we are violating LSP.
     */

    public class DataExporter
    {
        public virtual bool ExportData(string data)
        {
            Console.WriteLine("Exporting the data");
            return true;
        }
        public virtual bool ValidateData(string data)
        {
            // Assume that the data is proper
            return true;
        }
    }
    public class CSVExporter : DataExporter
    {
        public override bool ExportData(string data)
        {
            // Using the base class Method to validate
            if(!ValidateData(data))
            {
                Console.WriteLine("Cannot export since the data is corrupted");
                return false ;
            }

            // Assume that we are having export logic below
            Console.WriteLine("Exporting data in CSV format is successful");
            return true;
        }
    }
    public class PDFExporter : DataExporter
    {
        public override bool ExportData(string data)
        {
            // Using the base class Method to validate
            if (!ValidateData(data))
            {
                Console.WriteLine("Cannot export since the data is corrupted");
                return false;
            }

            if (data.Length > 5)
            {
                Console.WriteLine("Cannot export data when length is greater than 5");
                throw new NotSupportedException("Cannot export data when length is greater than 5");
            }
            // Assume that we are having export logic below

            return true;
        }
    }

    public class ExcelExporter : DataExporter
    {
        public override bool ExportData(string data)
        {
            // Using the base class Method to validate
            if (!ValidateData(data))
            {
                Console.WriteLine("Cannot export since the data is corrupted");
                return false;
            }
            if (!HasExcelViewerInstalled())
            {
                Console.WriteLine("Cannot export data when Excel viewer is not installed");
                throw new NotSupportedException("Cannot export data when Excel viewer is not installed");
            }
            // Assume that we are having export logic below

            return true;
        }

        public bool HasExcelViewerInstalled()
        {
            return false;
        }
    }
}
