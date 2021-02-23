using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
    //Constraint kısıtlamaları var.
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            //IDısposable Pattern implementation 
            // Belleği hızlı temizlemeye yarar, çöp toplayıcıyı beklemez.

            using (TContext context = new TContext())
            {
                var AddedEntity = context.Entry(entity);
                AddedEntity.State = EntityState.Added;
                //transection
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                //context.Products.Remove(context.Products.SingleOrDefault(p=>p.ProductId==entity.ProductId));
                var DeletedEntity = context.Entry(entity);
                DeletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            // Filtre kullanmak zorunda değiliz, kullanılıp kullanılmadığında neler olur:
            using (TContext context = new TContext())
            {
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {

                //var ProductToUpdate=(context.Products.SingleOrDefault(p => p.ProductId == entity.ProductId));
                //ProductToUpdate.CategoryId = entity.CategoryId;
                //ProductToUpdate.ProductName = entity.ProductName;
                //ProductToUpdate.UnitsInStock = entity.UnitsInStock;
                //ProductToUpdate.UnitPrice = entity.UnitPrice;
                //context.SaveChanges();

                var UpdatedEntity = context.Entry(entity);
                UpdatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

    }
}
