using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MahApps.Metro.IconPacks;
using System.ComponentModel;
using System.Windows;

namespace DeltaMemo
{
    public class MemoModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _dispaly = PackIconMaterialKind.EyeOutline.ToString();

        public string Display
        {
            get
            {
                return _dispaly;
            }
            set
            {
                _dispaly = value;
                NotifyPropertyChanged(nameof(Display));
            }
        }

        private string _inTop = PackIconMaterialKind.PinOffOutline.ToString();

        public string InTop
        {
            get
            {
                return _inTop;
            }
            set
            {
                _inTop = value;
                NotifyPropertyChanged(nameof(InTop));
            }
        }

        private int _lineHeight = 1;

        public int LineHeight
        {
            get
            {
                return _lineHeight;
            }
            set
            {
                _lineHeight = value;
                if (value == 1)
                {
                    CanIncreaseLineHeight = true;
                    CanDecreaseLineHeight = false;
                }
                if (value == 10)
                {
                    CanIncreaseLineHeight = false;
                    CanDecreaseLineHeight = true;
                }
                NotifyPropertyChanged(nameof(LineHeight));
            }
        }

        private bool _canIncreaseLineHeight = true;

        public bool CanIncreaseLineHeight
        {
            get
            {
                return _canIncreaseLineHeight;
            }
            set
            {
                _canIncreaseLineHeight = value;
                NotifyPropertyChanged(nameof(CanIncreaseLineHeight));
            }
        }

        private bool _canDecreaseLineHeight;

        public bool CanDecreaseLineHeight
        {
            get
            {
                return _canDecreaseLineHeight;
            }
            set
            {
                _canDecreaseLineHeight = value;
                NotifyPropertyChanged(nameof(CanDecreaseLineHeight));
            }
        }

        private Visibility _isShowToolbar = Visibility.Visible;

        public Visibility IsShowToolbar
        {
            get
            {
                return _isShowToolbar;
            }
            set
            {
                _isShowToolbar = value;
                NotifyPropertyChanged(nameof(IsShowToolbar));
            }
        }

        private string _toggleToolbarButtonText = PackIconMaterialKind.ChevronDown.ToString();

        public string ToggleToolbarButtonText
        {
            get
            {
                return _toggleToolbarButtonText;
            }
            set
            {
                _toggleToolbarButtonText = value;
                NotifyPropertyChanged(nameof(ToggleToolbarButtonText));
            }
        }

    }
}
