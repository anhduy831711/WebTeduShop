using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduShop.Data.Infrastructure;
using TeduShop.Data.Respositories;
using TeduShop.Model.Models;
using TeduSop.Common;

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

        IEnumerable<Product> GetLastProduct(int top);

        IEnumerable<Product> GetHotProduct(int top);
    }
    public class ProductService : IProductService
    {
        private IProductRespository _ProductRepository;
        private ITagRespository _tagRepository;
        private IUnitOfWord _unitOfWord;
        private IProductTagRespository _productTagRepository;

        public ProductService(IProductRespository ProductRepository,IProductTagRespository productTagRepository, ITagRespository tagRepository , IUnitOfWord unitOfWord)
        {
            this._ProductRepository = ProductRepository;
            this._unitOfWord = unitOfWord;
            this._tagRepository = tagRepository;
            this._productTagRepository = productTagRepository;
        }

        public Product Add(Product product)
        {
            var productNew = _ProductRepository.Add(product);
            _unitOfWord.Commit();
            if (!string.IsNullOrEmpty(product.Tags))
            {
                string[] tags = product.Tags.Split(',');
                foreach(string item in tags)
                {
                    var tagId = StringHelper.ToUnsignString(item);
                    if (_tagRepository.Count(x => x.Id == tagId) == 0)
                    {
                        Tag tag = new Tag()
                        {
                            Id = tagId,
                            Name = item,
                            Type = CommonConstant.PRODUCT_TAG
                        };
                        _tagRepository.Add(tag);
                    }
                    ProductTag productTag = new ProductTag()
                    {
                        ProductId = productNew.ID,
                        TagID = tagId,
                    };
                    _productTagRepository.Add(productTag);
                }
            }
            return productNew;
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
            _productTagRepository.DeleteMulti(x => x.ProductId == product.ID);
            if (!string.IsNullOrEmpty(product.Tags))
            {
                string[] tags = product.Tags.Split(',');
                foreach (string item in tags)
                {
                    var tagId = StringHelper.ToUnsignString(item);
                    if (_tagRepository.Count(x => x.Id == tagId) == 0)
                    {
                        Tag tag = new Tag()
                        {
                            Id = tagId,
                            Name = item,
                            Type = CommonConstant.PRODUCT_TAG
                        };
                        _tagRepository.Add(tag);
                    }
                    ProductTag productTag = new ProductTag()
                    {
                        ProductId = product.ID,
                        TagID = tagId,
                    };
                    _productTagRepository.Add(productTag);
                }
            }
        }

        public IEnumerable<Product> GetLastProduct(int top)
        {
            return _ProductRepository.GetMulti(x => x.Status).OrderByDescending(x=>x.CreatedDate).Take(top);
        }

        public IEnumerable<Product> GetHotProduct(int top)
        {
            return _ProductRepository.GetMulti(x => x.Status && x.HotFlag ==true).OrderByDescending(x => x.CreatedDate).Take(top);
        }
    }
}
