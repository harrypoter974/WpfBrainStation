using CL.BS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.NotionsManager.Engine
{
    internal class PictureToStory2Engine
    {
        private string[] Subject = new string[] { "Animals"
,"Food","kitchenware","Clothing","Fruit","MusicalLnstruments"
,"Professions","Tools","Vegetables","Vehicles"};
        protected Random _ran = new Random(DateTime.Now.Millisecond);

            List<LetterObject>[] _picList = new List<LetterObject>[4];
        internal PictureToStory2Engine() {
            for (int i = 0; i < 4; i++)
                _picList[i] = new List<LetterObject>();
        }

        AnimalsEngine PicList = new AnimalsEngine();

        internal void ClearBord()
        {
            indexNum = 0; indxPlayer = 0; indexPic = 0;
        }

        int[] numPlayer = new int[] { 0, 1,  3 };
        int indexNum = 0,indxPlayer=0,indexPic=0;
        internal List<LetterObject>[] SetPicList(int v)
        {
            indexPic = indexPic<4?indexPic+1:0;
            indxPlayer=indxPlayer < numPlayer[v]? indxPlayer+1: 0;          

            if (indexNum== (numPlayer[v]+1)*4)
            {
                indexNum = 0;
                for (int i = 0; i < 4; i++)
                    _picList[i] = new List<LetterObject>();
            }

            else
            {
                int sub = _ran.Next(Subject.Length);
                int subLength = Subject[sub].Length;
                _picList[indxPlayer].Add(new LetterObject
                {
                    Background =
                  String.Format(@"{0}Resources\Notions\{1}\{2}.png"
, System.AppDomain.CurrentDomain.BaseDirectory, Subject[sub],
PicList._wordDictionary[Subject[sub]][_ran.Next(subLength)])
                });
                indexNum++;
            }
            return _picList;
        }
    }
}
