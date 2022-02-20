using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class PhotoRepository : IPhotoRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public PhotoRepository(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Photo> GetPhotoById(int id)
        {
            var query = _context.Photos
                .Where(p => p.Id == id)
                .IgnoreQueryFilters()
                .AsQueryable();

            return await query.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<PhotoForApprovalDto>> GetUnapprovedPhotos()
        {
            var query = _context.Photos
                .Where(p => p.IsApproved == false)
                .IgnoreQueryFilters()
                .ProjectTo<PhotoForApprovalDto>(_mapper.ConfigurationProvider)
                .AsQueryable();

            return await query.ToListAsync();
        }

        public async Task RemovePhoto(int id)
        {
            var photo = await _context.Photos.Where(p => p.Id == id).IgnoreQueryFilters().SingleAsync();
            _context.Photos.Remove(photo);
        }

        public async Task<bool> ApprovePhoto(int id)
        {
            var photo = await _context.Photos.Where(p => p.Id == id).IgnoreQueryFilters().SingleAsync();

            if (photo != null) 
            {
                photo.IsApproved = true;
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Photo>> GetAllPhotosFromUser(int id)
        {
            return await _context.Photos.Where(p => p.AppUserId == id).IgnoreQueryFilters().ToListAsync();
        }
    }
}