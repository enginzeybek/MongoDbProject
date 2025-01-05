using MongoDB.Bson;
using MongoDB.Driver;
using MongoDbProject.Models;

namespace MongoDbProject.Services
{
    public class ProductOperation
    {
        public void AddProduct(Product product) 
        {
            var connection = new MongoDbConnection();
            var productCollection = connection.GetProductCollection();

            var document = new BsonDocument
            {
                {"ProductName",product.ProductName},
                {"Unit",product.Unit},
                {"Price",product.Price},
                {"Category",product.Category}
            };

            productCollection.InsertOne(document);
        }

        public List<Product> ProductList()
        {
            var connection = new MongoDbConnection();
            var productCollection = connection.GetProductCollection();

            var product = productCollection.Find(new BsonDocument()).ToList();
            List<Product> productsList = new List<Product>();
            foreach (var item in product)
            {
                productsList.Add(new Product
                {
                    ProductId = item["_id"].ToString(),
                    ProductName = item["ProductName"].ToString(),
                    Price = Convert.ToDecimal(item["Price"].ToString()),
                    Unit = Convert.ToInt32(item["Unit"].ToString()),
                    Category = item["Category"].ToString()
                });
            }

            return productsList;
        }

        public void DeleteProduct(string id)
        {
            var connection = new MongoDbConnection();
            var productCollection = connection.GetProductCollection();

            var filter = Builders<BsonDocument>.Filter.Eq("_id",ObjectId.Parse(id));
            productCollection.DeleteOne(filter);
        }

        public void UpdateProduct(Product product)
        {
            var connection = new MongoDbConnection();
            var productCollection = connection.GetProductCollection();

            var filter = Builders<BsonDocument>.Filter.Eq("_id",ObjectId.Parse(product.ProductId));
            var updatedProduct = Builders<BsonDocument>.Update
                .Set("ProductName", product.ProductName)
                .Set("Price", product.Price)
                .Set("Unit", product.Unit)
                .Set("Category", product.Category);

            productCollection.UpdateOne(filter,updatedProduct);
        }

        public Product GetProduct(string id)
        {
            var connection = new MongoDbConnection();
            var productCollection = connection.GetProductCollection();

            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id));
            var result = productCollection.Find(filter).FirstOrDefault();

            return new Product
            {
                Category = result["Category"].ToString(),
                Price = Convert.ToDecimal(result["Price"].ToString()),
                ProductName = result["ProductName"].ToString(),
                Unit = Convert.ToInt32(result["Unit"].ToString())
            };
        }

        

    }
}
