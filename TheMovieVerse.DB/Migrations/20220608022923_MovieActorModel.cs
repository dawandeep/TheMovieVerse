using Microsoft.EntityFrameworkCore.Migrations;

namespace TheMovieVerse.DB.Migrations
{
    public partial class MovieActorModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Actors_Movies_MovieId",
                table: "Actors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Movies",
                table: "Movies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Actors",
                table: "Actors");

            migrationBuilder.DropIndex(
                name: "IX_Actors_MovieId",
                table: "Actors");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Actors");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "Actors");

            migrationBuilder.AddColumn<long>(
                name: "MovieId",
                table: "Movies",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<long>(
                name: "ActorId",
                table: "Actors",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Movies",
                table: "Movies",
                column: "MovieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Actors",
                table: "Actors",
                column: "ActorId");

            migrationBuilder.CreateTable(
                name: "MovieActors",
                columns: table => new
                {
                    MovieActorId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<long>(nullable: false),
                    ActorId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieActors", x => x.MovieActorId);
                    table.ForeignKey(
                        name: "FK_MovieActors_Actors_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actors",
                        principalColumn: "ActorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieActors_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShowSchedules_MovieId",
                table: "ShowSchedules",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieActors_ActorId",
                table: "MovieActors",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieActors_MovieId",
                table: "MovieActors",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShowSchedules_Movies_MovieId",
                table: "ShowSchedules",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "MovieId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShowSchedules_Movies_MovieId",
                table: "ShowSchedules");

            migrationBuilder.DropTable(
                name: "MovieActors");

            migrationBuilder.DropIndex(
                name: "IX_ShowSchedules_MovieId",
                table: "ShowSchedules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Movies",
                table: "Movies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Actors",
                table: "Actors");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "ActorId",
                table: "Actors");

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "Movies",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "Actors",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<long>(
                name: "MovieId",
                table: "Actors",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Movies",
                table: "Movies",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Actors",
                table: "Actors",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Actors_MovieId",
                table: "Actors",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Actors_Movies_MovieId",
                table: "Actors",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
