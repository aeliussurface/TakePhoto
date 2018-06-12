using System;
using System.Collections.Generic;
using System.Text;
using TakePhotoCore.Resources;

namespace TakePhotoCore.UI.Helpers
{
    public class DisplayAlertMessage
    {
        public DisplayAlertMessage()
        {
            Cancel = AppRes.OptionCancel;
        }

        public string Title { get; set; }
        public string Message { get; set; }
        public string Cancel { get; set; }
        public string Accept { get; set; }

        public Action<bool> OnCompleted { get; set; }
    }
}
