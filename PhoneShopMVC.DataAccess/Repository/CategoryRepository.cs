using PhoneShopMVC.DataAccess.Data;
using PhoneShopMVC.DataAccess.Repository.IRepository;
using PhoneShopMVC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneShopMVC.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }

        public Category? GetById(int id)
        {
            return _db.Categories.Find(id);
        }

        public void Update(Category category)
        {
            _db.Categories.Update(category);
        }
    }
}
