using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Helpers;

public static class MessagesHelper
{
    public static class Email
    {
        public static class InstructorApplicationInfo
        {
            public static string Subject => "Thank you for instructor application to Teach It Free!";
            public static string OrganizationLink => "https://github.com/Tobeto-NET-Angular3A-Pair2";

            public static string FullName(string firstName, string lastName) => $"{firstName} {lastName}";

            public static string ContactEmail => "teachitfree@teachitfree.com";
            public static string Address => "Teach It Free, Tobeto Istonbul Kodluyor, Istanbul/Türkiye";
        }
    }
}
