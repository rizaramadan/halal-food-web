using Logic;
using Microsoft.EntityFrameworkCore;

namespace Web.Data;
public partial class AppDbContext : IRestoRepo
{

    public async Task<string[]> WilayahList()
    {
        return await Restos.Select(r => r.Address).Distinct().ToArrayAsync();
    }

    public async Task<string[]> CategoryList()
    {
        return await Restos.Select(r => r.Category).Distinct().ToArrayAsync();
    }

    public async Task<Logic.Resto[]> Search(SearchParam s)
    {
        var restos = await Restos.Where(p => p.SearchVector.Matches(EF.Functions.WebSearchToTsQuery(s.Query)))
            .ToListAsync();
        return restos.Select(r => r.ToDomainResto()).ToArray();
    }

    public async Task<Logic.Resto[]> Search(SearchStatusParam s)
    {
        var restos = await Restos.Where(p => p.SearchVector.Matches(EF.Functions.WebSearchToTsQuery(s.Query)))
            .Where(r => r.Status == s.Status)
            .ToListAsync();
        return restos.Select(r => r.ToDomainResto()).ToArray();
    }

    public async Task<Logic.Resto[]> Search(SearchWilayahParam s)
    {
        var restos = await Restos.Where(p => p.SearchVector.Matches(EF.Functions.WebSearchToTsQuery(s.Query)))
            .Where(r => r.Address == s.Wilayah)
            .ToListAsync();
        return restos.Select(r => r.ToDomainResto()).ToArray();
    }

    public async Task<Logic.Resto[]> Search(SearchCategoryParam s)
    {
        var restos = await Restos.Where(p => p.SearchVector.Matches(EF.Functions.WebSearchToTsQuery(s.Query)))
            .Where(r => r.Address == s.Category)
            .ToListAsync();
        return restos.Select(r => r.ToDomainResto()).ToArray();
    }

    public async Task<Logic.Resto[]> Search(SearchStatusWilayahParam s)
    {
        var restos = await Restos.Where(p => p.SearchVector.Matches(EF.Functions.WebSearchToTsQuery(s.Query)))
            .Where(r => r.Status == s.Status)
            .Where(r => r.Address == s.Wilayah)
            .ToListAsync();
        return restos.Select(r => r.ToDomainResto()).ToArray();
    }

    public async Task<Logic.Resto[]> Search(SearchStatusCategoryParam s)
    {
        var restos = await Restos.Where(p => p.SearchVector.Matches(EF.Functions.WebSearchToTsQuery(s.Query)))
            .Where(r => r.Status == s.Status)
            .Where(r => r.Category == s.Category)
            .ToListAsync();
        return restos.Select(r => r.ToDomainResto()).ToArray();
    }

    public async Task<Logic.Resto[]> Search(SearchWilayahCategoryParam s)
    {
        var restos = await Restos.Where(p => p.SearchVector.Matches(EF.Functions.WebSearchToTsQuery(s.Query)))
            .Where(r => r.Address == s.Wilayah)
            .Where(r => r.Category == s.Category)
            .ToListAsync();
        return restos.Select(r => r.ToDomainResto()).ToArray();
    }

    public async Task<Logic.Resto[]> Search(SearchStatusWilayahCategoryParam s)
    {
        var restos = await Restos.Where(p => p.SearchVector.Matches(EF.Functions.WebSearchToTsQuery(s.Query)))
            .Where(r => r.Address == s.Wilayah)
            .Where(r => r.Category == s.Category)
            .ToListAsync();
        return restos.Select(r => r.ToDomainResto()).ToArray();
    }


    public async Task<Logic.Resto[]> Search(FilterStatusParam s)
    {
        var restos = await Restos
            .Where(r => r.Status == s.Status)
            .ToListAsync();
        return restos.Select(r => r.ToDomainResto()).ToArray();
    }

    public async Task<Logic.Resto[]> Search(FilterWilayahParam s)
    {
        var restos = await Restos
            .Where(r => r.Address == s.Wilayah)
            .ToListAsync();
        return restos.Select(r => r.ToDomainResto()).ToArray();
    }

    public async Task<Logic.Resto[]> Search(FilterCategoryParam s)
    {
        var restos = await Restos
            .Where(r => r.Category == s.Category)
            .ToListAsync();
        return restos.Select(r => r.ToDomainResto()).ToArray();
    }

    public async Task<Logic.Resto[]> Search(FilterStatusWilayahParam s)
    {
        var restos = await Restos
            .Where(r => r.Address == s.Wilayah)
            .Where(r => r.Status == s.Status)
            .ToListAsync();
        return restos.Select(r => r.ToDomainResto()).ToArray();
    }

    public async Task<Logic.Resto[]> Search(FilterStatusCategoryParam s)
    {
        var restos = await Restos
            .Where(r => r.Category == s.Category)
            .Where(r => r.Status == s.Status)
            .ToListAsync();
        return restos.Select(r => r.ToDomainResto()).ToArray();
    }

    public async Task<Logic.Resto[]> Search(FilterWilayahCategoryParam s)
    {
        var restos = await Restos
            .Where(r => r.Address == s.Wilayah)
            .Where(r => r.Category == s.Category)
            .ToListAsync();
        return restos.Select(r => r.ToDomainResto()).ToArray();
    }

    public async Task<Logic.Resto[]> Search(FilterStatusWilayahCategoryParam s)
    {
        var restos = await Restos
            .Where(r => r.Address == s.Wilayah)
            .Where(r => r.Category == s.Category)
            .Where(r => r.Status == s.Status)
            .ToListAsync();
        return restos.Select(r => r.ToDomainResto()).ToArray();
    }
}
