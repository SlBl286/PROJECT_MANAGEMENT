using NpgsqlTypes;

namespace PM.Domain.Common.Models;

public abstract class AggregatetRoot<TId, TIdType> : Entity<TId> ,IBaseAggregate
where TId : AggregateRootId<TIdType>
{
    protected AggregatetRoot(TId id) : base(id)
    {
        
    }

     public NpgsqlTsVector SearchVector { get ; set; } = null!;
#pragma warning disable CS0618
    protected AggregatetRoot()
    {

    }
#pragma warning restore CS0618
}