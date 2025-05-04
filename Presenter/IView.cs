using Model;

namespace Presenter
{
    public interface IView
    {
        public event EventHandler<TaskSettings> OnCreateTask;
        public event EventHandler<Task> OnDeleteTask;
        void CreateLayout();
        void UpdateAfterCreation(TaskSettings taskSettings);
    }
}
