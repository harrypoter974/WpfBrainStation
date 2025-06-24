using CL.BS.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.MEF
{
    public class ServerExternalGame
    {
        private static ServerExternalGame _ins;
        public IPageVM CurGame { get; set; }
        public Action<IPageVM> OpenGame { get; set; }

        private ServerExternalGame()
        {
        }

        public static ServerExternalGame Ins
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new ServerExternalGame();
                }
                return _ins;
            }
        }

        public List<IBasePlugin> GetPlugin()
        {
            return ExportService.GetExportedValues<IBasePlugin>().ToList();
        }

        public void ChooseGame(IPageVM game)
        {
            CurGame = game;
            OpenGame(game);
        }
    }
}