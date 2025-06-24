using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.MEF
{
 internal   class ExportService
    {
        public static IEnumerable<T> GetExportedValues<T>()
        {
            var catalog = new AggregateCatalog();
            string currentDirectory = Directory.GetCurrentDirectory();
            catalog.Catalogs.Add(new DirectoryCatalog(currentDirectory));

            var container = new CompositionContainer(catalog);

            container.ComposeParts();
            return container.GetExportedValues<T>();
        }
    }
}
