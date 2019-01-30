using Microsoft.EntityFrameworkCore.Migrations;

namespace RelogioDePonto.Migrations
{
    public partial class spGetProjetos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE [dbo].[GetProjetos]
                    @Nome varchar(50)
                AS
                BEGIN
                    SET NOCOUNT ON;
                    select * from Projetos where Nome like @Nome +'%'
                END";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
