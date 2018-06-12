using System;
using System.Collections.Generic;
using System.Text;

namespace TakePhotoCore.UI.Helpers
{
    public interface IUiContentPage
    {
        void ErrorOcurred(int errorCode, string errorDescription);

        void IsExecuting(UpdateProgress progress);

        void Success();

        void ShowMessage(DisplayAlertMessage message);

        //void ShowActionSheet(ActionSheetMenu menu);
    }
}
