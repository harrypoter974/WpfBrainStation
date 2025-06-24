using CL.BS.Contract;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace CL.BS.NotionsVM.VM.Gardens
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class MusicalLnstrumentsVM : BaseItemPage, IPageVM
    {
        private string[] _musicName = new string[] { "piano", "harp", "mandoline",
            "cello", "guitar", "Violin"  , "harmonica", "accordion"
            , "Flute", "trumpet", "xylophone", "drum" };
        string[] _lan = new string[] { "He", "En", "Ar" };
        public override string Name =>nameof(MusicalLnstrumentsVM) ;

        public MusicalLnstrumentsVM()
        {
            ShowItem = new RelayCommand(DoShowFruit);
        }

        void IPageVM.load()
        {
            ListWordVisible();
        }

        private void DoShowFruit(object obj)
        {
            lock (this)
            {
                //if (Common.StaticVar.PlayMode)
                //    return;
                new Thread(new ThreadStart(() =>
            {
                int music = int.Parse(obj.ToString());
                Common.StaticVar.PlayMode = false;
                WhitAntilPlayStop(ref Common.StaticVar.PlayMode);
                Items[music].ItemsVisible = Visibility.Hidden;
                NotifyPropertyChanged("Item" + music);
                for (int l = 0; l < 3; l++)
                {
                    if (LanguageBut[l].Background.Contains("AnimalStitle"))
                    {
                        PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\Audio\" + _lan[l]
                    + @"\MusicalLnstruments\" +
                    _musicName[music].Replace("\u0095", string.Empty) + ".wav");  //                
                        WhitAntilPlayStop(ref Common.StaticVar.PlayMode);
                    }
                }
                WhitAntilPlayStop(ref Common.StaticVar.PlayMode);
                PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\Audio\He\Music\" +
                    _musicName[music].Replace("\u0095", string.Empty) + ".wav");
            })).Start();
            }
        }
    }
}
