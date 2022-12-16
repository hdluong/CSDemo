using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.BehavioralPatterns.StrategyPattern.Demo2
{
    public class ExportContext
    {
        private IExport _export;
        public IExport Export 
        {
            get { return _export; }
            set { _export = value; }
        }

        public ExportContext(IExport export)
        {
            Export = export;
        }

        public void CreateArchive(string fileName)
        {
            Export.ExportFile(fileName);
        }
    }
}
