namespace WebAddressBookTests
{
    public class GroupData
    {
        private string name;
        private string header = "";
        private string footer = "";

        public string Header
        {
            get => header;
            set => header = value;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public string Footer
        {
            get => footer;
            set => footer = value;
        }

        public GroupData(string name)
        {
            this.name = name;
        }
        
        public GroupData(string name, string header, string footer)
        {
            this.name = name;
            this.header = header;
            this.footer = footer;
        }
    }
}