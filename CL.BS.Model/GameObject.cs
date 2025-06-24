using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CL.BS.Model
{
  public  class GameObject
    {
        public string Uid { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public Visibility BlinkCell { get; set; }
        public int Width { get; set; }

        public GameObject Duplicate()
        {
            return new GameObject()
            {
                Uid = this.Uid,
                Question = this.Question,
                Answer = this.Answer,
                BlinkCell = this.BlinkCell,
                Width = this.Width,
            };
        }
    }
}
