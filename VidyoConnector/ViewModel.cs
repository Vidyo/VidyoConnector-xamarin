using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace VidyoConnector
{
    public class ViewModel : INotifyPropertyChanged
    {
        private static ViewModel _instance = new ViewModel();
        public static ViewModel GetInstance() { return _instance; }
        private ViewModel() 
        { 
            this.DisplayDiagnostics = false; 
        }

        public event PropertyChangedEventHandler PropertyChanged;

        const string _cameraOnImage      = "camera_on.png";
        const string _cameraOffImage     = "camera_off.png";
        const string _microphoneOnImage  = "microphone_on.png";
        const string _microphoneOffImage = "microphone_off.png";
        const string _callStartImage     = "call_start.png";
        const string _callEndImage       = "call_end.png";
        const string _gearIMage          = "gear.png";
        string _cameraPrivacyImage       = _cameraOnImage;
        string _microphonePrivacyImage   = _microphoneOnImage;
        string _callImage                = _callStartImage;
        bool   _cameraPrivacy            = false;
        bool   _microphonePrivacy        = false;
        string _host                     = "prod.vidyo.io";
        string _token                    = "cHJvdmlzaW9uAHVzZXIxQDg3MTFlMC52aWR5by5pbwA2Mzc0MTQwODIyMQAAOWM2YjQxMDNjODRlMWYxYzA1MmVjZjEwNDkzYjA2ODk5OTVlNjQzZDU4NGUwMTY0NTM0ZmZjNjBkNjUyMGE5YTRjYzExYzk1YzQxMzhiY2UxYTI4Y2Q3MDZlODgzZjM0"; // INSERT VALID TOKEN
        string _displayName              = "XamarinUser";
        string _resourceId               = "DemoRoom";
        string _toolbarStatus            = "Ready to Connect";
        string _clientVersion            = "v 0.0.00.x";
        VidyoCallAction _callAction      = VidyoCallAction.VidyoCallActionConnect;

        public bool ToggleCameraPrivacy()
        {
            _cameraPrivacy = !_cameraPrivacy;
            CameraPrivacyImage = _cameraPrivacy ? _cameraOffImage : _cameraOnImage;
            return _cameraPrivacy;
        }

        public bool ToggleMicrophonePrivacy()
        {
            _microphonePrivacy = !_microphonePrivacy;
            MicrophonePrivacyImage = _microphonePrivacy ? _microphoneOffImage : _microphoneOnImage;
            return _microphonePrivacy;
        }

        public VidyoCallAction ToggleCallAction()
        {
            CallAction = _callAction == VidyoCallAction.VidyoCallActionConnect ?
                          VidyoCallAction.VidyoCallActionDisconnect : VidyoCallAction.VidyoCallActionConnect;
            return _callAction;
        }

        public VidyoCallAction CallAction
        {
            set {
                _callAction = value;
                CallImage = _callAction == VidyoCallAction.VidyoCallActionConnect ? _callStartImage : _callEndImage;
            }
            get { return _callAction; }
        }

        public string Host
        {
            get { return _host; }
            set {
                if (_host != value) {
                    _host = value;
                    OnPropertyChanged("Host");
                }
            }
        }

        public string Token
        {
            get { return _token; }
            set {
                if (_token != value) {
                    _token = value;
                    OnPropertyChanged("Token");
                }
            }
        }

        public string DisplayName
        {
            get { return _displayName; }
            set {
                if (_displayName != value) {
                    _displayName = value;
                    OnPropertyChanged("DisplayName");
                }
            }
        }

        public string ResourceId
        {
            get { return _resourceId; }
            set {
                if (_resourceId != value) {
                    _resourceId = value;
                    OnPropertyChanged("ResourceId");
                }
            }
        }

        public string ToolbarStatus
        {
            get { return _toolbarStatus; }
            set {
                if (_toolbarStatus != value) {
                    _toolbarStatus = value;
                    OnPropertyChanged("ToolbarStatus");
                }
            }
        }

        public string ClientVersion
        {
            get { return _clientVersion; }
            set {
                if (_clientVersion != value) {
                    _clientVersion = value;
                    OnPropertyChanged("ClientVersion");
                }
            }
        }

        public string CallImage
        {
            get { return _callImage; }
            set {
                if (_callImage != value) {
                    _callImage = value;
                    OnPropertyChanged("CallImage");
                }
            }
        }

        public string CameraPrivacyImage
        {
            get { return _cameraPrivacyImage; }
            set {
                if (_cameraPrivacyImage != value) {
                    _cameraPrivacyImage = value;
                    OnPropertyChanged("CameraPrivacyImage");
                }
            }
        }

        public bool DisplayDiagnostics { get; set; }

        public string MicrophonePrivacyImage
        {
            get { return _microphonePrivacyImage; }
            set {
                if (_microphonePrivacyImage != value) {
                    _microphonePrivacyImage = value;
                    OnPropertyChanged("MicrophonePrivacyImage");
                }
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var changed = PropertyChanged;
            if (changed != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
