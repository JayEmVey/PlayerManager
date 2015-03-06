using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMvvm.Models
{
    class PlayerModel
    {

        // Model construction
        public PlayerModel(string PlayerName, int PlayerAge, string Position, string ClubName, string Message, string Image)
        {
            this.PlayerName = PlayerName;
            this.PlayerAge = PlayerAge;
            this.Position = Position;
            this.ClubName = ClubName;
            this.Message = Message;
            this.Image = Image;
        }

        #region Properties
        /// The player name.
        public string PlayerName { get; set; }

        /// The player age
        public int PlayerAge { get; set; }

        /// The club name.
        public string ClubName { get; set; }

        /// The Model message
        public string Message { get; set; }

        public string Position { get; set; }

        public string Image { get; set; }
        #endregion
        
    }
}
