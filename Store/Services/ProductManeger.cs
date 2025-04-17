using System.Reflection.Metadata;
using AutoMapper;
using Entities.Dtos;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class ProductManager : IProductService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;//de�ire ne olur
        public ProductManager(IRepositoryManager manager,IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public void CreateProduct(ProductDtoForInsertion productDto)
        {
            Product product=_mapper.Map<Product>(productDto);
            //Product product = new Product()
            //{
            //    ProductName = productDto.ProductName,
            //    Price = productDto.Price,
            //    CategoryId = productDto.CategoryId
            //};
            _manager.Product.Create(product);
            _manager.Save();
        }

        public void DeleteOneProduct(int id)
        {
            Product product = GetOneProduct(id, false);
            if(product is not null)
            {
                _manager.Product.DeleteOneProduct(product);//ilgili gecici olarak silinir 
                _manager.Save();//kal�c� olarak siler
            }
            
        }

        public IEnumerable<Product> GetAllProducts(bool trackChanges)
        {
            return _manager.Product.GetAllProducts(trackChanges);
        }



        public Product? GetOneProduct(int id, bool trackChanges)
        {
            var product = _manager.Product.GetOneProduct(id, trackChanges);
            if (product is null)
                throw new Exception("Product not found!");
            return product;

        }

        public ProductDtoForUpdate? GetOneProductForUpdate(int id, bool trakcChanges)
        {
           var product=GetOneProduct(id,trakcChanges);
           var productDto=_mapper.Map<ProductDtoForUpdate>(product);
            return productDto; 
        }

        public void UpdateOneProduct(ProductDtoForUpdate productDto)
        {
            //var entity = _manager.Product.GetOneProduct(productDto.ProductId, true);
            //entity.ProductName= productDto.ProductName;
            //entity.Price= productDto.Price;
            //entity.CategoryId= productDto.CategoryId;
           var entity=_mapper.Map<Product>(productDto);//burda izleneme oluca�� i�in reference ihtiyac yok
            _manager.Product.UpdateOneProduct(entity);
            _manager.Save();
                
        }
    }
}