

namespace PM.Domain.Common.Models;

public interface IBaseEntity
{

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get;  set; }
}