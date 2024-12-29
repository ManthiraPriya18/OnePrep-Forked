using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples._3.LiskovSubsitutionPrinciple.Solution
{
    public interface IDataExporter
    {
        bool CanExport(string data);
        void ExportData(string data);
    }

    public interface IDataExporterHelper
    {
        bool ValidateData(string data);
    }

   
}
