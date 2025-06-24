using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CL.BS.Common.GlobalVar;

namespace CL.BS.Common
{
    [Serializable]
    class GameData
    {
        public readonly string[] HeVowels = new string[] { "shuruk",  "kubuts"
 , "holam male" ,  "holamDot" , "hirik"  , "segol", "tsere", "patah",  "kamats"};
        public EnterType enterType { set; get; }
        private string _enLetterList, _colorsIndex, _name, _nicknameA, _nicknameB
            , _nicknameC, _nicknameD, _selectedLanguage;
       
        internal string _EnLetterList
        {
            get
            {
                if (string.IsNullOrEmpty(_enLetterList))
                    _enLetterList = "abcdefghijklmnopqrstuvwxyz";
                return _enLetterList;
            }
            set { _enLetterList = value; }
        }
        internal int DomainNumIndex { set; get; }
        //Properties.Settings.Default.DomainNumIndex

       internal string Name
        {
            get
            {
                if (string.IsNullOrEmpty(_name))
                    _name = string.Empty;
                return _name;
            }
            set { _name = value; }
        }
        //Properties.Settings.Default.Name

        //Properties.Settings.Default.EnLetterList
       
        internal bool _IsBigEnLetter { set; get; }

        private bool[] _languages;
        internal bool[] _Languages
        {
            get
            {
                if (null== _languages)
                    _languages = new bool[] { true, true, true };
                return _languages;
            }
            set { _languages = value; }
        }
       
        internal bool _HeIsManuscript
        { set; get; }
        private List<string> _heLetterList;
        internal List< string> _HeLetterList
        {
            get
            {
                if (null == _heLetterList)
                    _heLetterList =  new List<string>(StaticVar.HeLeters);
                return _heLetterList;
            }
            set { _heLetterList = value; }
        }
        private List<string> _heVowels;
        internal List<string> _HeVowels
        {
            get
            {
                if (null == _heVowels) {
                    _heVowels = new List<string>(new string[] { "shuruk",  "kubuts"
 , "holam male" ,  "holamDot" , "hirik"  , "segol", "tsere", "patah",  "kamats"});
                }
                return _heVowels;
            }
            set { _heVowels = value; }
        }
        // Properties.Settings.Default.HeLetterList
        internal string _ColorsIndex
        {
            get
            {
                if (string.IsNullOrEmpty(_colorsIndex))
                    _colorsIndex = string.Empty;
                return _colorsIndex;
            }
            set { _colorsIndex = value; }
        }
        //Properties.Settings.Default.ColorsIndex
        internal bool IsBoy
        { set; get; }
        //Properties.Settings.Default.IsBoy
        internal bool IsCard
        { set; get; }
        //Properties.Settings.Default.IsCard
        internal bool IsTest
        { set; get; }
        //Properties.Settings.Default.IsTest
        internal bool IsPlay
        { set; get; }
        //Properties.Settings.Default.IsPlay
        internal double Volume
        { set; get; }
        //Properties.Settings.Default.Volume
        internal int AnimalsLern
        { set; get; }
        //Properties.Settings.Default.AnimalsLern
        internal int AnimalsLernWord
        { set; get; }
        //Properties.Settings.Default.AnimalsLernWord

        internal string NicknameA
        {
            get
            {
                if (string.IsNullOrEmpty(_nicknameA))
                    _nicknameA = string.Empty;
                return _nicknameA;
            }
            set { _nicknameB = value; }
        }
        //Properties.Settings.Default.NicknameA
        internal string NicknameB
        {
            get
            {
                if (string.IsNullOrEmpty(_nicknameB))
                    _nicknameB = string.Empty;
                return _nicknameB;
            }
            set { _nicknameB = value; }
        }
        //Properties.Settings.Default.NicknameB
        internal string NicknameC
        {
            get
            {
                if (string.IsNullOrEmpty(_nicknameC))
                    _nicknameC = string.Empty;
                return _nicknameC;
            }
            set { _nicknameC = value; }
        }
        //Properties.Settings.Default.NicknameC
        internal string NicknameD
        {
            get
            {
                if (string.IsNullOrEmpty(_nicknameD))
                    _nicknameD = string.Empty;
                return _nicknameD;
            }
            set { _nicknameD = value; }
        }
        //Properties.Settings.Default.NicknameD
        internal int ArrayDomain
        { set; get; }
        //Properties.Settings.Default.ArrayDomain
        internal string SelectedLanguage
        {
            get
            {
                if (string.IsNullOrEmpty(_selectedLanguage))
                    _selectedLanguage = string.Empty;
                return _selectedLanguage;
            }
            set { _selectedLanguage = value; }
        }
        internal List<string> LimitingPages = new List<string>();
    }
}
