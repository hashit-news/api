public sealed class RoleEntityTypeConfiguration : EntityTypeConfigurationBase<Role>
{
    public override void ConfigureEntity(EntityTypeBuilder<Role> builder)
    {
        builder.HasData(Enum.GetValues<RoleType>().Select(x => new Role(x)));
    }
}
