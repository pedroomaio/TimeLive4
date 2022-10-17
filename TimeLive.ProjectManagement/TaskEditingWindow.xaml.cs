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
using RadiantQ.Windows.Controls.Gantt.Model;
using System.Collections.ObjectModel;
using System.Windows.Data;
using System.Collections;
using RadiantQ.Windows.Controls.Gantt.Utils;
using ProjectManagement.SREmployee;
using System.ServiceModel;
namespace ProjectManagement
{
    // This sample illustrates how to bring up a dialog when the user double-clicks on a row in the list on the left.
    // This sample illustrates editing the resources. You can update it to edit anything in the task.
    public partial class TaskEditingWindow : ChildWindow
    {
        IActivity _editedActivity;
        GanttControl _gc;
        ObservableCollection<EditableAssignment> _localAssgnColl;
        private readonly EmployeeServiceClient employeeService = WCFHelper.CreateService<EmployeeServiceClient>(WebServiceUtilities.GetEmployeeServiceURI());

        internal static List<String> ResourcesList;
        int AccountEmployeeId;

        public TaskEditingWindow(IActivity editedActivity, GanttControl gc)
        {
            InitializeComponent();
            EndpointAddress EmployeeServiceAddress = new EndpointAddress(WebServiceUtilities.GetEmployeeServiceURI());
            employeeService.Endpoint.Address = EmployeeServiceAddress;
            employeeService.ChannelFactory.Endpoint.Address = EmployeeServiceAddress;
            this._editedActivity = editedActivity;
            this._gc = gc;

            // Create a local collection that is convenient to bind to the DataGrid in this window.
            this._localAssgnColl = this.GetEditableAssignmentsCollection();
            this.resourceAssignmentsGrid.ItemsSource = this._localAssgnColl;

            employeeService.AddAccountProjectTaskEmployeeCompleted += new EventHandler<AddAccountProjectTaskEmployeeCompletedEventArgs>(employeeService_AddAccountProjectTaskEmployeeCompleted);
            employeeService.DeleteAccountProjectTaskEmployeeCompleted += new EventHandler<DeleteAccountProjectTaskEmployeeCompletedEventArgs>(employeeService_DeleteAccountProjectTaskEmployeeCompleted);
            // Canching the bound resource names list in a static field.
            // Create a list of strings, since we are only interested in the resource names in this context.
            ResourcesList = new List<String>();
            // In this sample the resource is represented by the ResourceInfo type, so we parse through the list and retrieve just the names of the resources.
            // If the resource list is just a string array, then the code here will look much simpler.
            foreach (ResourceInfo ri in this._gc.ResourceItemsSource)
            {
                ResourcesList.Add(ri.ResourceName);
            }
        }
        private ObservableCollection<EditableAssignment> GetEditableAssignmentsCollection()
        {
            ObservableCollection<EditableAssignment> list = new ObservableCollection<EditableAssignment>();
            foreach (ResourceAssignment assgn in this._editedActivity.Assignments)
            {
                EditableAssignment eassgn = new EditableAssignment(this._gc.Model.GanttResources)
                {
                    ResourceID = assgn.Resource.ResourceID,
                    ResourceName = assgn.Resource.ResourceName,
                    AllocationUnits = assgn.AllocationUnits
                };
                list.Add(eassgn);
            }
            return list;
        }
        // Update the task's assignments based on the assignments that the user added/changed in the DataGrid.
        private void UpdateActivityAssignment(ObservableCollection<EditableAssignment> localAssgns)
        {
            int dtcount = 0;
            if (this._editedActivity.Assignments.Count > 0)
            { 
            foreach (EditableAssignment localAssgn in localAssgns)
            {
                if (localAssgn.ResourceID != null)
                {
                    IGanttResource matchingRes = this._gc.Model.GanttResources[localAssgn.ResourceID.Trim()];
                    if (matchingRes != null)
                    {
                        if (this._editedActivity.Assignments.ContainsResource(matchingRes) == false)
                        {
                            if (this._editedActivity.Assignments.Count > dtcount)
                            {
                                employeeService.DeleteAccountProjectTaskEmployeeAsync(this._gc.SelectedActivity.ID, Convert.ToInt32(this._editedActivity.Assignments[dtcount].Resource.ResourceID));
                            }
                        }
                    }
                    dtcount += 1;
                }
            }
            }
            this._editedActivity.Assignments.Clear();
            // Embedding some method calls within this DelayUpdates block will delay UI updates in the GanttControl
            // resulting in better performance.
            using (new DelayUpdates())
            {
                foreach (EditableAssignment localAssgn in localAssgns)
                {
                    if (localAssgn.ResourceID != null)
                    { 
                    IGanttResource matchingRes = this._gc.Model.GanttResources[localAssgn.ResourceID.Trim()];
                     
                    if (matchingRes != null)
                     {
                        if (this._editedActivity.Assignments.ContainsResource(matchingRes) == false)
                        { 
                            this._editedActivity.Assignments.Add(new ResourceAssignment(matchingRes , localAssgn.AllocationUnits <= 0 ? 100 : localAssgn.AllocationUnits));
                            employeeService.AddAccountProjectTaskEmployeeAsync(Convert.ToInt32(System.Windows.Browser.HtmlPage.Document.QueryString["AccountProjectId"]), this._gc.SelectedActivity.ID, Convert.ToInt32(matchingRes.ResourceID), Convert.ToDecimal(localAssgn.AllocationUnits <= 0 ? 100 : localAssgn.AllocationUnits));
                        }
                     }
                    }
                }
            }
        }
        private void employeeService_AddAccountProjectTaskEmployeeCompleted(object sender, AddAccountProjectTaskEmployeeCompletedEventArgs  e)
        {
         
        }
        private void employeeService_DeleteAccountProjectTaskEmployeeCompleted(object sender, DeleteAccountProjectTaskEmployeeCompletedEventArgs e)
        {

        }
        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            this.UpdateActivityAssignment(this._localAssgnColl);
            this.DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            this._localAssgnColl.Add(new EditableAssignment(this._gc.Model.GanttResources) { ResourceName = "(Edit This)", AllocationUnits = 100 });
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (this.resourceAssignmentsGrid.SelectedItem != null)
             {  
                AccountEmployeeId =  Convert.ToInt32(this._localAssgnColl[this.resourceAssignmentsGrid.SelectedIndex].ResourceID);
                int EmployeeSelectedIndex = this.resourceAssignmentsGrid.SelectedIndex;
                this._localAssgnColl.Remove(this.resourceAssignmentsGrid.SelectedItem as EditableAssignment);
                this._editedActivity.Assignments.RemoveAt(EmployeeSelectedIndex);
                employeeService.DeleteAccountProjectTaskEmployeeAsync(this._gc.SelectedActivity.ID, AccountEmployeeId);
            }
        }
    }

    // A simple, convenient local type for binding to the DataGrid.
    public class EditableAssignment
    {
        public string ResourceID { get; set; }
        private string _resName;
        public string ResourceName
        {
            get { return this._resName; }
            set
            {
                if (this._resName != value)
                {
                    this.ResourceID = null;
                    this._resName = value;
                    foreach (IGanttResource resource in this._resCollection)
                    {
                        if (resource.ResourceName == this._resName)
                        {
                            this.ResourceID = resource.ResourceID;
                            break;
                        }
                    }
                }
            }
        }
        public double AllocationUnits { get; set; }

        GanttResourcesCollection _resCollection;
        public EditableAssignment(GanttResourcesCollection resCollection)
        {
            this._resCollection = resCollection;
        }

    }

    // A way to provide the choice list to the combobox
    public class ResourceNamesListProvider : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return TaskEditingWindow.ResourcesList;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new Exception("Not Supported");
        }

        #endregion
    }

}

