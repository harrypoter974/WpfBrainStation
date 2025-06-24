using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CL.BS.Model;
using CL.BS.VMCommon;

namespace CL.BS.MathLearningManager.Engine.Recognaz
{
    class MathArray1Engine
    {
        private  Random _ran = new Random(DateTime.Now.Millisecond);
        private int _blankNum = 0;

        internal LetterObject[] GetAnswer()
        {
            LetterObject[] list = new LetterObject[10];
            for (int i = 0; i < list.Length; i++)
                list[i] = new LetterObject() {visibility= Visibility.Hidden };
            return list;
        }

        internal LetterObject[] GetQuestion(ref string messeg)
        {
            int blankNum = _blankNum;
            LetterObject[] list = new LetterObject[10];
            int i = 0, leftNum = list.Length - _blankNum;
            bool isBlun = messeg == "B";
            for (; leftNum > 0 & i < list.Length; i++)
            {
                list[i] = new LetterObject();
                if (leftNum <= list.Length - i & _ran.Next(2) == 1)
                {
                    list[i].visibility = isBlun?Visibility.Hidden:  Visibility.Visible;
                }
                else
                {
                    list[i].visibility = isBlun ? Visibility.Visible :Visibility.Hidden ;
                    list[i].Text = (i + 1).ToString();
                    leftNum--;
                }
            }
            for (; i < list.Length; i++)
            {
                list[i] = new LetterObject();
                list[i].visibility = Visibility.Hidden;
            }
            _blankNum = _blankNum == 9 ? 1 : _blankNum + 1;
            messeg= System.AppDomain.CurrentDomain.BaseDirectory +
                  @"Resources\Math\Recognaz\"+(blankNum==1?"ArrayMessage.png":
               (Common.StaticVar.inline.IsBoy ? "ArrayBoyMessage.png" : "ArrayGirlMessage.png")) ;
            return list;
        }

        internal string[] PlayBlunMessage()
        {
            string[] message = new string[3];
            message[0] = Common.StaticVar.inline.PlayName();
            if (Common.StaticVar.inline.IsBoy)
                message[1] = @"Resources\Audio\He\General\putItDown.wav";
            else
                message[1] = @"Resources\Audio\He\General\put_it_down.wav";
            message[2] = @"Resources\Audio\He\Sentences\A14.wav";

            return message;
        }

        internal string[] PlayMessage()
        {
            string[] message = new string[2];
            message[0] = Common.StaticVar.inline.PlayName();
            if (Common.StaticVar.inline.IsBoy)
                message[1] = @"Resources\Audio\He\Sentences\A12.wav";
            else
                message[1] = @"Resources\Audio\He\Sentences\A13.wav";

            return message;
        }
    }
}
