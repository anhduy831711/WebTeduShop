namespace TeduShop.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class initialDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Posts",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 256),
                    Alias = c.String(nullable: false, maxLength: 256, unicode: false),
                    CategogyID = c.Int(nullable: false),
                    Image = c.String(maxLength: 256),
                    Descreption = c.String(maxLength: 500),
                    Content = c.String(maxLength: 500),
                    HomeFlag = c.Boolean(),
                    ViewCount = c.Int(),
                    HotFlag = c.Boolean(),
                    CreatedDate = c.DateTime(),
                    CreadedBy = c.String(maxLength: 256),
                    UpdateDate = c.DateTime(),
                    UpdateBy = c.String(maxLength: 256),
                    MetaKeyWord = c.String(maxLength: 256),
                    MetaDescription = c.String(maxLength: 256),
                    Status = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.PostCategories", t => t.CategogyID, cascadeDelete: true)
                .Index(t => t.CategogyID);

            CreateTable(
                "dbo.PostCategories",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 256),
                    Alias = c.String(nullable: false, maxLength: 256, unicode: false),
                    ParentID = c.Int(),
                    Decription = c.String(maxLength: 500),
                    DisplayOrder = c.Int(),
                    Image = c.String(maxLength: 256),
                    HomeFlag = c.Boolean(),
                    CreatedDate = c.DateTime(),
                    CreadedBy = c.String(maxLength: 256),
                    UpdateDate = c.DateTime(),
                    UpdateBy = c.String(maxLength: 256),
                    MetaKeyWord = c.String(maxLength: 256),
                    MetaDescription = c.String(maxLength: 256),
                    Status = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.Footers",
                c => new
                {
                    ID = c.String(nullable: false, maxLength: 50),
                    Content = c.String(maxLength: 256),
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.MenuGroups",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 256),
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.Menus",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 50),
                    URL = c.String(nullable: false, maxLength: 500),
                    DisplayOrder = c.Int(),
                    GroupID = c.Int(nullable: false),
                    Target = c.String(maxLength: 10),
                    Status = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MenuGroups", t => t.GroupID, cascadeDelete: true)
                .Index(t => t.GroupID);

            CreateTable(
                "dbo.OrderDetails",
                c => new
                {
                    OrderID = c.Int(nullable: false),
                    ProductID = c.Int(nullable: false),
                    Quantity = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.OrderID, t.ProductID })
                .ForeignKey("dbo.Orders", t => t.OrderID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.OrderID)
                .Index(t => t.ProductID);

            CreateTable(
                "dbo.Orders",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    CustumerName = c.String(nullable: false, maxLength: 256),
                    CustummerAddress = c.String(nullable: false, maxLength: 256),
                    CustumerEmail = c.String(nullable: false, maxLength: 256),
                    CustumnerPhone = c.String(nullable: false, maxLength: 256),
                    CustumerMessage = c.String(maxLength: 256),
                    CreateDate = c.DateTime(nullable: false),
                    CreateBy = c.DateTime(nullable: false),
                    PaymentMethod = c.String(maxLength: 256),
                    PaymentStatus = c.String(maxLength: 256),
                    Status = c.String(maxLength: 500),
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.Products",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 256),
                    Alias = c.String(nullable: false, maxLength: 256, unicode: false),
                    CategogyID = c.Int(nullable: false),
                    Image = c.String(maxLength: 256),
                    Descreption = c.String(maxLength: 500),
                    Content = c.String(maxLength: 256),
                    MoreImages = c.String(storeType: "xml"),
                    Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    PromotionPrice = c.Decimal(precision: 18, scale: 2),
                    Warranty = c.Int(nullable: false),
                    HomeFlag = c.Boolean(),
                    ViewCount = c.Int(),
                    HotFlag = c.Boolean(),
                    CreatedDate = c.DateTime(),
                    CreadedBy = c.String(maxLength: 256),
                    UpdateDate = c.DateTime(),
                    UpdateBy = c.String(maxLength: 256),
                    MetaKeyWord = c.String(maxLength: 256),
                    MetaDescription = c.String(maxLength: 256),
                    Status = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ProductCategories", t => t.CategogyID, cascadeDelete: true)
                .Index(t => t.CategogyID);

            CreateTable(
                "dbo.ProductCategories",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 256),
                    Alias = c.String(nullable: false, maxLength: 50, unicode: false),
                    ParentID = c.Int(),
                    Decription = c.String(maxLength: 256),
                    DisplayOrder = c.Int(),
                    Image = c.String(maxLength: 256),
                    HomeFlag = c.Boolean(),
                    CreatedDate = c.DateTime(),
                    CreadedBy = c.String(maxLength: 256),
                    UpdateDate = c.DateTime(),
                    UpdateBy = c.String(maxLength: 256),
                    MetaKeyWord = c.String(maxLength: 256),
                    MetaDescription = c.String(maxLength: 256),
                    Status = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.Pages",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 256),
                    Alias = c.String(nullable: false, maxLength: 256, unicode: false),
                    Content = c.String(maxLength: 256),
                    MetaKeyWord = c.String(),
                    MetaDescription = c.String(),
                    Status = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.PostTags",
                c => new
                {
                    PostID = c.Int(nullable: false),
                    TagID = c.String(nullable: false, maxLength: 50, unicode: false),
                })
                .PrimaryKey(t => new { t.PostID, t.TagID })
                .ForeignKey("dbo.Posts", t => t.PostID, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.TagID, cascadeDelete: true)
                .Index(t => t.PostID)
                .Index(t => t.TagID);

            CreateTable(
                "dbo.Tags",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 50, unicode: false),
                    Name = c.String(nullable: false, maxLength: 50),
                    Type = c.String(nullable: false, maxLength: 50),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.ProductTags",
                c => new
                {
                    ProductId = c.Int(nullable: false),
                    TagID = c.String(nullable: false, maxLength: 50, unicode: false),
                })
                .PrimaryKey(t => new { t.ProductId, t.TagID })
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.TagID, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.TagID);

            CreateTable(
                "dbo.Slides",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 256),
                    Description = c.String(maxLength: 500),
                    Image = c.String(nullable: false, maxLength: 500),
                    URL = c.String(nullable: false, maxLength: 500),
                    DisplayOrder = c.String(maxLength: 256),
                    Status = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.SupportOnlines",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Name = c.String(maxLength: 50),
                    Depatement = c.String(maxLength: 50),
                    Skyle = c.String(maxLength: 50),
                    Phone = c.String(maxLength: 50),
                    Email = c.String(maxLength: 50),
                    FaceBook = c.String(maxLength: 50),
                    Status = c.String(maxLength: 500),
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.SystemConfigs",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Code = c.String(nullable: false, maxLength: 50),
                    ValueString = c.String(maxLength: 50),
                    ValueInt = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.VisitorStatistics",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    VisitedDate = c.DateTime(nullable: false),
                    IPAddress = c.String(maxLength: 60),
                })
                .PrimaryKey(t => t.ID);
        }

        public override void Down()
        {
            DropForeignKey("dbo.ProductTags", "TagID", "dbo.Tags");
            DropForeignKey("dbo.ProductTags", "ProductId", "dbo.Products");
            DropForeignKey("dbo.PostTags", "TagID", "dbo.Tags");
            DropForeignKey("dbo.PostTags", "PostID", "dbo.Posts");
            DropForeignKey("dbo.OrderDetails", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Products", "CategogyID", "dbo.ProductCategories");
            DropForeignKey("dbo.OrderDetails", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.Menus", "GroupID", "dbo.MenuGroups");
            DropForeignKey("dbo.Posts", "CategogyID", "dbo.PostCategories");
            DropIndex("dbo.ProductTags", new[] { "TagID" });
            DropIndex("dbo.ProductTags", new[] { "ProductId" });
            DropIndex("dbo.PostTags", new[] { "TagID" });
            DropIndex("dbo.PostTags", new[] { "PostID" });
            DropIndex("dbo.Products", new[] { "CategogyID" });
            DropIndex("dbo.OrderDetails", new[] { "ProductID" });
            DropIndex("dbo.OrderDetails", new[] { "OrderID" });
            DropIndex("dbo.Menus", new[] { "GroupID" });
            DropIndex("dbo.Posts", new[] { "CategogyID" });
            DropTable("dbo.VisitorStatistics");
            DropTable("dbo.SystemConfigs");
            DropTable("dbo.SupportOnlines");
            DropTable("dbo.Slides");
            DropTable("dbo.ProductTags");
            DropTable("dbo.Tags");
            DropTable("dbo.PostTags");
            DropTable("dbo.Pages");
            DropTable("dbo.ProductCategories");
            DropTable("dbo.Products");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Menus");
            DropTable("dbo.MenuGroups");
            DropTable("dbo.Footers");
            DropTable("dbo.PostCategories");
            DropTable("dbo.Posts");
        }
    }
}