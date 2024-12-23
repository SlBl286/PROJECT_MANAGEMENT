using NpgsqlTypes;

namespace PM.Domain.Common.Models;

public interface IBaseAggregate
{
    public NpgsqlTsVector SearchVector {get; set;}

}