using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.JudaismManager.Engen
{
    public class BrahotEngen
    {
        private const int BrahotLength = 9;
        private List< string>[]  _Brahots = new List<string>[BrahotLength];
        private Dictionary<string, string> BrahotDic = new Dictionary<string, string>();
        public static BrahotEngen _Logic;
        public static BrahotEngen GetInstans()
        {
            if (_Logic == null)
                _Logic = new BrahotEngen();
            return _Logic;
        }

        private Random _ran = new Random(DateTime.Now.Millisecond);
        private BrahotEngen()
        {
            BrahotDic.Add("אבוקדו"           , @"Resources\Notions\Fruit\Avocado.png");
            BrahotDic.Add("תפוח"             , @"Resources\Notions\Fruit\Apple.png");
            BrahotDic.Add("בננה"             , @"Resources\Notions\Fruit\Banana.png");
            BrahotDic.Add("תאנה"             , @"Resources\Notions\Fruit\fig.png");
            BrahotDic.Add("אשכולית"         , @"Resources\Notions\Fruit\grapefruit.png");
            BrahotDic.Add("ענבים"           , @"Resources\Notions\Fruit\Grapes.png");
            BrahotDic.Add("לימון"           , @"Resources\Notions\Fruit\lemon.png");
            BrahotDic.Add("מנגו"            , @"Resources\Notions\Fruit\mango.png");
            BrahotDic.Add("תפוז"            , @"Resources\Notions\Fruit\orange.png");
            BrahotDic.Add("אפרסק"           , @"Resources\Notions\Fruit\peach.png");
            BrahotDic.Add("אגס"             , @"Resources\Notions\Fruit\pear.png");
            BrahotDic.Add("אננס"            , @"Resources\Notions\Fruit\pineapple.png");
            BrahotDic.Add("שזיף"            , @"Resources\Notions\Fruit\plum.png");
            BrahotDic.Add("תמר"             , @"Resources\Notions\Fruit\Tamar.png");
            BrahotDic.Add("רמון"            , @"Resources\Notions\Fruit\Ramon.png");
            BrahotDic.Add("דבדבן"           , @"Resources\Notions\Fruit\cherry.png");
            BrahotDic.Add("קשוא"             , @"Resources\Notions\Vegetables\Zucchini.png");
            BrahotDic.Add("אבטיח"            , @"Resources\Notions\Vegetables\watermelon.png");
            BrahotDic.Add("עגבניה"          , @"Resources\Notions\Vegetables\tomato.png");
            BrahotDic.Add("צנונית"          , @"Resources\Notions\Vegetables\radish.png");
            BrahotDic.Add("דלעת"            , @"Resources\Notions\Vegetables\pumpkin.png");
            BrahotDic.Add("תפוח אדמה"       , @"Resources\Notions\Vegetables\Potato.png");
            BrahotDic.Add("פלפל"            , @"Resources\Notions\Vegetables\pepper.png");
            BrahotDic.Add("אפונה"           , @"Resources\Notions\Vegetables\pea.png");
            BrahotDic.Add("בצל"             , @"Resources\Notions\Vegetables\Onion.png");
            BrahotDic.Add("מלון"            , @"Resources\Notions\Vegetables\Melon.png");
            BrahotDic.Add("חסה"             , @"Resources\Notions\Vegetables\lettuce.png");
            BrahotDic.Add("חציל"            , @"Resources\Notions\Vegetables\eggplant.png");
            BrahotDic.Add("מלפפון"          , @"Resources\Notions\Vegetables\cucumber.png");
            BrahotDic.Add("תירס"            , @"Resources\Notions\Vegetables\corn.png");
            BrahotDic.Add("כרובית"          , @"Resources\Notions\Vegetables\cauliflower.png");
            BrahotDic.Add("גזר"             , @"Resources\Notions\Vegetables\Carrot.png");
            BrahotDic.Add("כרוב"            , @"Resources\Notions\Vegetables\cabbage.png");
            BrahotDic.Add("בסלי"           , @"Resources\JudaismImage\Brahot\mezonot\Beasley.png");//בורא מיני מזונות
            BrahotDic.Add("בורקס"          , @"Resources\JudaismImage\Brahot\mezonot\Bourekas.png");
            BrahotDic.Add("עוגיות"         , @"Resources\JudaismImage\Brahot\mezonot\cookie.png");
            BrahotDic.Add("קרואסון"        , @"Resources\JudaismImage\Brahot\mezonot\croissant.png");
            BrahotDic.Add("סופגניה"        , @"Resources\JudaismImage\Brahot\mezonot\Doughnut.png");
            BrahotDic.Add("פתיתים"         , @"Resources\JudaismImage\Brahot\mezonot\flakes.png");
            BrahotDic.Add("אוזן המן"       , @"Resources\JudaismImage\Brahot\mezonot\HamanEar.png");
            BrahotDic.Add("קיגל"           , @"Resources\JudaismImage\Brahot\mezonot\Kugel.png");
            BrahotDic.Add("פסטה"           , @"Resources\JudaismImage\Brahot\mezonot\pasta.png");
            BrahotDic.Add("עוגה"           , @"Resources\JudaismImage\Brahot\mezonot\Pie.png");
            BrahotDic.Add("ביגלה"           , @"Resources\JudaismImage\Brahot\mezonot\begale.png");
            BrahotDic.Add("ופלה"           , @"Resources\JudaismImage\Brahot\mezonot\waffer.png");
            BrahotDic.Add("burekas", @"Resources\JudaismImage\Brahot\mezonot\burekas.png");
            BrahotDic.Add("פטריה"           , @"Resources\Lang\He\Recognition\Image\Pe0.jpg");//שהכל נהיה בדברו
            BrahotDic.Add("בירה"         , @"Resources\JudaismImage\Brahot\shehkol\beer.png");
            BrahotDic.Add("סוכריה"      , @"Resources\JudaismImage\Brahot\shehkol\cheese.png");
            BrahotDic.Add("שוקולד"      , @"Resources\JudaismImage\Brahot\shehkol\chocolate.png");
            BrahotDic.Add("ביצה"          , @"Resources\JudaismImage\Brahot\shehkol\egg.png");
            BrahotDic.Add("גלידה"         , @"Resources\JudaismImage\Brahot\shehkol\IceCream.png");
            BrahotDic.Add("חביתה"       , @"Resources\JudaismImage\Brahot\shehkol\milk.png");
            BrahotDic.Add("עוף"         , @"Resources\JudaismImage\Brahot\shehkol\polka.png");
            BrahotDic.Add("ארטיק"         , @"Resources\JudaismImage\Brahot\shehkol\Popsicle.png");
            BrahotDic.Add("שניצל"       , @"Resources\JudaismImage\Brahot\shehkol\schnitzel.png");
            BrahotDic.Add("בשר"         , @"Resources\JudaismImage\Brahot\shehkol\Stick.png");
            BrahotDic.Add("מים"         , @"Resources\JudaismImage\Brahot\shehkol\water.png");
            BrahotDic.Add("במבה"        , @"Resources\JudaismImage\Brahot\shehkol\Bamba.png");
            BrahotDic.Add("דג"          , @"Resources\JudaismImage\Brahot\shehkol\Fish.png");
            BrahotDic.Add("ביגל טוסט", @"Resources\JudaismImage\Brahot\hamozy\BagelToast.png");//המוציא לחם מן הארץ
            BrahotDic.Add("בגט"         , @"Resources\JudaismImage\Brahot\hamozy\Baguette.png");
            BrahotDic.Add("לחם"        , @"Resources\JudaismImage\Brahot\hamozy\bread.png");
            BrahotDic.Add("לחמניה"    , @"Resources\JudaismImage\Brahot\hamozy\bun.png");
            BrahotDic.Add("לחם עגול", @"Resources\JudaismImage\Brahot\hamozy\roundBread.png");
            BrahotDic.Add("חלה"       , @"Resources\JudaismImage\Brahot\hamozy\Challah.png");
            BrahotDic.Add("לחם מטוגן" , @"Resources\JudaismImage\Brahot\hamozy\FrenchToast.png");
            BrahotDic.Add("מצה"       , @"Resources\JudaismImage\Brahot\hamozy\Matzo.png");
            BrahotDic.Add("פיתה"      , @"Resources\JudaismImage\Brahot\hamozy\Seduced.png");
            BrahotDic.Add("טוסט"      , @"Resources\JudaismImage\Brahot\hamozy\toast.png");
            BrahotDic.Add("יין"       , @"Resources\JudaismImage\Brahot\wine.png");
            SetShita("Spain.xls");



        }

        public void SetShita(string shita)
        {
            for (int i = 0; i < _Brahots.Length; i++)
                _Brahots[i] = new List<string>();
            StreamReader streamReader = new StreamReader(System.AppDomain.CurrentDomain.BaseDirectory +
         @"Resources\JudaismImage\Brahot\"+ shita, System.Text.Encoding.UTF8);
            string[] brahots = streamReader.ReadToEnd().Split('\n');
            for (int i = 1; i < brahots.Length; i++)
            {
                try
                {
                    if (string.IsNullOrEmpty(brahots[i]))
                        continue;
                    string[] Cells = brahots[i].Split('\t');
                    string pic = BrahotDic[Cells[0].Trim()];
                    for (int j = 1; j < Cells.Length; j++)
                    {
                        if (Cells[j] == "v")
                            _Brahots[j - 1].Add(pic);
                    }
                }
                catch (Exception e)
                {
                }
            }
        }


        public List< string[]> GetBrahots()
        {
            List<string[]> bl = new List<string[]>();
            for (int i = 0; i < BrahotLength; i++)
            {
                bl.Add(new string[] { i.ToString(), _Brahots[i][_ran.Next(_Brahots[i].Count()-1)] });
            }
            return bl;
        }
        public List<string[]> GetBrahots(int length = BrahotLength)
        {
            List<string[]> bl = new List<string[]>();
            for (int i = 0; i < length; i++)
            {
                int n = i % 9;
                string[] item= new string[] { n.ToString(), _Brahots[n][_ran.Next(_Brahots[n].Count() - 1)] };
                //do
                //{
                //    item ;
                //    if (n == 5)
                //        break;
                //} while (bl.Contains(item));
                bl.Add(item);
            }
            return bl;
        }
    }
}
