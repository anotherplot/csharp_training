using mantis_tests.MantisConnect;

namespace mantis_tests
{
    public class APIHelper : HelperBase
    {
        public APIHelper(ApplicationManager manager) : base(manager)
        {
        }

        public void CreateIssue(AccountData accountData)
        {
            MantisConnect.MantisConnectPortTypeClient client = new MantisConnectPortTypeClient();
           
          
        }
    }
}