using System;
using System.Collections.Generic;
using System.Text;

namespace SurvaySystem.ApplicationProject.Common
{
    public class CollectionResponse<T>
    {
        public CollectionResponse(int length, ICollection<T> collection)
        {
            Length = length;
            Collection = collection;
        }
        public int Length { get; }
        public ICollection<T> Collection { get; set; }

    }

}
