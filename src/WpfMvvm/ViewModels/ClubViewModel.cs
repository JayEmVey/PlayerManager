namespace WpfMvvm.ViewModels
{
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Media.Imaging;
    using WpfMvvm.Models;
    using WpfMvvm.Services;
    using WpfMvvm.Windows;

    public class ClubViewModel: ViewModelBase
    {
        private readonly IWindowService windowService;
        private ClubModel model;

        /// <summary>
        /// Club View Model contruction
        /// </summary>
        /// <param name="windowService"></param>
        /// <param name="model"></param>
        public ClubViewModel(IWindowService windowService, object model)
        {
            this.windowService = windowService;
            this.model = (ClubModel)model;
            this.clubPlayer = this.model.ClubPlayers;
        }

        private object clubPlayer;
        /// <summary>
        /// Get All Club's players
        /// </summary>
        public object ClubPlayers{
            get{
                return this.model != null ? (List<PlayerModel>)this.clubPlayer : null;
            }
            set
            {
                this.Set(() => this.ClubPlayers, ref this.clubPlayer, value);
            }
        }

        /// <summary>
        /// Get MOCKING CLUB COLLECTION
        /// </summary>
        public object Clubs
        {
            get
            {
                List<ClubModel> clubs = new List<ClubModel>();
                clubs.Add(this.model);

                // Mockin data
                var playerModel = new PlayerModel("W. Rooney", 29, "SS", "Manchester United", "A England professional football player", "wayne-rooney");
                var tmpImg = String.Format("/Images/{0}.jpg", playerModel.Image);
                playerModel.Image = tmpImg.ToString();

                var playerModel1 = new PlayerModel("R V Persie", 30, "CF", "Manchester United", "A Netherlander professional football player", "persie");
                tmpImg = String.Format("/Images/{0}.jpg", playerModel1.Image);
                playerModel1.Image = tmpImg.ToString();

                var playerModel2 = new PlayerModel("Johny Evans", 25, "DF", "Manchester United", "A England professional football player", "evans");
                tmpImg = String.Format("/Images/{0}.jpg", playerModel2.Image);
                playerModel2.Image = tmpImg.ToString();

                var playerModel3 = new PlayerModel("Radamel Falcao", 26, "CF", "Manchester United", "A Colombian professional football player", "falcao");
                tmpImg = String.Format("/Images/{0}.jpg", playerModel3.Image);
                playerModel3.Image = tmpImg.ToString();

                var playerModel4 = new PlayerModel("Angel Di Maria", 26, "MF", "Manchester United", "A Arghentini professional football player", "angel-di-maria");
                tmpImg = String.Format("/Images/{0}.jpg", playerModel4.Image);
                playerModel4.Image = tmpImg.ToString();

                var playerModel5 = new PlayerModel("Davia De Gea", 22, "GK", "Manchester United", "A Spainish professional football player", "de-gea");
                tmpImg = String.Format("/Images/{0}.jpg", playerModel5.Image);
                playerModel5.Image = tmpImg.ToString();

                var playerModel6 = new PlayerModel("Rafael Da Silva", 25, "RB", "Manchester United", "A Brazilian professional football player", "rafael");
                tmpImg = String.Format("/Images/{0}.jpg", playerModel6.Image);
                playerModel6.Image = tmpImg.ToString();

                var MuPlayers = new List<PlayerModel>();
                MuPlayers.Add(playerModel);
                MuPlayers.Add(playerModel1);
                MuPlayers.Add(playerModel2);
                MuPlayers.Add(playerModel3);
                MuPlayers.Add(playerModel4);
                MuPlayers.Add(playerModel5);
                MuPlayers.Add(playerModel6);

                var MuClubModel = new ClubModel("Manchester United", "MUFC", "Glory glory Manchester United", 25, MuPlayers);

                clubs.Add(MuClubModel);

                return clubs != null ? (List<ClubModel>)clubs : null;
            }
        }

        /// <summary>
        /// Get Club's number of players
        /// </summary>
        public int TotalPlayers
        {
            get
            {
                return this.model != null ? this.model.TotalPlayers : 0;
            }
        }

        /// <summary>
        /// Get Club's full name
        /// </summary>
        public string ClubName
        {
            get{
                return this.model != null ? this.model.ClubName : "This club name is not publish";
            }
        }

        /// <summary>
        /// Get Club's short name
        /// </summary>
        public string ShortName
        {
            get
            {
                return this.model != null ? this.model.ShortName : "This short name is not publish";
            }
        }

        //public ICommand DisplayPlayerCommand
        //{
        //    get
        //    {
        //        // Mocking player data for test
        //        var playerModel = new PlayerModel("Giang NGUYEN", 29, "FW", "Futsal MUSVN", "I am Giang NGUYEN! Im a RED ^^");
        //        return new RelayCommand(() => this.windowService.OpenWindow<PlayerViewModel>("PlayerDetail", playerModel));
        //    }
        //}

        /// <summary>
        /// Selected player on ClubViewModel
        /// </summary>
        private object selectedPlayer;
        /// <summary>
        /// Gets or sets the user's name
        /// </summary>
        public object SelectedPlayer
        {
            get
            {
                return this.selectedPlayer;
            }

            set
            {
                this.Set(() => this.SelectedPlayer, ref this.selectedPlayer, value);
            }
        }

        /// <summary>
        /// Display selected player command
        /// </summary>
        public ICommand DisplayPlayerCommand
        {
            get
            {
                return new RelayCommand(this.DisplayPlayer);
            }
        }

        /// <summary>
        /// Display selected player
        /// </summary>
        private void DisplayPlayer()
        {
            // Mocking player data for test
            //var playerModel = new PlayerModel("Giang NGUYEN", 29, "FW", "Futsal MUSVN", "I am Giang NGUYEN! Im a RED ^^");
            this.windowService.OpenWindow<PlayerViewModel>("PlayerDetail", SelectedPlayer);
        }

        // Selected club
        private object selectedClub;

        /// <summary>
        /// Selected club value
        /// </summary>
        public object SelectedClub
        {
            get
            {
                return this.selectedClub;
            }
            set
            {
                this.Set(() => this.SelectedClub, ref this.selectedClub, value);
            }
        }

        /// <summary>
        /// Display Club info
        /// </summary>
        private void DisplayClub()
        {
            if (SelectedClub != null)
            {
                this.model = (ClubModel)SelectedClub;
                this.Set(() => this.ClubPlayers, ref this.clubPlayer, this.model.ClubPlayers);
            }
        }


        /// <summary>
        /// Display club info command
        /// </summary>
        public ICommand DisplayClubCommand
        {
            get
            {
                return new RelayCommand(this.DisplayClub);
            }
        }

        /// <summary>
        /// Update player info
        /// </summary>
        private void UpdatePlayerInfo()
        {
            // Put the code update to database here
        }

        /// <summary>
        /// Update player info command
        /// </summary>
        public ICommand UpdatePlayerCommand
        {
            get
            {
                return new RelayCommand(this.UpdatePlayerInfo);
            }
        }


        /// <summary>
        /// Close window
        /// </summary>
        private void CloseWindow()
        {
            Application.Current.MainWindow.Close();
        }


        /// <summary>
        /// Close window command
        /// </summary>
        public ICommand CloseCommand
        {
            get
            {
                return new RelayCommand(this.CloseWindow);
            }
        }

    }
}
