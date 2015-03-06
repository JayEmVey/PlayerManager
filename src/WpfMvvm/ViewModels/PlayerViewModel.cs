namespace WpfMvvm.ViewModels
{
    using System.Windows.Input;
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    using WpfMvvm.Entities;
    using WpfMvvm.Messages;
    using WpfMvvm.Models;
    using WpfMvvm.Services;
using WpfMvvm.Windows;
    using System.Windows;

    /// <summary>
    /// The view model for the main Window
    /// </summary>
    public class PlayerViewModel : ViewModelBase
    {
        /// <summary>
        /// The window service
        /// </summary>
        private readonly IWindowService windowService;

        /// <summary>
        /// The message box service
        /// </summary>
        private readonly IMessageboxService messageboxService;

        /// <summary>
        /// THe model
        /// </summary>
        private readonly PlayerModel model;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        /// <param name="model">
        /// The model
        /// </param>
        /// <param name="windowService">
        /// The window service
        /// </param>
        /// <param name="messageboxService">
        /// The message box service
        /// </param>
        public PlayerViewModel(object model, IWindowService windowService, IMessageboxService messageboxService)
        {
            this.windowService = windowService;
            this.messageboxService = messageboxService;
            this.model = (PlayerModel)model;
        }

        /// <summary>
        /// Current player getter
        /// </summary>
        public object SelectedPlayer
        {
            get
            {
                return this.model != null ? (PlayerModel)this.model : null;
            }
        }

        /// <summary>
        /// Gets some text from the model
        /// </summary>
        public string ModelText 
        {
            get
            {
                return this.model != null ? this.model.Message : "This is Player Model message";
            }
        }

        /// <summary>
        /// player name dynamic variable
        /// </summary>
        private string playerName;
        /// <summary>
        /// Get Player Name
        /// </summary>
        public string PlayerName
        {
            get
            {
                return this.model != null ? this.model.PlayerName : "Player name is not publish";
            }
            set
            {
                this.Set(() => this.PlayerName, ref playerName, value);
                this.model.PlayerName = playerName;
            }
        }

        /// <summary>
        /// player age dynamic variable
        /// </summary>
        private int playerAge;
        /// <summary>
        /// Get player age
        /// </summary>
        public int PlayerAge
        {
            get
            {
                return this.model != null ? this.model.PlayerAge : 0;
            }
            set
            {
                this.Set(() => this.PlayerAge, ref playerAge, value);
                this.model.PlayerAge = playerAge;
            }
        }

        /// <summary>
        /// player position dynamic variable
        /// </summary>
        private string playerPosition;
        /// <summary>
        /// Player position accessibility
        /// </summary>
        public string PlayerPosition
        {
            get
            {
                return this.model != null ? this.model.Position : "Player position is not publish";
            }
            set
            {
                // Check if any changes of value
                if (this.playerPosition != value)
                {
                    this.Set(() => this.PlayerPosition, ref playerPosition, value);
                    this.model.Position = playerPosition;
                    RaisePropertyChanged("PlayerPosition");
                }
            }
        }

        /// <summary>
        /// Player image dynamic variable
        /// </summary>
        private string playerImage;
        /// <summary>
        /// Player image accessibility
        /// </summary>
        public string PlayerImage
        {
            get
            {
                return this.model != null ? this.model.Image : "This player image is not publish";
            }
            set
            {
                this.Set(() => this.PlayerImage, ref playerImage, value);
                this.model.Image = playerImage;
            }
        }

        /// <summary>
        /// Club name dynamic variable
        /// </summary>
        private string clubName;
        /// <summary>
        /// Get club name
        /// </summary>
        public string ClubName
        {
            get
            {
                return this.model != null ? this.model.ClubName : "Club name is not publish";
            }
            set
            {
                this.Set(() => this.ClubName, ref clubName, value);
                this.model.ClubName = clubName;
            }
        }

        /// <summary>
        /// Player message dynamic variable
        /// </summary>
        private string playerMessage;
        /// <summary>
        /// PLayer message acessibility
        /// </summary>
        public string PlayerMessage
        {
            get
            {
                return this.model != null ? this.model.Message : "Player message is not publish";
            }
            set
            {
                this.Set(() => this.PlayerMessage, ref playerMessage, value);
                this.model.Message = playerMessage;
            }
        }

        /// <summary>
        /// Display short description of a player
        /// </summary>
        public string ShortDesc
        {
            get
            {
                return this.model != null ? "Age: " + this.model.PlayerAge + " | Position: " + this.model.Position : "This information is not publish";
            }
        }

        /// <summary>
        /// Open new Window
        /// </summary>
        /// <param name="window"></param>
        private void OpenEditWindow()
        {
            this.windowService.OpenWindow<PlayerViewModel>("PlayerEdit",this.model);
        }

        /// <summary>
        /// Gets the open window command
        /// </summary>
        public ICommand OpenWindowCommand
        {
            get
            {
                return new RelayCommand(() => this.windowService.OpenWindow<MainViewModel>());
            }
        }

        /// <summary>
        /// Gets the open dialog command
        /// </summary>
        public ICommand OpenDialogCommand
        {
            get
            {
                return new RelayCommand(() => this.windowService.OpenDialog<MainViewModel>());
            }
        }

        /// <summary>
        /// Gets the show message command
        /// </summary>
        public ICommand ShowMessageCommand
        {
            get
            {
                return new RelayCommand(() => this.messageboxService.ShowMessagebox("Message text from Player", MessageboxKind.YesNo,  "Message title"));
            }
        }

        /// <summary>
        /// Gets the open alternative window command
        /// </summary>
        public ICommand OpenAlternativeWindowCommand
        {
            get
            {
                return new RelayCommand(() => this.windowService.OpenWindow<MainViewModel>("AlternativeWindow"));
            }
        }

        /// <summary>
        /// Gets the close windows command
        /// </summary>
        public ICommand EditWindowCommand
        {
            get
            {
                return new RelayCommand(this.OpenEditWindow);
            }
        }

        /// <summary>
        /// Close window
        /// </summary>
        private void CloseWindow()
        {
            //Application.Current.MainWindow.Close();

            foreach (Window window in Application.Current.Windows)
            {
                if (window.DataContext == this)
                {
                    window.Close();
                }
            }

        }
        /// <summary>
        /// Close window command
        /// </summary>
        public ICommand CloseWindowCommand
        {
            get
            {
                return new RelayCommand(this.CloseWindow);
            }
        }

        /// <summary>
        /// Update player information
        /// </summary>
        private void UpdatePlayer()
        {
            var response = this.messageboxService.ShowMessagebox("Are you sure you want to update information?", MessageboxKind.YesNo, "Update confirmation");

            if (response == MessageboxResponce.Yes)
            {
                // Put your update code here

                // Close window after update
                this.CloseWindow();
            }

        }
        /// <summary>
        /// Update player information command
        /// </summary>
        public ICommand UpdatePlayerCommand
        {
            get
            {
                return new RelayCommand(this.UpdatePlayer);
            }
        }
    }
}