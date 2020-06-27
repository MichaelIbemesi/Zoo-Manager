using System;
using System.Collections;
using System.Data.SqlTypes;
using System.Data.SqlClient;


namespace ZooManager.Database
{
    /// <summary>
    /// Class which contains all database functionality.
    /// </summary>
    public static class DBConnector
    {
        private static SqlConnection sc;
        private static ArrayList Animals = new ArrayList();
        private static ArrayList Zoos = new ArrayList();
        private static ArrayList AnimalReports = new ArrayList();
        private static ArrayList ZooReports = new ArrayList();


        /// <summary>
        /// Opens a connection to the database.
        /// </summary>
        public static void OpenDb()
        {
            String connection = @"Data Source=DESKTOP-K4320T8;Initial Catalog=ZooDB;Integrated Security=True;Pooling=False";
            sc = new SqlConnection(connection);

            sc.Open();
        }

        /// <summary>
        /// Closes the connection to the database.
        /// </summary>
        public static void CloseDb()
        {
            sc.Close();
        }

        /// <summary>
        /// Gets all the data from the tables provided.
        /// </summary>
        /// <param name="tableName"> The name of the table to recieve data from.</param>
        public static void getAllData(String tableName)
        {
            String sql = "SELECT * FROM " + tableName;

            SqlCommand command = new SqlCommand(sql, sc);
            SqlDataReader dataReader = command.ExecuteReader();

            Animals.Clear();
            AnimalReports.Clear();

            if (tableName == "Animal")
            {
                while (dataReader.Read())
                {
                    Animal a1 = new Animal((int)dataReader.GetValue(0), (String)dataReader.GetValue(1), (int)dataReader.GetValue(2), (String)dataReader.GetValue(3), (int) dataReader.GetValue(4), (DateTime)dataReader.GetValue(5));
                    Animals.Add(a1);
                }

                dataReader.Close();
                String sql2 = "SELECT * FROM  AnimalReport";

                SqlCommand command2 = new SqlCommand(sql2, sc);
                SqlDataReader dataReader2 = command2.ExecuteReader();

                while (dataReader2.Read())
                {
                    AnimalReport ar1 = new AnimalReport((int)dataReader2.GetValue(0), (int)dataReader2.GetValue(1), (String)dataReader2.GetValue(2), (DateTime)dataReader2.GetValue(3));
                    AnimalReports.Add(ar1);

                }

            }

            Zoos.Clear();
            ZooReports.Clear();

            if (tableName == "Zoo")
            {
                while (dataReader.Read())
                {
                    Zoo z1 = new Zoo((int)dataReader.GetValue(0), (String)dataReader.GetValue(1), (String)dataReader.GetValue(2));
                    Zoos.Add(z1);
                }

                dataReader.Close();
                String sql2 = "SELECT * FROM  ZooReport";

                SqlCommand command2 = new SqlCommand(sql2, sc);
                SqlDataReader dataReader2 = command2.ExecuteReader();

                while (dataReader2.Read())
                {
                    ZooReport zr1 = new ZooReport((int)dataReader2.GetValue(0), (int)dataReader2.GetValue(1), (String)dataReader2.GetValue(2), (DateTime)dataReader2.GetValue(3));
                    ZooReports.Add(zr1);
                }
            }

            dataReader.Close();
        }

        /// <summary>
        /// Method which adds a new animal to the database.
        /// </summary>
        /// <param name="name">The name of the animal.</param>
        /// <param name="age">The age of the animal.</param>
        /// <param name="species">The species of the animal.</param>
        /// <param name="location">The ID of the zoo, which the animal inhabits.</param>
        public static Boolean AddAnimal(String name, int age, String species, int location)
        {
            Animal a1 = new Animal(name, age, species, location);

            Boolean result = false;
            Boolean alreadyExists = true;

            if (Animals.Count == 0)
            {
                alreadyExists = false;
            }

            foreach (Animal animal in Animals)
            {
                if (!animal.Equals(a1))
                {
                    alreadyExists = false;

                    Console.WriteLine("Animal already exists.");
                } 
            }

            if (!alreadyExists)
            {
                String sql = "INSERT INTO Animal (Name, Age, Species, Location, DateAdded) VALUES (@Name, @Age, @Species, @Location, @DateAdded)";

                using (SqlCommand command = new SqlCommand(sql, sc))
                {
                    command.Parameters.AddWithValue("@Name", a1.AnimalName);
                    command.Parameters.AddWithValue("@Age", a1.Age);
                    command.Parameters.AddWithValue("@Species", a1.Species);
                    command.Parameters.AddWithValue("@Location", a1.Location);
                    command.Parameters.AddWithValue("@DateAdded", (SqlDateTime)a1.DateAdded);

                    command.ExecuteNonQuery();
                    result = true;
                }
            }
            return result;
        }

