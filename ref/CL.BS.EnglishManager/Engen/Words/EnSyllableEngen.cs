using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.EnglishManager.Engen.Words
{
    class EnSyllableEngen
    {
        internal
           String GetWord(string syllable,object i)
        {
            int index = int.Parse(i.ToString());
            string path = string.Empty;
            switch (syllable)
            {
                case "ba": path = new string[] { "Opposites\\Bad", "Animals\\Bat", "Fruits\\Banana" }[index]; break;
                case "ca": path = new string[] { "Syllable\\can", "Syllable\\Cap", "Animals\\Cat" }[index]; break;
                case "fa": path = new string[] { "Syllable\\fan", "Syllable\\Fat", "" }[index]; break;
                case "ha": path = new string[] { "OpeningLetter\\Hat", "", "" }[index]; break;
                case "ma": path = new string[] { "Syllable\\map", "Syllable\\man", "Syllable\\mat" }[index]; break;
                case "ra": path = new string[] { "Animals\\Rat", "OpeningLetter\\Rabbit", "" }[index]; break;
                case "sa": path = new string[] { "Opposites\\Sad", "", "" }[index]; break;
                case "va": path = new string[] { "Syllable\\van", "", "" }[index]; break;

                case "be": path = new string[] { "Syllable\\bed", "Syllable\\bell", "Syllable\\beggar" }[index]; break;
                case "le": path = new string[] { "Syllable\\leg", "Fruits\\lemon", "Letters\\Letters" }[index]; break;
                case "pe": path = new string[] { "AtSchool\\Pencil", "OpeningLetter\\Penguin", "" }[index]; break;
                case "ye": path = new string[] { "Syllable\\Yell", "Colors\\Yellow", "" }[index]; break;

                case "bi": path = new string[] { "Syllable\\bin", "Syllable\\bib", "" }[index]; break;
                case "di": path = new string[] { "Syllable\\dill", "Syllable\\dish", "" }[index]; break;
                case "fi": path = new string[] { "Animals\\Fish", "", "" }[index]; break;
                case "hi": path = new string[] { "Syllable\\hill", "OpeningLetter\\hippo", "" }[index]; break;
                case "ki": path = new string[] { "OpeningLetter\\king", "", "" }[index]; break;
                case "li": path = new string[] { "Syllable\\lid", "TheBody\\lips", "" }[index]; break;
                case "pi": path = new string[] { "Syllable\\pin", "Syllable\\pill", "OpeningLetter\\Pizza" }[index]; break;

                case "bo": path = new string[] { "Syllable\\Box", "TheBody\\Body", "" }[index]; break;
                case "co": path = new string[] { "Syllable\\Cot", "Syllable\\Cottage", "" }[index]; break;
                case "do": path = new string[] { "Animals\\Dog", "Syllable\\dot", "Syllable\\doll" }[index]; break;
                case "fo": path = new string[] { "Syllable\\fox", "", "" }[index]; break;
                case "ho": path = new string[] { "Opposites\\Hot", "", "" }[index]; break;
                case "lo": path = new string[] { "Syllable\\log", "Opposites\\Long", "" }[index]; break;
                case "mo": path = new string[] { "Syllable\\mom", "Syllable\\mop", "" }[index]; break;
                case "no": path = new string[] { "Syllable\\not", "Syllable\\note", "AtSchool\\Notebook" }[index]; break;
                case "po": path = new string[] { "Syllable\\pot", "Syllable\\pop", "" }[index]; break;
                case "to": path = new string[] { "Syllable\\top", "Syllable\\toy", "" }[index]; break;
                case "yo": path = new string[] { "OpeningLetter\\Yo-yo", "", "" }[index]; break;

                case "bu": path = new string[] { "Syllable\\Bug", "Transportation\\Bus", "" }[index]; break;
                case "cu": path = new string[] { "Syllable\\Cut", "Syllable\\cup", "" }[index]; break;
                case "fu": path = new string[] { "Syllable\\fun", "", "" }[index]; break;
                case "mu": path = new string[] { "Syllable\\mug", "Syllable\\mud", "" }[index]; break;
                case "nu": path = new string[] { "OpeningLetter\\nuts", "", "" }[index]; break;
                case "pu": path = new string[] { "Syllable\\pup", "", "" }[index]; break;
                case "ru": path = new string[] { "Syllable\\run", "Syllable\\rug", "" }[index]; break;
                case "su": path = new string[] { "Syllable\\sun", "", "" }[index]; break;

                default:
                    break;
            }
            return path;
        }
    }
}
