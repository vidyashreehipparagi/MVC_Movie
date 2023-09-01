using System.Data.SqlClient;

namespace MVC_Movie.Models
{
    public class MovieCRUD
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        IConfiguration configuration;

        public MovieCRUD(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(connectionString: configuration.GetConnectionString("defaultConnection"));

        }
        public IEnumerable<Movie> GetALLMovie() 
        { 
          List<Movie> list = new List<Movie>();
            string qry = "select * from Movie where isActive="+1;
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if(dr.HasRows)
            {
                while(dr.Read())
                {
                    Movie m = new Movie();
                    m.Id = Convert.ToInt32(dr["id"]);
                    m.Mname =dr["Mname"].ToString();
                    m.ReleaseDate = Convert.ToDateTime(dr["ReleaseDate"]);
                    m.Genre = dr["Genre"].ToString();
                    m.StarsName = dr["StarsName"].ToString();
                    list.Add(m);

                }
            }
            con.Close();
            return list;
        }
        public Movie GetMovieById(int id)
        {
            Movie m=new Movie();
            string qry = "Select * from Movie where Id=@id";
            cmd=new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if(dr.HasRows)
            {
                while(dr.Read())
                {
                    m.Id = Convert.ToInt32(dr["Id"]);
                    m.Mname = dr["Mname"].ToString() ;
                    m.ReleaseDate = Convert.ToDateTime(dr["ReleaseDate"]);
                    m.Genre= dr["Genre"].ToString();
                    m.StarsName = dr["StarsName"].ToString();
                }
            }
            con.Close();
            return m;
        }
        public int AddMovie(Movie movie)
        {
            movie.isActive = 1;
            int result = 0;
            string qry = "insert into Movie values(@Mname,@ReleaseDate,@Genre,@StarsName,@isActive)";
            cmd=new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@Mname", movie.Mname);
            cmd.Parameters.AddWithValue("@ReleaseDate", movie.ReleaseDate);
            cmd.Parameters.AddWithValue("@Genre", movie.Genre);
            cmd.Parameters.AddWithValue("@StarsName", movie.StarsName);
            cmd.Parameters.AddWithValue("@isActive", movie.isActive);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close() ;
            return result;
        
        }
        public int UpdateMovie(Movie movie)
        {
            movie.isActive = 1;
            int result = 0;
            string qry = "Update Movie set Mname=@Mname,ReleaseDate=@ReleaseDate,Genre=@Genre,StarsName=@StarsName,isActive=@isActive where Id=@Id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@Mname", movie.Mname);
            cmd.Parameters.AddWithValue("@ReleaseDate", movie.ReleaseDate);
            cmd.Parameters.AddWithValue("@Genre", movie.Genre);
            cmd.Parameters.AddWithValue("@StarsName", movie.StarsName);
            cmd.Parameters.AddWithValue("@isActive", movie.isActive);
            cmd.Parameters.AddWithValue("@Id", movie.Id);

            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int DeleteMovie(int Id)
        {
            int result = 0;
            string qry = "update Movie set isActive=0 where Id=@Id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@Id", Id);
            con.Open();
            result= cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }

    }
}
