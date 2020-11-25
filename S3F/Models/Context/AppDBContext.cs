using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SPS.Entities;


namespace SPS.Models.Context
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<AddressBook> AddressBooks { get; set; }
        public DbSet<Commodity> Commodities { get; set; }
        public DbSet<CommodityPrice> CommodityPrices { get; set; }
        public DbSet<Percentage_Income> PercentageIncomes { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<StoreHouse> StoreHouses { get; set; }
        public DbSet<Unit> Units { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<AddressBook>(entity =>
            {
                entity.HasKey(x => x.AddressBookId);
                entity.Property(x => x.Address).HasMaxLength(250);
                entity.Property(x => x.City).HasMaxLength(50);
                entity.Property(x => x.Description).HasMaxLength(350);
                entity.Property(x => x.EmailAddress).HasMaxLength(150);
                entity.Property(x => x.FaxNumber).HasMaxLength(11);
                entity.Property(x => x.InstagrameID).HasMaxLength(150);
                entity.Property(x => x.TelegramID).HasMaxLength(150);
                entity.Property(x => x.MobileNumber1).HasMaxLength(11);
                entity.Property(x => x.MobileNumber2).HasMaxLength(11);
                entity.Property(x => x.PhoneNumber1).HasMaxLength(11);
                entity.Property(x => x.PhoneNumber2).HasMaxLength(11);
                entity.Property(x => x.WebSiteaAddress).HasMaxLength(150);
            });

            builder.Entity<Commodity>(e =>
            {
                e.HasKey(x => x.CommodityId);
                e.Property(x => x.Description).HasMaxLength(350);
                e.Property(x => x.CommodityName).HasMaxLength(100).IsRequired();
                e.Property(x => x.Enabled).IsRequired();
                e.Property(x => x.Register).HasDefaultValueSql("CURRENT_TIMESTAMP").IsRequired();
            });

            builder.Entity<CommodityPrice>(e =>
            {
                e.HasKey(x => x.PriceId);
                e.Property(x => x.CommodityId).IsRequired();
                e.Property(x => x.SellerId).IsRequired();
                e.Property(x => x.UnitId).IsRequired();
                e.Property(x => x.PurchasePrice).IsRequired();
                e.Property(x => x.SalesPrice).IsRequired();

            });

            builder.Entity<Seller>(e =>
            {
                e.HasKey(x => x.SellerId);
                e.Property(x => x.SellerName).HasMaxLength(150).IsRequired().IsUnicode();
                e.Property(x => x.Company).HasMaxLength(350);
                e.Property(x => x.Enabled).IsRequired();
                e.Property(x => x.Register).HasDefaultValueSql("CURRENT_TIMESTAMP").IsRequired();
                
            });

            builder.Entity<Percentage_Income>(e =>
            {
                e.HasKey(x => x.IncomeId);
                e.Property(x => x.PercentageOfIncome).IsRequired().HasDefaultValue(20);
                e.Property(x => x.Enabled).IsRequired();
                e.Property(x => x.Register).HasDefaultValueSql("CURRENT_TIMESTAMP").IsRequired();
            });

            builder.Entity<Unit>(e =>
            {
                e.HasKey(x => x.UnitId);
                e.Property(x => x.UnitName).HasMaxLength(50).IsRequired().IsUnicode();
                e.Property(x => x.Enabled).IsRequired(); 
                e.Property(x => x.Register).HasDefaultValueSql("CURRENT_TIMESTAMP").IsRequired();
            });

            builder.Entity<StoreHouse>(e =>
            {
                e.HasKey(x => x.StoreId);
                e.Property(x => x.CommodityId).IsRequired();
                e.Property(x => x.Stock).IsRequired().HasDefaultValue(0);
            });
        }
    }
}
