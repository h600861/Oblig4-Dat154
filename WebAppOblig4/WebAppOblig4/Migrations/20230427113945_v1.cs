using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WebAppOblig4.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "hotel");

            migrationBuilder.CreateTable(
            name: "available_rooms",
            schema: "hotel",
            columns: table => new
            {
             RoomNumber = table.Column<int>(type: "integer", nullable: false),
             CheckinDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                CheckoutDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                RoomId = table.Column<int>(type: "integer", nullable: true)
             },
             constraints: table =>
            {
                 table.PrimaryKey("PK_available_rooms", x => x.RoomNumber);
                  table.ForeignKey(
               name: "FK_available_rooms_rooms_RoomId",
                 column: x => x.RoomId,
            principalSchema: "hotel",
            principalTable: "rooms",
            principalColumn: "id",
            onDelete: ReferentialAction.Restrict);
    });



            migrationBuilder.CreateTable(
                name: "customers",
                schema: "hotel",
                columns: table => new
                {
                    email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("email_pk", x => x.email);
                });

            migrationBuilder.CreateTable(
                name: "rooms",
                schema: "hotel",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    roomType = table.Column<int>(type: "integer", nullable: false),
                    num_beds = table.Column<int>(type: "integer", nullable: false),
                    price_per_night = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("rooms_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tasks",
                schema: "hotel",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    task_type = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    room_number = table.Column<int>(type: "integer", nullable: false),
                    task_status = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false, defaultValueSql: "'new'::character varying"),
                    task_notes = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("tasks_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "bookings",
                schema: "hotel",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    room_type = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    checkin_date = table.Column<DateOnly>(type: "date", nullable: false),
                    checkout_date = table.Column<DateOnly>(type: "date", nullable: false),
                    customers_email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    RoomId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("bookings_pkey", x => x.id);
                    table.ForeignKey(
                        name: "FK_bookings_rooms_RoomId",
                        column: x => x.RoomId,
                        principalSchema: "hotel",
                        principalTable: "rooms",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "email_fk",
                        column: x => x.customers_email,
                        principalSchema: "hotel",
                        principalTable: "customers",
                        principalColumn: "email");
                });

            migrationBuilder.CreateIndex(
                name: "IX_bookings_customers_email",
                schema: "hotel",
                table: "bookings",
                column: "customers_email");

            migrationBuilder.CreateIndex(
                name: "IX_bookings_RoomId",
                schema: "hotel",
                table: "bookings",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "customers_email_key",
                schema: "hotel",
                table: "customers",
                column: "email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bookings",
                schema: "hotel");

            migrationBuilder.DropTable(
                name: "tasks",
                schema: "hotel");

            migrationBuilder.DropTable(
                name: "rooms",
                schema: "hotel");

            migrationBuilder.DropTable(
                name: "customers",
                schema: "hotel");
        }
    }
}
