using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MahApps.Metro.IconPacks;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace DeltaMemo
{
    public class MemoListModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _queryText;

        public string QueryText
        {
            get
            {
                return _queryText;
            }
            set
            {
                _queryText = value;
                NotifyPropertyChanged(nameof(QueryText));
            }
        }

        private List<Content> _contents = new List<Content>();

        public List<Content> Contents
        {
            get
            {
                return _contents;
            }
            set
            {
                _contents = value;
                NotifyPropertyChanged(nameof(Contents));
            }
        }

        private Visibility _listVisibility = Visibility.Visible;

        public Visibility ListVisibility
        {
            get
            {
                return _listVisibility;
            }
            set
            {
                _listVisibility = value;
                NotifyPropertyChanged(nameof(ListVisibility));
            }
        }

        private Visibility _optionVisibility = Visibility.Hidden;

        public Visibility OptionVisibility
        {
            get
            {
                return _optionVisibility;
            }
            set
            {
                _optionVisibility = value;
                NotifyPropertyChanged(nameof(OptionVisibility));
            }
        }
    }
}
