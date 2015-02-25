using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web.Mvc;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Linq;
using Expression = System.Linq.Expressions.Expression;

namespace GUT.Core.Repositories
{
    public class Repositorio<TEntidade> : IRepositorio<TEntidade> where TEntidade : class
    {
        private static ISession Session
        {
            get
            {
                return DependencyResolver.Current.GetService<ISession>();
            }
        }

        public virtual void Adicionar(TEntidade entidade)
        {
            Session.Save(entidade);
            Session.Flush();
        }

        public virtual void Adicionar(IList<TEntidade> entidades)
        {
            foreach (var entidade in entidades)
            {
                Adicionar(entidade);
            }
        }

        public virtual void Atualizar(TEntidade entidade)
        {
            Session.SaveOrUpdate(entidade);
            Session.Flush();

        }

        public virtual void Atualizar(IList<TEntidade> entidades)
        {
            foreach (var entidade in entidades)
            {
                Atualizar(entidade);
            }
        }

        public virtual void Remover(TEntidade entidade)
        {
            Session.Delete(entidade);
            Session.Flush();
        }

        public virtual void Remover(IList<TEntidade> entidades)
        {
            foreach (var entidade in entidades)
            {
                Remover(entidade);
            }
        }

        public IQueryable<TEntidade> Listar()
        {
            return Session.Query<TEntidade>();
        }

        public IQueryable<TEntidade> Listar(System.Linq.Expressions.Expression<System.Func<TEntidade, bool>> expression)
        {
            return Listar().Where(expression).AsQueryable();
        }

        #region Implementation of IEnumerable

        public IEnumerator<TEntidade> GetEnumerator()
        {
            return Session.Query<TEntidade>().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        #region Implementation of IQueryable

        public Expression Expression
        {
            get { return Session.Query<TEntidade>().Expression; }
        }

        public Type ElementType
        {
            get { return Session.Query<TEntidade>().ElementType; }
        }

        public IQueryProvider Provider
        {
            get { return Session.Query<TEntidade>().Provider; }
        }

        #endregion
    }
}
