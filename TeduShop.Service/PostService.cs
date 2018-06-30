using System;
using System.Collections.Generic;
using TeduShop.Data.Infrastructure;
using TeduShop.Data.Respositories;
using TeduShop.Model.Models;

namespace TeduShop.Service
{
    public interface IPostService
    {
        void Add(Post post);

        void Update(Post post);

        void Delete(int id);

        IEnumerable<Post> GetAll();

        IEnumerable<Post> GetAllPaging(int page, int pageSize, out int TotalRow);
        IEnumerable<Post> GetAllByCategoryPaging(int categoryId,int page, int pageSize, out int TotalRow);
        IEnumerable<Post> GetAllByTagPaging(string tag, int page, int pageSize, out int TotalRow);

        Post GetById(int id);

        void SaveChanges();
    }

    public class PostService : IPostService
    {
        private IPostRespository _postRepository;
        private IUnitOfWord _unitOfWord;

        public PostService(IPostRespository postRepository, IUnitOfWord unitOfWord)
        {
            this._postRepository = postRepository;
            this._unitOfWord = unitOfWord;
        }

        public void Add(Post post)
        {
            _postRepository.Add(post);
        }

        public void Delete(int id)
        {
            _postRepository.Delete(id);
        }

        public IEnumerable<Post> GetAll()
        {
            return _postRepository.GetAll(new string[] { "PostCategory" });
        }

        public IEnumerable<Post> GetAllByCategoryPaging(int categoryId, int page, int pageSize, out int TotalRow)
        {
            return _postRepository.GetMultiPaging(x => x.Status && x.CategogyID == categoryId,out TotalRow, page, pageSize,new string[] { "PostCategory" });
        }

        public IEnumerable<Post> GetAllByTagPaging(string tag, int page, int pageSize, out int TotalRow)
        {
            return _postRepository.GetAllByTag(tag,page,pageSize,out TotalRow);
        }

        public IEnumerable<Post> GetAllPaging(int page, int pageSize, out int TotalRow)
        {
            return _postRepository.GetMultiPaging(x => x.Status, out TotalRow, page, pageSize);
        }

        public Post GetById(int id)
        {
            return _postRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWord.Commit();
        }

        public void Update(Post post)
        {
            _postRepository.Update(post);
        }
    }
}