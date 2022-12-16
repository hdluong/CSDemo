using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.BehavioralPatterns.StrategyPattern.Demo2.ConcreteExports
{
    public class PDFExport : IExport
    {
        public void ExportFile(string fileName)
        {
            Console.WriteLine($"Export file {fileName}.PDF suscessfully!");
        }
    }
}
