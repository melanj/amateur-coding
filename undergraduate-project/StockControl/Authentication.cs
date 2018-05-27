using System;
using StockControl.Model;

namespace StockControl
{
    public class Authentication
    {
        private static Boolean authenticated=false;
        private static User user=null;

        // check authentication of givin username and password 
        public static Boolean authenticate(string userid, string password)
        {
            user = new User();
            user.Name = userid;
            user.Password = password;
            if (DataAccess.isUser(user)) // check is valid user
            {
                    switch (user.Category)
                    {
                        case 1: // Administrator
                        case 2: // Manager
                        case 3: // General
                            authenticated = true;
                            break;
                        default: // if other user category
                            clear();
                            break;
                    }
                }
                else
                    clear();
            
            return authenticated;
        }

        //clear current  authentication details 
        public static void clear(){
        authenticated = false;
        user = null;
        }

        //get current authenticated user
        public static User GetUser() {
            return user;
        }

        //get current authentication status
        public static Boolean IsAuthenticated()
        {
            return authenticated;
        }
    }
}
