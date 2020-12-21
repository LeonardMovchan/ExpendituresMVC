using AutoMapper;
using ExpendituresBL.Interfaces;
using ExpendituresBL.Models;
using ExpendituresDAL;
using ExpendituresDAL.Entities;
using ExpendituresDAL.Interfaces;
using ExpendituresDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpendituresBL.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IMapper _mapper;
        private readonly ITransactionRepository _tranasctionRepository;

        public TransactionService(ITransactionRepository tranasctionRepository)
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Transaction,TransactionBL>().ReverseMap();
            });

            _mapper = new Mapper(mapperConfig);
            _tranasctionRepository = tranasctionRepository;
        }

        public TransactionBL Create(TransactionBL model)
        {
            var categoryMapper = _mapper.Map<Transaction>(model);
            var createdTransaction = _tranasctionRepository.Create(categoryMapper);

            return _mapper.Map<TransactionBL>(createdTransaction);
        }

        public void Delete(TransactionBL model)
        {
            var deleteModel = _mapper.Map<Transaction>(model);
            _tranasctionRepository.Delete(deleteModel);
        }

        public IEnumerable<TransactionBL> GetAll()
        {
            IEnumerable<Transaction> models = _tranasctionRepository.GetAll();

            var mappedModels = _mapper.Map<IEnumerable<TransactionBL>>(models);

            return mappedModels;
        }

        public TransactionBL GetById(int id)
        {
            var model = _tranasctionRepository.GetById(id);

            return _mapper.Map<TransactionBL>(model);
        }

        public TransactionBL Update(TransactionBL model)
        {
            var categoryMapper = _mapper.Map<Transaction>(model);
            var updatedCategory = _tranasctionRepository.Update(categoryMapper);

            return _mapper.Map<TransactionBL>(updatedCategory);
        }   
    }
}
