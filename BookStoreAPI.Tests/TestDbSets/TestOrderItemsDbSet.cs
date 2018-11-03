using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStoreAPI.Models;

namespace BookStoreAPI.Tests.TestDbSets
{
    class TestOrderItemsDbSet : TestDbSet<OrderItem>
    {

        public override OrderItem Find(params object[] keyValues)
        {
            return this.SingleOrDefault(order => order.Id == (string)keyValues.Single());
        }

        public override async Task<OrderItem> FindAsync(params object[] keyValues)
        {
            return await Task.Run(() => this.SingleOrDefault(orderItem => orderItem.Id == (string)keyValues.Single()));
        }

        public override IEnumerable<OrderItem> AddRange(IEnumerable<OrderItem> entities)
        {
            List<OrderItem> addedItems = new List<OrderItem>();
            foreach (OrderItem orderItem in entities)
            {
                addedItems.Add(this.Add(orderItem));
            }
            return addedItems;
        }
    }
}
