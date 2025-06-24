using CL.BS.MEF;
using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UserInformationManager.Interface;

namespace CL.BS.UserInformationVM.BaseClass
{
    public class BaseUserBord  : BasePageVM
    {
        protected IUserInfoManager _logic= (IUserInfoManager)
    SupportHandlerManager.Base.GetManager("UserInfoManager");
        private ItemObject[] Users = new ItemObject[36];
        public string Pic0  { get { return Users[0].Background; } set {  Users[0 ].Background = value; } }
        public string Pic1  { get { return Users[1 ].Background; } set { Users[1 ].Background = value; } }
        public string Pic2  { get { return Users[2 ].Background; } set { Users[2 ].Background = value; } }
        public string Pic3  { get { return Users[3 ].Background; } set { Users[3 ].Background = value; } }
        public string Pic4  { get { return Users[4 ].Background; } set { Users[4 ].Background = value; } }
        public string Pic5  { get { return Users[5 ].Background; } set { Users[5 ].Background = value; } }
        public string Pic6  { get { return Users[6 ].Background; } set { Users[6 ].Background = value; } }
        public string Pic7  { get { return Users[7 ].Background; } set { Users[7 ].Background = value; } }
        public string Pic8  { get { return Users[8 ].Background; } set { Users[8 ].Background = value; } }
        public string Pic9  { get { return Users[9 ].Background; } set { Users[9 ].Background = value; } }
        public string Pic10 { get { return Users[10].Background; } set { Users[10].Background = value; } }
        public string Pic11 { get { return Users[11].Background; } set { Users[11].Background = value; } }
        public string Pic12 { get { return Users[12].Background; } set { Users[12].Background = value; } }
        public string Pic13 { get { return Users[13].Background; } set { Users[13].Background = value; } }
        public string Pic14 { get { return Users[14].Background; } set { Users[14].Background = value; } }
        public string Pic15 { get { return Users[15].Background; } set { Users[15].Background = value; } }
        public string Pic16 { get { return Users[16].Background; } set { Users[16].Background = value; } }
        public string Pic17 { get { return Users[17].Background; } set { Users[17].Background = value; } }
        public string Pic18 { get { return Users[18].Background; } set { Users[18].Background = value; } }
        public string Pic19 { get { return Users[19].Background; } set { Users[19].Background = value; } }
        public string Pic20 { get { return Users[20].Background; } set { Users[20].Background = value; } }
        public string Pic21 { get { return Users[21].Background; } set { Users[21].Background = value; } }
        public string Pic22 { get { return Users[22].Background; } set { Users[22].Background = value; } }
        public string Pic23 { get { return Users[23].Background; } set { Users[23].Background = value; } }
        public string Pic24 { get { return Users[24].Background; } set { Users[24].Background = value; } }
        public string Pic25 { get { return Users[25].Background; } set { Users[25].Background = value; } }
        public string Pic26 { get { return Users[26].Background; } set { Users[26].Background = value; } }
        public string Pic27 { get { return Users[27].Background; } set { Users[27].Background = value; } }
        public string Pic28 { get { return Users[28].Background; } set { Users[28].Background = value; } }
        public string Pic29 { get { return Users[29].Background; } set { Users[29].Background = value; } }
        public string Pic30 { get { return Users[30].Background; } set { Users[30].Background = value; } }
        public string Pic31 { get { return Users[31].Background; } set { Users[31].Background = value; } }
        public string Pic32 { get { return Users[32].Background; } set { Users[32].Background = value; } }
        public string Pic33 { get { return Users[33].Background; } set { Users[33].Background = value; } }
        public string Pic34 { get { return Users[34].Background; } set { Users[34].Background = value; } }
        public string Pic35 { get { return Users[35].Background; } set { Users[35].Background = value; } }
       
        
        
