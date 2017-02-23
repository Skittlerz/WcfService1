using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Add your service operations here
        [OperationContract]
        string Welcome(string userName);

        [OperationContract]
        List<Movie> GetAllMovies();

        [OperationContract]
        List<Movie> GetMovieByTitle(String title);

        [OperationContract]
        List<Movie> GetMoviesByCategoryId(int catId);

        [OperationContract]
        List<MovieCategory> GetAllMovieCategories();

        [OperationContract]
        List<Stock> GetAllStocks();

        [OperationContract]
        List<Stock> GetStockByCode(string code);
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }

    [DataContract]
    public class Movie
    {
        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Director { get; set; }

        [DataMember]
        public string Description { get; set; }

        public Movie() { }

        public Movie(string title, string director, string descrip)
        {
            Title = title;
            Director = director;
            Description = descrip;
        }
    }

    [DataContract]
    public class MovieCategory
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int Id { get; set; }

        public MovieCategory() { }

        public MovieCategory(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }

    [DataContract]

    public class Stock
    {
        [DataMember]
        private string StockName { get; set; }

        [DataMember]
        private string StockCode { get; set; }

        [DataMember]
        private int Quantity { get; set; }

        [DataMember]
        private double Price { get; set; }

        public Stock() { }

        public Stock(string name, string code, int quantity, double price)
        {
            StockName = name;
            StockCode = code;
            Quantity = quantity;
            Price = price;
        }
    }
}
