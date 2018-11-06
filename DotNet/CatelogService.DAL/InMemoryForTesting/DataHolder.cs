using CatelogService.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CatelogService.DAL.InMemoryForTesting
{
    public class DataHolder
    {
        private Collection<ProductModel> _products;

        public Collection<ProductModel> Products
        {
            get
            {
                if (_products == null)
                {
                    _products = new Collection<ProductModel>();
                }

                return _products;
            }
        }
    }
}
