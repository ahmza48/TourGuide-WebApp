using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Travel.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Admin",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        FirstName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        LastName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        Password = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__Admin__3214EC07B0E30218", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Guide",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        Image = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        Contact = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        PlaceName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__Guide__3214EC07C7BADD53", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Hotels",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        HotelName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        OwnerName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        Contact = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        Image = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        PlaceName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        Rooms = table.Column<int>(type: "int", nullable: true),
            //        Price = table.Column<int>(type: "int", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__tmp_ms_x__3214EC07CB909248", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Photographer",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        Image = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        Contact = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        PlaceName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__Photogra__3214EC07FB09963D", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Place",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
            //        Photo = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__Place__3214EC070B56382A", x => x.Id);
            //    });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "Admin");

            //migrationBuilder.DropTable(
            //    name: "Guide");

            //migrationBuilder.DropTable(
            //    name: "Hotels");

            //migrationBuilder.DropTable(
            //    name: "Photographer");

            //migrationBuilder.DropTable(
            //    name: "Place");
        }
    }
}
