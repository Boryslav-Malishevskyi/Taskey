using Model;

namespace Presenter
{
    public interface IView
    {
        public event EventHandler<TaskSettings> OnCreateTask;
        public event EventHandler<STask> OnDeleteTask;
        void CreateLayout();
        void UpdateAfterCreation(TaskSettings taskSettings);
    }
}
