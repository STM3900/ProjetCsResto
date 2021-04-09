﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using MySqlConnector;
using ProjetCsTheo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ds.Database
{

    public class ApplicationDBContext : DbContext
    {
        public static MySqlConnection con;
        string connectStr = "server=localhost;uid=root;pwd=;database=csproject";
        public virtual DbSet<Restaurant> resto { get; set; }

        public ApplicationDBContext()
        {
            try
            {
                MySqlConnection conn = new MySqlConnection();
                conn.ConnectionString = connectStr;
                conn.Open();
                Console.WriteLine(conn.GetSchema());
                con = conn;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static List<Restaurant> getAllResto()
        {
            string sql = "SELECT * from restaurant";
            MySqlCommand cmd = new MySqlCommand(sql, ApplicationDBContext.con);
            MySqlDataReader rdr = cmd.ExecuteReader();
            List<Restaurant> restos = new List<Restaurant>();
            while (rdr.Read())
            {
                Restaurant temp = new Restaurant();
                temp.Id = (int)rdr[0];
                temp.Name = (string)rdr[1];
                temp.Phone = (string)rdr[2];
                temp.Commentary = (string)rdr[3];
                temp.Email = (string)rdr[4];
                temp.Street = (string)rdr[5];
                temp.Zip = (int)rdr[6];
                temp.City = (string)rdr[7];
                temp.LastTimeVisited = (string)rdr[8];
                temp.Note = (int)rdr[9];
                temp.NoteCommentary = (string)rdr[10];
                restos.Add(temp);
            }
            return restos;
        }
        public static List<Restaurant> getFiveBest()
        {
            string sql = "SELECT * FROM restaurant ORDER BY note DESC LIMIT 5";
            MySqlCommand cmd = new MySqlCommand(sql, ApplicationDBContext.con);
            MySqlDataReader rdr = cmd.ExecuteReader();
            List<Restaurant> restos = new List<Restaurant>();
            while (rdr.Read())
            {
                Restaurant temp = new Restaurant();
                temp.Id = (int)rdr[0];
                temp.Name = (string)rdr[1];
                temp.Phone = (string)rdr[2];
                temp.Commentary = (string)rdr[3];
                temp.Email = (string)rdr[4];
                temp.Street = (string)rdr[5];
                temp.Zip = (int)rdr[6];
                temp.City = (string)rdr[7];
                temp.LastTimeVisited = (string)rdr[8];
                temp.Note = (int)rdr[9];
                temp.NoteCommentary = (string)rdr[10];
                restos.Add(temp);
            }
            return restos;
        }

        public static void deleteResto(int id)
        {
            string sql = "DELETE FROM restaurant WHERE id=" + id;
            MySqlCommand cmd = new MySqlCommand(sql, ApplicationDBContext.con);
            cmd.ExecuteNonQuery();
        }
    }
}