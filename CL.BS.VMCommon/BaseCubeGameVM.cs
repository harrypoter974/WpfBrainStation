using CL.BS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CL.BS.VMCommon
{
    public class BaseCubeGameVM : BaseAutoGameVM
    {
        public string VisibilityCube0 { get { return VisibilityCubeList[0].Background; } set { VisibilityCubeList[0].Background = value; } }
        public string VisibilityCube1 { get { return VisibilityCubeList[1].Background; } set { VisibilityCubeList[1].Background = value; } }
        public string VisibilityCube2 { get { return VisibilityCubeList[2].Background; } set { VisibilityCubeList[2].Background = value; } }
        public string VisibilityCube3 { get { return VisibilityCubeList[3].Background; } set { VisibilityCubeList[3].Background = value; } }
         public int SoldierX0 { get { return SoldierList[0].Width; } set { SoldierList[0].Width = value; } }
        public int SoldierX1 { get { return SoldierList[1].Width; } set { SoldierList[1].Width = value; } }
        public int SoldierX2 { get { return SoldierList[2].Width; } set { SoldierList[2].Width = value; } }
        public int SoldierX3 { get { return SoldierList[3].Width; } set { SoldierList[3].Width = value; } }

        public int SoldierY0 { get { return SoldierList[0].FontSize; } set { SoldierList[0].FontSize = value; } }
        public int SoldierY1 { get { return SoldierList[1].FontSize; } set { SoldierList[1].FontSize = value; } }
        public int SoldierY2 { get { return SoldierList[2].FontSize; } set { SoldierList[2].FontSize = value; } }
        public int SoldierY3 { get { return SoldierList[3].FontSize; } set { SoldierList[3].FontSize = value; } }
        public string Border0 { get { return SoldierList[0].Background; } set { SoldierList[0].Background = value; } }
        public string Border1 { get { return SoldierList[1].Background; } set { SoldierList[1].Background = value; } }
        public string Border2 { get { return SoldierList[2].Background; } set { SoldierList[2].Background = value; } }
        public string Border3 { get { return SoldierList[3].Background; } set { SoldierList[3].Background = value; } }
        public Visibility QuestionVisible0 { get { return SoldierList[0].visibility; } set { SoldierList[0].visibility = value; } }
        public Visibility QuestionVisible1 { get { return SoldierList[1].visibility; } set { SoldierList[1].visibility = value; } }
        public Visibility QuestionVisible2 { get { return SoldierList[2].visibility; } set { SoldierList[2].visibility = value; } }
        public Visibility QuestionVisible3 { get { return SoldierList[3].visibility; } set { SoldierList[3].visibility = value; } }

        public string StepNum0 { get; set; }
        public string StepNum1 { get; set; }
        public string QuestionText { get; set; }
        public int TextAngle { get; set; }
        public string QuestionVisible { get; set; }
        protected Random Ran = new Random(DateTime.Now.Millisecond);
        protected int Soldier = 0, TurnInxex=0;
        protected int[] SoldierTurn = new int[] { 3, 2, 0, 1 };
        protected bool IsQuestion = false, IsStartGame = true;
        protected List<GameObject> Question;
        protected int[] SoldierIndex = new int[] { 0, 0, 0, 0 };
        protected int[] StartSum ;
        protected SoldierObject[] VisibilityCubeList = new SoldierObject[4];
        protected LetterObject[] SoldierList = new LetterObject[4];
        public ICommand NextStep { get; set; }
        public ICommand TapAnswer { get; set; }
        public override string Name => "";
        public BaseCubeGameVM()
        {
            for (int i = 0; i < VisibilityCubeList.Length; i++)
            {
                SoldierList[i] = new LetterObject()
                {
                    Background =
 System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\BS.Items\redBorder.png"
               ,visibility=Visibility.Collapsed };
                VisibilityCubeList[i] = new SoldierObject() { Background = "Visible" };
            }
        }

        protected void NextPlayer()
        {
            do
            {
                Soldier = Soldier == 3 ?  0: Soldier + 1;
            } while (PlayerBut[Soldier].LineVisible == System.Windows.Visibility.Hidden);
        }
        protected void NextTurn()
        {
            TurnInxex = TurnInxex ==PlayerIndex  ? 0 : TurnInxex + 1;
            Soldier = SoldierTurn[TurnInxex];
        }

        
    }
}
