using DesignPattern.BehavioralPatterns.StrategyPattern.Demo2.ConcreteExports;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.BehavioralPatterns.StrategyPattern.Demo2
{
    class Client
    {
        public static void Main(string[] args)
        {
            var exportContext = new ExportContext(new JPGExport());
            exportContext.CreateArchive("Banana");
            exportContext.Export = new PDFExport();
            exportContext.CreateArchive("Banana");
            exportContext.Export = new PNGExport();
            exportContext.CreateArchive("Banana");
        }
    }
}
