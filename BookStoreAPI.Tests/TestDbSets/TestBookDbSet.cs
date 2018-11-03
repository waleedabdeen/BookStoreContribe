using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStoreAPI.Models;

namespace BookStoreAPI.Tests.TestDbSets
{
    class TestBookDbSet : TestDbSet<Book>
    {
        public override Book Find(params object[] keyValues)
        {
            return this.SingleOrDefault(book => book.Id == (string)keyValues.Single());
        }

        public override async Task<Book> FindAsync(params object[] keyValues)
        {
            return await Task.Run(() => this.SingleOrDefault(book => book.Id == (string)keyValues.Single()));
        }
    }
}
