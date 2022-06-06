using System;
using Entity.POCO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Mappings
{
    public class GameMap : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.Property(x => x.Name).HasColumnName("Name").HasColumnType("nvarchar(50)").IsRequired();
            builder
                .HasMany(x => x.GameImages)
                .WithOne(x => x.Game)
                .HasForeignKey(x => x.GameID);
        }
    }
}
