
namespace Model
{
    internal class DeleteOperation : IOperation
    {
        public DeleteOperation(ModelController controller, Task task)
        {
            this.controller = controller;
            this.task = task;
        }

        private readonly ModelController controller;
        private readonly Task task;
        
        public void Do()
        {

        }

        public void Undo()
        {

        }
    }
}
