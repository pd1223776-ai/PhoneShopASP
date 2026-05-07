using PhoneShopMVC.DataAccess.Repository.IRepository;
using PhoneShopMVC.Model;
using Microsoft.AspNetCore.Mvc;

namespace PhoneShopMVC.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {
        IUnitOfWork _unitOfWork;

        public IViewComponentResult Invoke()
        {
            IEnumerable<Category> categoryList = _unitOfWork.Category.GetAll();
            return View(categoryList);
        }

        public MenuViewComponent(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
