namespace StarbucksProje.PagedList
{
    public class Pager
    {
        public int startPage { get; set; }
        public int endPage { get; set; }
        public int totalPageNumber { get; set; }
        public int displayedRecordNumber { get; set; }
        public int totalRecordNumber { get; set; }
        public int activePage { get; set; }
        public Pager()
        {

        }
        public Pager(int pageSize, int itemCounts, int page)
        {

            activePage = page;
            displayedRecordNumber = pageSize;
            totalRecordNumber = itemCounts;

            totalPageNumber = (int)Math.Ceiling((decimal)totalRecordNumber / (decimal)displayedRecordNumber);

            startPage = activePage - 5;
            endPage = activePage + 4;

            if (startPage < 1)
            {
                endPage = endPage - (startPage - 1);
                startPage = 1;
            }
            if (endPage > totalPageNumber)
            {
                endPage = totalPageNumber;
                if (endPage > 10)
                {
                    startPage = endPage - 9;
                }
            }

          
        }
    }
}
