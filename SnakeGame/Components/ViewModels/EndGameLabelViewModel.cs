using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Components.ViewModels
{
    public class EndGameLabelViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region Props

        private Color androidColor;
        public Color AndroidColor
        {
            get => androidColor;
            set
            {
                androidColor = value;
#if ANDROID
                this.CustomTextColor = value;
#endif
            }
        }

        private Color windowsColor;
        public Color WindowsColor
        {
            get => windowsColor;
            set
            {
                windowsColor = value;
#if WINDOWS
                this.CustomTextColor = value;
#endif
            }
        }

        private Color customTextColor;
        public Color CustomTextColor
        {
            get => customTextColor;
            set => customTextColor = value;
        }
        #endregion

        #region Constructor
        public EndGameLabelViewModel()
        {
            this.WindowsColor = Colors.Aqua;
            this.AndroidColor = Colors.Green;
        }
        #endregion
    }
}
