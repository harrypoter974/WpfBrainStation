using CL.BS.Contract;
using CL.BS.MEF;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace CL.BS.VMCommon
{
   public class GameHandler : IPartImportsSatisfiedNotification
    {
        public const string HOME_PAGE = "MenuOpenVM";
        private static Task _task;
        private static GameHandler _logic;
        private static bool _isNotUplode = true;

        private GameHandler()
        {
            _task = new Task(MEFSection);
            _task.Start();
        }

        public static GameHandler GetIntense()
        {
            if (_isNotUplode)
            {
                _isNotUplode = false;
                _logic = new GameHandler();
            }
            else
            {
                try
                {
                    _task.Wait();
                }
                catch (Exception e)
                {
                    Common.GlobalLog.Write(e.ToString());

                }
            }
            return _logic;
        }

        public IPageVM GetGame(string input)
        {
            return _support.FirstOrDefault(s => s.Name == input);
        }

        #region MEF
        [ImportMany(typeof(IPageVM))]
        private List<IPageVM> _support;
        #endregion MEF

        #region MEF section

        private CompositionContainer _container;


        private void MEFSection()
        {

          //  Database.DatabaseManager.Inline.GetAllUser();
            var catalog = new AggregateCatalog();
            string currentDirectory =
        //System.Environment.GetFolderPath(
        //    System.Environment.SpecialFolder.ProgramFilesX86)+ "\\BrainStation";
        System.AppDomain.CurrentDomain.BaseDirectory;        //Directory.GetCurrentDirectory();
            Common.GlobalLog.Write("Time MEF dll :"+ currentDirectory);
            catalog.Catalogs.Add(new DirectoryCatalog(currentDirectory));
         
            _container = new CompositionContainer(catalog);
            this._container.ComposeParts();
            _container.SatisfyImportsOnce(this);
            Common.GlobalLog.Write("End MEF dll");
            foreach (var item in _support)
            {
                System.Console.WriteLine("Name: " + item.Name);
            }
            foreach (var app in ServerExternalGame.Ins.GetPlugin())
            {
                // Take the View from the Plugin and Merge it with,
                // our Applications Resource Dictionary.
                Application.Current.Resources.MergedDictionaries.Add(app.View);

                _support.Add(app.ViewModel);
            }
        }

        internal void WreteClassCaunt()
        {
            Common.GlobalLog.Write("WreteClassCaunt"+_container.Catalog.Count());  
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
        }

        #endregion MEF - Finished Compose
    }
}
