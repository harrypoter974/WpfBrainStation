

namespace CL.BS.NotionsManager.Engine
{
    class ShapeEngine
    {
        string[] _shapesList = new string []{
            "pentagon", "Trapezoid", "Diamond", "rectangle",
            "Square", "triangular", "heart", "Star",
            "Oval", "Circle",
            "octagon", "hexagon", "Box", "cube"
            , "Cylinder", "cone", "Sphere",
            "pyramid"};

        string[] lan = new string[] { "He", "En", "Ar" };
            internal string PlayShape(int shape, int language)
        {
            return string.Format(@"{0}Resources\Audio\{1}\Shapes\{2}.wav",
           System.AppDomain.CurrentDomain.BaseDirectory, lan[language],_shapesList[shape]);
        }
    }
}
