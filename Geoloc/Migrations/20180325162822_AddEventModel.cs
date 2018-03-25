﻿using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Geoloc.Migrations
{
    public partial class AddEventModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Meetings_MeetingId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersInMeetings_Meetings_MeetingId",
                table: "UsersInMeetings");

            migrationBuilder.DropIndex(
                name: "IX_UsersInMeetings_MeetingId",
                table: "UsersInMeetings");

            migrationBuilder.RenameColumn(
                name: "MeetingId",
                table: "AspNetUsers",
                newName: "EventId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_MeetingId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_EventId");

            migrationBuilder.RenameColumn(
                name: "Time",
                table: "Meetings",
                newName: "StartTime");

            migrationBuilder.AddColumn<Guid>(
                name: "EventId",
                table: "UsersInMeetings",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "Meetings",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_UsersInMeetings_EventId",
                table: "UsersInMeetings",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Meetings_EventId",
                table: "AspNetUsers",
                column: "EventId",
                principalTable: "Meetings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersInMeetings_Meetings_EventId",
                table: "UsersInMeetings",
                column: "EventId",
                principalTable: "Meetings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Meetings_EventId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersInMeetings_Meetings_EventId",
                table: "UsersInMeetings");

            migrationBuilder.DropIndex(
                name: "IX_UsersInMeetings_EventId",
                table: "UsersInMeetings");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "UsersInMeetings");

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "Meetings");

            migrationBuilder.RenameColumn(
                name: "EventId",
                table: "AspNetUsers",
                newName: "MeetingId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_EventId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_MeetingId");

            migrationBuilder.RenameColumn(
                name: "StartTime",
                table: "Meetings",
                newName: "Time");

            migrationBuilder.CreateIndex(
                name: "IX_UsersInMeetings_MeetingId",
                table: "UsersInMeetings",
                column: "MeetingId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Meetings_MeetingId",
                table: "AspNetUsers",
                column: "MeetingId",
                principalTable: "Meetings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersInMeetings_Meetings_MeetingId",
                table: "UsersInMeetings",
                column: "MeetingId",
                principalTable: "Meetings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
