using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.MathLearningManager.Engine.Recognaz
{
    class MathRecognaz10Engine
    {
        internal string[] PlayNum(object num)
        {
            string n = num.ToString();
            string[] list=new string[n=="0"?1:5];
           
            switch (n)
            {
                case "1":
                    list[0]= @"Resources\Audio\He\General\sheep.wav";
                    list[1]= @"Resources\Audio\He\Num\n1.wav";
                    list[2]= @"Resources\Audio\He\General\cow.wav";
                    list[3]= @"Resources\Audio\He\Num\n1.wav";
                    break;
                case "2":
                   list[0]= @"Resources\Audio\He\Num\n2.wav";
                   list[1]= @"Resources\Audio\He\General\bananas.wav";
                   list[2]= @"Resources\Audio\He\Num\n2.wav";
                   list[3]= @"Resources\Audio\He\General\cows.wav";
                    break;
                case "3":
                    list[0]= @"Resources\Audio\He\Num\n3.wav";
                    list[1]= @"Resources\Audio\He\General\Tomatoes.wav";
                    list[2]= @"Resources\Audio\He\Num\n3.wav";
                    list[3]= @"Resources\Audio\He\General\cows.wav";
                    break;
                case "4":
                    list[0]= @"Resources\Audio\He\Num\n4.wav";
                    list[1]= @"Resources\Audio\He\General\bananas.wav";
                    list[2]= @"Resources\Audio\He\Num\n4.wav";
                    list[3]= @"Resources\Audio\He\General\cats.wav";
                    break;
                case "5":
                    list[0]= @"Resources\Audio\He\Num\n5.wav";
                    list[1]= @"Resources\Audio\He\General\Tomatoes.wav";
                    list[2]= @"Resources\Audio\He\Num\n5.wav";
                    list[3]= @"Resources\Audio\He\General\trucks.wav";
                    break;
                case "6":
                    list[0]= @"Resources\Audio\He\Num\n6.wav";
                    list[1]= @"Resources\Audio\He\General\boats.wav";
                    list[2]= @"Resources\Audio\He\Num\n6.wav";
                    list[3]= @"Resources\Audio\He\General\cows.wav";
                    break;
                case "7":
                    list[0]=@"Resources\Audio\He\Num\n7.wav";
                    list[1]= @"Resources\Audio\He\General\Tomatoes.wav";
                    list[2]=@"Resources\Audio\He\Num\n7.wav";
                    list[3] = @"Resources\Audio\He\General\boats.wav";
                    break;
                case "8":
                    list[0]=@"Resources\Audio\He\Num\n8.wav";
                    list[1]= @"Resources\Audio\He\General\trucks.wav";
                    list[2]=@"Resources\Audio\He\Num\n8.wav";
                    list[3] = @"Resources\Audio\He\General\cows.wav";
                    break;
                case "9":
                    list[0]=@"Resources\Audio\He\Num\n9.wav";
                    list[1]= @"Resources\Audio\He\General\cows.wav";
                    list[2]=@"Resources\Audio\He\Num\n9.wav";
                    list[3] = @"Resources\Audio\He\General\Tomatoes.wav";
                    break;
                case "10":
                    list[0]=@"Resources\Audio\He\Num\n10.wav";
                    list[1]= @"Resources\Audio\He\General\boats.wav";
                    list[2]=@"Resources\Audio\He\Num\n10.wav";
                    list[3] = @"Resources\Audio\He\General\bananas.wav";
                    break;
                default:
                    break;
            }
            if (n=="0")
                list[0] = @"Resources\Audio\He\Num\0.wav";
            else if(n=="2")
                list[4] = @"Resources\Audio\He\Num\two.wav";
            else
                list[4] = @"Resources\Audio\He\Num\n" + num + ".wav";
            return list;
        }
    }
}
