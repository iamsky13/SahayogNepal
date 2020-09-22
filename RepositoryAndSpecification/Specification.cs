using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SahayogNepal.RepositoryAndSpecification
{
    public class Specification<T> : ISpecification<T>
    {
        public Specification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }
        public Expression<Func<T, bool>> Criteria { get; }
        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();
        public List<string> IncludeStrings { get; } = new List<string>();
        public Expression<Func<T, object>> OrderBy { get; private set; }
        public Expression<Func<T, object>> OrderByDescending { get; private set; }
        public Expression<Func<T, object>> GroupBy { get; private set; }
        public Expression<Func<T, T>> Select { get; private set; }

        public int Take { get; private set; }
        public int Skip { get; private set; }
        public bool IsPagingEnabled { get; private set; } = false;

        public virtual Specification<T> ApplySelect(Expression<Func<T, T>> selector)
        {
            Select = selector;
            return this;
        }


        public virtual Specification<T> AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);

            return this;
        }


        public virtual Specification<T> AddInclude(string includeString)
        {
            IncludeStrings.Add(includeString);

            return this;
        }
        public virtual Specification<T> ApplyPaging(int skip, int take)
        {
            Skip = skip;
            Take = take;
            IsPagingEnabled = true;

            return this;
        }
        public virtual Specification<T> ApplyOrderBy(Expression<Func<T, object>> orderByExpression)
        {
            OrderBy = orderByExpression;

            return this;
        }
        public virtual Specification<T> ApplyOrderByDescending(Expression<Func<T, object>> orderByDescendingExpression)
        {
            OrderByDescending = orderByDescendingExpression;

            return this;
        }

        public virtual Specification<T> ApplyGroupBy(Expression<Func<T, object>> groupByExpression)
        {
            GroupBy = groupByExpression;

            return this;
        }

    }
}
