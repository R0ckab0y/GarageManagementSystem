namespace GMS.Application.Common
{
    public class PagedResponse<T>
    {
        public IEnumerable<T> Data { get; set; } = new List<T>();
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
        public int TotalPages => (int)Math.Ceiling((double)TotalRecords / PageSize);
        public bool HasPreviousPage => PageNumber > 1;
        public bool HasNextPage => PageNumber < TotalPages;

        public static PagedResponse<T> Create(IEnumerable<T> data, int pageNumber, int pageSize, int totalRecords)
        {
            return new PagedResponse<T>
            {
                Data = data,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalRecords = totalRecords
            };
        }
    }
}