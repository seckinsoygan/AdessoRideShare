using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
	public partial class mig1 : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "Travels",
				columns: table => new
				{
					TravelId = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					FromWhere = table.Column<string>(type: "nvarchar(max)", nullable: false),
					FromTo = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Date = table.Column<DateTime>(type: "datetime2", nullable: false),
					Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
					SeatCount = table.Column<int>(type: "int", nullable: false),
					TravelStatus = table.Column<bool>(type: "bit", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Travels", x => x.TravelId);
				});
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "Travels");
		}
	}
}
