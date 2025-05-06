using Model;

namespace Taskey
{
    internal interface IDisplay
    {
        internal event EventHandler<ActionParameters> OnButtonClick;
        void Display();
        void AddItemToList(TaskSettings settings);
        void RemoveItemFromList(TaskSettings settings);
    }

    public enum ActionType
    {
        CreateTask,
        DeleteTask
    }

    internal class ActionParameters
    {
        internal ActionType actionType;
        internal TaskSettings taskSettings;
    }

}
