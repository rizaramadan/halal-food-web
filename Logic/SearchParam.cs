namespace Logic;

public interface SearchHandler
{
    Task<Resto[]> ExecuteSearch(IRestoRepo restoRepo);
}

public record CompleteSearchParam(string? Search, string Status, string Wilayah, string Category) : SearchHandler
{
    public override string ToString() => $"{Search} {Status} {Wilayah} {Category}";
    public async Task<Resto[]> ExecuteSearch(IRestoRepo restoRepo)
        => await Task.FromResult(Array.Empty<Resto>());

    public bool HasQuery() => !string.IsNullOrWhiteSpace(Search);

    public bool HasWilayah() => !string.IsNullOrWhiteSpace(Wilayah) &&
                                !string.Equals(Wilayah, "Semua", StringComparison.InvariantCultureIgnoreCase);

    public bool HasStatus() => !string.IsNullOrWhiteSpace(Status) &&
                               !string.Equals(Status, "Semua", StringComparison.InvariantCultureIgnoreCase);

    public bool HasCategory() => !string.IsNullOrWhiteSpace(Category) &&
                                 !string.Equals(Category, "Semua", StringComparison.InvariantCultureIgnoreCase);
}

public record SearchStatusParam(string Query, string Status) : SearchHandler
{
    public async Task<Resto[]> ExecuteSearch(IRestoRepo restoRepo)
        => await restoRepo.Search(this);
}

public record SearchWilayahParam(string Query, string Wilayah): SearchHandler
{
    public async Task<Resto[]> ExecuteSearch(IRestoRepo restoRepo)
        => await restoRepo.Search(this);
}

public record SearchCategoryParam(string Query, string Category): SearchHandler
{
    public async Task<Resto[]> ExecuteSearch(IRestoRepo restoRepo)
        => await restoRepo.Search(this);
}

public record SearchStatusWilayahCategoryParam(string Query, string Status, string Wilayah, string Category): SearchHandler
{
    public async Task<Resto[]> ExecuteSearch(IRestoRepo restoRepo)
        => await restoRepo.Search(this);
}

public record SearchWilayahCategoryParam(string Query, string Wilayah, string Category): SearchHandler
{
    public async Task<Resto[]> ExecuteSearch(IRestoRepo restoRepo)
        => await restoRepo.Search(this);
}

public record SearchStatusCategoryParam(string Query, string Status, string Category): SearchHandler
{
    public async Task<Resto[]> ExecuteSearch(IRestoRepo restoRepo)
        => await restoRepo.Search(this);
}

public record SearchStatusWilayahParam(string Query, string Status, string Wilayah): SearchHandler
{
    public async Task<Resto[]> ExecuteSearch(IRestoRepo restoRepo)
        => await restoRepo.Search(this);
}

public record FilterStatusWilayahCategoryParam(string Status, string Wilayah, string Category): SearchHandler
{
    public async Task<Resto[]> ExecuteSearch(IRestoRepo restoRepo)
        => await restoRepo.Search(this);
}

public record FilterWilayahCategoryParam(string Wilayah, string Category): SearchHandler
{
    public async Task<Resto[]> ExecuteSearch(IRestoRepo restoRepo)
        => await restoRepo.Search(this);
}

public record FilterStatusCategoryParam(string Status, string Category): SearchHandler
{
    public async Task<Resto[]> ExecuteSearch(IRestoRepo restoRepo)
        => await restoRepo.Search(this);
}

public record FilterStatusWilayahParam(string Status, string Wilayah): SearchHandler
{
    public async Task<Resto[]> ExecuteSearch(IRestoRepo restoRepo)
        => await restoRepo.Search(this);
}

public record FilterCategoryParam(string Category): SearchHandler
{
    public async Task<Resto[]> ExecuteSearch(IRestoRepo restoRepo)
        => await restoRepo.Search(this);
}

public record FilterWilayahParam(string Wilayah): SearchHandler
{
    public async Task<Resto[]> ExecuteSearch(IRestoRepo restoRepo)
        => await restoRepo.Search(this);
}

public record FilterStatusParam(string Status): SearchHandler
{
    public async Task<Resto[]> ExecuteSearch(IRestoRepo restoRepo)
        => await restoRepo.Search(this);

}

public record SearchParam(string Query): SearchHandler
{
    public async Task<Resto[]> ExecuteSearch(IRestoRepo restoRepo)
        => await restoRepo.Search(this);

}
