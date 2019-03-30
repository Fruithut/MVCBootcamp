namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'71d0ad4c-bafc-443b-b32f-37680c09148c', N'admin@vidly.com', 0, N'AM7HPuIIfuKPEmaehg2+86l5k+p5EJJKUaA95ijOYNILeXcrtzcdlu9mUymEpnB7rA==', N'e3c944f0-7765-400c-a08b-588907f8793c', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'7a3847cc-2a80-49b1-aaa6-3c053cb03a52', N'guest@vidly.com', 0, N'ANTZTq9zMMu2KEjsCbRPrIdOsLAnY+78pElLoLzxVOfwfdL9Ixm4prWQtkbW3siIuQ==', N'319db6a6-3225-4d07-b906-f95cac05eee7', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')

                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'dea62eb1-9e24-4254-9b59-533e9e0e99da', N'CanManageMovies')

                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'71d0ad4c-bafc-443b-b32f-37680c09148c', N'dea62eb1-9e24-4254-9b59-533e9e0e99da')
            ");
        }

        public override void Down()
        {
        }
    }
}
