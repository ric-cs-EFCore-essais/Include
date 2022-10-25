﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using Microsoft.EntityFrameworkCore;

using Domain.Repositories.Interfaces.Ports;

using Domain.Entities.Ports;
using Infra.DataContext.EF.Ports;


namespace Infra.Repositories.Ports
{
    public class VilleRepository : APortsRepository<Ville>, IVilleRepository
    {
        public VilleRepository(PortsDbDataContext dataContext): base(dataContext)
        {
        }

        protected override DbSet<Ville> GetEntities()
        {
            return dataContext.Villes;
        }

        public override Ville Get(int id)
        {
            var retour = IncludingPorts(GetEntities()).SingleOrDefault(entity => entity.Id == id);
            return retour;
        }

        public override IEnumerable<Ville> GetAll()
        {
            var retour = IncludingPorts(GetEntities()).ToList();
            return retour;
        }

        private IQueryable<Ville> IncludingPorts(IQueryable<Ville> villesQuery)
        {
            var retour = villesQuery.Include(ville => ville.Ports);
            return retour;
        }

        public Ville GetByPort(int portId)
        {
            var retour = IncludingPorts(GetEntities()).SingleOrDefault(ville => ville.Ports.Select(port => port.Id).Contains(portId));
            return retour;
        }

        public IEnumerable<Ville> GetWithNameContaining(string subString)
        {
            subString = subString.ToLower();

            Expression<Func<Ville, bool>> villesFilter = (Ville ville) => ville.Nom.ToLower().Contains(subString); //Conversion auto. du filtre (lambda), en LINQ Expression !

            var retours = IncludingPorts(FindAsQueryable(villesFilter));
            
            return retours.ToList();
        }

    }
}
