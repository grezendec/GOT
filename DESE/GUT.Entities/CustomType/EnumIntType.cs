using System;
using System.Data;
using NHibernate;
using NHibernate.Dialect;
using NHibernate.Engine;
using NHibernate.SqlTypes;
using NHibernate.Type;

namespace GUT.Entities.CustomTypes
{
    [Serializable]
    public abstract class EnumIntType : ImmutableType, IDiscriminatorType
    {
        private readonly Type enumClass;

        protected EnumIntType(Type enumClass) : base(new StringSqlType())
        {
            if (enumClass.IsEnum)
            {
                this.enumClass = enumClass;
            }
            else
            {
                throw new MappingException(enumClass.Name + " did not inherit from System.Enum");
            }
        }

        public virtual object GetInstance(object code)
        {
            if (code is decimal || code is int)
            {
                int value = Convert.ToInt32(code);

                try
                {
                    return Enum.Parse(enumClass, value.ToString());
                }
                catch (ArgumentException ae)
                {
                    throw new HibernateException(string.Format("Can't Parse {0} as {1}", value, enumClass.Name), ae);
                }
            }

            throw new HibernateException(string.Format("Can't Parse {0} as {1}", code, enumClass.Name));
        }

        public virtual object GetValue(object instance)
        {
            if (instance == null)
            {
                return null;
            }

            if (instance.GetType() == typeof(string))
            {
                return ((int)Enum.Parse(enumClass, (string)instance, true));
            }

            return Convert.ToInt32(instance);
        }

        public override Type ReturnedClass
        {
            get { return enumClass; }
        }

        public override void Set(IDbCommand cmd, object value, int index)
        {
            IDataParameter par = (IDataParameter)cmd.Parameters[index];
            if (value == null)
            {
                par.Value = DBNull.Value;
            }
            else
            {
                if (value.GetType() == typeof(string))
                {
                    par.Value = ((char)(int)Enum.Parse(enumClass, (string)value, true));
                }
                else
                {
                    par.Value = Convert.ToInt32(value);
                }
            }
        }

        public override object Get(IDataReader rs, int index)
        {
            object code = rs[index];
            if (code == DBNull.Value || code == null)
            {
                return null;
            }
            return GetInstance(code);
        }

        public override object Get(IDataReader rs, string name)
        {
            return Get(rs, rs.GetOrdinal(name));
        }

        public override string Name
        {
            get { return "enumint - " + enumClass.Name; }
        }

        public override string ToString(object value)
        {
            return (value == null) ? null : GetValue(value).ToString();
        }

        public override object Assemble(object cached, ISessionImplementor session, object owner)
        {
            if (cached == null)
            {
                return null;
            }
            return GetInstance(cached);
        }

        public override object Disassemble(object value, ISessionImplementor session, object owner)
        {
            return (value == null) ? null : GetValue(value);
        }

        public virtual object StringToObject(string xml)
        {
            return (string.IsNullOrEmpty(xml)) ? null : FromStringValue(xml);
        }

        public override object FromStringValue(string xml)
        {
            return GetInstance(xml);
        }

        public string ObjectToSQLString(object value, Dialect dialect)
        {
            return '\'' + GetValue(value).ToString() + '\'';
        }
    }
}