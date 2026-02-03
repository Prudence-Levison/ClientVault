using System.ComponentModel.Design;
using adonetdatabase.Models;
using Microsoft.Data.Sqlite;

namespace adonetdatabase.Data

{
    public  class UserRepository
    {
        private readonly DbConnection _db;

        public UserRepository()
        {
            _db = new DbConnection();
        }

         public void Create (User user)
        {

            using var connection = _db.GetConnection();

             var command = connection.CreateCommand();
             command.CommandText = @"INSERT INTO USERS(Name, Gender,Age,Email) VALUES (@name,@gender,@age,@email)";
             command.Parameters.AddWithValue("@name", user.Name);
             command.Parameters.AddWithValue("@gender", user.Gender);
             command.Parameters.AddWithValue("@age", user.Age);
            command.Parameters.AddWithValue("@email", user.Email);
            command.ExecuteNonQuery();
        }  

        public List<User> GetAll()
        {
            var users = new List<User>();

            using var connection = _db.GetConnection();
            var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Users";

            using (var reader = command.ExecuteReader())
            while (reader.Read())
            {
                var user = new User
                {
                    Name = reader["Name"].ToString(),
                    Gender = reader["Gender"].ToString(),
                    Age = Convert.ToInt32(reader["Age"]),
                    Email = reader["Email"].ToString()

                };
                users.Add(user);
            }
            return users;
    }

    }

}