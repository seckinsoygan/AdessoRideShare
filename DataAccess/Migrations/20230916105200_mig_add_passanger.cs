using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
	public partial class mig_add_passanger : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "Passengers",
				columns: table => new
				{
					PassengerId = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
					TravelId = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Passengers", x => x.PassengerId);
					table.ForeignKey(
						name: "FK_Passengers_Travels_TravelId",
						column: x => x.TravelId,
						principalTable: "Travels",
						principalColumn: "TravelId",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateIndex(
				name: "IX_Passengers_TravelId",
				table: "Passengers",
				column: "TravelId");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "Passengers");
		}
	}
}
