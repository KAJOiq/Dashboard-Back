using Microsoft.EntityFrameworkCore;

namespace projects.Contracts;

public class PaginatedResponse<T>
{                              
    public IEnumerable<T> Items { get; set; }
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
    public int TotalRows { get; set; }

    public PaginatedResponse(IEnumerable<T> items, int currentPage, int totalPages, int totalRows)
    {
        Items = items;
        CurrentPage = currentPage;     
        TotalPages = totalPages;
        TotalRows = totalRows;
    }

    public static async Task<PaginatedResponse<T>> CreateAsync(IQueryable<T> query, int pageNumber, int pageSize)
    {
        var totalRows = await query.CountAsync();

        var totalPages = (int)Math.Ceiling((double)totalRows / pageSize);

        var items = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToArrayAsync();

        return new PaginatedResponse<T>(items, pageNumber, totalPages, totalRows);
    }
}
