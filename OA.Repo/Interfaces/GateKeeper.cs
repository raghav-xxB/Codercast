using OA.Data;
using System;

namespace OA.Repo
{
    public class GateKeeper
    {
        private User loggedInUser;
        public User LoggedInUser { get => this.loggedInUser; set => this.loggedInUser = value; }

    }
}