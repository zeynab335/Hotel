using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Hotel.Configuration
{
    public class FrontendConfiguration : IEntityTypeConfiguration<frontend>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<frontend> builder)
        {

            //builder.HasKey(e => e.user_name)
            //    .HasName("PK_Table");
        }

        
    }
}
