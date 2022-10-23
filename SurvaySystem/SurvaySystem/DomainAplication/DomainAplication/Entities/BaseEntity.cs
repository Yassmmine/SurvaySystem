namespace SurvaySystem.DomainProject.Entities
{
    public class BaseEntity<IdType>
    {
        public IdType Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
