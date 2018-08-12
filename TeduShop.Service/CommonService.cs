using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduShop.Data.Infrastructure;
using TeduShop.Data.Respositories;
using TeduShop.Model.Models;

namespace TeduShop.Service
{
    public interface ICommonService
    {
        IEnumerable<Slide> GetAllSlide();
    }
    public class CommonService : ICommonService
    {
        private ISlideRespository _slideRepository;
        private IUnitOfWord _unitOfWord;
        public CommonService(ISlideRespository slideRepository,IUnitOfWord unitOfWord)
        {
            _slideRepository = slideRepository;
            _unitOfWord = unitOfWord;
        }
        public IEnumerable<Slide> GetAllSlide()
        {
            return _slideRepository.GetAll();
        }
    }
}
