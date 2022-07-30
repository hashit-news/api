public sealed class UserRoleEntityTypeConfiguration : EntityTypeConfigurationBase<UserRole>
{
    public override void ConfigureEntity(EntityTypeBuilder<UserRole> builder)
    {
        builder.HasKey(x => new { x.UserId, x.RoleId });

        builder
            .Property(x => x.RoleId)
            .HasConversion(v => v.ToString(), v => (RoleId)Enum.Parse(typeof(RoleId), v))
            .HasMaxLength(Enum.GetNames<RoleId>().Max(x => x.Length));
        builder
            .HasOne(x => x.User)
            .WithMany()
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(x => x.Role)
            .WithMany()
            .HasForeignKey(x => x.RoleId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
