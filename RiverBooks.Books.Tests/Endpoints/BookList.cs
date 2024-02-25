using FastEndpoints.Testing;
using Xunit.Abstractions;

namespace RiverBooks.Books.Tests.Endpoints;

public class BookList(Fixture fixture, ITestOutputHelper outputHelper) :
  TestClass<Fixture>(fixture, outputHelper)
{
  [Fact]
  public void Test1()
  {
  }
}
