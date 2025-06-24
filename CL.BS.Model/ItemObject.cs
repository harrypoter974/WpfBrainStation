using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CL.BS.Model
{
    public class ItemObject
    {
        public Visibility ItemsVisible { get; set; }
        public bool IsHideLine { get; set; }
        public string Button { get; set; }
        public Visibility LineVisible { get; set; }
        public string Background { get; set; }
        public string Uid { get; set; }

        public ItemObject Duplicate()
        {
            return new ItemObject()
            {
                ItemsVisible = this.ItemsVisible,
                IsHideLine = this.IsHideLine,
                Button = this.Button,
                Background = this.Background,
                LineVisible = this.LineVisible
            };
        }
    }
}
