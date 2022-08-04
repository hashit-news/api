using Microsoft.EntityFrameworkCore.Migrations;
using NodaTime;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Hashit.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase().Annotation("Npgsql:Enum:role_type", "admin,user");

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table =>
                    new
                    {
                        id = table.Column<RoleType>(type: "role_type", nullable: false),
                        created_at = table.Column<Instant>(
                            type: "timestamp with time zone",
                            nullable: false,
                            defaultValueSql: "CURRENT_TIMESTAMP"
                        ),
                        updated_at = table.Column<Instant>(
                            type: "timestamp with time zone",
                            nullable: false,
                            defaultValueSql: "CURRENT_TIMESTAMP"
                        )
                    },
                constraints: table =>
                {
                    table.PrimaryKey("pk_roles", x => x.id);
                }
            );

            migrationBuilder.CreateTable(
                name: "users",
                columns: table =>
                    new
                    {
                        id = table
                            .Column<int>(type: "integer", nullable: false)
                            .Annotation(
                                "Npgsql:ValueGenerationStrategy",
                                NpgsqlValueGenerationStrategy.IdentityByDefaultColumn
                            ),
                        username = table.Column<string>(
                            type: "character varying(20)",
                            maxLength: 20,
                            nullable: true
                        ),
                        email = table.Column<string>(
                            type: "character varying(255)",
                            maxLength: 255,
                            nullable: true
                        ),
                        email_verified = table.Column<bool>(type: "boolean", nullable: false),
                        wallet_address = table.Column<string>(
                            type: "character varying(40)",
                            maxLength: 40,
                            nullable: false
                        ),
                        wallet_signing_nonce = table.Column<string>(
                            type: "character varying(255)",
                            maxLength: 255,
                            nullable: false
                        ),
                        last_logged_in_at = table.Column<Instant>(
                            type: "timestamp with time zone",
                            nullable: true
                        ),
                        failed_login_attempts = table.Column<int>(type: "integer", nullable: false),
                        lockout_expiry_at = table.Column<Instant>(
                            type: "timestamp with time zone",
                            nullable: true
                        ),
                        created_at = table.Column<Instant>(
                            type: "timestamp with time zone",
                            nullable: false,
                            defaultValueSql: "CURRENT_TIMESTAMP"
                        ),
                        updated_at = table.Column<Instant>(
                            type: "timestamp with time zone",
                            nullable: false,
                            defaultValueSql: "CURRENT_TIMESTAMP"
                        )
                    },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                }
            );

            migrationBuilder.CreateTable(
                name: "user_roles",
                columns: table =>
                    new
                    {
                        user_id = table.Column<int>(type: "integer", nullable: false),
                        role_id = table.Column<RoleType>(type: "role_type", nullable: false),
                        created_at = table.Column<Instant>(
                            type: "timestamp with time zone",
                            nullable: false,
                            defaultValueSql: "CURRENT_TIMESTAMP"
                        ),
                        updated_at = table.Column<Instant>(
                            type: "timestamp with time zone",
                            nullable: false,
                            defaultValueSql: "CURRENT_TIMESTAMP"
                        )
                    },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_roles", x => new { x.user_id, x.role_id });
                    table.ForeignKey(
                        name: "fk_user_roles_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "fk_user_roles_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.InsertData(
                table: "roles",
                column: "id",
                values: new object[] { RoleType.Admin, RoleType.User }
            );

            migrationBuilder.CreateIndex(
                name: "ix_user_roles_role_id",
                table: "user_roles",
                column: "role_id"
            );

            migrationBuilder.CreateIndex(
                name: "ix_users_email",
                table: "users",
                column: "email",
                unique: true
            );

            migrationBuilder.CreateIndex(
                name: "ix_users_username",
                table: "users",
                column: "username",
                unique: true
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "user_roles");

            migrationBuilder.DropTable(name: "roles");

            migrationBuilder.DropTable(name: "users");
        }
    }
}
