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
    public interface IProductService
    {
        Product Add(Product product);

        Product Delete(int id);

        void Update(Product productCategory);

        IEnumerable<Product> GetAll();

        IEnumerable<Product> GetAll(string keyword);

        Product GetById(int id);

        void Save();
    }
    public class ProductService : IProductService
    {
        private IProductRespository _ProductRepository;
        private IUnitOfWord _unitOfWord;

        public ProductService(IProductRespository ProductRepository, IUnitOfWord unitOfWord)
        {
            this._ProductRepository = ProductRepository;
            this._unitOfWord = unitOfWord;
        }

        public Product Add(Product product)
        {
            return _ProductRepository.Add(product);
        }

        public Product Delete(int id)
        {
            return _ProductRepository.Delete(id);
        }

        public IEnumerable<Product> GetAll()
        {
            return _ProductRepository.GetAll();
        }

        public IEnumerable<Product> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _ProductRepository.GetMulti(x => x.Name.Contains(keyword) || x.Alias.Contains(keyword));
            else
                return _ProductRepository.GetAll();
        }

        public Product GetById(int id)
        {
            return _ProductRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWord.Commit();
        }

        public void Update(Product product)
        {
            _ProductRepository.Update(product);
        }
    }
}
