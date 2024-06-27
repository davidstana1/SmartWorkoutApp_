namespace DataAccess.Entities.BaseEntity;

public class Entity : IEntity
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
}