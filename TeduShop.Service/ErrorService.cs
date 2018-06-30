using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduShop.Data.Infrastructure;
using TeduShop.Data.Repositories;
using TeduShop.MoDel.Models;

namespace TeduShop.Service
{
    public interface IErrorService
    {
        Error Create(Error error);
        void Save();
    }
    public class ErrorService : IErrorService
    {
        IErrorRespository _errorRepository;
        IUnitOfWord _unitOfWord;
        public ErrorService(IErrorRespository errorRepository , IUnitOfWord unitOfWord)
        {
            this._errorRepository = errorRepository;
            this._unitOfWord = unitOfWord;
        }
        public Error Create(Error error)
        {
            return _errorRepository.Add(error);
        }

        public void Save()
        {
            _unitOfWord.Commit();
        }
    }
}
