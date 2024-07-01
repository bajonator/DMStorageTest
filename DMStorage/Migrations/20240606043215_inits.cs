using Microsoft.EntityFrameworkCore.Migrations;

namespace DMStorage.Migrations
{
    public partial class inits : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Devices_Departments_DepartmentId",
                table: "Devices");

            migrationBuilder.DropForeignKey(
                name: "FK_Devices_TypeDevices_TypeDeviceId",
                table: "Devices");

            migrationBuilder.CreateIndex(
                name: "IX_Devices_MachineId",
                table: "Devices",
                column: "MachineId");

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_Departments_DepartmentId",
                table: "Devices",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_Machines_MachineId",
                table: "Devices",
                column: "MachineId",
                principalTable: "Machines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_TypeDevices_TypeDeviceId",
                table: "Devices",
                column: "TypeDeviceId",
                principalTable: "TypeDevices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Devices_Departments_DepartmentId",
                table: "Devices");

            migrationBuilder.DropForeignKey(
                name: "FK_Devices_Machines_MachineId",
                table: "Devices");

            migrationBuilder.DropForeignKey(
                name: "FK_Devices_TypeDevices_TypeDeviceId",
                table: "Devices");

            migrationBuilder.DropIndex(
                name: "IX_Devices_MachineId",
                table: "Devices");

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_Departments_DepartmentId",
                table: "Devices",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_TypeDevices_TypeDeviceId",
                table: "Devices",
                column: "TypeDeviceId",
                principalTable: "TypeDevices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
