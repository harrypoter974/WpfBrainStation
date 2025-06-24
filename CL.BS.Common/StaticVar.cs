using CL.BS.Common.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using static CL.BS.Common.GlobalVar;

namespace CL.BS.Common
{

    public class StaticVar
    {
        /// <summary>
        /// Global Var in the solution
        /// </summary>

        public readonly string[] HeVowels = new string[] { "shuruk",  "kubuts"
 , "holam male" ,  "holamDot" , "hirik"  , "segol", "tsere", "patah",  "kamats"};
        public static readonly string[] HeLetersList = new string[] { "alef", "Bet","Vet","Gimel", "Dalet",
            "He", "Waw", "Zayin","Heth" , "Teth","Yodh", "Kaph","Haph", "Lamedh",
            "Mem","Nun","Samekh","Ayin","Pe","pe_","Tsade","Qoph","Resh","Shin","Sin", "Taw" };
        public static readonly string[] HeLeters = new string[] { "alef", "Bet", "Gimel", "Dalet",
            "He", "Waw", "Zayin", "Heth" , "Teth","Yodh", "Kaph","Lamedh",
            "Mem","Nun","Samekh","Ayin","Pe","Tsade","Qoph"
            ,"Resh","Shin","Taw" , "KaphFinal","MemFinal","NunFinal","PeFinal","TsadeFinal"};// "אבגדהוזחטיכלמנסעפצקרשתךםןףץ";
  
        public const string EnLeters = "abcdefghijklmnopqrstuvwxyz";
        public const string GameData = @"C:\bs\GameData.xml";
        public static readonly string[] ColorsText = new string[] { "LightBlue", "Blue", "Violet", "Red", "Pink", "Gray", "Yellow", "Green", "White", "Black", "Orange", "Brown" };
        public static string PageKyeName = string.Empty;//  "AngleOpenVM";
        public static bool KyeOpen = true;
        //public static List<string> LimitingPages = new List<string>();    
        public static List<int> GardenTriviaTopic = new List<int>(new int[] { 1, 2, 3, 4 });
        public static readonly string[] LevelButton = new string[] { "Easy", "Medium", "Hard" };
        public static string BoardName = "";
        public static bool PlayMode = false;
        public static bool IsGarden = false;
        public static string SelectBoy;
        public static object MatchLevel = 1;
        public static string ComplexLevel;
        public static bool isTimerRedRun = false;
        public const string Green = "#FF59AD55";
        public static int LanguageIndex = 0;
        public enum ArithmeticType { Add, Moltipol, Sub, Splite, Complex };
        public static string BingoGroup = "Clothing";
        public static string ShadowGroup = "Clothing";
        public static int ComperGameIndex = 2;
        public static object TransferVar ;
        public static string NotionsThinkGropeName = "Stuff";


        public  string PlayName()
        {
            return @"Resources\Audio\He\Name\" + (_gameData.IsBoy ? "Boy\\" : "Girl\\") +
                _gameData.Name + ".wav";
        }
        public static StaticVar inline = new StaticVar();
      

        private StaticVar()
        {
            #region LettrStop
            LettrStop.Add('A', 39);
            LettrStop.Add('B', 51);
            LettrStop.Add('C', 30);
            LettrStop.Add('D', 42);
            LettrStop.Add('E', 34);
            LettrStop.Add('F', 29);
            LettrStop.Add('G', 47);
            LettrStop.Add('H', 40);
            LettrStop.Add('I', 25);
            LettrStop.Add('J', 27);
            LettrStop.Add('K', 37);
            LettrStop.Add('L', 22);
            LettrStop.Add('M', 52);
            LettrStop.Add('N', 46);
            LettrStop.Add('O', 39);
            LettrStop.Add('P', 33);
            LettrStop.Add('Q', 44);
            LettrStop.Add('R', 42);
            LettrStop.Add('S', 30);
            LettrStop.Add('T', 26);
            LettrStop.Add('U', 34);
            LettrStop.Add('V', 31);
            LettrStop.Add('W', 59);
            LettrStop.Add('X', 35);
            LettrStop.Add('Y', 26);
            LettrStop.Add('Z', 33);
            #endregion
            if (!File.Exists(GameData))
            {
                GameData gd = new GameData();
                gd._HeLetterList = new List<string>(StaticVar.HeLeters);
                gd._EnLetterList = EnLeters;
                gd._ColorsIndex = gd.Name = gd.NicknameA = gd.NicknameB =
                gd.NicknameC = gd.NicknameD = string.Empty;
                gd.Volume = 0.3;
               gd.IsBoy= gd.IsPlay = true;
                 gd._Languages =new bool[] { true, true, true };
                gd.SelectedLanguage = "He";
                gd.LimitingPages = new List<string>();
                // Opens a file and serializes the object into it in binary format.
                Stream tream = File.Open(GameData, FileMode.Create);
                BinaryFormatter ormatter = new BinaryFormatter();
                gd._HeVowels = new List<string>(gd.HeVowels);
                ormatter.Serialize(tream, gd);
                tream.Close();
            }
            try
            {
                Stream stream = File.Open(GameData, FileMode.Open);
                BinaryFormatter formatter = new BinaryFormatter();
                _gameData = (GameData)formatter.Deserialize(stream);
            stream.Close();
            }
            catch (Exception)
            {
                _gameData = new GameData(); _gameData._HeLetterList = new List<string>(StaticVar.HeLeters);
                _gameData._EnLetterList = EnLeters;
                _gameData._ColorsIndex
                  = _gameData.Name = _gameData.NicknameA = _gameData.NicknameB =
                  _gameData.NicknameC = _gameData.NicknameD = string.Empty;
                _gameData.Volume = 0.3;
                _gameData.IsPlay = true;
                _gameData.IsBoy = false;
                _gameData.LimitingPages = new List<string>();
            }
        }

