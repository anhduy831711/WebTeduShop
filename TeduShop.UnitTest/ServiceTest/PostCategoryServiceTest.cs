using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduShop.Data.Infrastructure;
using TeduShop.Data.Respositories;
using TeduShop.Model.Models;
using TeduShop.Service;

namespace TeduShop.UnitTest.ServiceTest
{
    [TestClass]
    public class PostCategoryServiceTest
    {
        private Mock<IPostCategoryRespository> _mockRepository;
        private Mock<IUnitOfWord> _mockUnitOfWord;
        private IPostCategoryService _postCategoryService;
        private List<PostCategory> _listPostCategory;
        [TestInitialize]
        public void Intialize()
        {
            _mockRepository = new Mock<IPostCategoryRespository>();
            _mockUnitOfWord = new Mock<IUnitOfWord>();
            _postCategoryService = new PostCategoryService(_mockRepository.Object, _mockUnitOfWord.Object);
            _listPostCategory = new List<PostCategory>()
            {
                new PostCategory() {ID =1,Name="Test1",Status=true,Alias="Test1" },
               new PostCategory() {ID =2,Name="Test2",Status=true,Alias="Test2" },
               new PostCategory() {ID =3,Name="Test3",Status=true,Alias="Test3" }
            };
        }

        [TestMethod]
        public void PostCategory_Service_GetAll()
        {
            //setup Method
            _mockRepository.Setup(x => x.GetAll(null)).Returns(_listPostCategory);

            //call action
            var result = _postCategoryService.GetAll() as List<PostCategory>;

            //Compare
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count());
        }
        [TestMethod]
        public void PostCategory_Service_Create()
        {
            PostCategory test1 = new PostCategory();
            test1.Name = "Test1";
            test1.Status = true;
            test1.Alias = "test1";

            _mockRepository.Setup(m => m.Add(test1)).Returns((PostCategory p) =>
            {
                p.ID = 1;
                return p;
            });

            var result=_postCategoryService.Add(test1);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.ID);
        }
    }
}
