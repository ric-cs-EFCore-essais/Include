using System;
using System.Linq.Expressions;

using Domain.Entities.Specifications.Interfaces;

namespace Domain.Entities.Specifications
{
    public class ASpecification<T> : ISpecification<T>
    {
        public Expression<Func<T, bool>> FilterExpression { get; }

        private Func<T, bool> filterExpressionAsFunction = null;
        private Func<T, bool> FilterExpressionAsFunction
        {
            get
            {
                return filterExpressionAsFunction ?? (filterExpressionAsFunction = FilterExpression.Compile());
            }
        }

        protected ASpecification(Expression<Func<T, bool>> filterExpression)
        {
            FilterExpression = filterExpression;
        }

        public bool isSatisfiedBy(T x)
        {
            var retour = FilterExpressionAsFunction(x);
            return retour;


        }
    }
}
