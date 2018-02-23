using System;
using System.Collections.Generic;
using TeduShop.Data.Infrastructure;
using TeduShop.Data.Responsitories;
using TeduShop.Model.Models;

namespace TeduShop.Service
{
    public interface IProductCategoryService
    {
        ProductCategory Add(ProductCategory ProductCategory);

        ProductCategory Delete(int id);

        void Update(ProductCategory ProductCategory);

        IEnumerable<ProductCategory> GetAll();

        IEnumerable<ProductCategory> GetAll(string Keyword);

        IEnumerable<ProductCategory> GetAllByParenId(int parentId);

        ProductCategory GetById(int id);

        void Save();
    }

    public class ProductCategoryService : IProductCategoryService
    {
        private IProductCategoryRespository _ProductCategoryRepository;
        private IUnitOfWord _unitOfWord;

        public ProductCategoryService(IProductCategoryRespository ProductCategoryRepository, IUnitOfWord unitOfWord)
        {
            this._ProductCategoryRepository = ProductCategoryRepository;
            this._unitOfWord = unitOfWord;
        }

        public ProductCategory Add(ProductCategory ProductCategory)
        {
            return _ProductCategoryRepository.Add(ProductCategory);
        }

        public ProductCategory Delete(int id)
        {
            return _ProductCategoryRepository.Delete(id);
        }

        public IEnumerable<ProductCategory> GetAll()
        {
            return _ProductCategoryRepository.GetAll();
        }

        public IEnumerable<ProductCategory> GetAll(string Keyword)
        {
            if(!string.IsNullOrEmpty(Keyword))
                return _ProductCategoryRepository.GetMulti(x=>x.Name.Contains(Keyword) || x.Decription.Contains(Keyword));
            else
                return _ProductCategoryRepository.GetAll();
        }

        public IEnumerable<ProductCategory> GetAllByParenId(int parentId)
        {
            return _ProductCategoryRepository.GetMulti(x => x.Status && x.ParentID == parentId);
        }

        public ProductCategory GetById(int id)
        {
            return _ProductCategoryRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWord.Commit();
        }

        public void Update(ProductCategory ProductCategory)
        {
            _ProductCategoryRepository.Update(ProductCategory);
        }
    }
}