using System;

namespace DevFreela.Core.Entities
{
    public abstract class BaseEntity
    {
        protected BaseEntity()
        {
            CreatedAt = DateTime.Now;
        }
        public int Id { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}
