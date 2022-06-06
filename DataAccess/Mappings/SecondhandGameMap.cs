using System;
using Entity.POCO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Mappings
{
    public class SecondhandGameMap : IEntityTypeConfiguration<SecondhandGame>
    {
        public void Configure(EntityTypeBuilder<SecondhandGame> builder)
        {
            builder.Property(x => x.GameName).IsRequired();
            builder.Property(x => x.Price).IsRequired();
            builder
                .HasMany(x => x.SecondhandGameImages)
                .WithOne(x => x.SecondhandGame)
                .HasForeignKey(x => x.SecondhandGameID);
        }
    }
}
