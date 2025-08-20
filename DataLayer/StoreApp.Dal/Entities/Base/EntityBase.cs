namespace StoreApp.Dal.Entities.Base;

public abstract class EntityBase
{
    public int Id { get; set; }

    public override string ToString()
    {
        return $"{GetType().Name} [Id={Id}]";
    }
}
