using Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Model
{
    public class CategoryReview:BaseModel
    {
        public CategoryReview()
        {

        }
        public string Id { get; set; }
        public string Title { get; set; }
    }
}
