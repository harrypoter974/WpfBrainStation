using CL.BS.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CL.BS.Model;

namespace CL.BS.GameManager.Interface
{
    public interface IQuartets_manager : IManager
    {
        List<string>[] NewGame(string subject, int numbPlayers);
        string GetCard();
    }
}
