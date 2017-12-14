using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduShop.Data.Infrastructure;
using TeduShop.Data.Respositories;
using TeduShop.Model.Models;

namespace TeduShop.UnitTest.RepositoryTest
{
    [TestClass]
    public class PostCategoryRepositoryTest
    {
        IDbFactory _dbFactory;
        IPostCategoryRespository _objRepository;
        IUnitOfWord _unitOfWord;
        [TestInitialize]
        public void Initialize()
        {
            _dbFactory = new DbFactory();
            _objRepository = new PostCategoryRespository(_dbFactory);
            _unitOfWord = new UnitOfWord(_dbFactory);
        }
        [TestMethod]
        public void PostCategory_Repository_GetAll()
        {
            var test = _objRepository.GetAll().ToList();
            Assert.AreEqual(1, test.Count());
        }
        [TestMethod]
        public void PostCategory_Repository_Create()
        {
            PostCategory test1 = new PostCategory();
            test1.Name = "Test_Case";
            test1.Alias = "Test_Case";
            test1.Status = true;
            var result=_objRepository.Add(test1);
            _unitOfWord.Commit();

            Assert.IsNotNull(result);
            Assert.AreEqual(1,result.ID);
        }
    }
}
