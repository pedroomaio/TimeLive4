using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using RadiantQ.Windows.Controls.Gantt;
using RadiantQ.Windows.Controls.Gantt.View;
using RadiantQ.Windows.Controls.Gantt.Model;
using System.Windows.Data;
using RadiantQ.Windows.Controls.Gantt.Utils;
using ProjectManagement.SRProjectTask;
using ProjectManagement.SREmployee;
using System.Globalization;
using RadiantQ.Windows.Controls.Gantt.Primitives;
using System.ServiceModel;

namespace ProjectManagement
{
    public partial class MainPage : UserControl
    {
        public bool IsWorking
        {
            get { return myProgressbar.IsIndeterminate; }
            set { myProgressbar.IsIndeterminate = value; }

        }
        private readonly TaskServiceClient mService = WCFHelper.CreateService<TaskServiceClient >(WebServiceUtilities.GetTaskServiceURI());
        private readonly EmployeeServiceClient employeeService = WCFHelper.CreateService<EmployeeServiceClient >(WebServiceUtilities.GetEmployeeServiceURI());
        private readonly MouseClickManager _gridClickManager;
        int TotalTaskUpdating = 0;
        int TotalTaskUpdated = 0;

        public MainPage()
        {
            string asdf = string.Empty;
            InitializeComponent();
            StartProgressBar();    
            // To listen to double click on GanttTable:
            _gridClickManager = new MouseClickManager(200);
            this._gridClickManager.DoubleClick += new MouseButtonEventHandler(_gridClickManager_RowDoubleClick);
            EndpointAddress TaskServiceAddress = new EndpointAddress(WebServiceUtilities.GetTaskServiceURI());
            EndpointAddress EmployeeServiceAddress = new EndpointAddress(WebServiceUtilities.GetEmployeeServiceURI());
         
            mService.Endpoint.Address = TaskServiceAddress;
            employeeService.Endpoint.Address = EmployeeServiceAddress;
            mService.ChannelFactory.Endpoint.Address = TaskServiceAddress;
            employeeService.ChannelFactory.Endpoint.Address = EmployeeServiceAddress;
          
            employeeService.GetEmployeesCompleted += new EventHandler<GetEmployeesCompletedEventArgs>(employeeService_GetEmployeesCompleted);
            employeeService.GetEmployeesAsync(Convert.ToInt32(System.Windows.Browser.HtmlPage.Document.QueryString["AccountProjectId"]),0);
            mService.DeleteAccountProjectTaskCompleted += new EventHandler<DeleteAccountProjectTaskCompletedEventArgs>(mservice_DeleteAccountProjectTaskCompleted);
            mService.UpdateAccountProjectTaskCompleted += new EventHandler<UpdateAccountProjectTaskCompletedEventArgs>(mservice_UpdateAccountProjectTaskCompleted);
            mService.GetTasksCompleted += new EventHandler<GetTasksCompletedEventArgs>(mService_GetTasksCompleted);
            mService.AddAccountProjectTaskCompleted += new EventHandler<AddAccountProjectTaskCompletedEventArgs>(mservice_AddAccountProjectTaskCompleted);
            mService.SetPermissionForTaskCompleted += new EventHandler<SetPermissionForTaskCompletedEventArgs>(mService_SetPermissionForTaskCompleted);
            mService.SetPermissionForTaskAsync();
            this.ganttControl.WorkTimeSchedule = CreateCustomScheduleForLoginEmployee();
            this.ganttControl.TemplateApplied += new EventHandler(ganttControl_TemplateApplied);
         }
        void ganttControl_TemplateApplied(object sender, EventArgs e)
        {
            this.ganttControl.GanttTable.Columns[6].Visibility = Visibility.Collapsed;
            this.ganttControl.GanttTable.LoadingRow += new EventHandler<DataGridRowEventArgs>(GanttTable_LoadingRow);
            this.ganttControl.GanttTable.UnloadingRow += new EventHandler<DataGridRowEventArgs>(GanttTable_UnloadingRow);
            this.ganttControl.GanttTable.SelectedRowsDrag += new SelectedRowsDragEventHandler(GanttTable_SelectedRowsDrag);
            // Remove the built-in Effort column.
            this.ganttControl.GanttTable.Columns.RemoveAt(4);
            // Add a custom Effort column
            this.ganttControl.GanttTable.Columns.Insert(4, this.LayoutRoot.Resources["effortColumnTemplate"] as DataGridTemplateColumn);
            // Add a custom Description column
            this.ganttControl.GanttTable.Columns.Insert(8, this.LayoutRoot.Resources["descColumnTemplate"] as DataGridTemplateColumn);
            //this.ganttControl.DescriptionBinding = new Binding("Description");
            // To Freeze columns:
            this.ganttControl.GanttTable.FrozenColumnCount = 2;
            // While dragging rows, enable dropping as a child of another row.
            this.ganttControl.GanttTable.EnableDropAsChild = true;

            this.ganttControl.SyncRowBackgrounds = true;
            this.ganttControl.GanttTable.CanUserSortColumns = true;
           
        }
        #region LISTENING TO TASK DRAG AND CANCELLING DROP
        void GanttTable_SelectedRowsDrag(object sender, SelectedRowsDragEventArgs args)
        {
            //IActivityView selectedView = this.ganttControl.GanttTable.SelectedItem as IActivityView;
            //TaskInfo selectedTask = ((DataBoundActivity)selectedView.Activity).DataSource as TaskInfo;

            //// Note that "selectedView.Activity.Parent" will give you the parent of an activity.

            //if (args.DragOverRowIndex == 0)
            //{
            //    // can it be dropped way on top?
            //}
            //else if (args.DragOverRowIndex == this.ganttControl.ActivityViews.Count)
            //{
            //    // can the selected task be dropped way at the bottom?
            //}
            //else
            //{
            //    TaskInfo dropTask = ((DataBoundActivity)this.ganttControl.ActivityViews[args.DragOverRowIndex].Activity).DataSource as TaskInfo;
            //    // Can the selected task be dropped above this?
            //}
            //// Right now using this simple logic.
            //if (selectedTask.IndentLevel == 0)
            //    args.Cancel = true;
        }
        #endregion

