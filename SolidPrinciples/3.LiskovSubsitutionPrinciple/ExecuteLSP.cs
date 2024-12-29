using SolidPrinciples._3.LiskovSubsitutionPrinciple.Problem;
using SolidPrinciples._3.LiskovSubsitutionPrinciple.Solution;
using SolidPrinciples.Helpers.Common;
using SolidPrinciples.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples._3.LiskovSubsitutionPrinciple
{
    internal class ExecuteLSP : IExecute
    {
        public void Run()
        {
            Seperators.PrintProblemExecStartsSeperator();
            RunProblem();
            Seperators.PrintProblemExecEndsSeperator();
            Seperators.PrintSolutionExecStartsSeperator();
            RunSolution();
            Seperators.PrintSolutionExecEndsSeperator();
        }

        public void RunProblem()
        {
            string reportData = "Some report data...";
            var exporters = new List<DataExporter>
            {
                new Problem.PDFExporter(),
                new Problem.ExcelExporter(),
                new Problem.CSVExporter()
            };
            for(int i = 0; i < exporters.Count; i++)
            {
                var exporter = exporters[i];
                try
                {
                    // This will work for CSV Exporter, But for PDF & Excel, It will throw error
                    // The behavior of base class (DataExporter) is changed by its dervied class (PDFExporter,ExcelExporter)
                    exporter.ExportData(reportData);
                }
                catch(Exception ex) 
                {
                    Console.WriteLine(ex.ToString());   
                }
            }
        }

        public void RunSolution()
        {
            string reportData = "Some report data...";
            IDataExporterHelper dataExporterHelper = new DataExporterHelper();
            var exporters = new List<IDataExporter>
            {
                new Solution.CSVExporter(dataExporterHelper),
                new Solution.PDFExporter(dataExporterHelper),
                new Solution.ExcelExporter(dataExporterHelper)
            };
            for (int i = 0; i < exporters.Count; i++)
            {
                var exporter = exporters[i];
                // Since it is now depending on interface, we can create a method which is pre requiste for the exporting
                if (exporter.CanExport(reportData))
                {
                    exporter.ExportData(reportData);
                }
                else
                {
                    Console.WriteLine("Selected exporter cannot handle this data");
                }
            }
        }
    }
}
