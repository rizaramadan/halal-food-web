using System;
using Logic;
using JetBrains.Annotations;
using Xunit;

namespace Web.Tests.Features;

[TestSubject(typeof(RestoFinder))]
public class RestoFinderTest
{
    [Theory]
    [InlineData("query", "status", "wilayah", "category", typeof(SearchStatusWilayahCategoryParam))]
    [InlineData("query", "", "wilayah", "category", typeof(SearchWilayahCategoryParam))]
    [InlineData("query", "status", "wilayah", "", typeof(SearchStatusWilayahParam))]
    [InlineData("query", "status", "", "category", typeof(SearchStatusCategoryParam))]
    [InlineData("query", "status", "", "", typeof(SearchStatusParam))]
    [InlineData("query", "", "wilayah", "", typeof(SearchWilayahParam))]
    [InlineData("query", "", "", "category", typeof(SearchCategoryParam))]
    [InlineData("", "status", "wilayah", "category", typeof(FilterStatusWilayahCategoryParam))]
    [InlineData("", "", "wilayah", "category", typeof(FilterWilayahCategoryParam))]
    [InlineData("", "status", "wilayah", "", typeof(FilterStatusWilayahParam))]
    [InlineData("", "status", "", "category", typeof(FilterStatusCategoryParam))]
    [InlineData("", "status", "", "", typeof(FilterStatusParam))]
    [InlineData("", "", "wilayah", "", typeof(FilterWilayahParam))]
    [InlineData("", "", "", "category", typeof(FilterCategoryParam))]
    public void ParseSearchParam_VariousCombinations_ReturnsCorrectType(string search, string status, string wilayah, string category, Type expectedType)
    {
        // Arrange
        var param = new CompleteSearchParam(search, status, wilayah, category);

        // Act
        var result = RestoFinder.ParseSearchParam(param);

        // Assert
        Assert.IsType(expectedType, result);
    }
}
