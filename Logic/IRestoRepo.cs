
namespace Logic;


public interface IRestoRepo
{
    Task<string[]> WilayahList();
    Task<string[]> CategoryList();
    public Task<Resto[]> Search(SearchParam searchParam);
    public Task<Resto[]> Search(SearchStatusParam searchParam);
    public Task<Resto[]> Search(SearchWilayahParam searchParam);
    public Task<Resto[]> Search(SearchCategoryParam searchParam);
    public Task<Resto[]> Search(SearchStatusWilayahParam searchParam);
    public Task<Resto[]> Search(SearchStatusCategoryParam searchParam);
    public Task<Resto[]> Search(SearchWilayahCategoryParam searchParam);
    public Task<Resto[]> Search(SearchStatusWilayahCategoryParam searchParam);
    public Task<Resto[]> Search(FilterStatusParam searchParam);
    public Task<Resto[]> Search(FilterWilayahParam searchParam);
    public Task<Resto[]> Search(FilterCategoryParam searchParam);
    public Task<Resto[]> Search(FilterStatusWilayahParam searchParam);
    public Task<Resto[]> Search(FilterStatusCategoryParam searchParam);
    public Task<Resto[]> Search(FilterWilayahCategoryParam searchParam);
    public Task<Resto[]> Search(FilterStatusWilayahCategoryParam searchParam);
}


public record Resto (
    string Status,
    string Name,
    string? Address,
    string? Info,
    string? ValidUntil,
    string category);
