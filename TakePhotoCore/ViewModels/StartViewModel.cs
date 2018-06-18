using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Plugin.Media;
using Xamarin.Forms;

namespace TakePhotoCore.ViewModels
{
    public class StartViewModel : BaseViewModel
    {
        private ImageSource _photoSource;
        public ICommand TryTakePhoto { get; }
        public ICommand TryPickPhoto { get; }

        public StartViewModel()
        {
            TryTakePhoto = new Command(TakePhoto);
            TryPickPhoto = new Command(PickPhoto);
        }

        public ImageSource PhotoSource
        {
            get { return _photoSource; }
            set
            {
                _photoSource = value;
                OnPropertyChanged();
            }
        }

        private async void TakePhoto()
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                ShowMessage("No Camera", ":( No camera available.", null, "OK");
                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "TakePhoto",
                CompressionQuality = 100,
                Name = $"{ DateTime.UtcNow }.jpg",
                SaveToAlbum = true
            });

            if (file == null)
                return;

            ShowMessage("File Location", file.Path, null, "OK");

            Device.BeginInvokeOnMainThread(() =>
            {
                PhotoSource = ImageSource.FromStream(() => file.GetStream());
            });

            //PhotoSource = ImageSource.FromFile(file.Path);
        }

        private async void PickPhoto()
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                ShowMessage("No pictures to pick", ":( No able to pick photos.", null, "OK");
                return;
            }

            var file = await CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
            {
                ModalPresentationStyle = Plugin.Media.Abstractions.MediaPickerModalPresentationStyle.FullScreen,
                CompressionQuality = 100,
            });

            if (file == null)
                return;

            ShowMessage("File Location", file.Path, null, "OK");

            PhotoSource = ImageSource.FromStream(() => file.GetStream());
        }
    }
}
