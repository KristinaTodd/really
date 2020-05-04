using System;
using System.Collections.Generic;
using System.Data;
using Really.Models;
using Dapper;

namespace Really.Repositories
{
  public class ProfileRepository
  {
    private readonly IDbConnection _db;

    public ProfileRepository(IDbConnection db)
    {
      _db = db;
    }

    internal IEnumerable<Profile> Get()
    {
      string sql = "SELECT * FROM Profile";
      return _db.Query<Profile>(sql);
    }

    internal Profile Create(Profile ProfileData)
    {
      throw new NotImplementedException();
    }
  }
}