﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using SQLite;
using ProjectMVVM_FlowerOnline.Model;

namespace ProjectMVVM_FlowerOnline.Helper
{
    public class Database
    {
        string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        readonly SQLiteAsyncConnection _database;

        public Database()
        {
            try
            {
                _database = new SQLiteAsyncConnection(folder);
                _database.CreateTableAsync<Hoa>().Wait();
                _database.CreateTableAsync<LoaiHoa>().Wait();
            }
            catch (Exception)
            {
                //Console.WriteLine("Exception caught!");
            }
        }

        public Task<List<LoaiHoa>> GetLoaiHoa()
        {
            try
            {
                return _database.Table<LoaiHoa>().ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<List<LoaiHoa>> GetLoaiHoa(int maLoai)
        {
            try
            {
                return _database.Table<LoaiHoa>().Where(i => i.MaLoai == maLoai).ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<int> SaveLoaiHoa(LoaiHoa temp)
        {
            try
            {
                if (temp.MaLoai != 0)
                    return _database.UpdateAsync(temp);
                else
                    return _database.InsertAsync(temp);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<int> DeleteLoaiHoa(LoaiHoa temp)
        {
            try
            {
                return _database.Table<LoaiHoa>().DeleteAsync(i => i.MaLoai == temp.MaLoai);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<List<Hoa>> GetHoa()
        {
            try
            {
                return _database.Table<Hoa>().ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<List<Hoa>> GetHoa(int maLoai)
        {
            try
            {
                return _database.Table<Hoa>().Where(i => i.MaLoai == maLoai).ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<List<Hoa>> GetHoa(int maLoai, int maHoa)
        {
            try
            {
                return _database.Table<Hoa>()
                    .Where(i => ((i.MaLoai == maLoai) && (i.MaHoa == maHoa))).ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<int> SaveHoa(Hoa temp)
        {
            try
            {
                if (temp.MaHoa != 0)
                    return _database.UpdateAsync(temp);
                else
                    return _database.InsertAsync(temp);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<int> DeleteHoa(Hoa Hoa)
        {
            try
            {
                return _database.Table<Hoa>().DeleteAsync(i => i.TenHoa == Hoa.TenHoa);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
