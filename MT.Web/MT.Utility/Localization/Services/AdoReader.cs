using System.Collections.Generic;
using System.Data.SqlClient;

namespace MT.Utility.Localization.Services
{
    // TODO: This is temporary decision to read data from db.
    public static class AdoReader
    {
        public static IEnumerable<LocalizationReource> ReadResources()
        {
            var result = new List<LocalizationReource>();
            using (SqlConnection connection = new SqlConnection("Server=.;Database=MentorTraineeDb;Integrated Security=true;"))
            using (SqlCommand command = new SqlCommand("select * from LocalizationResources", connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(new LocalizationReource()
                        {
                            ResourceKey = reader["ResourceKey"].ToString(),
                            LocalizedResource = reader["LocalizedResource"].ToString(),
                            ResourceCultureCode = reader["ResourceCultureCode"].ToString()
                        });
                    }
                }
            }

            return result;
        }
    }
}