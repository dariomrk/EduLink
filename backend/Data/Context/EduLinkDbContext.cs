﻿using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class EduLinkDbContext : DbContext
    {
        public EduLinkDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) { }
    }
}
