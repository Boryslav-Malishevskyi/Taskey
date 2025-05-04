using Model;

namespace Presenter
{
    public class PresenterController
    {
        public PresenterController(IView view) 
        {
            this.view = view;
            model = new ModelController();

            InitializeEvents();
        }

        private readonly IView view;
        private readonly ModelController model;

        private void InitializeEvents()
        {
            view.OnCreateTask += NewTaskAdded;
        }

        private void NewTaskAdded(object? sender, TaskSettings arg)
        {
            model.CreateTask(arg);
            view.UpdateAfterCreation(arg);
        }
    }
}
