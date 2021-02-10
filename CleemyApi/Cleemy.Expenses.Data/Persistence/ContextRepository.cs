using Cleemy.Expenses.Data.Expenses;
using Cleemy.Expenses.Data.Technical;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Cleemy.Expenses.Data.DataAccess
{
    public abstract class ContextRepository<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class, IBaseEntity
        where TContext : DbContext
    {
        protected readonly TContext context;
        public ContextRepository(TContext context)
        {
            this.context = context;
        }
        public async Task<TEntity> Add(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Delete(int id)
        {
            var entity = await context.Set<TEntity>().FindAsync(id);
            if (entity == null)
            {
                return entity;
            }

            context.Set<TEntity>().Remove(entity);
            await context.SaveChangesAsync();

            return entity;
        }

        public async Task<TEntity> Get(int id)
        {
            return await context.Set<TEntity>().Where(e => e.Id == id).SingleOrDefaultAsync();
        }

        public async Task<List<TEntity>> Find(Expression<Func<TEntity, bool>> expression)
        {
            return await context.Set<TEntity>().Where(expression).ToListAsync();
        }
        public async Task<List<TEntity>> GetAll()
        {
            return await context.Set<TEntity>().ToListAsync();
        }

        public async Task<List<TEntity>> GetAllOrderedBy(string expression)
        {
            var options = ScriptOptions.Default.AddReferences(typeof(Expense).Assembly);

            Expression<Func<TEntity, string>> orderByExpression = await CSharpScript.EvaluateAsync<Expression<Func<TEntity, string>>>(expression, options);

            return await context.Set<TEntity>().OrderBy(orderByExpression).ToListAsync();
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return entity;
        }

    }
}
