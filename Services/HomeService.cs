using System;
using System.Collections.Generic;
using System.Data;
using Really.Models;
using Really.Repositories;

namespace Really.Services
{
  public class HomeService
  {
    private readonly HomeRepository _repo;
    public HomeService(HomeRepository repo)
    {
      _repo = repo;
    }
    public IEnumerable<Home> Get()
    {
      return _repo.Get();
    }

    public Home Create(Home newHome)
    {
      return _repo.Create(newHome);
    }
  }
}