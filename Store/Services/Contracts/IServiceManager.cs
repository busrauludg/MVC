namespace Services.Contracts
{
    public interface IServiceManager
    {
        IProductService ProductService{get;}
        ICategoryServic CategoryServic{get;}
    }
}