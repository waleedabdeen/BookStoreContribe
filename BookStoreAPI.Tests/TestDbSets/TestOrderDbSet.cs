using System.Linq;
using System.Threading.Tasks;
using BookStoreAPI.Models;

namespace BookStoreAPI.Tests.TestDbSets
{
    class TestOrderDbSet : TestDbSet<Order>
    {

        public override Order Find(params object[] keyValues)
        {
            return this.SingleOrDefault(order => order.Id == (string)keyValues.Single());
        }

        public override async Task<Order> FindAsync(params object[] keyValues)
        {
            return await Task.Run(() => this.SingleOrDefault(order => order.Id == (string)keyValues.Single()));
        }

    }
}
