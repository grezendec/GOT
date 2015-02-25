using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GUT.Entities
{
    public class EntityBase<T> : ICloneable
    {
        protected T id;

        public virtual T Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }

        #region Metodos

        public virtual object Clone()
        {
            return base.MemberwiseClone();
        }

        public override bool Equals(object obj)
        {
            EntityBase<T> entidade = obj as EntityBase<T>;

            return (Id.Equals(entidade.Id));
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion
    }
}
