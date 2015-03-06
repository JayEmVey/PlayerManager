using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMvvm.Models
{
    class ClubModel
    {

        #region properties
        public string ClubName { get; set; }
        public string ShortName { get; set; }
        public string ClubInfo { get; set; }
        public int TotalPlayers { get; set; }
        public object ClubPlayers { get; set; }
        #endregion

        #region contruction
        public ClubModel(string ClubName, string ShortName, string ClubInfo, int TotalPlayers, object ClubPlayers)
        {
            this.ClubName = ClubName;
            this.ShortName = ShortName;
            this.ClubInfo = ClubInfo;
            this.TotalPlayers = TotalPlayers;
            this.ClubPlayers = ClubPlayers;
        }
        #endregion
    }
}
