using FastEndpoints;
using FastEndpoints.Testing;
using FluentAssertions;
using RiverBooks.Books.Application;
using RiverBooks.Books.BookEndpoints;
using Xunit.Abstractions;

namespace RiverBooks.Books.Tests.Endpoints;

public class BookGetById(Fixture fixture, ITestOutputHelper outputHelper) :
  TestClass<Fixture>(fixture, outputHelper)
{
  [Theory]
  [InlineData("81A8CDD9-C1CB-48D7-9CFF-C76EA9502518", "The Fellowship of the Ring")]
  [InlineData("376D55C1-713D-4C6E-A905-D6E8808C1979", "The Two Towers")]
  [InlineData("1CD306A6-8CFE-4719-B8F6-BFBC44202833", "The Return of the King")]
  [InlineData("EAC9A9E8-5446-4553-8ED4-FE66C88299AB", "The Hobbit")]
  public async Task ReturnsExpectedBookGivenIdAsync(string validId, string expectedTitle)
  {
    var testResult = await Fixture.Client.GETAsync<GetById, GetBookByIdRequest, BookDto>(new GetBookByIdRequest { Id = Guid.Parse(validId) });

    testResult.Response.EnsureSuccessStatusCode();
    testResult.Result.Title.Should().Be(expectedTitle);
  }
}
