﻿using AutoMapper;
using CuarAuthentication.Domain.IPersistance;

namespace CuarAuthentication.DomainService.Helpers
{
    public class BaseService
    {
        #region Fields

        public IMapper _mapper;
        public IUnitOfWork _unitOfWork;

        #endregion

        #region Ctor

        public BaseService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        #endregion

        #region Methods

        public void SaveChanges()
        {
            _unitOfWork.SaveChanges();
        }

        public Task SaveChangesAsync()
        {
            return _unitOfWork.SaveChangesAsync();
        }
        #endregion
    }
}
