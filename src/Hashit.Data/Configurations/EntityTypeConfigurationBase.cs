public abstract class EntityTypeConfigurationBase<T> : IEntityTypeConfiguration<T> where T : Entity
{
    public abstract void ConfigureEntity(EntityTypeBuilder<T> builder);

    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
        builder.Property(e => e.UpdatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");

        ConfigureEntity(builder);
    }
}
