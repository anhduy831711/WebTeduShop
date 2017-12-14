using System.Collections.Generic;
using TeduShop.Data.Infrastructure;
using TeduShop.Data.Respositories;
using TeduShop.Model.Models;

namespace TeduShop.Service
{
    public interface IPostCategoryService
    {
        void Add(PostCategory postCategory);

        void Delete(int id);

        void Update(PostCategory postCategory);

        IEnumerable<PostCategory> GetAll();

        IEnumerable<PostCategory> GetAllByParenId(int parentId);

        PostCategory GetById(int id);
    }

    public class PostCategoryService : IPostCategoryService
    {
        private IPostCategoryRespository _postCategoryRepository;
        private IUnitOfWord _unitOfWord;

        public void Add(PostCategory postCategory)
        {
            _postCategoryRepository.Add(postCategory);
        }

        public void Delete(int id)
        {
            _postCategoryRepository.Delete(id);
        }

        public IEnumerable<PostCategory> GetAll()
        {
            return _postCategoryRepository.GetAll();
        }

        public IEnumerable<PostCategory> GetAllByParenId(int parentId)
        {
            return _postCategoryRepository.GetMulti(x => x.Status && x.ParentID == parentId);
        }

        public PostCategory GetById(int id)
        {
            return _postCategoryRepository.GetSingleById(id);
        }

        public void Update(PostCategory postCategory)
        {
            _postCategoryRepository.Update(postCategory);
        }
    }
}