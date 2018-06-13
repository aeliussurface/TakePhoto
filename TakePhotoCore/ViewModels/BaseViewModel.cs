using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using TakePhotoCore.Common;
using TakePhotoCore.Resources;
using TakePhotoCore.UI.Helpers;
using Xamarin.Forms;

namespace TakePhotoCore.ViewModels
{
    public class BaseViewModel
    {
        public BaseViewModel()
        {
            ToggleMenu = new Command(ToggleMenuView, CanExecute);
        }

        public IUiContentPage Listener { get; set; }

        public bool IsBusy { get; protected set; }

        protected void ShowMessage(string title, string msg, Action<bool> onCompleted = null, string accept = "")
        {
            var message = new DisplayAlertMessage
            {
                Message = msg,
                Title = title,
                Accept = accept
            };

            message.OnCompleted += onCompleted;

            Listener.ShowMessage(message);
        }

        protected void UpdateProgress(string msg, int percent, Action onCompleted)
        {
            var progress = new UpdateProgress
            {
                Message = msg,
                Percent = percent
            };

            Listener.IsExecuting(progress);
            //MessagingCenter.Send(Application.Current, CoreConstants.UpdateProgress, progress);
        }

        protected static void HideProgress()
        {
            MessagingCenter.Send(Application.Current, CoreConstants.DismissProgress, new UpdateProgress());
        }

        protected bool CanExecute()
        {
            return !IsBusy;
        }

        protected bool CanExecute<T>(T obj)
        {
            return !IsBusy;
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        //[NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        public void ErrorOcurred(int errorCode, string errorDescription)
        {
            //ShowMessage(AppRes.UiDialogErrorTitle, errorDescription);
            Listener.ErrorOcurred(errorCode, errorDescription);

            IsBusy = false;
        }

        public void IsExecuting(decimal progress, string message)
        {
            UpdateProgress(message, (int)(progress * 100), null);
        }

        #region Menu toggle
        public ICommand ToggleMenu { get; }

        private void ToggleMenuView()
        {
            //App.MainPage.IsPresented = !App.MainPage.IsPresented;
        }


        #endregion

        #region Page Title

        private string _title;

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Page SubTitle

        private string _subTitle;

        public string SubTitle
        {
            get => _subTitle;
            set
            {
                _subTitle = value;
                OnPropertyChanged();
            }
        }

        public bool ShowSubTitle { get; set; }

        #endregion

        #region Context Menu
        public bool ShowContextMenu { get; set; }

        public ICommand ToggleContextMenu { get; protected set; }
        #endregion


    }
}
