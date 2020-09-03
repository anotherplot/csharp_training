using System;
using System.Text;
using NUnit.Framework;

namespace WebAddressBookTests
{
    public class TestBase
    {
        public static Random rnd = new Random();
        protected ApplicationManager app;

        [SetUp]
        public void SetupApplicationManager()
        {
            app = ApplicationManager.GetInstance();
        }

        public static string GenerateRandomString(int max)
        {
            int l = Convert.ToInt32(rnd.NextDouble() * max);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < l; i++)
            {
                builder.Append(Convert.ToChar(32 + Convert.ToInt32(rnd.NextDouble() * 223)));
            }

            return builder.ToString();
        }

        public static string GenerateRandomPhoneNumber(int length)
        {
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                builder.Append(rnd.Next(10));
            }

            return builder.ToString();
        }
        
        
        public static DateTime GenerateRandomDateInPast(int yearsRange)
        {
            return DateTime.Today.AddDays(-rnd.Next(yearsRange * 365));
        }
    }
}