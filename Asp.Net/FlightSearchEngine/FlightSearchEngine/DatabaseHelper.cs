using Microsoft.Data.SqlClient;
using System.Data;
using FlightSearchEngine.Models;

namespace FlightSearchEngine.Helpers
{
	public class DatabaseHelper
	{
		private readonly string _connectionString;

		public DatabaseHelper(IConfiguration configuration)
		{
			_connectionString = configuration.GetConnectionString("DefaultConnection");
		}

		// Get distinct source cities
		public async Task<List<string>> GetSourcesAsync()
		{
			List<string> sources = new List<string>();

			using (SqlConnection con = new SqlConnection(_connectionString))
			using (SqlCommand cmd = new SqlCommand("sp_GetSources", con))
			{
				cmd.CommandType = CommandType.StoredProcedure;
				await con.OpenAsync();

				using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
				{
					while (await reader.ReadAsync())
					{
						sources.Add(reader[0].ToString());
					}
				}
			}

			return sources;
		}

		// Get distinct destination cities
		public async Task<List<string>> GetDestinationsAsync()
		{
			List<string> destinations = new List<string>();

			using (SqlConnection con = new SqlConnection(_connectionString))
			using (SqlCommand cmd = new SqlCommand("sp_GetDestinations", con))
			{
				cmd.CommandType = CommandType.StoredProcedure;
				await con.OpenAsync();

				using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
				{
					while (await reader.ReadAsync())
					{
						destinations.Add(reader[0].ToString());
					}
				}
			}

			return destinations;
		}

		// Search flights only
		public async Task<List<FlightResult>> SearchFlightsAsync(string source, string destination, int persons)
		{
			List<FlightResult> results = new List<FlightResult>();

			using (SqlConnection con = new SqlConnection(_connectionString))
			using (SqlCommand cmd = new SqlCommand("sp_SearchFlights", con))
			{
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@Source", source);
				cmd.Parameters.AddWithValue("@Destination", destination);
				cmd.Parameters.AddWithValue("@Persons", persons);

				await con.OpenAsync();

				using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
				{
					while (await reader.ReadAsync())
					{
						results.Add(new FlightResult
						{
							FlightId = Convert.ToInt32(reader["FlightId"]),
							FlightName = reader["FlightName"].ToString(),
							FlightType = reader["FlightType"].ToString(),
							FlightSource = reader["FlightSource"].ToString(),
							FlightDestination = reader["FlightDestination"].ToString(),
							TotalCost = Convert.ToDecimal(reader["TotalCost"])
						});
					}
				}
			}

			return results;
		}

		// Search flights + hotels
		public async Task<List<FlightHotelResult>> SearchFlightsWithHotelsAsync(string source, string destination, int persons)
		{
			List<FlightHotelResult> results = new List<FlightHotelResult>();

			using (SqlConnection con = new SqlConnection(_connectionString))
			using (SqlCommand cmd = new SqlCommand("sp_SearchFlightsWithHotels", con))
			{
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@Source", source);
				cmd.Parameters.AddWithValue("@Destination", destination);
				cmd.Parameters.AddWithValue("@Persons", persons);

				await con.OpenAsync();

				using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
				{
					while (await reader.ReadAsync())
					{
						results.Add(new FlightHotelResult
						{
							FlightId = Convert.ToInt32(reader["FlightId"]),
							FlightName = reader["FlightName"].ToString(),
							FlightSource = reader["FlightSource"].ToString(),
							FlightDestination = reader["FlightDestination"].ToString(),
							HotelName = reader["HotelName"].ToString(),
							TotalCost = Convert.ToDecimal(reader["TotalCost"])
						});
					}
				}
			}

			return results;
		}
	}
}