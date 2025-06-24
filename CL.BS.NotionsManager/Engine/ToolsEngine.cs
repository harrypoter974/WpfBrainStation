using System;

namespace CL.BS.NotionsManager.Engine
{
    class ToolsEngine
    {
        string[] _ToolsList = new string[]{ "TapeMeasure"
            , "Saw", "screwdriver", "Axe",
            "Pincer", "Scalpel", "pliers", "hammer",
            "brush", "drill",
            "File", "wrench"};
        string[] lan = new string[] { "He", "En", "Ar" };
            internal string PlayTool(int item, int language)
        {
            return string.Format(@"{0}Resources\Audio\{1}\Tools\{2}.wav",
       System.AppDomain.CurrentDomain.BaseDirectory, lan[language],_ToolsList[item] );      
        }
    }
}
