using System.Data;
using System.Data.SqlClient;

namespace ConsoleApp15
{
    internal class Program
    {


        static void Main(string[] args)
        {
           

            Music musics = new Music
            {
                Name = "Aydan",
                BirthYear = 1976

            };


            Create(musics);


            List<Music> list = GetAll();
            foreach (Music music in list)
            {
                Console.WriteLine($" Birth Year: {music.BirthYear}");
            }


        }


        public static void Create(Music music)
        {
            int result;
            using (SqlConnection connection = new SqlConnection(@"Server=DESKTOP-JFHUTM3\MSSQLSERVER02;Database=Music;Trusted_connection=true;Integrated security=true;"))
            {
                connection.Open();
                string cmd = $"INSERT INTO Music VALUES ('{music.Name}','{music.BirthYear}')";
                SqlCommand command = new SqlCommand(cmd, connection);
                result = command.ExecuteNonQuery();
            }

        }

        public List<Music> GetAll()
        {
            List<Music> musicList = new List<Music>();
            string query = "select *from music ";
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(@"Server=DESKTOP-JFHUTM3\MSSQLSERVER02;Database=Music;Trusted_connection=true;Integrated security=true;"))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(dt);
            }
            foreach (DataRow item in dt.Rows)
            {
                Music music = new Music
                {
                    Name = item["name"].ToString(),
                    BirthYear = Convert.ToInt32(item["birthyear"])
                };
                musicList.Add(music);

            }

            return musicList;

        }
    }
}