﻿using Calendar_XF.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Calendar_XF.ViewModels
{
    public class CalendarViewModel : ViewModelBase
    {
        public event EventHandler<DayModel[,]> OnMakeCalendar;

        private Calendar_XF.Models.CalendarModel _calendar;

        public CalendarViewModel()
        {
            _calendar = new Calendar_XF.Models.CalendarModel(DateTime.Now);

            this.PriorCommand = new Command(() =>
            {
                _calendar.PriorMonth();

                OnPropertyChanged(nameof(YearMonthLabel));
                OnPropertyChanged(nameof(SelectedDates));

                this.RefreshChanges();
            });

            this.NextCommand = new Command(() =>
            {
                _calendar.NextMonth();

                OnPropertyChanged(nameof(YearMonthLabel));
                OnPropertyChanged(nameof(SelectedDates));

                this.RefreshChanges();
            });

        }

        #region [ Commands ]

        public ICommand NextCommand { get; protected set; }

        public ICommand PriorCommand { get; protected set; }

        #endregion

        public ObservableCollection<DayModel> SelectedDates
        {
            get
            {
                return _calendar.GetSelectedDates();
            }
        }

        public void Draw()
        {
            this.RefreshChanges();
        }

        public string YearMonthLabel
        {
            get { return $"{CultureInfo.CurrentUICulture.DateTimeFormat.AbbreviatedMonthNames[_calendar.CurrentMonth - 1]} / {_calendar.CurrentYear} "; }
        }

        public void UpdateSelectedDates()
        {
            OnPropertyChanged(nameof(SelectedDates));
        }

        private void RefreshChanges()
        {
            OnMakeCalendar?.Invoke(this, _calendar.CurrentCalendar);
        }
    }
}
