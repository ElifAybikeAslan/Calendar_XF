﻿using Calendar_XF.Models;
using Calendar_XF.ViewModels;
using Calendar_XF.Views.Template;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Calendar_XF.Views
{
    public partial class CalendarView : ContentPage
    {
        public CalendarView()
        {
            InitializeComponent();

            CalendarViewModel vm = new CalendarViewModel();
            BindingContext = vm;

            vm.OnMakeCalendar += Vm_OnMakeCalendar;

            gridControls.BackgroundColor = Color.FromHex("#00B0F6");
            gridCalendar.BackgroundColor = Color.FromHex("#F4F4F4");

            vm.Draw();

            SetDaysOfWeekNames();
        }

        private void Vm_OnMakeCalendar(object sender, Models.DayModel[,] e)
        {
            stklSun.Children.Clear();
            stklMon.Children.Clear();
            stklTue.Children.Clear();
            stklWed.Children.Clear();
            stklThu.Children.Clear();
            stklFri.Children.Clear();
            stklSat.Children.Clear();

            for (int i = 0; i < e.GetLength(0); i++)
            {
                SetItem(stklSun, i, 0, e);
                SetItem(stklMon, i, 1, e);
                SetItem(stklTue, i, 2, e);
                SetItem(stklWed, i, 3, e);
                SetItem(stklThu, i, 4, e);
                SetItem(stklFri, i, 5, e);
                SetItem(stklSat, i, 6, e);
            }
        }

        private void SetItem(StackLayout stk, int line, int col, Models.DayModel[,] calendar)
        {
            DayViewTemplate tpl = null;

            if (calendar[line, col] != null)
                tpl = new DayViewTemplate(calendar[line, col]);
            else
                tpl = new DayViewTemplate(DayModel.GetDayNothing());

            tpl.OnSelected += Tpl_OnSelected;

            stk.Children.Add(tpl);
        }

        private void Tpl_OnSelected(object sender, EventArgs e)
        {
            ((CalendarViewModel)BindingContext).UpdateSelectedDates();
        }

        private void SetDaysOfWeekNames()
        {
            lblSun.Text = CultureInfo.CurrentUICulture.DateTimeFormat.AbbreviatedDayNames[0];
            lblMon.Text = CultureInfo.CurrentUICulture.DateTimeFormat.AbbreviatedDayNames[1];
            lblTue.Text = CultureInfo.CurrentUICulture.DateTimeFormat.AbbreviatedDayNames[2];
            lblWed.Text = CultureInfo.CurrentUICulture.DateTimeFormat.AbbreviatedDayNames[3];
            lblThu.Text = CultureInfo.CurrentUICulture.DateTimeFormat.AbbreviatedDayNames[4];
            lblFri.Text = CultureInfo.CurrentUICulture.DateTimeFormat.AbbreviatedDayNames[5];
            lblSat.Text = CultureInfo.CurrentUICulture.DateTimeFormat.AbbreviatedDayNames[6];
        }
    }
}