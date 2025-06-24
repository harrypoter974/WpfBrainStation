using CL.BS.Contract;
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
  public  class SupportHandlerManager : IPartImportsSatisfiedNotification
    {
        public const string HOME_PAGE = "MenuOpenVM";
        public static SupportHandlerManager Base = new SupportHandlerManager();

        private SupportHandlerManager()
        {
            MEFSection();
        }

        public IManager GetManager(string input)
        {
            return _support.FirstOrDefault(s => s.ManagerName == input);
        }

        #region MEF
        [ImportMany(typeof(IManager))]
        private List<IManager> _support;
        #endregion MEF
        
        #region MEF section

        private CompositionContainer _container;


        private void MEFSection()
        {
            var catalog = new AggregateCatalog();
            string currentDirectory =
                //System.Environment.GetFolderPath(System.Environment.SpecialFolder.ProgramFilesX86) + "\\BrainStation";
                System.AppDomain.CurrentDomain.BaseDirectory;     //Directory.GetCurrentDirectory(); Directory.GetCurrentDirectory();
            catalog.Catalogs.Add(new DirectoryCatalog(currentDirectory));

            _container = new CompositionContainer(catalog);

            this._container.ComposeParts();
            _container.SatisfyImportsOnce(this);
            foreach (var item in _support)
            {
                System.Console.WriteLine("Name: " + item.ManagerName);
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
      
    }
}
