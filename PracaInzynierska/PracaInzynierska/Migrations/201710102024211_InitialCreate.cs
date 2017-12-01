namespace PracaInzynierska.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Device",
                c => new
                    {
                        DeviceId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Producer = c.String(),
                        Type = c.String(),
                        IsWorking = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.DeviceId);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        Place = c.String(nullable: false, maxLength: 50),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        TimeAtWorehouse = c.DateTime(nullable: false),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => t.OrderId);
            
            CreateTable(
                "dbo.Worker",
                c => new
                    {
                        WorkerId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 15),
                        Surname = c.String(nullable: false, maxLength: 20),
                        PhoneNumber = c.Int(nullable: false),
                        EmailAdress = c.String(nullable: false, maxLength: 30),
                        Position = c.Int(nullable: false),
                        Order_OrderId = c.Int(),
                    })
                .PrimaryKey(t => t.WorkerId)
                .ForeignKey("dbo.Order", t => t.Order_OrderId)
                .Index(t => t.Order_OrderId);
            
            CreateTable(
                "dbo.OrderDevice",
                c => new
                    {
                        Order_OrderId = c.Int(nullable: false),
                        Device_DeviceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Order_OrderId, t.Device_DeviceId })
                .ForeignKey("dbo.Order", t => t.Order_OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Device", t => t.Device_DeviceId, cascadeDelete: true)
                .Index(t => t.Order_OrderId)
                .Index(t => t.Device_DeviceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Worker", "Order_OrderId", "dbo.Order");
            DropForeignKey("dbo.OrderDevice", "Device_DeviceId", "dbo.Device");
            DropForeignKey("dbo.OrderDevice", "Order_OrderId", "dbo.Order");
            DropIndex("dbo.OrderDevice", new[] { "Device_DeviceId" });
            DropIndex("dbo.OrderDevice", new[] { "Order_OrderId" });
            DropIndex("dbo.Worker", new[] { "Order_OrderId" });
            DropTable("dbo.OrderDevice");
            DropTable("dbo.Worker");
            DropTable("dbo.Order");
            DropTable("dbo.Device");
        }
    }
}
