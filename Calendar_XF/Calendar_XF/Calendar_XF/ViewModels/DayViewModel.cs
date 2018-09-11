﻿using Calendar_XF.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Calendar_XF.ViewModels
{
    public class DayViewModel : ViewModelBase
    {
        private DayModel _dayModel;
        private Color _selectedColor;

        public event EventHandler OnSelected;

        public DayViewModel(DayModel dayModel)
        {
            _dayModel = dayModel;

            DayClick = new Command(() =>
            {
                if (_dayModel.Date != DateTime.MinValue)
                    _dayModel.Selected = !dayModel.Selected;

                SelectedColor = _dayModel.Selected ? Color.FromHex("#00B0F6") : Color.Transparent;

                if (OnSelected != null)
                    OnSelected(this, new EventArgs());
            });
        }

        public ICommand DayClick { get; protected set; }

        public string Text
        {
            get
            {
                if (_dayModel.Date != DateTime.MinValue)
                    return _dayModel.Date.Day.ToString();
                return " ";
            }
            set
            {
                if (value != _dayModel.Date.Day.ToString())
                    OnPropertyChanged(nameof(Text));
            }
        }

        public Color SelectedColor
        {
            get { return _selectedColor; }
            set
            {
                if (value != _selectedColor)
                {
                    _selectedColor = value;

                    OnPropertyChanged(nameof(SelectedColor));
                }
            }
        }
        
    }
}
