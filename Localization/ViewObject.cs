using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CL.BS.VMCommon
{
    public class ViewObject
    {
        public string Uid { get; set; }
        public string Text { get; set; }
        public string Background { get; set; }
        public Visibility visibility { get; set; }
        public int Width { get; set; }
        public int FontSize { get; set; }
        public bool IsQuestionMode { get; set; }

        public ViewObject Duplicate()
        {
            return new ViewObject()
            {
                Uid = this.Uid,
                Text = this.Text,
                Background = this.Background,
                visibility = this.visibility,
                Width=this.Width,
                FontSize = this.FontSize,
                IsQuestionMode = this.IsQuestionMode
            };
        }
    }
}
