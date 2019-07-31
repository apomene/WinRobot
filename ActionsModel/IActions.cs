using System;

namespace ActionsModel
{
    /// <summary>
    /// Our External Interface - Contract for Available Actions
    /// </summary>
    public interface IActions
    {
        void GetWindow(string windowTitle);

        void MoveMouse(int x, int y);

        void MouseCLick(string clickType);

        void SetText(string text);
      
    }

}
