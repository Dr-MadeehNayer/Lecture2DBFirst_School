using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Lecture2DBFirst_School.Migrations
{
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
          //  Sql("INSERT INTO[dbo].[AspNetUsers] ([Id], [BirthDate], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [EmploymentDate]) VALUES(N'd5930c55-ec2b-40ed-aeba-a780fd911369', N'2021-01-26 00:00:00', N'madeehnayer@hotmail.com', 0, N'AGuv7n4WO7zXrVpBirB+krNen6TI63Jam869qg/z3W1o3atZnjl7yZ4KD10+ZCEoxA==', N'623f2866-b793-4040-b5c6-f3f33de3a2d9', NULL, 0, 0, NULL, 1, 0, N'madeeh', NULL)");
        }
    }
}