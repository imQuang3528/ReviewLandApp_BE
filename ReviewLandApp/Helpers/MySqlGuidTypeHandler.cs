using Dapper;
using System;
using System.Data;

namespace ReviewLandApp.Helpers
{
    public class MySqlGuidTypeHandler:SqlMapper.TypeHandler<Guid>
    {
        public override void SetValue(IDbDataParameter parameter, Guid value)
        {
            parameter.Value = value.ToString();
        }

        public override Guid Parse(object value)
        {
            return new Guid(value.ToString());
        }
    }
}
