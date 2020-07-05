using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace api.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "person",
                columns: table => new
                {
                    person_id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    person_name = table.Column<string>(unicode: false, maxLength: 500, nullable: true, defaultValueSql: "'NULL'"),
                    person_age = table.Column<int>(type: "int(11)", nullable: true, defaultValueSql: "'NULL'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_person", x => x.person_id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<int>(type: "mediumint(8) unsigned", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    first_name = table.Column<string>(unicode: false, maxLength: 255, nullable: true, defaultValueSql: "'NULL'"),
                    last_name = table.Column<string>(unicode: false, maxLength: 255, nullable: true, defaultValueSql: "'NULL'"),
                    phone = table.Column<string>(unicode: false, maxLength: 100, nullable: true, defaultValueSql: "'NULL'"),
                    email = table.Column<string>(unicode: false, maxLength: 255, nullable: true, defaultValueSql: "'NULL'"),
                    company = table.Column<string>(unicode: false, maxLength: 255, nullable: true, defaultValueSql: "'NULL'"),
                    street_address = table.Column<string>(unicode: false, maxLength: 255, nullable: true, defaultValueSql: "'NULL'"),
                    city = table.Column<string>(unicode: false, maxLength: 255, nullable: true, defaultValueSql: "'NULL'"),
                    zip = table.Column<string>(unicode: false, maxLength: 10, nullable: true, defaultValueSql: "'NULL'"),
                    country = table.Column<string>(unicode: false, maxLength: 100, nullable: true, defaultValueSql: "'NULL'"),
                    date_created = table.Column<string>(unicode: false, maxLength: 255, nullable: true, defaultValueSql: "'NULL'"),
                    date_modified = table.Column<string>(unicode: false, maxLength: 255, nullable: true, defaultValueSql: "'NULL'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "person");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
