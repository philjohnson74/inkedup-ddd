using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using InkedUp.Api.Contracts;
using InkedUp.Domain;

namespace InkedUp.Api.Repositories
{
    public class PenInMemoryRepository : IPenRepository
    {
        private Dictionary<PenId, Pen> _pens = new Dictionary<PenId, Pen>();
        
        public async Task<bool> Exists(PenId id)
        {
            return _pens.ContainsKey(id);
        }

        public async Task<Pen> Load(PenId id)
        {
            return _pens[id];
        }

        public async Task Save(Pen entity)
        {
            if (await Exists(entity.Id))
                _pens[entity.Id] = entity;
            else
                _pens.Add(entity.Id, entity);
        }
    }
}