        /// <summary>
        /// Method which adds a new zoo to the database.
        /// </summary>
        /// <param name="name">The name of the zoo.</param>
        /// <param name="address">The post code of the zoo.</param>
        public static Boolean AddZoo(String name, String address)
        {
            Zoo z1 = new Zoo(name, address);

            Boolean result = false;
            Boolean alreadyExists = true;

            if (Zoos.Count == 0)
            {
                alreadyExists = false;
            }

            foreach (Zoo zoo in Zoos)
            {
                if (!zoo.Equals(z1))
                {
                    alreadyExists = false;

                    Console.WriteLine("Zoo already exists.");
                }
            }

            if (!alreadyExists)
            {
                String sql = "INSERT INTO Zoo (Name, Address) VALUES (@Name, @Address)";
                using (SqlCommand command = new SqlCommand(sql, sc))
                {
                    command.Parameters.AddWithValue("@Name", z1.ZooName);
                    command.Parameters.AddWithValue("@Address", z1.ZooAddress);

                    command.ExecuteNonQuery();
                    result = true;
                }
            }
            return result;
        }

        /// <summary>
        /// Method which deletes an animal from the database.
        /// </summary>
        /// <param name="id">the ID for the animal to be removed.</param>
        public static Boolean DeleteAnimal(int id)
        {
            Boolean result = false;

            String sql = "DELETE FROM Animal WHERE Id = " + id;
            using (SqlCommand command = new SqlCommand(sql, sc))
            {
                command.ExecuteNonQuery();
                result = true;
            }
            return result;
        }

        /// <summary>
        /// Method which deletes a zoo from the database.
        /// </summary>
        /// <param name="id">The ID of the zoo to be removed.</param>
        public static Boolean DeleteZoo(int id)
        {
            Boolean result = false;

            String sql = "DELETE FROM Zoo WHERE Id = " + id;
            using (SqlCommand command = new SqlCommand(sql, sc))
            {
                command.ExecuteNonQuery();
                result = true;
            }
            return result;
        }

        /// <summary>
        /// Method which adds a new animal report to the database. 
        /// </summary>
        /// <param name="animalId">The ID of the animal being reported.</param>
        /// <param name="desc">The report body.</param>
        public static Boolean AddAnimalReport(int animalId, String desc)
        {
            Boolean result = false;
            AnimalReport ar = new AnimalReport(animalId, desc);

            String sql = "INSERT INTO AnimalReport (AnimalId, Description, Date) VALUES (@AnimalId, @Description, @Date)";
            using (SqlCommand command = new SqlCommand(sql, sc))
            {
                command.Parameters.AddWithValue("@AnimalId", ar.AnimalId);
                command.Parameters.AddWithValue("@Description", ar.Description);
                command.Parameters.AddWithValue("@Date", ar.DateCreated);

                command.ExecuteNonQuery();
                result = true;
            }
            return result;
        }

        /// <summary>
        /// Method which adds a new zoo report to the database. 
        /// </summary>
        /// <param name="zooId">The ID of the zoo being reported.</param>
        /// <param name="desc">The report body.</param>
        public static Boolean AddZooReport(int zooId, String desc)
        {
            Boolean result = false;
            ZooReport zr = new ZooReport(zooId, desc);

            String sql = "INSERT INTO ZooReport (ZooId, Description, Date) VALUES (@ZooId, @Description, @Date)";
            using (SqlCommand command = new SqlCommand(sql, sc))
            {
                command.Parameters.AddWithValue("@ZooId", zr.ZooId);
                command.Parameters.AddWithValue("@Description", zr.Description);
                command.Parameters.AddWithValue("@Date", zr.DateCreated);

                command.ExecuteNonQuery();
                result = true;
            }
            return result;
        }

        /// <summary>
        /// Method which deletes an animal report from the database.
        /// </summary>
        /// <param name="id">The ID of the report being deleted.</param>
        public static Boolean DeleteAnimalReport(int id)
        {
            Boolean result = false;
            String sql = "DELETE FROM AnimalReport WHERE Id = " + id;
            using (SqlCommand command = new SqlCommand(sql, sc))
            {
                command.ExecuteNonQuery();
                result = true;
            }
            return result;
        }

        /// <summary>
        /// Method which deletes an zoo report from the database.
        /// </summary>
        /// <param name="id">The ID of the report being deleted.</param>
        public static Boolean DeleteZooReport(int id)
        {
            Boolean result = false;
            String sql = "DELETE FROM ZooReport WHERE Id = " + id;
            using (SqlCommand command = new SqlCommand(sql, sc))
            {
                command.ExecuteNonQuery();
                result = true;
            }
            return result;
        }

        /// <summary>
        /// returns all animals objects.
        /// </summary>
        /// <returns>An arraylist of animals</returns>
        public static ArrayList getAnimals()
        {
            return Animals;
        }

        /// <summary>
        /// returns all zoo objects.
        /// </summary>
        /// <returns>An arraylist of zoos</returns>
        public static ArrayList getZoos()
        {
            return Zoos;
        }

        /// <summary>
        /// returns all animal report objects.
        /// </summary>
        /// <returns>An arraylist of animalReports</returns>
        public static ArrayList getAnimalReports()
        {
            return AnimalReports;
        }

        /// <summary>
        /// returns all zoo report objects.
        /// </summary>
        /// <returns>An arraylist of zooReports</returns>
        public static ArrayList getZooReports()
        {
            return ZooReports;
        }
    }
}
