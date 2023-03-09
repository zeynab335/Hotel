using Hotel.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Configuration
{
    public class KitchenConfiguration : IEntityTypeConfiguration<kitchen>
    {
        public void Configure(EntityTypeBuilder<kitchen> builder)
        {
            //builder.HasKey(e => e.user_name)
            //      .HasName("PK_Table");
        }
    }
}
