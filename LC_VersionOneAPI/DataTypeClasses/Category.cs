namespace LC_VersionOne.DataTypeClasses
{
    public class Category
    {
        public string? Id { get;set; }
        public string? Name { get; set; }

        private string? url;
        public string? Url
        {
            get { return url; }
            set => url = $"https://www5.v1host.com{value}";
        }
    }
}