        public Dictionary<char, int> LettrStop = new Dictionary<char, int>() { };

        public static int GetIndexHeLetersList(object letter)
        {
            string l = letter.ToString();
            for (int i = 0; i < HeLetersList.Length; i++)
            {
                if (l == HeLetersList[i])
                    return i;
            }
            return 0;
        }

        private GameData _gameData;

        public EnterType enterType { set { _gameData.enterType = value; } get { return _gameData.enterType; } }
        public int DomainNumIndex { set { _gameData.DomainNumIndex = value; } get { return _gameData.DomainNumIndex; } }
        public string Name
        {
            set
            {
                _gameData.Name = value;
            }
            get { return _gameData.Name; }
        }
        public string _EnLetterList
        { set { _gameData._EnLetterList = value; } get { return _gameData._EnLetterList; } }
        public bool _IsBigEnLetter
        { set { _gameData._IsBigEnLetter = value; } get { return _gameData._IsBigEnLetter; } }
        public bool _HeIsManuscript
        { set { _gameData._HeIsManuscript = value; } get { return _gameData._HeIsManuscript; } }
        public List<string> _HeLetterList
        { set { _gameData._HeLetterList = value; } get { return _gameData._HeLetterList; } }
        public List<string> _HeVowels
        { set { _gameData._HeVowels = value; } get { return _gameData._HeVowels; } }
        public string _ColorsIndex
        { set { _gameData._ColorsIndex = value; } get { return _gameData._ColorsIndex; } }
        public bool IsBoy
        { set { _gameData.IsBoy = value; } get { return _gameData.IsBoy; } }
        public bool IsCard
        { set { _gameData.IsCard = value; } get { return _gameData.IsCard; } }
        public bool IsTest
        { set { _gameData.IsTest = value; } get { return _gameData.IsTest; } }
        public bool IsPlay
        { set { _gameData.IsPlay = value; } get { return _gameData.IsPlay; } }
        public bool[] Languages
        { set { _gameData._Languages = value; } get { return _gameData._Languages; } }
        public double Volume
        { set { _gameData.Volume = value; } get { return _gameData.Volume; } }
        public string SelectedLanguage
        { set { _gameData.SelectedLanguage = value; } get { return _gameData.SelectedLanguage; } }
        public int AnimalsLern
        { set { _gameData.AnimalsLern = value; } get { return _gameData.AnimalsLern; } }
        public int AnimalsLernWord
        { set { _gameData.AnimalsLernWord = value; } get { return _gameData.AnimalsLernWord; } }
        public string NicknameA
        { set { _gameData.NicknameA = value; } get { return _gameData.NicknameA; } }
        public string NicknameB
        { set { _gameData.NicknameB = value; } get { return _gameData.NicknameB; } }
        public string NicknameC
        { set { _gameData.NicknameC = value; } get { return _gameData.NicknameC; } }
        public string NicknameD
        { set { _gameData.NicknameD = value; } get { return _gameData.NicknameD; } }
        public int ArrayDomain
        { set { _gameData.ArrayDomain = value; } get { return _gameData.ArrayDomain; } }
        public List<string> LimitingPages
        { set { _gameData.LimitingPages = value; } get { return _gameData.LimitingPages; } }

        public string CardOrWritingPic(bool doSwitch)
        {
            if (doSwitch)
            {
                Settings.Default.IsCard = !Settings.Default.IsCard;
            }
            string[] picName = { "Card.png", "Writing.png" }; ;
            return picName[IsCard ? 0 : 1];
        }

        public void SaveGameData()
        {
            Stream tream = File.Open(GameData, FileMode.Create);
            BinaryFormatter ormatter = new BinaryFormatter();            


            ormatter.Serialize(tream, _gameData);
            tream.Close();
        }
    }
}
