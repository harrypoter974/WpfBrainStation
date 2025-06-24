using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CL.BS.GameManager.Engen
{
    class MapEngen
    {
        private int[] _soldiers;
        private List<int[]> _point;

        internal void SetStep(int soldier, int stepNum)
        {
            _soldiers[soldier] += stepNum;
        }

        internal void Refresh()
        {
            _soldiers = new int[] { 0, 0, 0, 0 };
            _point = new List<int[]>();
            System.IO.StreamReader file = new System.IO.StreamReader(@"Resources\Game\Map.txt");
            string line;
            while ((line = file.ReadLine()) != null)
            {
                string[] s = line.Split(' ');
                if (s.Length <= 1)
                    continue;
                int x = (int)(double.Parse(s[1]) *System.Windows.SystemParameters.PrimaryScreenWidth*0.645);//0. 225
                int y = (int)(double.Parse(s[2]) * System.Windows.SystemParameters.PrimaryScreenHeight*0.646);//0.61
                _point.Add(new int[] { x, y });
            }
            file.Close();
        }

        internal string[] GetSoldiersLocation()
        {
            string[] locatin = new string[4];
            for (int i = 0; i < locatin.Length; i++)
            {
                int step = _soldiers[i] >= _point.Count() ? _point.Count() - 1:_soldiers[i];
                locatin[i] =( _point[step][0]+i*4) + "," + _point[step][1] + ",0,0";
            }
            return locatin;
        }
    }
}