        #region Showing a child window on row double click. Click on the ID column cells for example.
        void GanttTable_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.MouseLeftButtonUp += _gridClickManager.HandleClick;
        }

        void GanttTable_UnloadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.MouseLeftButtonUp -= _gridClickManager.HandleClick;
        }


        void _gridClickManager_RowDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // The GanttActivityView is how a DataBoundActivity gets rendered in the gantt table and chart.
            IActivityView activityView = ((DataGridRow)sender).DataContext as IActivityView;
            // The DataBoundActivity is the Gantt's Model that wraps around the underlying bound "task" type.
            // ((DataBoundActivity)activityView).DataSource is the bound TaskInfo instance.
            IActivity activity = activityView.Activity;

            TaskEditingWindow window = new TaskEditingWindow(activity, this.ganttControl);
            window.Show();
        }
        #endregion

        public WorkTimeSchedule CreateCustomScheduleByEmployee(int EmployeeId, List<object> WorkingDays, double HoursPerDay, List<object> HolidayDays)
        {
            return new WorkTimeSchedule("Custom Schedule",
                // This delegate defines your schedule
                delegate(DateTime date)
                {
                    // Holidays for 2011
                    if (HolidayDays.Contains(date.Date))
                        return null;

                    if (WorkingDays.Contains(date.DayOfWeek.ToString()))
                    {
                        TimePeriodCollection intervals = new TimePeriodCollection();
                        intervals.Add(new TimePeriod(date.AddHours(HoursPerDay), TimeSpan.FromHours(HoursPerDay)));
                        return intervals;
                    }
                    else
                    {
                        return null;
                    }
                });
        }
        public static WorkTimeSchedule CreateCustomScheduleForLoginEmployee()
        {
            return new WorkTimeSchedule("8X7",
                // This delegate defines your schedule
                delegate(DateTime date)
                {
                    TimePeriodCollection intervals = new TimePeriodCollection();
                    intervals.Add(new TimePeriod(date.AddHours(8), TimeSpan.FromHours(8)));
                    return intervals;
                }
                );
        }
        private void mService_SetPermissionForTaskCompleted(object sender, SetPermissionForTaskCompletedEventArgs e)
        {
           ProjectTask c = e.Result[0];
                if (c.IsViewPermission == false)
                { 
                    this.ganttControl.Visibility = Visibility.Collapsed ;
                }
                if (c.IsAddPermission == false)
                { 
                    Add.Visibility  = Visibility.Collapsed ;
                }
                if (c.IsUpdatePermission == false)
                { 
                    Update.Visibility  = Visibility.Collapsed ;
                }
                if (c.IsDeletePermission == false)
                {
                    Delete.Visibility  = Visibility.Collapsed;
                }
         }
       private void mService_GetTasksCompleted(object sender, GetTasksCompletedEventArgs e)
        {
            List<TaskInfo> taskItems = new List<TaskInfo>();
            foreach (ProjectTask c in e.Result)
            {
                taskItems.Add(new TaskInfo {ID = c.ID, Name = c.Name, StartTime = c.StartTime, Effort = c.Effort, Resources = c.Resources, IndentLevel = c.IndentLevel, ProgressPercent = c.ProgressPercent, Description= c.Description, PredecessorIndices = c.Predecessor});
            }

            this.ganttControl.ItemsSource = taskItems;
            StopProgressBar();
        }
        private void mservice_AddAccountProjectTaskCompleted(object sender, AddAccountProjectTaskCompletedEventArgs e)
        {
            foreach (ProjectTask c in e.Result)
            {
                TaskInfo newTask = new TaskInfo() { ID = c.ID, StartTime = c.StartTime, Effort = c.Effort, Name = c.Name, Description = c.Description };
                if (this.ganttControl.ActivityViews.Count == 0)
                {
                    this.ganttControl.AddNewItem(newTask);
                }
                else 
                    if (c.ID != this.ganttControl.ActivityViews[this.ganttControl.ActivityViews.Count - 1].Activity.ID)
                {
                    this.ganttControl.AddNewItem(newTask);
                }
            }
            StopProgressBar();
        }
        private void mservice_UpdateAccountProjectTaskCompleted(object sender, UpdateAccountProjectTaskCompletedEventArgs e)
        {
            TotalTaskUpdated += 1;
            if (TotalTaskUpdating == TotalTaskUpdated)
            {
                StopProgressBar();
                TotalTaskUpdating = 0;
                TotalTaskUpdated = 0;
            }
        }
        private void mservice_DeleteAccountProjectTaskCompleted(object sender, DeleteAccountProjectTaskCompletedEventArgs  e)
        {
            if (e.Error == null && e.Result != null)
            { 
                // Get the selected activity.
                IActivity activity = this.ganttControl.SelectedActivity;
                if (activity != null)
                {
                    // First remove that activity from the GanttControl.
                    int id = activity.ID;
                    // RemoveActivity method will remove the specified activity's children as well.
                    IList<IActivity> removedTasks = this.ganttControl.RemoveActivity(id);

                    // Then remove the activities from the bound list.
                    List<TaskInfo> taskinfos = this.ganttControl.ItemsSource as List<TaskInfo>;

                    foreach (IActivity task in removedTasks)
                    {
                        taskinfos.Remove(((DataBoundActivity)task).DataSource as TaskInfo);
                    }
               }
            }
            else if (e.Error != null)
            {
                MessageBox.Show("Cannot delete data because of existing dependent data.");
            }
            StopProgressBar();
        }
     private void employeeService_GetEmployeesCompleted(object sender, GetEmployeesCompletedEventArgs  e)
        {
          if (e.Error == null && e.Result != null)
            {
                // Consume the result
                List<ResourceInfo> resList = new List<ResourceInfo>();
                foreach (ProjectTaskEmployee c in e.Result)
                {
                    int EmployeeId = c.ID;
                    WorkTimeSchedule WTSCreateCustomScheduleByEmployee = CreateCustomScheduleByEmployee(EmployeeId,c.WorkingDays,c.HoursPerDay,c.HolidayDays);
                    resList.Add(new ResourceInfo() { ResourceID = c.ID, ResourceName = c.Name, CustomSchedule = WTSCreateCustomScheduleByEmployee });
                    }
                this.ganttControl.ResourceItemsSource = resList;
            }
           mService.GetTasksAsync(Convert.ToInt32(System.Windows.Browser.HtmlPage.Document.QueryString["AccountProjectId"]));
        }
     private void Add_Click(object sender, RoutedEventArgs e)
     {
         StartProgressBar();      
         DateTime startTime = TimeComputingUtils.ToUtcKind(DateTime.Today);
         if (this.ganttControl.WorkTimeSchedule != null)
             startTime = this.ganttControl.WorkTimeSchedule.ConvertToNextWorkingTime(startTime);

         // This will also add the task to the bound list (if the bound list implements IList)
         // If the bound list does not implement IList, then add the CustomTask manually to the bound list.
         TimeSpan effort = TimeSpan.FromHours(8);
         string TaskName = "New Task";
         string TaskDescription = "New Task Description";
         int AccountProjectId = Convert.ToInt32(System.Windows.Browser.HtmlPage.Document.QueryString["AccountProjectId"]);
         DateTime deadlinedate = startTime + effort;
         mService.AddAccountProjectTaskAsync(AccountProjectId, 0, TaskName, TaskDescription, 0, deadlinedate, startTime,8,"");
     }
     private void Update_Click(object sender, RoutedEventArgs e)
     {
         StartProgressBar();
         int ParentAccountProjectTaskId = 0 ;
         //int SaveParentAccountProjectTaskId = 0;
         //int LastParentAccountProjectTaskId = 0;
         for (int i = 0; i < this.ganttControl.ActivityViews.Count; i++)
         {
             //if (this.ganttControl.ActivityViews[i].IsParent == true)
             //{
             //    SaveParentAccountProjectTaskId = this.ganttControl.ActivityViews[i].Activity.ID;
             //}
             //if (this.ganttControl.ActivityViews[i].IndentLevel > 0)
             //{
             //    if (this.ganttControl.ActivityViews[i].IsParent == false)
             //    {
             //        ParentAccountProjectTaskId = SaveParentAccountProjectTaskId;
             //    }
             //    else if (this.ganttControl.ActivityViews[i].IsParent == true)
             //    {
             //        ParentAccountProjectTaskId = LastParentAccountProjectTaskId;
             //    }
             //}
             //else
             //{
             //    ParentAccountProjectTaskId = 0;
             //}
             //if (this.ganttControl.ActivityViews[i].IsParent == true)
             //{
             //    LastParentAccountProjectTaskId = this.ganttControl.ActivityViews[i].Activity.ID;
             //}
             if (this.ganttControl.ActivityViews[i].ParentActivity != null)
             {
                 ParentAccountProjectTaskId = this.ganttControl.ActivityViews[i].ParentActivity.ID;
             }
             else
             {
                 ParentAccountProjectTaskId = 0;
             }
            mService.UpdateAccountProjectTaskAsync(Convert.ToInt32(System.Windows.Browser.HtmlPage.Document.QueryString["AccountProjectId"]), ParentAccountProjectTaskId, this.ganttControl.ActivityViews[i].Activity.ActivityName, this.ganttControl.ActivityViews[i].Activity.Description, this.ganttControl.ActivityViews[i].Activity.ProgressPercent, this.ganttControl.ActivityViews[i].Activity.EndTime, this.ganttControl.ActivityViews[i].Activity.ID, this.ganttControl.ActivityViews[i].Activity.StartTime, this.ganttControl.ActivityViews[i].IsParent, this.ganttControl.ActivityViews[i].Activity.Effort.TotalHours,this.ganttControl.ActivityViews[i].Activity.PredecessorIndexString );
            TotalTaskUpdating += 1;
         }
     }

     private void Delete_Click(object sender, RoutedEventArgs e)
     {
         StartProgressBar();
         // Get the selected activity.
         IActivity activity = this.ganttControl.SelectedActivity;
         if (activity != null)
         {
             int id = activity.ID;
             mService.DeleteAccountProjectTaskAsync(id);
         }
         else
         {
             StopProgressBar();
         }
      }
     public void StartProgressBar()
     {
         myProgressbar.Visibility = Visibility.Visible;
         this.IsWorking = true;
         Add.IsEnabled = false;
         Update.IsEnabled = false;
         Delete.IsEnabled = false;
         Resource.IsEnabled = false;
         ganttControl.IsEnabled = false;
     }
     public void StopProgressBar()
     {
         this.IsWorking = false;
         myProgressbar.Visibility = Visibility.Collapsed;
         Add.IsEnabled = true;
         Update.IsEnabled = true;
         Delete.IsEnabled = true;
         Resource.IsEnabled = true;
         ganttControl.IsEnabled = true;
     }

     private void Resource_Click(object sender, RoutedEventArgs e)
     {
         // The GanttActivityView is how a DataBoundActivity gets rendered in the gantt table and chart.
         IActivity activity = this.ganttControl.SelectedActivity;
         // The DataBoundActivity is the Gantt's Model that wraps around the underlying bound "task" type.
         // ((DataBoundActivity)activityView).DataSource is the bound TaskInfo instance.
         if (activity != null)
         {
             TaskEditingWindow window = new TaskEditingWindow(activity, this.ganttControl);
             window.Show();
         }
         else
         {
             MessageBox.Show("Please select a task.");
         }
    }
    //MainPage End ({)
    }
    /// <summary>
    /// A sample type that represents a resource
    /// </summary>
    public class ResourceInfo
    {
        public int ResourceID{get; set;}
        public string ResourceName{get; set;}
        public WorkTimeSchedule CustomSchedule { get; set; }
    }
    /// <summary>
    /// An updown control to edit TimeSpan as hours.
    /// </summary>
    public class EffortAsHoursPicker : RefreshableUpDownBase<TimeSpan>
    {
        public double MaxValue { get; set; }
        public double MinValue { get; set; }
        public EffortAsHoursPicker()
        {
            Value = TimeSpan.Zero;
            IsTabStop = false;
            this.MinValue = 0;
            this.MaxValue = double.MaxValue;
        }

        protected override void OnIncrement()
        {
            double curHours = (double)this.Value.TotalHours;

            if (curHours == this.MaxValue)
                curHours = this.MinValue;
            else
                curHours++;

            this.Value = TimeSpan.FromHours(curHours);
        }

        protected override void OnDecrement()
        {
            double curHours = (double)this.Value.TotalHours;

            if (curHours == this.MinValue)
                curHours = this.MaxValue;
            else
                curHours--;

            this.Value = TimeSpan.FromHours(curHours);
        }

        protected override TimeSpan ParseValue(string text)
        {
            double hours = double.Parse(text);
            return TimeSpan.FromHours(hours);
        }

        protected override string FormatValue()
        {
            return Math.Round(Value.TotalHours,2).ToString();
        }
    }
    // Converts TimeSpan to hours.
    public class TimeSpanToHoursConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            TimeSpan ts = (TimeSpan)value;
            return ts.TotalHours;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
