using FluentAssertions;
using Logic;
using JetBrains.Annotations;
using Xunit;

namespace Web.Tests.Features;

[TestSubject(typeof(CompleteSearchParam))]
public class SearchParamTest
{

    [Fact]
    public void SearchParamToQueryTest()
    {
        var param = new CompleteSearchParam("::only this text survive::", "semua", "Semua", "seMUa");
        param.HasCategory().Should().BeFalse();
        param.HasWilayah().Should().BeFalse();
        param.HasStatus().Should().BeFalse();

        param = new CompleteSearchParam(string.Empty, "semua", "Semua", "seMUa");
        param.HasCategory().Should().BeFalse();
        param.HasWilayah().Should().BeFalse();
        param.HasStatus().Should().BeFalse();
        param.HasQuery().Should().BeFalse();

        param = new CompleteSearchParam(string.Empty, string.Empty, string.Empty, string.Empty);
        param.HasCategory().Should().BeFalse();
        param.HasWilayah().Should().BeFalse();
        param.HasStatus().Should().BeFalse();
        param.HasQuery().Should().BeFalse();
    }
}
