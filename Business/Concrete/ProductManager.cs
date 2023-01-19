using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.CCS;
using Business.Constant;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using MongoDB.Driver;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Model;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;


        string connectionS = "mongodb://localhost:27017";
        string databaseName = "mongo";
        string collectionName = "testDb";

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
       // [SecuredOperation("admin")]
       // [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            //IResult result = BusinessRules.Run(CheckIfProductNameExists(product.ProductName));
            //if (result != null)
            //{
            //    return result;
            //}
            _productDal.Add(product);

            var client = new MongoClient(connectionS);
            var db = client.GetDatabase(databaseName);
            var collection = db.GetCollection<PersonModel>(collectionName);
            var person = new PersonModel
            {
                FirstName = product.ProductName,
                LastName = product.ProductName
            };
            collection.InsertOneAsync(person);


            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Delete(Product product)
        {
            _productDal.Delete(product);
            return new SuccessResult();
        }

        [SecuredOperation("user,admin")]
        public IDataResult<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour == 3)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductsListed);
        }

        [SecuredOperation("user,admin")]
        public IDataResult<Product> GetById(int productid)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productid));
        }

        private IResult CheckIfProductNameExists(string productName)
        {
            var result = _productDal.GetAll(p=>p.ProductName==productName);
            if (result!=null)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.ProductNameAlreadyExists);
        }
    }
}
