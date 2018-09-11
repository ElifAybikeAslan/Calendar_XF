using Calendar_XF.Models;
using Calendar_XF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Calendar_XF.Views.Template
{
    public partial class DayViewTemplate : ContentView
    {
        public event EventHandler OnSelected;

        public DayViewTemplate(DayModel currentDay)
        {
            InitializeComponent();

            DayViewModel vm = new DayViewModel(currentDay);

            this.BindingContext = vm;

            vm.OnSelected += Vm_OnSelected;

            this.lblDay.AutomationId = string.Format("LabelDay_{0}", currentDay.Date.ToString("dd"));
        }

        private void Vm_OnSelected(object sender, EventArgs e)
        {
            OnSelected?.Invoke(this, new EventArgs());
        }
    }
}