using System;
using System.Data;
using NHibernate.SqlTypes;
using NHibernate.UserTypes;
using NH = NHibernate;

namespace GUT.Entities.CustomTypes
{
    public class TrimmedString : IUserType
    {
        private readonly NH.Type.AnsiStringType stringType;

        public TrimmedString()
        {
            stringType = (NH.Type.AnsiStringType)NH.NHibernateUtil.AnsiString;
        }

        #region IUserType Members

        bool IUserType.Equals(object x, object y)
        {
            if (ReferenceEquals(x, y))
            {
                return true;
            }

            return Equals(
                (x == null || x == DBNull.Value ? String.Empty : x.ToString().Trim()),
                (y == null || y == DBNull.Value ? String.Empty : y.ToString().Trim()));
        }

        public object Assemble(object cached, object owner)
        {
            return cached;
        }

        public object Disassemble(object value)
        {
            return value;
        }

        public object Replace(object original, object target, object owner)
        {
            return original;
        }

        public SqlType[] SqlTypes
        {
            get
            {
                return new[] {stringType.SqlType};
            }
        }

        public DbType[] DbTypes
        {
            get
            {
                return new[] {stringType.SqlType.DbType};
            }
        }

        public object DeepCopy(object value)
        {
            return value;
        }

        public void NullSafeSet(IDbCommand cmd, object value, int index)
        {
            if (value == null ||
                value == DBNull.Value ||
                value.ToString().Trim().Equals(string.Empty))
            {
                ((IDbDataParameter) cmd.Parameters[index]).Value = DBNull.Value;
            }
            else
            {
                stringType.Set(cmd, value.ToString().Trim(), index);
            }
        }

        public Type ReturnedType
        {
            get
            {
                return typeof(string);
            }
        }

        public object NullSafeGet(IDataReader rs, string[] names, object owner)
        {
            int index = rs.GetOrdinal(names[0]);

            if (rs.IsDBNull(index))
            {
                return string.Empty;
            }
            
            return rs[index].ToString().Trim();
        }

        public bool IsMutable
        {
            get
            {
                return false;
            }
        }

        public int GetHashCode(object obj)
        {
            return obj.GetHashCode();
        }

        #endregion
    }
}