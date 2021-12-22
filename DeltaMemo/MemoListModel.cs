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

        private bool _isList = true;

        public bool IsList
        {
            get
            {
                return _isList;
            }
            set
            {
                _isList = value;
                NotifyPropertyChanged(nameof(IsList));
            }
        }

        private bool _isOption = false;

        public bool IsOption
        {
            get
            {
                return _isOption;
            }
            set
            {
                _isOption = value;
                NotifyPropertyChanged(nameof(IsOption));
            }
        }
    }
}
