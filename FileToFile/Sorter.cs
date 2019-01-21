using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileToFile
{
    public static class Sorter<T>
    {
        public static List<T> SingleSorting(List<T> source, string sortByProperty, bool isAscending)
           => isAscending ? source.OrderBy(p => p.GetType().GetProperty(sortByProperty).GetValue(p, null)).ToList()
                          : source.OrderByDescending(p => p.GetType().GetProperty(sortByProperty).GetValue(p, null)).ToList();

    }
}
