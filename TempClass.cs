using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace InstantChat
{
    class TempClass
    {
        internal static string username;

        internal static Hashtable usernameList;
        internal static string connectionString;
        internal static string hostIP;
        internal static string ToUsername;
        internal static string FromUsername;
        internal static int i, j;
        internal static UserStatus user;
        internal static AdminStatus admin;
        

        static TempClass()
        {
            usernameList = new Hashtable();

            TempClass.hostIP = "";

        }
    }
}
