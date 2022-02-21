namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'137989d0-f095-472d-8ea4-77922a16bd4f', N'admin@vidly.com', 0, N'AIrsomPh9hSF8D0WxQNAF0I286sZLRB/2cVn2mQn9iAV5mkYSzDQbTJu+657TfkKsw==', N'9609a734-5cfb-4d10-a3bc-565ca00a1649', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'ad1b8a17-d335-4c9c-983b-3db68eff3f2b', N'guest@vidly.com', 0, N'AJ0s5S3nRNbR/+wV0krPdYQ7ZatB8OBZiwM1tvBTjR7pAmpou16DalMaUBLloIpKNg==', N'a89ccf62-14cc-4ba9-8038-4c07dc367c5e', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')

                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'4fceaa82-438c-4677-8c5c-58472fd8b011', N'CanManageMovies')

                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'137989d0-f095-472d-8ea4-77922a16bd4f', N'4fceaa82-438c-4677-8c5c-58472fd8b011')
            ");
        }

        public override void Down()
        {
        }
    }
}
