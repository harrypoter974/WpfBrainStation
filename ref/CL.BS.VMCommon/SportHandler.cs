using CL.BS.Contract;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.VMCommon
{
   public class SportHandler : IPartImportsSatisfiedNotification
    {

        #region MEF
        [ImportMany(typeof(IPageVM))]
        private List<IPageVM> _support;
        #endregion MEF
        public const string HOME_PAGE = "MenuOpenVM";
        public SportHandler()
        {
            MEFSection();
        }

        #region MEF section

        private CompositionContainer _container;


        private void MEFSection()
        {
            var catalog = new AggregateCatalog();
            string currentDirectory = Directory.GetCurrentDirectory();
            catalog.Catalogs.Add(new DirectoryCatalog(currentDirectory));

            _container = new CompositionContainer(catalog);

            this._container.ComposeParts();
            _container.SatisfyImportsOnce(this);
            foreach (var item in _support)
            {
                System.Console.WriteLine("Name: " + item.Name);
            }
        }


        public void OnImportsSatisfied()
        {
            Console.WriteLine();
            Console.WriteLine("----- Finished compose exports-imports -----------");
            foreach (var part in ((AggregateCatalog)_container.Catalog).Parts)
            {
                Console.WriteLine(part.ToString() + " imported");
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        #endregion MEF - Finished Compose
        public IPageVM GetGame(string input)
        {
            return _support.FirstOrDefault(s => s.Name == input);
        }
    }
}
