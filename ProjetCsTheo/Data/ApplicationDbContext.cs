using Microsoft.EntityFrameworkCore;
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
        String connectStr = "server=localhost;uid=root;pwd=;database=csproject";
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
            String sql = "SELECT * from restaurant";
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
            String sql = "SELECT * FROM restaurant ORDER BY note DESC LIMIT 5";
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
            String sql = "DELETE FROM restaurant WHERE id=" + id;
            MySqlCommand cmd = new MySqlCommand(sql, ApplicationDBContext.con);
            cmd.ExecuteNonQuery();
        }

        public static void addResto(Restaurant resto)
        {
            String sql = "INSERT INTO `restaurant`(`name`, `phone`, `commentary`, `email`, `street`, `zip`, `city`, `lastTimeVisited`, `note`, `noteCommentary`) VALUES (";
            sql += "'" + resto.Name + "',";
            sql += "'" + resto.Phone + "',";
            sql += "'" + resto.Commentary + "',";
            sql += "'" + resto.Email + "',";
            sql += "'" + resto.Street + "',";
            sql += "'" + resto.Zip + "',";
            sql += "'" + resto.City + "',";
            sql += "'" + resto.LastTimeVisited.Replace("-", "/") + "',";
            sql += "'" + resto.Note + "',";
            sql += "'" + resto.NoteCommentary + "')";
            MySqlCommand cmd = new MySqlCommand(sql, ApplicationDBContext.con);
            cmd.ExecuteNonQuery();
        }

        public static void editResto(Restaurant resto)
        {
            String sql = "UPDATE `restaurant` SET `name`='" + resto.Name + "',`phone`='" + resto.Phone + "',`commentary`='" + resto.Commentary + "',`email`='" + resto.Email + "',`street`='" + resto.Street + "'," +
                "`zip`=" + resto.Zip + ",`city`='" + resto.City + "',`lastTimeVisited`='" + resto.LastTimeVisited + "',`note`='" + resto.Note + "',`noteCommentary`='" + resto.NoteCommentary + "' WHERE id=" + resto.Id;
            MySqlCommand cmd = new MySqlCommand(sql, ApplicationDBContext.con);
            cmd.ExecuteNonQuery();
        }

        public static Restaurant getRestoWithId(int id)
        {
            String sql = "SELECT * from restaurant WHERE id=" + id;
            MySqlCommand cmd = new MySqlCommand(sql, ApplicationDBContext.con);
            MySqlDataReader rdr = cmd.ExecuteReader();
            Restaurant resto = new Restaurant();
            while (rdr.Read())
            {
                resto.Id = (int)rdr[0];
                resto.Name = (string)rdr[1];
                resto.Phone = (string)rdr[2];
                resto.Commentary = (string)rdr[3];
                resto.Email = (string)rdr[4];
                resto.Street = (string)rdr[5];
                resto.Zip = (int)rdr[6];
                resto.City = (string)rdr[7];
                resto.LastTimeVisited = (string)rdr[8];
                resto.Note = (int)rdr[9];
                resto.NoteCommentary = (string)rdr[10];
            }
            return resto;
        }

        public static void editRestoNote(Restaurant resto)
        {
            String sql = "UPDATE `restaurant` SET `note`='" + resto.Note + "',`noteCommentary`='" + resto.NoteCommentary + "' WHERE id=" + resto.Id;
            MySqlCommand cmd = new MySqlCommand(sql, ApplicationDBContext.con);
            cmd.ExecuteNonQuery();
        }
    }
}