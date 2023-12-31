﻿using System.Linq.Expressions;

namespace InfrastructureLayer;

public interface IRepositoryBase<T>
{
    IQueryable<T> FindAll();
    IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
    void Create(T entity);
    void CreateRange(List<T> entity);
    void Update(T entity);
    void UpdateRange(List<T> entity);
    void Delete(T entity);
    void DeleteRange(List<T> entity);
}
