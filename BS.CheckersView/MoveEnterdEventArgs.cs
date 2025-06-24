using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.CheckersView
{
    public class MoveEnterdEventArgs : EventArgs
    {
        private Point m_From = new Point();
        private Point m_To = new Point();

        public MoveEnterdEventArgs(Point i_From, Point i_To)
        {
            m_From = i_From;
            m_To = i_To;
        }

        public Point From
        {
            get
            {
                return m_From;
            }
        }

        public Point To
        {
            get
            {
                return m_To;
            }
        }
    }
}
