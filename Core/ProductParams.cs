namespace Core
{
    public class ProductParams
    {
        private const int MaxPageSize = 50;
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 10;
        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = (value > MaxPageSize) ? MaxPageSize : value; }
        }
        public int? BrandId { get; set; }
        public int? TypeId { get; set; }
        public string Sort { get; set; }
        private string _search;
        public string Search
        {
            get { return _search; }
            set { _search = value.ToLower(); }
        }
    }
}