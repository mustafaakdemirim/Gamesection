using System;
using Entity.POCO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Mappings
{
    public class SecondhandGameImageMap : IEntityTypeConfiguration<SecondhandGameImage>
    {
        public void Configure(EntityTypeBuilder<SecondhandGameImage> builder)
        {
            builder
                .HasOne(x => x.SecondhandGame)
                .WithMany(x => x.SecondhandGameImages)
                .HasForeignKey(x => x.SecondhandGameID);
        }
    }
}
