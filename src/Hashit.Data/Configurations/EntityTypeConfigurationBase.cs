public abstract class EntityTypeConfigurationBase<T> : IEntityTypeConfiguration<T> where T : Entity
{
    public abstract void ConfigureEntity(EntityTypeBuilder<T> builder);

    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder
            .Property(e => e.CreatedAt)
            .HasDefaultValue(SystemClock.Instance.GetCurrentInstant());
        builder
            .Property(e => e.UpdatedAt)
            .HasDefaultValue(SystemClock.Instance.GetCurrentInstant());

        ConfigureEntity(builder);
    }
}
