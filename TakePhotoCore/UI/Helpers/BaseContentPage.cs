using System;
using System.Collections.Generic;
using System.Text;
using TakePhotoCore.Resources;
using Xamarin.Forms;

namespace TakePhotoCore.UI.Helpers
{
    public class BaseContentPage : ContentPage//, IUiContentPage
    {
        //public IProgressDialog ProgressDialog { get; }

        //public BaseContentPage()
        //{
        //    // Progress dialog Init
        //    var progressDialogConfig = new ProgressDialogConfig
        //    {
        //        AutoShow = false,
        //        CancelText = "Stop",
        //        IsDeterministic = true,
        //        MaskType = MaskType.Gradient,
        //        OnCancel = null,
        //        Title = "Loading..."
        //    };
        //    ProgressDialog = UserDialogs.Instance.Progress(progressDialogConfig);
        //}

        //public void ErrorOcurred(int errorCode, string errorDescription)
        //{
        //    Device.BeginInvokeOnMainThread(() =>
        //    {
        //        ProgressDialog.Hide();
        //    });

        //}

        //public void IsExecuting(UpdateProgress progress)
        //{
        //    Device.BeginInvokeOnMainThread(() =>
        //    {
        //        ProgressDialog.Title = progress.Title;
        //        ProgressDialog.PercentComplete = progress.Percent;
        //        ProgressDialog.Show();
        //    });
        //}

        //public void Success()
        //{
        //    Device.BeginInvokeOnMainThread(() =>
        //    {
        //        ProgressDialog.Hide();
        //    });
        //}

        //public void ShowMessage(DisplayAlertMessage message)
        //{
        //    Device.BeginInvokeOnMainThread(async () =>
        //    {

        //        var cancel = !string.IsNullOrEmpty(message.Accept) ? AppRes.OptionCancel : AppRes.OptionAccept;

        //        var result = true;
        //        if (!string.IsNullOrEmpty(message.Accept))
        //            result = await DisplayAlert(message.Title, message.Message, message.Accept, cancel);
        //        else
        //        {
        //            await DisplayAlert(message.Title, message.Message, cancel);
        //        }

        //        if (message.OnCompleted != null)
        //            message.OnCompleted(result);
        //    });
        //}

        //public void ShowActionSheet(ActionSheetMenu menu)
        //{
        //    Device.BeginInvokeOnMainThread(async () =>
        //    {
        //        var result = await DisplayActionSheet(menu.Title, menu.Cancel, menu.Destruction,
        //            menu.Buttons.ToArray());

        //        menu.OnCompleted?.Invoke(result);
        //    });
        //}
    }
}
