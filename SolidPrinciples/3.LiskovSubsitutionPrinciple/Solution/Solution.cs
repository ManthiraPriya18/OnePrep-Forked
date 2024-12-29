using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples._3.LiskovSubsitutionPrinciple.Solution
{
    /*
        Since there is inheritance between DataExporter class and CSVExported, PDFExporter etc in problem, and the derived class is not a proper
        subsitute for base class, here we removed the overriden methods and created a common interface which will be extends for all the exporters.
        And the common method is injected as Dependecy injection

     */
    public class CSVExporter :  IDataExporter
    {
        private IDataExporterHelper _dataExporterHelper;
        public CSVExporter(IDataExporterHelper dataExporterHelper) 
        { 
            _dataExporterHelper = dataExporterHelper;
        }
        public bool CanExport(string data)
        {
            if(!_dataExporterHelper.ValidateData(data))
            {
                Console.WriteLine("Cannot export since the data is corrupted");
                return false;
            }
            return true;
        }

        public void ExportData(string data)
        {
            Console.WriteLine("Exporting the data into CSV");
        }
    }
    public class PDFExporter :  IDataExporter
    {
        private IDataExporterHelper _dataExporterHelper;
        public PDFExporter(IDataExporterHelper dataExporterHelper)
        {
            _dataExporterHelper = dataExporterHelper;
        }
        public bool CanExport(string data)
        {
            if (!_dataExporterHelper.ValidateData(data))
            {
                Console.WriteLine("Cannot export since the data is corrupted");
                return false;
            }
            return (data.Length <= 5);
        }

        public void ExportData(string data)
        {
            if(!CanExport(data))
            {
                Console.WriteLine("Cannot export data when length is greater than 5");
                throw new NotSupportedException("Cannot export data when length is greater than 5");
            }
            Console.WriteLine("Exporting the data into PDF");
        }
    }
    public class ExcelExporter :  IDataExporter
    {
        private IDataExporterHelper _dataExporterHelper;
        public ExcelExporter(IDataExporterHelper dataExporterHelper)
        {
            _dataExporterHelper = dataExporterHelper;
        }
        public bool CanExport(string data)
        {
            if (!_dataExporterHelper.ValidateData(data))
            {
                Console.WriteLine("Cannot export since the data is corrupted");
                return false;
            }
            return HasExcelViewerInstalled();
        }

        public void ExportData(string data)
        {
            if(!HasExcelViewerInstalled())
            {
                Console.WriteLine("Cannot export data when Excel viewer is not installed");
                throw new NotSupportedException("Cannot export data when Excel viewer is not installed");
            }
            Console.WriteLine("Exporting the data into Excel");
        }

        public bool HasExcelViewerInstalled()
        {
            return false;
        }
    }
    public class DataExporterHelper : IDataExporterHelper
    {
        public  bool ValidateData(string data)
        {
            // Assume that the data is proper
            return true;
        }
    }


}
