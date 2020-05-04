using System;
using System.Collections.Generic;
using System.Data;
using Really.Models;
using Dapper;

namespace Really.Repositories
{
  public class HomeRepository
  {
    private readonly IDbConnection _db;

    public HomeRepository(IDbConnection db)
    {
      _db = db;
    }

    internal IEnumerable<Home> Get()
    {
      string sql = "SELECT * FROM Home";
      return _db.Query<Home>(sql);
    }


    internal Home Create(Home newHome)
    {
      string sql = @"
            INSERT INTO homes
            (title, description, userId, address, city, state, primaryImg, secondaryImg, baths, rooms, price, views, mls, favorite)
            VALUES
            (@Title, @Description, @UserId, @Address, @City, @State, @PrimaryImg, @SecondaryImg, @Baths, @Rooms, @Price @Views, @MLS, @Favorite);
            SELECT LAST_INSERT_ID()";
      newHome.Id = _db.ExecuteScalar<int>(sql, newHome);
      return newHome;
    }

    internal Home Get(int id)
    {
      string sql = "SELECT * FROM homes WHERE id = @Id LIMIT 1";
      return _db.QueryFirstOrDefault<Home>(sql, new { Id = id });
    }

    internal IEnumerable<Home> GetUserHomes(string UserId)
    {
      string sql = "SELECT * FROM homes WHERE userId = @UserId";
      return _db.Query<Home>(sql, new { UserId });
    }

    internal Home Edit(Home updatedHome)
    {
      string sql = @"
        UPDATE homes
        SET
            title = @Title,
            description = @Description,
            primaryImg = @PrimaryImg,
            secondaryImg = @SecondaryImg,
            price = @Price,
            views = @Views,
            favorite = @favorite
        WHERE id = @id
        ";
      _db.Execute(sql, updatedHome);
      return updatedHome;
    }

    internal bool Delete(int Id)
    {
      string sql = "DELETE FROM homes WHERE id = @Id LIMIT 1";
      int removed = _db.Execute(sql, new { Id });
      return removed == 1;
    }


  }
}