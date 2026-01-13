namespace Blogoria.Models.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; protected set; }
        public DateTime CreatedAt { get; protected set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; protected set; } = null;

        // Method - Update the entity (update) time
        protected void MarkUpdate()
        {
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
