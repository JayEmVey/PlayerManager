namespace WpfMvvm
{
    using System.Windows;
    using Ninject;

    using WpfMvvm.Models;
    using WpfMvvm.Services;
    using WpfMvvm.ViewModels;
    using WpfMvvm.Entities;
    using System.Collections.Generic;
    using System.Windows.Media.Imaging;
    using System;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Initializes a new instance of the App class.
        /// </summary>
        public App()
        {
            // Call boostrapper
            WpfMvvmApplication.Current.Bootstrap();

            // Make an app's window instance
            //var mainModel = new SampleModel("This text is retrieved from the model, which is injected as a named constructor argument to the ViewModel");
            //WpfMvvmApplication.Current.Container.Get<IWindowService>().OpenWindow<MainViewModel>(mainModel);

            // Mocking player data for test
            //var playerModel = new PlayerModel("Giang NGUYEN",29, "Futsal MUSVN", "I am Giang NGUYEN! Im a RED ^^");
            //WpfMvvmApplication.Current.Container.Get<IWindowService>().OpenWindow<PlayerViewModel>("PlayerDetail",playerModel);

            // Make an app's messagebog instance
            //MessageboxKind DemoAlertMsg = new MessageboxKind();
            //WpfMvvmApplication.Current.Container.Get<IMessageboxService>().ShowMessagebox("This is a demo version!!! Mind blow :D", DemoAlertMsg, "Demo alert");

            // Mocking player data for test
            var playerModel = new PlayerModel("Giang NGUYEN", 29, "MF", "Futsal MUSVN", "I am Giang NGUYEN! Im a RED ^^", "giang-nguyen");
            var tmpImg = String.Format("/Images/{0}.jpg", playerModel.Image);
            playerModel.Image = tmpImg.ToString();

            var playerModel1 = new PlayerModel("Tin Rom", 23, "MF", "Futsal MUSVN", "Nguyen Trung Tin", "player-img");
            tmpImg = String.Format("/Images/{0}.jpg", playerModel1.Image);
            playerModel1.Image = tmpImg.ToString();

            var playerModel2 = new PlayerModel("Duc Pham", 20, "DF", "Futsal MUSVN", "Duc Pham Khanh", "player-img");
            tmpImg = String.Format("/Images/{0}.jpg", playerModel2.Image);
            playerModel2.Image = tmpImg.ToString();

            var playerModel3 = new PlayerModel("Huy Tran", 26, "DF", "Futsal MUSVN", "Tran Tan Huy", "player-img");
            tmpImg = String.Format("/Images/{0}.jpg", playerModel3.Image);
            playerModel3.Image = tmpImg.ToString();

            tmpImg = null;

            var players = new List<PlayerModel>();
            players.Add(playerModel);
            players.Add(playerModel1);
            players.Add(playerModel2);
            players.Add(playerModel3);

            var clubModel = new ClubModel("Futsal MUSVN", "FMU","This is Futsal MUSVN club", 19, players);
            WpfMvvmApplication.Current.Container.Get<IWindowService>().OpenWindow<ClubViewModel>("ClubView", clubModel);

        }
    }
}
