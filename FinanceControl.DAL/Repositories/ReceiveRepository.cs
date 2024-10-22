

using System.Collections.Immutable;
using AutoMapper;
using FinanceControl.Common.Models;
using FinanceControl.DAL.Entities;
using FinanceControl.DAL.Interfaces;
using FinanceControl.Domain.Interfaces.Repositories;
using FinanceControl.Domain.Models.Business;
using Microsoft.EntityFrameworkCore;

namespace FinanceControl.DAL.Repositories
{
    public class ReceiveRepository : IReceiveRepository
    {
        private readonly IMapper _mapper;
        private readonly IDataContext _context;

        public ReceiveRepository(IMapper mapper, IDataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task Create(Receive receive)
        {
            var receiveEntity = _mapper.Map<ReceiveEntity>(receive);
            
            _context.Receives.Add(receiveEntity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Receive receive)
        {
            var existingReceiveEntity = await _context.Receives.FindAsync(receive.Id);
            if (existingReceiveEntity != null)
            {
                _mapper.Map(receive, existingReceiveEntity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task Delete(Guid Id)
        {
            var receiveEntity = await _context.Receives.FindAsync(Id);
            if (receiveEntity != null)
            {
                _context.Receives.Remove(receiveEntity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Receive> Read(Guid Id)
        {
            var receiveEntity = await _context.Receives.FindAsync(Id);
            return _mapper.Map<Receive>(receiveEntity);
        }

        public async Task<ImmutableList<Receive>> List(DateRangeFilter rangeFilter)
        {
            var query = _context.Receives.AsQueryable();

            query = query.Where(r => r.Date >= rangeFilter.Since && r.Date <= rangeFilter.Until);

            var receiveEntities = await query.ToListAsync();

            var receives = _mapper.Map<List<Receive>>(receiveEntities);
            var receivesImmutableList = receives.ToImmutableList();
            
            return receivesImmutableList;
        }
    }
}