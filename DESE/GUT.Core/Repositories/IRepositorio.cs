using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using System.Linq.Expressions;

namespace GUT.Core.Repositories
{
    public interface IRepositorio<TEntidade> : IQueryable<TEntidade> where TEntidade : class
    {
        void Adicionar(TEntidade entidade);

        void Adicionar(IList<TEntidade> entidades);

        void Atualizar(TEntidade entidade);

        void Atualizar(IList<TEntidade> entidades);

        void Remover(TEntidade entidade);

        void Remover(IList<TEntidade> entidades);

        IQueryable<TEntidade> Listar();

        IQueryable<TEntidade> Listar(System.Linq.Expressions.Expression<System.Func<TEntidade, bool>> expression);
    }
}
