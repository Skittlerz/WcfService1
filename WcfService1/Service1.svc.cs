using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Configuration;

namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public List<Movie> GetAllMovies()
        {
            List<Movie> movies = new List<Movie>();

            SqlConnection con = 
                new SqlConnection(WebConfigurationManager.ConnectionStrings["dbMovies"].ConnectionString);

            SqlCommand cmd = new SqlCommand("Select Title, Director, Description FROM Movies");
            cmd.Connection = con;

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Movie m = new WcfService1.Movie(reader["Title"].ToString(),
                                                reader["Director"].ToString(),
                                                reader["Description"].ToString());
                movies.Add(m);
            }

            return movies;
        }

        public List<Movie> GetMovieByTitle(string title)
        {
            List<Movie> movies = new List<Movie>();

            SqlConnection con =
                new SqlConnection(WebConfigurationManager.ConnectionStrings["dbMovies"].ConnectionString);

            SqlCommand cmd = new SqlCommand("Select Title, Director, Description FROM Movies Where Title=@title");
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("Title", title);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Movie m = new WcfService1.Movie(reader["Title"].ToString(),
                                                reader["Director"].ToString(),
                                                reader["Description"].ToString());
                movies.Add(m);
            }

            return movies;
        }

        public List<MovieCategory> GetAllMovieCategories()
        {
            List<MovieCategory> movieCats = new List<MovieCategory>();

            SqlConnection con =
                new SqlConnection(WebConfigurationManager.ConnectionStrings["dbMovies"].ConnectionString);

            SqlCommand cmd = new SqlCommand("Select Id, Name FROM MovieCategories");
            cmd.Connection = con;

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                MovieCategory m = new WcfService1.MovieCategory(Convert.ToInt32(reader["Id"].ToString()), 
                    reader["Name"].ToString());
                movieCats.Add(m);
            }

            return movieCats;
        }

        public List<Movie> GetMoviesByCategoryId(int catId)
        {
            List<Movie> movies = new List<Movie>();

            SqlConnection con =
                new SqlConnection(WebConfigurationManager.ConnectionStrings["dbMovies"].ConnectionString);

            SqlCommand cmd = new SqlCommand("Select Title, Director, Description FROM Movies Where CategoryId=@catId");
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("catId", catId);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Movie m = new WcfService1.Movie(reader["Title"].ToString(),
                                                reader["Director"].ToString(),
                                                reader["Description"].ToString());
                movies.Add(m);
            }

            return movies;
        }
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public string Welcome(string user)
        {
            return string.Format("Hello {0}, welcome to the world of web services!",user);
        }

        public List<Stock> GetAllStocks()
        {
            List<Stock> stocks = new List<Stock>();

            SqlConnection con =
                new SqlConnection(WebConfigurationManager.ConnectionStrings["dbStocks"].ConnectionString);

            SqlCommand cmd = new SqlCommand("Select StockName, StockSymbol, Shares, Price FROM Stocks");
            cmd.Connection = con;

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Stock s = new WcfService1.Stock(reader["StockName"].ToString(),
                                                reader["StockSymbol"].ToString(),
                                                Convert.ToInt32(reader["Shares"]),
                                                Convert.ToDouble(reader["price"]));
                stocks.Add(s);
            }

            return stocks;
        }

        public List<Stock> GetStockByCode(string code)
        {
            List<Stock> stocks = new List<Stock>();

            SqlConnection con =
                new SqlConnection(WebConfigurationManager.ConnectionStrings["dbStocks"].ConnectionString);

            SqlCommand cmd = new SqlCommand("Select StockName, StockSymbol, Shares, Price FROM Stocks Where StockSymbol=@code");
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("code", code);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Stock s = new WcfService1.Stock(reader["StockName"].ToString(),
                                                reader["StockSymbol"].ToString(),
                                                Convert.ToInt32(reader["Shares"]),
                                                Convert.ToDouble(reader["price"]));

                stocks.Add(s);
            }

            return stocks;
        }
    }
}
