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
      string sql = "SELECT * FROM Home WHERE isPrivate = 0;";
      return _db.Query<Home>(sql);
    }

    internal Home Create(Home HomeData)
    {
      throw new NotImplementedException();
    }
  }
}