using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Services.Mappers
{
    public interface IMapper<T,B> where T : class where B : class
    {
        public B MapItemToModel(T item);
        public T MapModelToItem(B model);
    }
}
