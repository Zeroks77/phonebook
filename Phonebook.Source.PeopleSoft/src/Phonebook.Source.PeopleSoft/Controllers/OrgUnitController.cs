﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Phonebook.Source.PeopleSoft.Models;

namespace Phonebook.Source.PeopleSoft.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrgUnitController : ControllerBase
    {
        public ModelContext Context { get; }

        public OrgUnitController(ModelContext context)
        {
            Context = context;
        }
        // GET: api/OrgUnit
        [HttpGet]
        public IEnumerable<OrgUnit> Get()
        {
            return this.inlcudeDependencies(Context.OrgUnits);

        }

        // GET: api/OrgUnit/5
        [HttpGet("{id}")]
        public OrgUnit Get(int id)
        {
            return this.inlcudeDependencies(Context.OrgUnits).First(o => o.Id == id);
        }

        private IQueryable<OrgUnit> inlcudeDependencies(IQueryable<OrgUnit> query)
        {
            return query
                    .AsNoTracking()
                    .Include(o => o.Members)
                    .Include(o => o.Parent);

        }
    }
}
