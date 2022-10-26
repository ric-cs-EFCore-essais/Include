using System;
using System.Linq.Expressions;

namespace Domain.Entities.Specifications.Interfaces
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> FilterExpression { get; }

        bool isSatisfiedBy(T x);
    }
}
