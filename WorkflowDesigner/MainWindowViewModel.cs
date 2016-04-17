using Microsoft.Win32;
using System;
using System.Activities;
using System.Activities.Presentation;
using System.Activities.Presentation.Toolbox;
using System.Activities.Statements;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text.RegularExpressions;
using System.Windows;
using System.Xml.Linq;

namespace Workflow.Designer {
    public class MainWindowViewModel : INotifyPropertyChanged {

        #region properties
        public string Title { get; private set; }
        public ToolboxControl Toolbox { get; private set; }
        public WorkflowDesigner Designer { get; set; }

        private UIElement _propertyInspector;
        public UIElement PropertyInspector {
            get { return _propertyInspector; }
            set {
                _propertyInspector = value;
                FirePropertyChanged("PropertyInspector");
            }
        }

        #endregion

        #region INotifyPropertyChanged
        
        private void FirePropertyChanged(string propertyName) {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged; 
        
        #endregion

        #region constructor
        public MainWindowViewModel() {

            this.Title = "Activity Designer";

            this.Toolbox = new ToolboxProvider().Toolbox;

            AddDesigner(true);

            AddPropertyInspector();

        }

        #endregion

        #region events

        public void LoadClicked() {
        }

        public void NewClicked() {
        }

        public void SaveClicked() {
        }

        internal void RunClicked() {
        }

        #endregion

        #region designer
        private void AddDesigner(bool loadBlank) {
            //Create an instance of WorkflowDesigner class.
            this.Designer = new WorkflowDesigner();

            //Load a new Sequence as default.
            if (loadBlank) {

                ActivityBuilder activityBuilderType = new ActivityBuilder();
                activityBuilderType.Name = "Activity Builder";
                activityBuilderType.Implementation = new Flowchart() {
                    DisplayName = "Default Template"
                };

                this.Designer.Load(activityBuilderType);

            }

            PropertyInspector = this.Designer.PropertyInspectorView;

        }

        private void AddPropertyInspector() {
            PropertyInspector = this.Designer.PropertyInspectorView;
        } 
        #endregion

    }

}
