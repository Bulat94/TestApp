using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestApp.Models;

namespace TestApp.Controllers
{
    public static class SortClass
    {
        static Dictionary<string, Func<Person, object>> Properties =
            new Dictionary<string, Func<Person, object>>
        {
            { "Name", x => x.Name},
            { "MiddleName", x => x.MiddleName},
            { "Patronic", x => x.Patronic},
            { "DateOfBirth", x => x.DateOfBirth},
            { "Sex", x => x.Sex},
            { "Age", x => x.Age}
        };

        public static List<Person> SortByProp (this IEnumerable<Person> list, PageInfo pageInfo)
        {
            Func<Person, object> func;
            Properties.TryGetValue(pageInfo.ClassName, out func);
            if (func != null)
            {
               return pageInfo.Asc ? list.OrderBy(func).ToList() : list.OrderBy(func).Reverse().ToList();
            }
            else
                throw new Exception("Eror");
        }
  
    }
}