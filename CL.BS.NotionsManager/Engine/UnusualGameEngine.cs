using CL.BS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.NotionsManager.Engine
{
    internal class UnusualGameEngine
    {
        List<string[]> PicList = new List<string[]>();
        public UnusualGameEngine()
        {
            FillList();
        }

        private void FillList()
        {
            if (PicList.Count()==0)
            {
                PicList.Add(new string[] { "Animals\\pigeon.png", "Animals\\rabbit.png", "Animals\\cat.png", "Animals\\dog.png" });

                PicList.Add(new string[] { "Animals\\lion.png", "Animals\\sheep.png", "Animals\\goat.png", "Animals\\cow.png" });
                PicList.Add(new string[] { "Animals\\rabbit.png","Animals\\lion.png" , "Animals\\bear.png", "Animals\\dog.png" });
                PicList.Add(new string[] { "Animals\\fish.png", "Animals\\lion.png", "Animals\\sheep.png", "Animals\\elephant.png" });
                PicList.Add(new string[] { "Animals\\pigeon.png", "Animals\\horse.png", "Animals\\sheep.png", "Animals\\giraffe.png" });

                PicList.Add(new string[] { "Shapes\\Square.png", "Shapes\\pyramid.png", "Shapes\\Cylinder.png", "Shapes\\Box.png" });
                PicList.Add(new string[] { "Shapes\\Sphere.png", "Shapes\\trapeze.png", "Shapes\\Square.png", "Shapes\\hexagon.png" });
                PicList.Add(new string[] { "Shapes\\triangular.png", "Shapes\\Diamond.png", "Shapes\\rectangle.png", "Shapes\\trapeze.png" });

                PicList.Add(new string[] { "Food\\cheese.png", "Food\\chicken.png", "Food\\HotDogs.png", "Food\\schnitzel.png" });
                PicList.Add(new string[] { "Food\\chicken.png", "Food\\cheese.png", "Food\\milk.png", "Food\\IceCream.png" });
                PicList.Add(new string[] { "Food\\schnitzel.png", "Food\\rice.png", "Food\\pasta.png", "Food\\FrenchFries.png" });


                PicList.Add(new string[] { "Fruit\\Pomegranate.png", "Vegetables\\Zucchini.png", "Vegetables\\lettuce.png", "Vegetables\\cucumber.png" });

                PicList.Add(new string[] { "Vegetables\\cauliflower.png", "Fruit\\Date.png", "Fruit\\cherry.png", "Fruit\\mango.png" });

                PicList.Add(new string[] { "Clothing\\Coat.png", "Clothing\\Shoes.png", "Clothing\\sandals.png", "Clothing\\boots.png" });
                PicList.Add(new string[] { "Clothing\\Socks.png", "Clothing\\undershirt.png", "Clothing\\shirt.png", "Clothing\\dress.png" });
                PicList = Common.GeneralFunctions.ShuffleList<string[]>(PicList);
            }
        }

        internal List<GameObject>[] NewGame()
        {
            FillList();
            List<GameObject>[] l = new List<GameObject>[4];
            List<GameObject>npl = new List<GameObject>();
            string[] pl = PicList[0];
            PicList.RemoveAt(0); 
           for (int i = 0; i < l.Length; i++)
            {
                npl.Add(new GameObject() { Answer= pl[i] });
            }
            for (int i = 0; i < l.Length; i++)
            {
                l[i]= npl;   
            }
           return l;
        }

        internal bool EndGame()
        {
            return true;
        }
    }
}
