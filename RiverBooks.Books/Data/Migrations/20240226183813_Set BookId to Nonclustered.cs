using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RiverBooks.Books.Data.Migrations
{
    /// <inheritdoc />
    public partial class SetBookIdtoNonclustered : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Books",
                schema: "Books",
                table: "Books");

            migrationBuilder.DeleteData(
                schema: "Books",
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("1cd306a6-8cfe-4719-b8f6-bfbc44202833"));

            migrationBuilder.DeleteData(
                schema: "Books",
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("376d55c1-713d-4c6e-a905-d6e8808c1979"));

            migrationBuilder.DeleteData(
                schema: "Books",
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("81a8cdd9-c1cb-48d7-9cff-c76ea9502518"));

            migrationBuilder.DeleteData(
                schema: "Books",
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("eac9a9e8-5446-4553-8ed4-fe66c88299ab"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Books",
                schema: "Books",
                table: "Books",
                column: "Id")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.InsertData(
                schema: "Books",
                table: "Books",
                columns: new[] { "Id", "Author", "Price", "Title" },
                values: new object[,]
                {
                    { new Guid("0cb67bd7-5a85-4dcd-bde6-ad78e6df9d1a"), "J.R.R. Tolkien", 10.99m, "The Fellowship of the Ring" },
                    { new Guid("26ef97f5-b502-472b-b9c3-6297e97a6b35"), "J.R.R. Tolkien", 12.99m, "The Return of the King" },
                    { new Guid("7d70ad75-13ab-4145-aa7b-a560a3c9b0b8"), "J.R.R. Tolkien", 9.99m, "The Hobbit" },
                    { new Guid("e00527f3-c22b-4c2b-8d8e-08e31bcf4ab7"), "J.R.R. Tolkien", 11.99m, "The Two Towers" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Books",
                schema: "Books",
                table: "Books");

            migrationBuilder.DeleteData(
                schema: "Books",
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("0cb67bd7-5a85-4dcd-bde6-ad78e6df9d1a"));

            migrationBuilder.DeleteData(
                schema: "Books",
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("26ef97f5-b502-472b-b9c3-6297e97a6b35"));

            migrationBuilder.DeleteData(
                schema: "Books",
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("7d70ad75-13ab-4145-aa7b-a560a3c9b0b8"));

            migrationBuilder.DeleteData(
                schema: "Books",
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("e00527f3-c22b-4c2b-8d8e-08e31bcf4ab7"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Books",
                schema: "Books",
                table: "Books",
                column: "Id");

            migrationBuilder.InsertData(
                schema: "Books",
                table: "Books",
                columns: new[] { "Id", "Author", "Price", "Title" },
                values: new object[,]
                {
                    { new Guid("1cd306a6-8cfe-4719-b8f6-bfbc44202833"), "J.R.R. Tolkien", 12.99m, "The Return of the King" },
                    { new Guid("376d55c1-713d-4c6e-a905-d6e8808c1979"), "J.R.R. Tolkien", 11.99m, "The Two Towers" },
                    { new Guid("81a8cdd9-c1cb-48d7-9cff-c76ea9502518"), "J.R.R. Tolkien", 10.99m, "The Fellowship of the Ring" },
                    { new Guid("eac9a9e8-5446-4553-8ed4-fe66c88299ab"), "J.R.R. Tolkien", 9.99m, "The Hobbit" }
                });
        }
    }
}
