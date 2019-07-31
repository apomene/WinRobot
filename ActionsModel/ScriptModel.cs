
namespace ActionsModel
{
    public static class ScriptModel
    {
        //TO DO: Maybe Read from external File - XML or JSON
  
        public const string Select = "select-window";
        public const string Move = "mouse-move";
        public const string Click = "mouse-click";
        public const string SendText = "send-keys";
        public const char delimeter = ':'; // each Action method is separated by this delimeter, from action Arguments
        public const char coordsDelim = ',';  //x,y coordinates are comma separated:

        #region Mouse Click Types
        public const string clickTypeL = "Left Click";
        public const string clickTypeR = "Right Click";
        public const string clickTypeD = "Double Click";
        #endregion

    }
}
