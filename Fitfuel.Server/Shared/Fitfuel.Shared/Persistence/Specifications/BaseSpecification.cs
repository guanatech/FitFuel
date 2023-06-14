using System.Linq.Expressions;

namespace Fitfuel.Shared.Persistence.Specifications;

public abstract class BaseSpecification<T>
    where T : class
{
    public Expression<Func<T, bool>>? Criteria { get; }
    
    protected BaseSpecification(Expression<Func<T, bool>> criteria) => 
        Criteria = criteria;

    public List<Expression<Func<T, object>>> IncludeExpressions { get; } = new();

    public Expression<Func<T, object>>? OrderByExpression { get; private set; } 
    
    public Expression<Func<T, object>>? OrderByDescExpression { get; private set; } 

    public void AddInclude(Expression<Func<T, object>> includeExpression) =>
        IncludeExpressions.Add(includeExpression);
    
    public void AddOrderBy(Expression<Func<T, object>> orderByExpression) =>
        OrderByExpression = orderByExpression;
    
    public void AddOrderByDesc(Expression<Func<T, object>> orderByDescExpression) =>
        OrderByDescExpression = orderByDescExpression;
}