using Presenter;
using Model;

namespace Taskey
{
    public class View : IView
    {
        public View(Form form) 
        {
            this._form = form;
            CreateLayout();
            AddListeners();
        }

        private readonly Form _form;

        public event EventHandler<TaskSettings> OnCreateTask;
        public event EventHandler<Task> OnDeleteTask;

        public ListBox TaskListBox { get; private set; }
        public Button CreateButton { get; private set; }
        public Button DeleteButton { get; private set; }

        public TextBox TaskNameTextBox { get; private set; }
        public TextBox TaskDescriptionTextBox { get; private set; }

        public Label DueDateLabel { get; private set; }
        public DateTimePicker DueDatePicker { get; private set; }


        #region Create layout
        public void CreateLayout()
        {
            // Get the screen resolution
            var screenBounds = Screen.PrimaryScreen.Bounds;

            // Set form size to, say, 80% of screen width and height
            _form.Width = screenBounds.Width;
            _form.Height = screenBounds.Height;

            _form.StartPosition = FormStartPosition.CenterScreen;
            _form.Text = "Taskey";

            // Control panel at top
            var controlPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                Height = (int)(_form.Height * 0.1),
                FlowDirection = FlowDirection.LeftToRight,
                Padding = new Padding(5),
                AutoSize = false
            };

            CreateButton = new Button 
            { 
                Text = "Create",
                Width = controlPanel.Height / 2,
                Height = controlPanel.Height / 2,
            };
            DeleteButton = new Button 
            { 
                Text = "Delete", 
                Width = controlPanel.Height / 2,
                Height = controlPanel.Height / 2,
            };

            controlPanel.Controls.Add(CreateButton);
            controlPanel.Controls.Add(DeleteButton);

            // List panel on the left
            TaskListBox = new ListBox
            {
                Dock = DockStyle.Left,
                Width = (int)(_form.Height * 0.2),
                Height = (int)(_form.Height * 0.7)
            };

            TaskListBox.SelectedIndexChanged += (sender, e) =>
            {
                if (TaskListBox.SelectedItem is TaskSettings selectedTask)
                {
                    TaskNameTextBox.Text = selectedTask.name;
                    TaskDescriptionTextBox.Text = selectedTask.description;
                    DueDatePicker.Value = selectedTask.dueDate;
                }
            };

            // Detail panel in the center/right
            var detailPanel = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(10)
            };

            var nameLabel = new Label { Text = "Name:", Top = 10, Left = 10, AutoSize = true };
            TaskNameTextBox = new TextBox { Top = 30, Left = 10, Width = 300 };

            var descriptionLabel = new Label { Text = "Description:", Top = 70, Left = 10, AutoSize = true };
            TaskDescriptionTextBox = new TextBox
            {
                Top = 90,
                Left = 10,
                Width = 300,
                Height = 100,
                Multiline = true
            };

            TaskNameTextBox.Margin = new Padding(0, 5, 0, 10);
            TaskDescriptionTextBox.Margin = new Padding(0, 5, 0, 10);

            // Due date picker
            DueDateLabel = new Label();
            DueDateLabel.Text = "Due Date:";
            DueDateLabel.Top = 200; // adjust this as needed
            DueDateLabel.Left = 10;
            DueDateLabel.AutoSize = true;
            DueDateLabel.Margin = new Padding(0, 5, 0, 0);

            DueDatePicker = new DateTimePicker();
            DueDatePicker.Format = DateTimePickerFormat.Short;
            DueDatePicker.Top = 220; // slightly below the label
            DueDatePicker.Left = 10;
            DueDatePicker.Margin = new Padding(0, 0, 0, 10);

            detailPanel.Controls.Add(nameLabel);
            detailPanel.Controls.Add(TaskNameTextBox);
            detailPanel.Controls.Add(descriptionLabel);
            detailPanel.Controls.Add(TaskDescriptionTextBox);
            detailPanel.Controls.Add(DueDateLabel);
            detailPanel.Controls.Add(DueDatePicker);

            // Add panels to form
            _form.Controls.Add(detailPanel);
            _form.Controls.Add(TaskListBox);
            _form.Controls.Add(controlPanel);
        }
        #endregion

        private void AddListeners()
        {
            CreateButton.Click += (s, e) =>
            {
                var newTaskSettings = new TaskSettings(TaskNameTextBox.Text, TaskDescriptionTextBox.Text, false, DueDatePicker.Value) ;
                OnCreateTask?.Invoke(this, newTaskSettings);
            };

        }

        public void UpdateAfterCreation(TaskSettings taskSettings)
        {
            TaskListBox.Items.Add(taskSettings);
        }


    }
}
