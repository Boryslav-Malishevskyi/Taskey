namespace Model
{
    public class ModelController
    {
        public ModelController() 
        {
            tasks = new List<Task>();
            operations = new Stack<IOperation>();
        }

        private List<Task> tasks;
        private Stack<IOperation> operations;

        internal void AddTask(Task task) => tasks.Add(task);
        internal void RemoveTask(Task task) => tasks.Remove(task);
        internal void PushOperation(IOperation operation) => operations.Push(operation);
        internal void PopOperation() => operations.Pop();


        public void CreateTask(TaskSettings taskSettings)
        {
            var t = new AddOperation(this, taskSettings);
            t.Do();
            operations.Push(t);
        }

        public void DeleteTask()
        {

        }
    }
}
