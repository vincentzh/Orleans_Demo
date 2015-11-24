using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Burrow;
using NHibernate.Burrow.Util;
using NUnit.Framework;

namespace DomainTest
{
   [TestFixture] 
    public class DataBase
    {

       [Test,Explicit]
        public void CreateDB()
        {
            new SchemaUtil().CreateSchemas();
        }

         [Test, Explicit]
        public void UpdateDB()
        {
            new SchemaUtil().UpdateSchemas(true,true);
        }
    }
}
