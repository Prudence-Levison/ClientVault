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

        public void Update(User user){
            using var connection = _db.GetConnection();
            var command = connection.CreateCommand();
            command.CommandText = @"UPDATE  Users SET Name=@name, Gender=@gender , Age = @age,Email =@email WHERE Id=@id ";
            command.Parameters.AddWithValue("@name", user.Name);
             command.Parameters.AddWithValue("@gender", user.Gender);
             command.Parameters.AddWithValue("@age", user.Age);
            command.Parameters.AddWithValue("@email", user.Email);
             command.Parameters.AddWithValue("@id", user.Id);
            command.ExecuteNonQuery();
        }
         
         public void Delete(int Id){
         using var connection = _db.GetConnection();
         var command = connection.CreateCommand();
         command.CommandText = @"DELETE FROM Users WHERE Id=@id";
         command.Parameters.AddWithValue("@id", Id);
         command.ExecuteNonQuery();

         }
        public List<User> GetAll()
        {
            var users = new List<User>();

            using var connection = _db.GetConnection();
            var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Users";

            using (var reader = command.ExecuteReader()){
            while (reader.Read())
            {
                var user = new User
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader["Name"].ToString(),
                    Gender = reader["Gender"].ToString(),
                    Age = Convert.ToInt32(reader["Age"]),
                    Email = reader["Email"].ToString()

                };
                users.Add(user);
            }
            }
            return users;
    }

    public User GetById(int Id){
       using  var connection = _db.GetConnection();
        var  command = connection.CreateCommand();
        command.CommandText = @"SELECT * FROM Users WHERE Id=@id";
        command.Parameters.AddWithValue("@id", Id);

             using (var reader = command.ExecuteReader())
    {
        if (!reader.Read())
            return null;

            
                 return new User
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader["Name"].ToString(),
                    Gender = reader["Gender"].ToString(),
                    Age = Convert.ToInt32(reader["Age"]),
                    Email = reader["Email"].ToString()
                   
                    

                };
    
    }

    }
    
}};
