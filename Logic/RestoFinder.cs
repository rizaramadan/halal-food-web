namespace Logic;

[Flags]
public enum SearchFlags
{
    None = 0,
    HasSearchText = 1,
    HasStatus =  2,
    HasWilayah =  4,
    HasCategory =  8,
}

public class RestoFinder(IRestoRepo restoRepo)
{
    public async Task<Resto[]> FindResto(CompleteSearchParam param)
    {
        var specificSearchParam = ParseSearchParam(param);
        return await specificSearchParam.ExecuteSearch(restoRepo);
    }

    public static SearchHandler ParseSearchParam(CompleteSearchParam param)
    {
        var flags = SearchFlags.None;
        if (!string.IsNullOrWhiteSpace(param.Search)) flags |= SearchFlags.HasSearchText;
        if (param.HasStatus()) flags |= SearchFlags.HasStatus;
        if (param.HasWilayah()) flags |= SearchFlags.HasWilayah;
        if (param.HasCategory()) flags |= SearchFlags.HasCategory;

        return flags switch
        {
            //Search
            SearchFlags.HasSearchText | SearchFlags.HasStatus | SearchFlags.HasWilayah | SearchFlags.HasCategory =>
                new SearchStatusWilayahCategoryParam(param.Search, param.Status, param.Wilayah, param.Category),
            SearchFlags.HasSearchText | SearchFlags.HasWilayah | SearchFlags.HasCategory =>
                new SearchWilayahCategoryParam(param.Search, param.Status, param.Wilayah),
            SearchFlags.HasSearchText | SearchFlags.HasStatus | SearchFlags.HasCategory =>
                new SearchStatusCategoryParam(param.Search, param.Status, param.Wilayah),
            SearchFlags.HasSearchText | SearchFlags.HasStatus | SearchFlags.HasWilayah =>
                new SearchStatusWilayahParam(param.Search, param.Status, param.Wilayah),
            SearchFlags.HasSearchText | SearchFlags.HasCategory =>
                new SearchCategoryParam(param.Search, param.Category),
            SearchFlags.HasSearchText | SearchFlags.HasWilayah =>
                new SearchWilayahParam(param.Search, param.Wilayah),
            SearchFlags.HasSearchText | SearchFlags.HasStatus =>
                new SearchStatusParam(param.Search, param.Status),
            SearchFlags.HasSearchText =>
                new SearchParam(param.Search),
            //filter
            SearchFlags.HasStatus | SearchFlags.HasWilayah | SearchFlags.HasCategory =>
                new FilterStatusWilayahCategoryParam(param.Status, param.Wilayah, param.Category),
            SearchFlags.HasWilayah | SearchFlags.HasCategory =>
                new FilterWilayahCategoryParam(param.Wilayah, param.Wilayah),
            SearchFlags.HasStatus | SearchFlags.HasCategory =>
                new FilterStatusCategoryParam(param.Status, param.Category),
            SearchFlags.HasStatus | SearchFlags.HasWilayah =>
                new FilterStatusWilayahParam(param.Status, param.Wilayah),
            SearchFlags.HasCategory =>
                new FilterCategoryParam(param.Category),
            SearchFlags.HasWilayah =>
                new FilterWilayahParam(param.Wilayah),
            SearchFlags.HasStatus =>
                new FilterStatusParam(param.Status),
            SearchFlags.None => param
        };
    }
}

