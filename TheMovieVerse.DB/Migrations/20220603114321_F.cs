using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TheMovieVerse.DB.Migrations
{
    public partial class F : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieTitle = table.Column<string>(maxLength: 150, nullable: false),
                    MovieDirector = table.Column<string>(maxLength: 50, nullable: false),
                    MovieProducer = table.Column<string>(maxLength: 50, nullable: false),
                    MovieLanguage = table.Column<string>(maxLength: 50, nullable: false),
                    MovieGenre = table.Column<string>(maxLength: 50, nullable: false),
                    MovieRating = table.Column<int>(nullable: false),
                    IsUpcoming = table.Column<bool>(nullable: false),
                    MovieDuration = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShowSchedules",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketPrice = table.Column<double>(nullable: false),
                    ShowDate = table.Column<DateTime>(type: "date", nullable: false),
                    TimeSlot = table.Column<string>(maxLength: 50, nullable: true),
                    MovieId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShowSchedules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Theatres",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TheatreName = table.Column<string>(maxLength: 60, nullable: true),
                    TotalSeats = table.Column<int>(nullable: false),
                    IsBooked = table.Column<bool>(nullable: false),
                    CinemaId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Theatres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Actors",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 50, nullable: true),
                    LastName = table.Column<string>(maxLength: 50, nullable: true),
                    MovieId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Actors_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieBookings",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 50, nullable: true),
                    LastName = table.Column<string>(maxLength: 50, nullable: true),
                    Age = table.Column<int>(nullable: false),
                    NoOfTickets = table.Column<int>(nullable: false),
                    MovieId = table.Column<long>(nullable: false),
                    TheatreId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieBookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovieBookings_Theatres_TheatreId",
                        column: x => x.TheatreId,
                        principalTable: "Theatres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seats",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeatNo = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    IsOccupied = table.Column<bool>(nullable: false),
                    TheatreId = table.Column<long>(nullable: false),
                    MovieBookingId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seats_MovieBookings_MovieBookingId",
                        column: x => x.MovieBookingId,
                        principalTable: "MovieBookings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Seats_Theatres_TheatreId",
                        column: x => x.TheatreId,
                        principalTable: "Theatres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Actors_MovieId",
                table: "Actors",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieBookings_TheatreId",
                table: "MovieBookings",
                column: "TheatreId");

            migrationBuilder.CreateIndex(
                name: "IX_Seats_MovieBookingId",
                table: "Seats",
                column: "MovieBookingId");

            migrationBuilder.CreateIndex(
                name: "IX_Seats_TheatreId",
                table: "Seats",
                column: "TheatreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Actors");

            migrationBuilder.DropTable(
                name: "Seats");

            migrationBuilder.DropTable(
                name: "ShowSchedules");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "MovieBookings");

            migrationBuilder.DropTable(
                name: "Theatres");
        }
    }
}
