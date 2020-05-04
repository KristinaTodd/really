using System;
using System.Collections.Generic;
using System.Data;
using Really.Models;
using Really.Repositories;

namespace Really.Services
{
  public class ProfileService
  {
    private readonly ProfileRepository _repo;
    public ProfileService(ProfileRepository repo)
    {
      _repo = repo;
    }
    public IEnumerable<Profile> Get()
    {
      return _repo.Get();
    }

    public Profile Create(Profile newProfile)
    {
      return _repo.Create(newProfile);
    }
  }
}