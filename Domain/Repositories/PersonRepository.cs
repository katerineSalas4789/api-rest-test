using api_rest_test.Domain.Models;
using api_rest_test.Domain.Models.Enums;
using api_rest_test.Domain.Repositories.Interfaces;
using api_rest_test.Domain.Persistence;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace api_rest_test.Domain.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private DAC dac;
        private SqlCommand sqlCommand;
        private SqlDataReader dataReader;

        public PersonRepository()
        {
            dac = new DAC();
        }

        public async Task<Person> SelectOne(int id)
        {
            var response = new Person();
            await Task.Run(() =>
            {
                try
                {
                    sqlCommand = new SqlCommand(string.Format("SELECT id, id_number, name, firstLastName, secondLastName, birthDate, weight, height, gender FROM person WHERE id = {0}", id), dac.connection);
                    dataReader = sqlCommand.ExecuteReader();

                    if (dataReader.HasRows && dataReader.Read())
                    {
                        response = PersonMapper(dataReader);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Message: {0} - StackTrace {1}", ex.Message, ex.StackTrace);
                }
                finally
                {
                    dataReader.Close();
                    sqlCommand.Dispose();
                }
            });
            return response;
        }

        public async Task<IEnumerable<Person>> SelectAll()
        {
            var response = new List<Person>();
            await Task.Run(() =>
            {
                try
                {
                    sqlCommand = new SqlCommand("SELECT id, id_number, name, firstLastName, secondLastName, birthDate, weight, height, gender FROM person", dac.connection);
                    dataReader = sqlCommand.ExecuteReader();

                    while (dataReader.Read())
                    {
                        var newPerson = PersonMapper(dataReader);
                        response.Add(newPerson);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Message: {0} - StackTrace {1}",ex.Message,ex.StackTrace);
                }
                finally
                {
                    dataReader.Close();
                    sqlCommand.Dispose();
                }

            });
            return response;
        }

        private Person PersonMapper(SqlDataReader dataReader)
        {
            var response = new Person();
            response.id = (int)dataReader.GetValue(0);
            response.id_number = dataReader.GetValue(1).ToString().Trim();
            response.name = dataReader.GetValue(2).ToString().Trim();
            response.firstLastName = dataReader.GetValue(3).ToString().Trim();
            response.secondLastName = dataReader.GetValue(4).ToString().Trim();
            response.birthDate = (DateTime)dataReader.GetValue(5);
            response.weight = Convert.ToSingle(dataReader.GetValue(6));
            response.height = Convert.ToSingle(dataReader.GetValue(7));
            response.gender = dataReader.GetValue(8).ToString() == "male" ? Gender.Male : Gender.Female;
            return response;
        }
    }
}
