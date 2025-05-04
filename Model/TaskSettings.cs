namespace Model
{
    public class TaskSettings
    {
        public TaskSettings(string name, string description, bool isDone, DateTime dueDate) 
        {
            this.name = name;
            this.description = description;
            this.dueDate = dueDate;
            this.isDone = isDone;
        }

        // Helps to determine, how tasks will be displayed in a list
        public override string ToString()
        {
            return name;
        }

        public string name;
        public string description;
        public bool isDone;
        public DateTime dueDate;
    }
}