        public string Background0   { get { return Users[0].Button; } set { Users[0].Button = value; } }
        public string Background1   { get { return Users[1].Button; } set { Users[1].Button= value; } }
        public string Background2   { get { return Users[2].Button; } set { Users[2].Button= value; } }
        public string Background3   { get { return Users[3].Button; } set { Users[3].Button= value; } }
        public string Background4   { get { return Users[4].Button; } set { Users[4].Button= value; } }
        public string Background5   { get { return Users[5].Button; } set { Users[5].Button= value; } }
        public string Background6   { get { return Users[6].Button; } set { Users[6].Button= value; } }
        public string Background7   { get { return Users[7].Button; } set { Users[7].Button= value; } }
        public string Background8   { get { return Users[8].Button; } set { Users[8].Button= value; } }
        public string Background9   { get { return Users[9].Button; } set { Users[9].Button= value; } }
        public string Background10 { get { return Users[10].Button; } set { Users[10].Button = value; } }
        public string Background11 { get { return Users[11].Button; } set { Users[11].Button = value; } }
        public string Background12 { get { return Users[12].Button; } set { Users[12].Button = value; } }
        public string Background13 { get { return Users[13].Button; } set { Users[13].Button = value; } }
        public string Background14 { get { return Users[14].Button; } set { Users[14].Button = value; } }
        public string Background15 { get { return Users[15].Button; } set { Users[15].Button = value; } }
        public string Background16 { get { return Users[16].Button; } set { Users[16].Button = value; } }
        public string Background17 { get { return Users[17].Button; } set { Users[17].Button = value; } }
        public string Background18 { get { return Users[18].Button; } set { Users[18].Button = value; } }
        public string Background19 { get { return Users[19].Button; } set { Users[19].Button = value; } }
        public string Background20 { get { return Users[20].Button; } set { Users[20].Button = value; } }
        public string Background21 { get { return Users[21].Button; } set { Users[21].Button = value; } }
        public string Background22 { get { return Users[22].Button; } set { Users[22].Button = value; } }
        public string Background23 { get { return Users[23].Button; } set { Users[23].Button = value; } }
        public string Background24 { get { return Users[24].Button; } set { Users[24].Button = value; } }
        public string Background25 { get { return Users[25].Button; } set { Users[25].Button = value; } }
        public string Background26 { get { return Users[26].Button; } set { Users[26].Button = value; } }
        public string Background27 { get { return Users[27].Button; } set { Users[27].Button = value; } }
        public string Background28 { get { return Users[28].Button; } set { Users[28].Button = value; } }
        public string Background29 { get { return Users[29].Button; } set { Users[29].Button = value; } }
        public string Background30 { get { return Users[30].Button; } set { Users[30].Button = value; } }
        public string Background31 { get { return Users[31].Button; } set { Users[31].Button = value; } }
        public string Background32 { get { return Users[32].Button; } set { Users[32].Button = value; } }
        public string Background33 { get { return Users[33].Button; } set { Users[33].Button = value; } }
        public string Background34 { get { return Users[34].Button; } set { Users[34].Button = value; } }
        public string Background35 { get { return Users[35].Button; } set { Users[35].Button = value; } }
        protected string Text = string.Empty;
        protected int _index = -1,_bordIndex;
        public List<LetterObject> LstProduct { get; set; }
        private LetterObject[] LettersList = new LetterObject[] {
new LetterObject { Text="0",Background="Black"}, 
 new LetterObject { Text="1",Background="Brown"} ,
 new LetterObject { Text="2",Background="Aqua"}
, new LetterObject { Text="3",Background="Orange"}
, new LetterObject { Text="4",Background="Yellow"}
, new LetterObject { Text="5",Background="Green"}
, new LetterObject { Text="6",Background="Blue"}
, new LetterObject { Text="7",Background="Purple"}
, new LetterObject { Text="8",Background="Gray"}
, new LetterObject { Text="9",Background="PaleVioletRed"}};
        public ICommand TapLetter { get; set; }
        public ICommand TopFeeling { get; set; }
        public ICommand SelectStudent { get; set; }

        public override string Name => nameof(BaseUserBord);
       
        public BaseUserBord(int bordIndex)
        {
            _bordIndex = bordIndex;
            List<Database.User> users = Database.DatabaseManager.Inline.GetAllUser();
            for (int i = 0; i < Users.Length; i++)
            {
                if (i < users.Count)
                    Users[i] = new ItemObject() { Background = users[i].Image };
                else
                    Users[i] = new ItemObject();
            }
            TapLetter = new VMCommon.RelayCommand(DoTapLetter);
            SelectStudent = new VMCommon.RelayCommand(DoSelectStudent);
            LstProduct = new List<LetterObject>();

        }

        private void DoSelectStudent(object obj)
        {
            int i=int.Parse(obj.ToString());
            if (string.IsNullOrEmpty(Users[i].Background))
                return;
            Database.DatabaseManager.Inline.SetUsers(_bordIndex, i);
            if (_index!=-1)
            {
                Users[_index].Button = String.Empty;
                NotifyPropertyChanged("Background" + _index);
            }
            _index = i;
            Users[_index].Button = System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\UserInformation\YELLOWRectangle.png";
            NotifyPropertyChanged("Background" + _index);
        }

        private void DoTapLetter(object obj)
        {
            string s = obj.ToString();
            if (s=="-1"&& LstProduct.Count>0)
            {
                LstProduct.RemoveAt(0);
            }
            else
            {
                int n=int.Parse(s);
                LstProduct.Add(LettersList[n]);
            }
            LstProduct = new List<LetterObject>(LstProduct);
            NotifyPropertyChanged(nameof(LstProduct));
        }
    }
}
